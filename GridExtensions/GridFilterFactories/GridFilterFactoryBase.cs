using System;
using System.Data;
using System.Windows.Forms;

namespace GridViewExtensions.GridFilterFactories
{
	/// <summary>
	/// Base implementation for <see cref="IGridFilterFactory"/> handling
	/// most of the common tasks. Inheriting classes only need to override
	/// <see cref="CreateGridFilterInternal"/>. 
	/// </summary>
	public abstract class GridFilterFactoryBase : IGridFilterFactory
	{
		#region Constructors

		/// <summary>
		/// Base constructor.
		/// </summary>
		public GridFilterFactoryBase() {}

		#endregion

		#region Protected interface

		/// <summary>
		/// Raises the <see cref="Changed"/> event.
		/// </summary>
		/// <param name="eventArgs">Event arguments</param>
		protected virtual void OnChanged(EventArgs eventArgs)
		{
			if (Changed != null)
				Changed(this, eventArgs);
		}

		/// <summary>
		/// Raises the <see cref="GridFilterCreated"/> event.
		/// </summary>
		/// <param name="eventArgs">Event arguments</param>
		protected virtual void OnGridFilterCreated(GridFilterEventArgs eventArgs)
		{
			if (GridFilterCreated != null)
				GridFilterCreated(this, eventArgs);
		}

		/// <summary>
		/// Must be overridden by implementing classes.
		/// Should return a valid <see cref="IGridFilter"/> for the specified arguments. 
		/// </summary>
		/// <param name="column">The <see cref="DataColumn"/> for which the filter control should be created.</param>
		/// <returns>A <see cref="IGridFilter"/>.</returns>
        protected abstract IGridFilter CreateGridFilterInternal(DataGridViewColumn column);

		#endregion

		#region IGridFilterFactory Member

		/// <summary>
		/// Event for notification that the behaviour of this
		/// instance has changed.
		/// </summary>
		public event EventHandler Changed;

		/// <summary>
		/// Event for notification when a <see cref="IGridFilter"/> has been
		/// created in order to use it in a specific column and to allow
		/// custom modifications to it.
		/// </summary>
		public event GridFilterEventHandler GridFilterCreated;

		/// <summary>
		/// Notifies this instance that the <see cref="IGridFilter"/> creation process
		/// is being started.
		/// </summary>
		public virtual void BeginGridFilterCreation() {}

		/// <summary>
		/// Notifies this instance that the <see cref="IGridFilter"/> creation process
		/// has finished. After this call all created <see cref="IGridFilter"/>s should
		/// be in a usable state.
		/// </summary>
		public virtual void EndGridFilterCreation() {}

		/// <summary>
		/// Creates a <see cref="IGridFilter"/> for the specified arguments.
		/// It calls <see cref="CreateGridFilterInternal"/> which must be overridden
		/// by any implementing class and raises the <see cref="GridFilterCreated"/>
		/// afterwards.
		/// </summary>
		/// <param name="column">The <see cref="DataColumn"/> for which the filter control should be created.</param>
		/// <returns>A <see cref="IGridFilter"/>.</returns>
		public IGridFilter CreateGridFilter(DataGridViewColumn column)
		{
			IGridFilter gridFilter = CreateGridFilterInternal(column);
			GridFilterEventArgs gridFilterEventArgs = new GridFilterEventArgs(column, gridFilter);
			OnGridFilterCreated(gridFilterEventArgs);
			return gridFilterEventArgs.GridFilter;
		}

		#endregion

		#region Overridden from Object

		/// <summary>
		/// Returns a textual representation of the class.
		/// </summary>
		/// <returns>A textual representation of the class.</returns>
		public override string ToString()
		{
			return this.GetType().Name;
		}

		#endregion
	}
}
