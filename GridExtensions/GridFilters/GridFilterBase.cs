using System;
using System.Data;
using System.Windows.Forms;

namespace GridViewExtensions.GridFilters
{
	/// <summary>
	/// Base class for easier <see cref="IGridFilter"/> implementation.
	/// </summary>
	public abstract class GridFilterBase : IGridFilter
	{
		#region Fields

		private bool _useCustomFilterPlacement;

		#endregion

		#region Constructors

		/// <summary>
		/// Base constructor.
		/// </summary>
		/// <param name="useCustomFilterPlacement">False, if the filter control should be
		/// placed within the grid, otherwise true.</param>
		protected GridFilterBase(bool useCustomFilterPlacement)
		{
			_useCustomFilterPlacement = useCustomFilterPlacement;
		}

		#endregion

		#region IGridFilter Member

		/// <summary>
		/// Event for notification that the filter criteria for this
		/// instance has changed.
		/// </summary>
		public event System.EventHandler Changed;

		/// <summary>
		/// The control which contains the GUI elements for the filter
		/// </summary>
		public abstract Control FilterControl { get; }

		/// <summary>
		/// Specifies whether the control is placed automatically or not.
		/// </summary>
		public bool UseCustomFilterPlacement 
		{
			get { return _useCustomFilterPlacement; }
			set { _useCustomFilterPlacement = value; }
		}

		/// <summary>
		/// Gets whether a filter is currently set
		/// </summary>
		public abstract bool HasFilter { get; }

		/// <summary>
		/// Gets a string representing the current filter.
		/// This must be a valid expression understandable by the 
		/// <see cref="DataView"/> class's property <see cref="DataView.RowFilter"/>.
		/// </summary>
		/// <param name="columnName">
		/// The name of the column for which the criteria should be generated.
		/// </param>
		/// <returns>a string representing the current filter criteria</returns>
		public abstract string GetFilter(string columnName);

		/// <summary>
		/// Sets a string which a a previous result of <see cref="GetFilter"/>
		/// in order to configure the <see cref="FilterControl"/> to match the
		/// given filter criteria.
		/// </summary>
		/// <param name="filter">filter criteria</param>
		/// <returns></returns>
		public abstract void SetFilter(string filter);

		/// <summary>
		/// Clears the filter to its initial state.
		/// </summary>
		public abstract void Clear();

		#endregion

		#region Protected

		/// <summary>
		/// Fires the <see cref="Changed"/> event.
		/// </summary>
		protected void OnChanged()
		{
			if (Changed != null)
				Changed(this, EventArgs.Empty);
		}

		#endregion

		#region IDisposable Member

		/// <summary>
		/// Frees the resources of this instance.
		/// Not needed in the base implementation but probably a good thing
		/// in deriving classes.
		/// </summary>
		public virtual void Dispose() {}

		#endregion
	}
}
