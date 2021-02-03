using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using GridViewExtensions.GridFilters;

namespace GridViewExtensions.GridFilterFactories
{
	/// <summary>
	/// Default implementation for <see cref="IGridFilterFactory"/> which
	/// should be applicable for most standard needs.
	/// The creation process consists of these steps:
	/// 1. If the column data type is an enumeration and <see cref="HandleEnumerationTypes"/>
	/// is set to true than an <see cref="EnumerationGridFilter"/> is created.
	/// 2. If <see cref="CreateDistinctGridFilters"/> is set to true than it is analyzed
	/// if the column contains less or equal distinct values than specified by
	/// <see cref="MaximumDistinctValues"/>. If yes than an <see cref="DistinctValuesGridFilter"/>
	/// is created. The <see cref="MaximumDistinctValues"/> property is not only 
	/// important to reduce the maximum number of entries the <see cref="ComboBox"/>
	/// gets filled with but also to improve performance because the analysis of the 
	/// columns data will be stopped immediately when more values are found then 
	/// specified by it and thus the analysis doesn't have to search through the whole 
	/// data source.
	/// 3. If a grid filter type is specified for the data type of the column than this
	/// one will be created. The data type to grid filter type matching can be altered
	/// by calls to <see cref="AddGridFilter"/> and <see cref="RemoveGridFilter"/>. Note 
	/// that only grid filter types which implement <see cref="IGridFilter"/> and which 
	/// have an empty public constructor are allowed.
	/// 4. If still no filter was created than the filter specified by
	/// <see cref="DefaultGridFilterType"/> will be created. By default this is the
	/// <see cref="TextGridFilter"/>. Note that again only grid filter types which implement
	/// <see cref="IGridFilter"/> and which have an empty public constructor are allowed.
	/// </summary>
	public class DefaultGridFilterFactory : GridFilterFactoryBase
	{
		#region Fields

		private Hashtable _hash;
		private Type _defaultGridFilterType;
		private bool _handleEnumerationTypes = true;
		private bool _createDistinctGridFilters = false;
        private int _maximumDistinctValues = 20;
        private bool _defaultShowDateInBetweenOperator = false;
        private bool _defaultShowNumericInBetweenOperator = false;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		public DefaultGridFilterFactory()
		{
			_hash = new Hashtable();

			DefaultGridFilterType = typeof(TextGridFilter);
			AddGridFilter(typeof(bool), typeof(BoolGridFilter));

			AddGridFilter(typeof(byte), typeof(NumericGridFilter));
			AddGridFilter(typeof(short), typeof(NumericGridFilter));
			AddGridFilter(typeof(int), typeof(NumericGridFilter));
			AddGridFilter(typeof(long), typeof(NumericGridFilter));

			AddGridFilter(typeof(float), typeof(NumericGridFilter));
			AddGridFilter(typeof(double), typeof(NumericGridFilter));
			AddGridFilter(typeof(decimal), typeof(NumericGridFilter));
			
			AddGridFilter(typeof(UInt16), typeof(NumericGridFilter));
			AddGridFilter(typeof(UInt64), typeof(NumericGridFilter));
			
			AddGridFilter(typeof(DateTime), typeof(DateGridFilter));
		}

		#endregion

        #region Public interface

