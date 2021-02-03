using System;
using System.Data;
using System.Windows.Forms;

namespace GridViewExtensions.GridFilterFactories
{
	/// <summary>
	/// <see cref="IGridFilterFactory"/> implementation which creates a
	/// <see cref="GridFilters.NullGridFilter"/> on every column.
	/// </summary>
	public class NullGridFilterFactory : GridFilterFactoryBase
	{
		#region Constructors

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		public NullGridFilterFactory() {}

		#endregion

		#region Overridden from GridFilterFactoryBase

		/// <summary>
		/// Return always a <see cref="GridFilters.NullGridFilter"/>. 
		/// </summary>
		/// <param name="column">The <see cref="DataColumn"/> for which the filter control should be created.</param>
		/// <returns>A <see cref="IGridFilter"/>.</returns>
        protected override IGridFilter CreateGridFilterInternal(DataGridViewColumn column)
		{
			return new GridFilters.NullGridFilter();
		}

		#endregion
	}
}
