using System;
using System.Data;
using System.Windows.Forms;

namespace GridViewExtensions
{
	/// <summary>
	/// Implemenations of this interface can provide the 
	/// <see cref="FilterableDataGrid"/> with specific implementations
	/// of <see cref="IGridFilter"/> to adjust special needs for filtering.
	/// </summary>
	public interface IGridFilterFactory
	{
		/// <summary>
		/// Event for notification that the behaviour of this
		/// instance has changed.
		/// </summary>
		event EventHandler Changed;

		/// <summary>
		/// Event for notification when a <see cref="IGridFilter"/> has been
		/// created in order to use it in a specific column and to allow
		/// custom modifications to it.
		/// </summary>
		event GridFilterEventHandler GridFilterCreated;

		/// <summary>
		/// Notifies this instance that the <see cref="IGridFilter"/> creation process
		/// is being started.
		/// </summary>
		void BeginGridFilterCreation();

		/// <summary>
		/// Notifies this instance that the <see cref="IGridFilter"/> creation process
		/// has finished. After this call all created <see cref="IGridFilter"/>s should
		/// be in a usable state.
		/// </summary>
		void EndGridFilterCreation();

		/// <summary>
		/// When implemented should return a valid <see cref="IGridFilter"/>
		/// for the specified arguments. 
		/// </summary>
		/// <param name="column">The <see cref="DataColumn"/> for which the filter control should be created.</param>
		/// <returns>A <see cref="IGridFilter"/>.</returns>
		IGridFilter CreateGridFilter(DataGridViewColumn column);
	}
}
