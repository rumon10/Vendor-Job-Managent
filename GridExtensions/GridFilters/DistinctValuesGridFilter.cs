using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using GridViewExtensions.GridFilters.EnumerationSources;

namespace GridViewExtensions.GridFilters
{
	/// <summary>
	/// A <see cref="IGridFilter"/> implementation for columns with a <see cref="ComboBox"/>
	/// containing all values found within the column.
	/// </summary>
	public class DistinctValuesGridFilter : GridFilterBase
	{
		#region Enumeration SpecialValueType

		private enum SpecialValueType
		{
			None,
			Null
		}

        #endregion

        #region Class SpecialValue

        /// <summary>
        /// Defines special values which can be contained in the <see cref="ComboBox"/>
        /// of a <see cref="DistinctValuesGridFilter"/>.
        /// </summary>
        public class SpecialValue
        {
            #region Public static fields

            /// <summary>
            /// The special value meaning 'No filtering'.
            /// </summary>
            public static readonly SpecialValue NoFilter = new SpecialValue(SpecialValueType.None);

            /// <summary>
            /// The special value meaning 'Filter null values'.
            /// </summary>
            public static readonly SpecialValue NullFilter = new SpecialValue(SpecialValueType.Null);

            #endregion

            #region Fields

            private SpecialValueType _type;

            #endregion

            #region Constructors

            private SpecialValue(SpecialValueType type)
            {
                _type = type;
            }

            #endregion

            #region Overridden from Object

            /// <summary>
            /// Gets a textual representation.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                switch (_type)
                {
                    case SpecialValueType.None:
                        return "(*)";
                    case SpecialValueType.Null:
                        return "(null)";
                }
                return base.ToString();
            }

            #endregion
        }

        #endregion

		#region Fields

		private const string FILTER_FORMAT = "Convert({0}, System.String) = '{1}'";
		private const string FILTER_REGEX = @"Convert\(\[[a-zA-Z].*\],\sSystem.String\)\s=\s'(?<Value>.*)'";

		private ComboBox _combo;
		private string[] _values;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="column">Column where the values list should be generated from.</param>
        public DistinctValuesGridFilter(DataGridViewColumn column)
            : this(new ComboBox(), false) 
		{
			Fill(column);
		}
		
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="column">Column where the values list should be generated from.</param>
		/// <param name="comboBox">Control which should be used to display the values.</param>
        public DistinctValuesGridFilter(DataGridViewColumn column, ComboBox comboBox)
            : this(comboBox, true) 
		{
			Fill(column);
		}
		
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="values">The list of values to be displayed.</param>
		/// <param name="containsDbNull">Indicates whether the (null) entry should be displayed or not.</param>
		public DistinctValuesGridFilter(string[] values, bool containsDbNull) : this(new ComboBox(), false) 
		{
			Fill(values, containsDbNull);
		}

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="values">The list of values to be displayed.</param>
		/// <param name="containsDbNull">Indicates whether the (null) entry should be displayed or not.</param>
		/// <param name="comboBox">Control which should be used to display the values.</param>
		public DistinctValuesGridFilter(string[] values, bool containsDbNull, ComboBox comboBox) : this(comboBox, true) 
		{
			Fill(values, containsDbNull);
		}

		private DistinctValuesGridFilter(ComboBox comboBox, bool useCustomFilterPlacement) : base(useCustomFilterPlacement)
		{
			_combo = comboBox;
			_combo.DropDownStyle = ComboBoxStyle.DropDownList;
			_combo.SelectedIndexChanged += new EventHandler(OnComboSelectedIndexChanged);

			_combo.Items.Clear();
			_combo.Items.Add(SpecialValue.NoFilter);
			_combo.SelectedIndex = 0;
		}

        #endregion

        #region Public interface

        /// <summary>
        /// Gets all values contained in the <see cref="ComboBox"/>.
        /// </summary>
        public object[] Values
        {
            get
            {
                object[] result = new object[_combo.Items.Count];
                _combo.Items.CopyTo(result, 0);
                return result;
            }
        }

        /// <summary>
        /// Gets or sets the current value of the contained <see cref="ComboBox"/>.
        /// </summary>
        public object CurrentValue
        {
            get { return _combo.SelectedItem; }
            set
            {
                if (value as string == null || value as SpecialValue == null)
                    throw new ArgumentException("Value must be either a string or of type SpecialValue", "value");
                _combo.SelectedItem = value;
            }
        }

        #endregion

		#region Overridden from GridFilterBase

		/// <summary>
		/// The <see cref="ComboBox"/> for the GUI.
		/// </summary>
		public override Control FilterControl
		{
			get { return _combo; }
		}

		/// <summary>
		/// Gets whether a filter is set.
		/// True, if the text of the <see cref="ComboBox"/> is not empty.
		/// </summary>
		public override bool HasFilter
		{
			get { return _combo.SelectedItem != SpecialValue.NoFilter; }
		}

