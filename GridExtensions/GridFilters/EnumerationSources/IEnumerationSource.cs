using System;

namespace GridViewExtensions.GridFilters.EnumerationSources
{
	/// <summary>
	/// Interface defining a data source for the <see cref="EnumerationGridFilter"/>.
	/// </summary>
	public interface IEnumerationSource
	{
		/// <summary>
		/// Gets all values which should be displayed.
		/// </summary>
		object[] AllValues { get; }

		/// <summary>
		/// Build the filter criteria from the given input.
		/// </summary>
		/// <param name="value">The selected value for which the criteria is created.</param>
		/// <returns>A <see cref="string"/> representing the criteria.</returns>
		string GetFilterFromValue(object value);

		/// <summary>
		/// Gets the object value for a specified filter.
		/// </summary>
		/// <param name="filter">The filter value to be searched</param>
		/// <returns>object value for the specified filter</returns>
		object GetValueFromFilter(string filter);
	}
}
