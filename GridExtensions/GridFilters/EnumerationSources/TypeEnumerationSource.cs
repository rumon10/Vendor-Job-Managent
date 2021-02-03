using System;

namespace GridViewExtensions.GridFilters.EnumerationSources
{
	/// <summary>
	/// <see cref="IEnumerationSource"/> implementation which gets its values from
	/// an enumeration type via reflection.
	/// </summary>
	public class TypeEnumerationSource : IEnumerationSource
	{
		#region Fields

		private Type _enumType;
		private object[] _allValues;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="dataType">Enumeration type</param>
		public TypeEnumerationSource(Type dataType)
		{
			if (!dataType.IsEnum)
				throw new ArgumentException("Only enumeration types are valid arguments.");

			_enumType = dataType;
		}

		#endregion

		#region IEnumerationSource Member

		/// <summary>
		/// Gets all values which should be displayed.
		/// </summary>
		public object[] AllValues
		{
			get 
			{
				if (_allValues == null)
				{
					Array arr = Enum.GetValues(_enumType);
					_allValues = new object[arr.Length];
					arr.CopyTo(_allValues, 0);
				}
				return _allValues; 
			}
		}

		/// <summary>
		/// Build the filter criteria from the given input.
		/// </summary>
		/// <param name="value">The selected value for which the criteria is created.</param>
		/// <returns>A <see cref="string"/> representing the criteria.</returns>
		public string GetFilterFromValue(object value)
		{
			return Convert.ToInt32(value).ToString();
		}

		/// <summary>
		/// Gets the object value for a specified filter.
		/// </summary>
		/// <param name="filter">The filter value to be searched</param>
		/// <returns>object value for the specified filter</returns>
		public object GetValueFromFilter(string filter)
		{
			return Enum.ToObject(_enumType, Convert.ToInt32(filter));
		}

		#endregion
	}
}
