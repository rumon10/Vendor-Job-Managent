using System;
using System.Data;
using System.Windows.Forms;

namespace GridViewExtensions.GridFilterFactories
{
	/// <summary>
	/// <see cref="IGridFilterFactory"/> implementation which creates a
	/// <see cref="GridFilters.DistinctValuesGridFilter"/> on every column.
	/// </summary>
	public class DistinctValuesGridFilterFactory : GridFilterFactoryBase
	{
		#region Constructors

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		public DistinctValuesGridFilterFactory() {}

		#endregion

		#region Overridden from GridFilterFactoryBase

		/// <summary>
		/// Return always a <see cref="GridFilters.DistinctValuesGridFilter"/>. 
		/// </summary>
		/// <param name="column">The <see cref="DataColumn"/> for which the filter control should be created.</param>
		/// <returns>A <see cref="IGridFilter"/>.</returns>
        protected override IGridFilter CreateGridFilterInternal(DataGridViewColumn column)
		{
			return new GridFilters.DistinctValuesGridFilter(column);
		}

		#endregion
	}
}