		/// <summary>
		/// Gets a filter with a criteria in string representation.
		/// </summary>
		/// <param name="columnName">
		/// The name of the column for which the criteria should be generated.
		/// </param>
		/// <returns>a string representing the current filter criteria</returns>
		public override string GetFilter(string columnName)
		{
			if (!HasFilter)
				return "";
			
			if (_combo.SelectedItem == SpecialValue.NullFilter)
				return string.Format(NullGridFilter.FILTER_FORMAT, columnName, "=");

			return string.Format(FILTER_FORMAT, columnName, (string)_combo.SelectedItem);
		}
		
		/// <summary>
		/// Sets a string which a a previous result of <see cref="GetFilter"/>
		/// in order to configure the <see cref="FilterControl"/> to match the
		/// given filter criteria.
		/// </summary>
		/// <param name="filter">filter criteria</param>
		/// <returns></returns>
		public override void SetFilter(string filter)
		{
			Regex regex = new Regex(NullGridFilter.FILTER_REGEX);
			if (regex.IsMatch(filter))
			{
				Match match = regex.Match(filter);
				_combo.SelectedItem = SpecialValue.NullFilter;
			} 
			else
			{
				regex = new Regex(FILTER_REGEX);
				if (regex.IsMatch(filter))
				{
					Match match = regex.Match(filter);
				
					_combo.SelectedItem = match.Groups["Value"].Value;
				}
			}
		}

		/// <summary>
		/// Clears the filter to its initial state.
		/// </summary>
		public override void Clear() 
		{
			_combo.SelectedIndex = 0;
		}

		#endregion

		#region Privates

        private void Fill(DataGridViewColumn column)
		{
			bool containsDbNull;
			string[] values = GetDistinctValues(column, out containsDbNull);
			Fill(values, containsDbNull);
		}

		private void Fill(string[] values, bool containsDbNull)
		{
			Array.Sort(values);
			_values = values;
			if (containsDbNull)
				_combo.Items.Add(SpecialValue.NullFilter);
			_combo.Items.AddRange(values);
		}

		private void OnComboSelectedIndexChanged(object sender, EventArgs e)
		{
			base.OnChanged();
		}

		#endregion

		#region Public static interface

		/// <summary>
		/// Gets all values found in the specified columns as a string array.
		/// </summary>
		/// <param name="column">Column to search for values.</param>
		/// <param name="containsDbNull">Indicates whether the (null) entry is contained in the column or not.</param>
		/// <returns>Array with different values.</returns>
        public static string[] GetDistinctValues(DataGridViewColumn column, out bool containsDbNull)
		{
			return GetDistinctValues(column, int.MaxValue, out containsDbNull);
		}

		/// <summary>
		/// Gets all values found in the specified columns as a string array
		/// limited in size to the value specified. If this value is exceeded
		/// than null will be returned instead.
		/// </summary>
		/// <param name="column">Column to search for values.</param>
		/// <param name="maximumValues">Value indicating how many different values should be fetched at maximum.</param>
		/// <param name="containsDbNull">Indicates whether the (null) entry is contained in the column or not.</param>
		/// <returns>Array with different values, or Null.</returns>
        public static string[] GetDistinctValues(DataGridViewColumn column, int maximumValues, out bool containsDbNull)
		{
			Hashtable hash = new Hashtable();
			containsDbNull = false;

            IBindingListView view;

            if (column.DataGridView.DataSource as BindingSource != null)
                view = (column.DataGridView.DataSource as BindingSource).List as IBindingListView;
            else
                view = GridFiltersControl.GetViewFromDataSource(column.DataGridView.DataSource, column.DataGridView.DataMember);

            ITypedList typedList = view as ITypedList;

            if (view == null || typedList == null)
                return new string[0];

            PropertyDescriptorCollection properties = typedList.GetItemProperties(null);
            PropertyDescriptor property = properties[column.DataPropertyName];

            if (property == null)
                return new string[0];

            int viewCount = view.Count;
            for (int i = 0; i < viewCount; i++)
            {
                object value = property.GetValue(view[i]);
                if (value == null || value == DBNull.Value)
                {
                    containsDbNull = true;
                }
                else
                {
                    string stringValue = value.ToString();
                    if (!hash.ContainsKey(stringValue))
                    {
                        hash.Add(stringValue, 0);
                        if (hash.Count > maximumValues)
                            return null;
                    }
                }
            }

            //foreach (DataRow row in dataView.Table.Rows)
            //{
            //    if (row[column.DataPropertyName] == DBNull.Value)
            //    {
            //        containsDbNull = true;
            //    } 
            //    else
            //    {
            //        string value = row[column.DataPropertyName].ToString();
            //        if (!hash.ContainsKey(value))
            //        {
            //            hash.Add(value, 0);
            //            if (hash.Count > maximumValues)
            //                return null;
            //        }
            //    }
            //}

			string[] result = new string[hash.Count];
			hash.Keys.CopyTo(result, 0);
			return result;
		}

		#endregion

		#region IDisposable Member

		/// <summary>
		/// Cleans up
		/// </summary>
		public override void Dispose()
		{
			_combo.SelectedIndexChanged -= new EventHandler(OnComboSelectedIndexChanged);
			_combo.Dispose();
		}

		#endregion
	}
}
