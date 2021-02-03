using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GridViewExtensions
{
	/// <summary>
	/// Interface which is used to provide different filter methods 
	/// and GUI elements for filtering in the <see cref="FilterableDataGrid"/>.
	/// </summary>
	public interface IGridFilter : IDisposable
	{
		/// <summary>
		/// Event for notification that the filter criteria for this
		/// instance has changed.
		/// </summary>
		event EventHandler Changed;

		/// <summary>
		/// The control which contains the GUI elements for the filter
		/// </summary>
		Control FilterControl { get; }

		/// <summary>
		/// Gets whether a filter is currently set
		/// </summary>
		bool HasFilter { get; }

		/// <summary>
		/// Specifies whether the control is placed automatically or not.
		/// </summary>
		bool UseCustomFilterPlacement { get; set; }

		/// <summary>
		/// Gets a string representing the current filter.
		/// This must be a valid expression understandable by the 
		/// <see cref="DataView"/> class's property <see cref="DataView.RowFilter"/>.
		/// </summary>
		/// <param name="columnName">
		/// The name of the column for which the criteria should be generated.
		/// </param>
		/// <returns>a string representing the current filter criteria</returns>
		string GetFilter(string columnName);

		/// <summary>
		/// Sets a string which a a previous result of <see cref="GetFilter"/>
		/// in order to configure the <see cref="FilterControl"/> to match the
		/// given filter criteria.
		/// </summary>
		/// <param name="filter">filter criteria</param>
		/// <returns></returns>
		void SetFilter(string filter);
	
		/// <summary>
		/// Clears the filter to its initial state.
		/// </summary>
		void Clear();
	}
}