        /// <summary>
        /// Sets or gets whether created <see cref="DateGridFilter"/>s should by default
        /// show the 'in between' operator.
        /// </summary>
        public bool DefaultShowDateInBetweenOperator
        {
            get { return _defaultShowDateInBetweenOperator; }
            set
            {
                if (value == _defaultShowDateInBetweenOperator)
                    return;
                _defaultShowDateInBetweenOperator = value;
                OnChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Sets or gets whether created <see cref="NumericGridFilter"/>s should by default
        /// show the 'in between' operator.
        /// </summary>
        public bool DefaultShowNumericInBetweenOperator
        {
            get { return _defaultShowNumericInBetweenOperator; }
            set
            {
                if (value == _defaultShowNumericInBetweenOperator)
                    return;
                _defaultShowNumericInBetweenOperator = value;
                OnChanged(EventArgs.Empty);
            }
        }

		/// <summary>
		/// Gets/sets whether enumeration types are automatically handled
		/// with a special <see cref="IGridFilter"/> implementation.
		/// Only applies for datatypes not explicitely set.
		/// </summary>
		public bool HandleEnumerationTypes 
		{
			get { return _handleEnumerationTypes; }
			set 
			{
				_handleEnumerationTypes = value; 
				OnChanged(EventArgs.Empty);
			}
		}

		/// <summary>
		/// Gets and sets the <see cref="Type"/> of the IGridFilter which
		/// should handle all unspecified datatypes.
		/// </summary>
		public Type DefaultGridFilterType 
		{
			get { return _defaultGridFilterType; }
			set 
			{
				CheckIfValidGridFilterType(value);
				_defaultGridFilterType = value; 
				OnChanged(EventArgs.Empty);
			}
		}

		/// <summary>
		/// Gets or sets whether grid filters of type <see cref="DistinctValuesGridFilter"/>
		/// should be created automatically. Note that this might reduce performance
		/// as every column is analyzed to get the different values it contains.
		/// </summary>
		public bool CreateDistinctGridFilters
		{
			get { return _createDistinctGridFilters; }
			set { ConfigureDistinctGridFilterHandling(value, _maximumDistinctValues); }
		}

		/// <summary>
		/// Gets or sets the maximum number of distinct values column should have
		/// when a <see cref="DistinctValuesGridFilter"/> is created.
		/// If this limit is exceeded than a standard filter will be created.
		/// Value is only considered when <see cref="CreateDistinctGridFilters"/> is
		/// set to true.
		/// The value set must be set to 1 or greater. If all values contained within
		/// a column without any limitation should be generated than set this property
		/// to <see cref="Int32.MaxValue"/>.
		/// </summary>
		public int MaximumDistinctValues
		{
			get { return _maximumDistinctValues; }
			set { ConfigureDistinctGridFilterHandling(_createDistinctGridFilters, value); }
		}

		/// <summary>
		/// Sets <see cref="CreateDistinctGridFilters"/> and <see cref="MaximumDistinctValues"/>
		/// simultaneously to improve performance.
		/// </summary>
		/// <param name="createDistinctGridFilters">
		/// Indicator whether grid filters of type <see cref="DistinctValuesGridFilter"/>
		/// should be created automatically
		/// </param>
		/// <param name="maximumDistinctValues">
		/// Maximum number of distinct values column should have
		/// when a <see cref="DistinctValuesGridFilter"/> is created.
		/// </param>
		public void ConfigureDistinctGridFilterHandling(bool createDistinctGridFilters, int maximumDistinctValues)
		{
			if (maximumDistinctValues <= 0)
				throw new ArgumentException("Value must be 1 or greater.", "maximumDistinctValues");
			_maximumDistinctValues = maximumDistinctValues;

			_createDistinctGridFilters = createDistinctGridFilters;

			OnChanged(EventArgs.Empty);
		}

		/// <summary>
		/// Adds a type for <see cref="IGridFilter"/> for the
		/// specified datatype.
		/// </summary>
		/// <param name="dataType">
		/// <see cref="Type"/> for which a special <see cref="IGridFilter"/> should be generated.
		/// </param>
		/// <param name="gridFilterType">
		/// <see cref="Type"/> of the <see cref="IGridFilter"/> to be generated.
		/// </param>
		public void AddGridFilter(Type dataType, Type gridFilterType)
		{
			CheckIfValidGridFilterType(gridFilterType);
			_hash.Add(dataType, gridFilterType);
			OnChanged(EventArgs.Empty);
		}

		/// <summary>
		/// Removes a specialized type for <see cref="IGridFilter"/> for a given datatype.
		/// </summary>
		/// <param name="dataType">
		/// <see cref="Type"/> for which a special <see cref="IGridFilter"/> should be removed.
		/// </param>
		public void RemoveGridFilter(Type dataType)
		{
			_hash.Remove(dataType);
			OnChanged(EventArgs.Empty);
		}

		#endregion

		#region Privates

		private void CheckIfValidGridFilterType(Type gridFilterType)
		{
			if (!gridFilterType.IsClass && !gridFilterType.IsValueType)
				throw new ArgumentException("Specified grid filter type must be either a class or a struct.", "gridFilterType");

			if (!typeof(IGridFilter).IsAssignableFrom(gridFilterType))
				throw new ArgumentException("Specified grid filter type does not implement IGridFilter.", "gridFilterType");

			if (gridFilterType.GetConstructor(new Type[0]) == null)
				throw new ArgumentException("Specified grid filter type does not have an empty public constructor are allowed.", "gridFilterType");
		}

		#endregion

		#region Overridden from GridFilterFactoryBase

		/// <summary>
		/// Creates a new instance of <see cref="IGridFilter"/>.
		/// The concrete implementation depends on the given datatype.
		/// The parameters tablename and columnanem are ignored in this implementation.
		/// </summary>
		/// <param name="column">The <see cref="DataColumn"/> for which the filter control should be created.</param>
		/// <returns>A <see cref="IGridFilter"/>.</returns>
        protected override IGridFilter CreateGridFilterInternal(DataGridViewColumn column)
		{
			IGridFilter result = null;

			Type dataType = column.ValueType;
            if (column.ValueType == null)
                return new EmptyGridFilter();

			if (dataType.IsEnum && _handleEnumerationTypes)
			{
				result = new EnumerationGridFilter(dataType);
			} 
			else if (_createDistinctGridFilters)
			{
				bool containsDbNull;
				string[] values = DistinctValuesGridFilter.GetDistinctValues(column, _maximumDistinctValues, out containsDbNull);
				if (values != null)
					result = new DistinctValuesGridFilter(values, containsDbNull);
			}

			if (result == null)
			{
				if (_hash.ContainsKey(dataType))
				{
					Type gridFilterType = _hash[dataType] as Type;
					result = gridFilterType.Assembly.CreateInstance(gridFilterType.FullName) as IGridFilter;
				}
				else if (_defaultGridFilterType != null)
				{
					result = _defaultGridFilterType.Assembly.CreateInstance(_defaultGridFilterType.FullName) as IGridFilter;
				}
			}

            if (result is DateGridFilter)
                (result as DateGridFilter).ShowInBetweenOperator = _defaultShowDateInBetweenOperator;
            if (result is NumericGridFilter)
                (result as NumericGridFilter).ShowInBetweenOperator = _defaultShowNumericInBetweenOperator;

			return result;
		}

		#endregion
	}
}
