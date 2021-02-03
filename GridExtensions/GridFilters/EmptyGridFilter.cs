using System;
using System.Windows.Forms;

namespace GridViewExtensions.GridFilters
{
	/// <summary>
	/// A dummy <see cref="IGridFilter"/> implementation, which does no filtering.
	/// </summary>
	public class EmptyGridFilter : GridFilterBase
	{
		#region Fields

		private Control _control;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		public EmptyGridFilter() : base(false)
		{
			_control = new Control();
		}

		#endregion

		#region Overridden from GridFilterBase

		/// <summary>
		/// Gets an empty control.
		/// </summary>
		public override Control FilterControl
		{
			get { return _control; }
		}

		/// <summary>
		/// Always return false.
		/// </summary>
		public override bool HasFilter
		{
			get { return false; }
		}

		/// <summary>
		/// Always returns an empty string.
		/// </summary>
		/// <param name="columnName">Not necessary.</param>
		/// <returns>An empty string.</returns>
		public override string GetFilter(string columnName)
		{
			return "";
		}		
		
		/// <summary>
		/// Does nothing.
		/// </summary>
		/// <param name="filter">filter criteria</param>
		/// <returns></returns>
		public override void SetFilter(string filter) {}

		/// <summary>
		/// Clears the filter to its initial state.
		/// </summary>
		public override void Clear() {}

		#endregion
	}
}
