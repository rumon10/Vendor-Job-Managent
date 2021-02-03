using System;
using System.Data;
using System.Windows.Forms;

namespace GridViewExtensions
{
	/// <summary>
	/// Delegate for use with <see cref="GridFilterEventArgs"/>.
	/// </summary>
	public delegate void GridFilterEventHandler(object sender, GridFilterEventArgs args);

	/// <summary>
	/// Argumentsclass for events needing extended informations about <see cref="IGridFilter"/>s.
	/// </summary>
	public class GridFilterEventArgs : EventArgs
	{
		#region Fields

        private DataGridViewColumn _column;
		private IGridFilter _gridFilter;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new instance
		/// </summary>
		/// <param name="column">Column the <see cref="IGridFilter"/> is created for.</param>
		/// <param name="gridFilter">Default <see cref="IGridFilter"/> instance.</param>
        public GridFilterEventArgs(DataGridViewColumn column, IGridFilter gridFilter)
		{
			_column = column;
			_gridFilter = gridFilter;
		}

		#endregion

		#region Public Interface

		/// <summary>
		/// Type of the column the <see cref="IGridFilter"/> is created for.
		/// </summary>
		public Type DataType 
		{
			get { return _column.ValueType; }
		}

		/// <summary>
		/// Name of the column the <see cref="IGridFilter"/> is created for.
		/// </summary>
		public string ColumnName 
		{
			get { return _column.DataPropertyName; }
		}

		/// <summary>
		/// The column the <see cref="IGridFilter"/> is created for.
		/// </summary>
        public DataGridViewColumn Column 
		{
			get { return _column; }
		}

		/// <summary>
		/// Text of the header of the column the <see cref="IGridFilter"/> is created for.
		/// </summary>
		public string HeaderText 
		{
			get { return _column.HeaderText; }
		}

		/// <summary>
		/// Gets/sets the <see cref="IGridFilter"/> which should be used.
		/// </summary>
		public IGridFilter GridFilter 
		{
			get { return _gridFilter; }
			set { _gridFilter = value; }
		}

		#endregion
	}
}
