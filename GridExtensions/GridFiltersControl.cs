using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using GridViewExtensions.GridFilterFactories;

namespace GridViewExtensions
{
	#region Enum LogicalOperators

	/// <summary>
	/// Logical operators which can be used to determine how the filter
	/// criterias are combined
	/// </summary>
	public enum LogicalOperators 
	{
		/// <summary>
		/// Logical And
		/// </summary>
		And,
		/// <summary>
		/// Logical Or
		/// </summary>
		Or
	}

	#endregion

	#region Enum FilterErrorModes

	/// <summary>
	/// Modes which determine the output generated when an error
	/// in the builded filter criterias occurs.
	/// </summary>
	[Flags]
	public enum FilterErrorModes 
	{
		/// <summary>
		/// No error output at all
		/// </summary>
		Off = 0,
		/// <summary>
		/// General error message
		/// </summary>
		General = 1,
		/// <summary>
		/// Message of the exception that occured
		/// </summary>
		ExceptionMessage = 2,
		/// <summary>
		/// StackTrace of the exception that occured
		/// </summary>
		StackTrace = 4,
		/// <summary>
		/// All available output
		/// </summary>
		All = 7
	}

	#endregion

    #region Enum RefreshMode

    /// <summary>
    /// Modes which determine when the filter criteria get automatically
    /// applied to the contents of the grid.
    /// </summary>
    public enum RefreshMode
    {
        /// <summary>
        /// Filters are regenerated on every user input.
        /// </summary>
        OnInput,
        /// <summary>
        /// Filters are regenerated whenever the user presses Enter while
        /// the focus is in one of the filter controls.
        /// </summary>
        OnEnter,
        /// <summary>
        /// Filters are regenerated whenever one of the filter controls
        /// looses input focus.
        /// </summary>
        OnLeave,
        /// <summary>
        /// Filters are regenerated whenever one of the filter controls
        /// looses input focus or the user presses Enter while
        /// the focus is in one of the filter controls.
        /// </summary>
        OnEnterOrLeave,
        /// <summary>
        /// No automatic filter generation.
        /// </summary>
        Off
    }

    #endregion

    /// <summary>
	/// A control where all controls all placed which are necessary for
	/// extending a grid for filtering.
	/// </summary>
	internal class GridFiltersControl : System.Windows.Forms.UserControl, ISupportInitialize
	{
		#region Events

        /// <summary>
        /// Event, which gets fired whenever the filter criteria has been changed.
        /// </summary>
        internal event EventHandler AfterFiltersChanged;

        /// <summary>
        /// Event, which gets fired whenever the filter criteria are going to be changed.
        /// </summary>
        internal event EventHandler BeforeFiltersChanging;

        /// <summary>
        /// Event, which gets fired whenever an <see cref="IGridFilter"/> has been bound
        /// and thus added to this instance.
        /// </summary>
        internal event GridFilterEventHandler GridFilterBound;

        /// <summary>
        /// Event, which gets fired whenever an <see cref="IGridFilter"/> has been unbound
        /// and thus removed to this instance.
        /// </summary>
        internal event GridFilterEventHandler GridFilterUnbound;

		#endregion

		#region Fields

		private Hashtable _columnToGridFilterHash;
		private IGridFilterFactory _filterFactory;
		private LogicalOperators _operator;
        private RefreshMode _autoRefreshMode = RefreshMode.OnInput;
		private bool _refreshDisabled = false;
		private bool _keepFilters = false;
		private Hashtable _keepFiltersHash;
		private string _lastRowFilter = "";

		private System.Windows.Forms.TextBox _refBox;
		private System.Windows.Forms.Label _lblFilter;
		private System.ComponentModel.Container components = null;

        private DataGridView _grid;

		private FilterErrorModes _messageErrorMode = FilterErrorModes.General;
		private FilterErrorModes _consoleErrorMode = FilterErrorModes.Off;
        private int _initCounter = 0;

        private StringDictionary _baseFilters;
        private bool _baseFilterEnabled = true;
        private LogicalOperators _baseFilterOperator = LogicalOperators.And;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new instance
		/// </summary>
		internal GridFiltersControl()
		{
			InitializeComponent();

			_columnToGridFilterHash = new Hashtable();
            _keepFiltersHash = new Hashtable();
            _baseFilters = new StringDictionary();

			FilterFactory = new DefaultGridFilterFactory();

			RecreateGridFilters();
		}

		#endregion

		#region Vom Komponenten-Designer generierter Code
		/// <summary> 
		/// Erforderliche Methode f|r die Designerunterst|tzung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor gedndert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this._refBox = new System.Windows.Forms.TextBox();
			this._lblFilter = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// _refBox
			// 
			this._refBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this._refBox.Location = new System.Drawing.Point(344, 0);
			this._refBox.Name = "_refBox";
			this._refBox.Size = new System.Drawing.Size(40, 20);
			this._refBox.TabIndex = 0;
			this._refBox.Text = "textBox1";
			this._refBox.Visible = false;
			// 
			// _lblFilter
			// 
			this._lblFilter.Dock = System.Windows.Forms.DockStyle.Left;
			this._lblFilter.Location = new System.Drawing.Point(0, 0);
			this._lblFilter.Name = "_lblFilter";
			this._lblFilter.Size = new System.Drawing.Size(100, 24);
			this._lblFilter.TabIndex = 1;
			this._lblFilter.Text = "Filter";
			this._lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// GridFiltersControl
			// 
			this.Controls.Add(this._lblFilter);
			this.Controls.Add(this._refBox);
			this.Name = "GridFiltersControl";
			this.Size = new System.Drawing.Size(384, 24);
			this.ResumeLayout(false);

		}
		#endregion		

		#region Overriden from UserControl

        public override RightToLeft RightToLeft
        {
            get { return base.RightToLeft; }
            set
            {
                try
                {
                    _initCounter++;
                    base.RightToLeft = value;
                }
                finally
                {
                    _initCounter--;
                }
                RecreateGridFilters();
            }
        }

		/// <summary> 
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
            DataGridView = null;

			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// Initiates recalculation for the positions of the filter GUI elements.
		/// </summary>
		/// <param name="e">Event data</param>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			RepositionGridFilters();			
		}

		/// <summary>
		/// Initiates recalculation for the positions of the filter GUI elements.
		/// </summary>
		/// <param name="e">Event data</param>
		protected override void OnRightToLeftChanged(EventArgs e)
		{
			base.OnRightToLeftChanged(e);
			RepositionGridFilters();
		}

		#endregion

		#region Internals

		/// <summary>
        /// Gets and sets the <see cref="DataGridView"/> instance to use.
		/// </summary>
		internal DataGridView DataGridView
		{
			get { return _grid; }
			set 
			{
				if (_grid != null)
				{
                    _grid.DataSourceChanged -= new System.EventHandler(this.OnDataSourceChanged);
                    _grid.DataMemberChanged -= new System.EventHandler(this.OnDataSourceChanged);
                    _grid.ColumnWidthChanged -= new DataGridViewColumnEventHandler(OnGridColumnsChanged);
                    _grid.ColumnDisplayIndexChanged -= new DataGridViewColumnEventHandler(OnGridColumnsChanged);
                    _grid.ColumnAdded -= new DataGridViewColumnEventHandler(OnGridColumnsAddedRemoved);
                    _grid.ColumnRemoved -= new DataGridViewColumnEventHandler(OnGridColumnsAddedRemoved);
                    _grid.ColumnStateChanged -= new DataGridViewColumnStateChangedEventHandler(OnGridColumnsStateChanged);
                    _grid.Scroll -= new ScrollEventHandler(OnGridScroll);
				}

				_grid = value;
				
				if (_grid != null)
				{
                    _grid.DataSourceChanged += new System.EventHandler(this.OnDataSourceChanged);
                    _grid.DataMemberChanged += new System.EventHandler(this.OnDataSourceChanged);
                    _grid.ColumnWidthChanged += new DataGridViewColumnEventHandler(OnGridColumnsChanged);
                    _grid.ColumnDisplayIndexChanged += new DataGridViewColumnEventHandler(OnGridColumnsChanged);
                    _grid.ColumnAdded += new DataGridViewColumnEventHandler(OnGridColumnsAddedRemoved);
                    _grid.ColumnRemoved += new DataGridViewColumnEventHandler(OnGridColumnsAddedRemoved);
                    _grid.ColumnStateChanged += new DataGridViewColumnStateChangedEventHandler(OnGridColumnsStateChanged);
                    _grid.Scroll += new ScrollEventHandler(OnGridScroll);
                }
				RecreateGridFilters();
			}
		}

		/// <summary>
		/// Gets and sets whether filters are kept while switching between different tables.
		/// </summary>
		internal bool KeepFilters
		{
			get { return _keepFilters; }
			set 
			{				
				_keepFilters = value;
				if (!_keepFilters)
					_keepFiltersHash.Clear();
				else
					RecreateRowFilter();
			}
		}

		/// <summary>
		/// Gets and sets whether the filter criteria is automatically refreshed when
		/// changes are made to the filter controls. If set to false then a call to
		/// <see cref="RefreshFilters"/> is needed to manually refresh the criteria.
		/// </summary>
		internal RefreshMode AutoRefreshMode
		{
			get { return _autoRefreshMode; }
			set 
			{
				_autoRefreshMode = value;
				RecreateRowFilter();
			}
		}
		
		/// <summary>
		/// Gets and sets the text for the filter label.
		/// </summary>
		internal string FilterText 
		{
			get { return _lblFilter.Text; }
			set { _lblFilter.Text = value; }
		}

		/// <summary>
		/// Gets and sets the <see cref="IGridFilterFactory"/> used to generate the filter GUI.
		/// </summary>
		internal IGridFilterFactory FilterFactory 
		{
			get { return _filterFactory; }
			set 
			{
				if (_filterFactory != null)
					_filterFactory.Changed -= new EventHandler(OnFilterFactoryChanged);
				_filterFactory = value; 
				if (_filterFactory == null)
					_filterFactory = new DefaultGridFilterFactory();
				_filterFactory.Changed += new EventHandler(OnFilterFactoryChanged);
				RecreateGridFilters();
			}
		}

		/// <summary>
		/// The selected operator to combine the filter criterias.
		/// </summary>
		internal LogicalOperators Operator 
		{
			get { return _operator; }
			set 
			{
				_operator = value; 
				RecreateRowFilter();
			}
		}

		/// <summary>
		/// Gets and sets whether the filter label should be visible.
		/// </summary>
		internal bool FilterTextVisible 
		{
			get { return _lblFilter.Visible; }
			set { _lblFilter.Visible = value; }
		}	

		/// <summary>
		/// Gets and sets what information is showed to the user
		/// if an error in the builded filter criterias occurs.
		/// </summary>
		internal FilterErrorModes MessageErrorMode 
		{
			get { return _messageErrorMode; }
			set { _messageErrorMode = value; }
		}

		/// <summary>
		/// Gets and sets what information is showed to the user
		/// if an error in the builded filter criterias occurs.
		/// </summary>
		internal FilterErrorModes ConsoleErrorMode 
		{
			get { return _consoleErrorMode; }
			set { _consoleErrorMode = value; }
        }

        /// <summary>
        /// Gets a modifyable collection which maps <see cref="DataTable.TableName"/>s
        /// to base filter strings which are applied in front of the automatically
        /// created filter.
        /// </summary>
        /// <remarks>
        /// The grid contents is not automatically refreshed when modifying this 
        /// collection. A call to <see cref="RefreshFilters"/> is needed for this.
        /// </remarks>
        internal StringDictionary BaseFilters
        {
            get { return _baseFilters; }
        }

        /// <summary>
        /// Gets or sets which operator should be used to combine the base filter
        /// with the automatically created filters.
        /// </summary>
        internal LogicalOperators BaseFilterOperator
        {
            get { return _baseFilterOperator; }
            set
            {
                _baseFilterOperator = value;
                RecreateRowFilter();
            }
        }

        /// <summary>
        /// Gets or sets whether base filters should be used when refreshing
        /// the filter criteria. Setting it to false will disable the functionality
        /// while still keeping the base filter strings in the <see cref="BaseFilters"/>
        /// collection intact.
        /// </summary>
        internal bool BaseFilterEnabled
        {
            get { return _baseFilterEnabled; }
            set
            {
                _baseFilterEnabled = value;
                RecreateRowFilter();
            }
        }

        /// <summary>
        /// Gets or sets the currently used base filter. Internally it adjusts the
        /// <see cref="BaseFilters"/> collection with the given value and the current
        /// <see cref="DataTable.TableName"/> and also initiates a refresh.
        /// </summary>
        internal string CurrentTableBaseFilter
        {
            get
            {
                if (!this.HasView)
                    return null;
                else
                   return _baseFilters[GetTableName()];
            }
            set
            {
                if (!this.HasView)
                    return;

                _baseFilters[GetTableName()] = value;
                RecreateRowFilter();
            }
        }
	
		/// <summary>
		/// Clears all filters to initial state.
		/// </summary>
		internal void ClearFilters() 
		{
			try 
			{
				_refreshDisabled = true;
				foreach (IGridFilter gridFilter in _columnToGridFilterHash.Values)
					gridFilter.Clear();
			} 
			finally 
			{
				_refreshDisabled = false;
			}
			RecreateRowFilter();
		}

		/// <summary>
		/// Sets all filters to the specified values.
		/// The values must be in order of the column styles in the current view.
		/// This function should normally be used with data previously coming
		/// from the <see cref="GetFilters"/> function.
		/// </summary>
		/// <param name="filters">filters to set</param>
		internal void SetFilters(string[] filters)
		{
			for (int i = 0; i < _grid.Columns.Count && i < filters.Length; i++)
			{
                IGridFilter gridFilter = (IGridFilter)_columnToGridFilterHash[_grid.Columns[i]];
				if (filters[i].Length > 0)
					gridFilter.SetFilter(filters[i]);
				else
					gridFilter.Clear();
			}
		}

		/// <summary>
		/// Gets all filters currently set
		/// </summary>
		/// <returns></returns>
		internal string[] GetFilters()
		{
			string[] result = new string[_columnToGridFilterHash.Count];
            for (int i = 0; i < _grid.Columns.Count; i++)
			{
                DataGridViewColumn column = _grid.Columns[i];
				IGridFilter gridFilter = (IGridFilter)_columnToGridFilterHash[column];
				if (gridFilter.HasFilter)
					result[i] = gridFilter.GetFilter(string.Format("[{0}]", column.DataPropertyName));
				else
					result[i] = "";
			}
			return result;
		}

		/// <summary>
		/// Refreshes the filter criteria to match the current contents of the associated
		/// filter controls.
		/// </summary>
		internal void RefreshFilters()
		{
			_lastRowFilter = "_";
			RecreateRowFilter(true);
        }

        /// <summary>
        /// Gets all currently set <see cref="IGridFilter"/>s.
        /// </summary>
        /// <returns>Collection of <see cref="IGridFilter"/>s.</returns>
        internal GridFilterCollection GetGridFilters()
        {
            if (_grid.Columns == null || _columnToGridFilterHash == null)
                return null;

            return new GridFilterCollection(_grid.Columns, _columnToGridFilterHash);
        }

		#endregion

        #region Static Internals

        /// <summary>
        /// Tries to resolve a <see cref="IBindingListView"/> from a given data source.
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="dataMember"></param>
        /// <returns></returns>
        internal static IBindingListView GetViewFromDataSource(object dataSource, string dataMember)
        {
            if (dataSource == null)
                return null;
            else if (dataSource as IBindingListView != null)
                return dataSource as IBindingListView;
            else if (dataSource as DataTable != null)
                return (dataSource as DataTable).DefaultView;
            else if (dataSource as DataSet != null)
            {
                DataTable dataTable = (dataSource as DataSet).Tables[dataMember];
                if (dataTable != null)
                    return dataTable.DefaultView;
                else
                    return null;
            }
            else
                return null;
        }

        #endregion

        #region Privates

        private bool HasView
        {
            get
            {
                if (_grid != null && _grid.DataSource != null)
                {
                    if (_grid.DataSource is DataTable)
                        return true;
                    else if (_grid.DataSource is DataView)
                        return true;
                    else if (_grid.DataSource is BindingSource)
                        return true;
                    else if (_grid.DataSource is IBindingListView)
                        return true;
                }
                return false;
            }
        }

        private void SetRowFilter(string rowFilter)
        {
            OnBeforeFiltersChanging(EventArgs.Empty);
            try
            {
                if (_grid != null && _grid.DataSource != null)
                {
                    if (_grid.DataSource is DataTable)
                        ((DataTable)_grid.DataSource).DefaultView.RowFilter = rowFilter;
                    else if (_grid.DataSource is DataView)
                        ((DataView)_grid.DataSource).RowFilter = rowFilter;
                    else if (_grid.DataSource is BindingSource)
                        ((BindingSource)_grid.DataSource).Filter = rowFilter;
                    else if (_grid.DataSource is IBindingListView)
                        ((IBindingListView)_grid.DataSource).Filter = rowFilter;
                }
            }
            finally
            {
                OnAfterFiltersChanged(EventArgs.Empty);
            }
        }

        private string GetTableName()
        {
            if (_grid != null && _grid.DataSource != null)
            {
                string name = null;
                if (GetDataSourceName(_grid.DataSource, ref name))
                    return name;
                else if (_grid.DataSource is BindingSource)
                {
                    if (GetDataSourceName(((BindingSource)_grid.DataSource).DataSource, ref name))
                        return name;
                    else
                        return ((BindingSource)_grid.DataSource).DataMember;
                }
                else if (_grid.DataSource is IBindingListView)
                {
                    return _grid.DataSource.GetType().Name;
                }
            }
            return null;
        }

        private bool GetDataSourceName(object dataSource, ref string name)
        {
            if (_grid.DataSource is DataTable)
            {
                name = ((DataTable)_grid.DataSource).TableName;
                return true;
            }
            else if (_grid.DataSource is DataView)
            {
                name = ((DataView)_grid.DataSource).Table.TableName;
                return true;
            }
            else if (_grid.DataSource is IBindingListView)
            {
                name = _grid.DataSource.GetType().Name;
                return true;
            }
            return false;
        }

        /*
        private BindingSource CurrentBindingSource
        {
            get { return _currentBindingSource; }
            set
            {
                if (value == _currentBindingSource)
                    return;

                if (_currentBindingSource != null)
                {
                    _currentBindingSource.DataSourceChanged -= new EventHandler(OnDataSourceChanged);
                    _currentBindingSource.DataMemberChanged -= new EventHandler(OnDataSourceChanged);
                }

                _currentBindingSource = value;

                if (_currentBindingSource != null)
                {
                    _currentBindingSource.DataSourceChanged += new EventHandler(OnDataSourceChanged);
                    _currentBindingSource.DataMemberChanged += new EventHandler(OnDataSourceChanged);
                }
            }
        }

        private DataView CurrentView
        {
            get
            {
                if (_grid == null)
                {
                    this.CurrentBindingSource = null;
                    return null;
                }
                else if (_grid.DataSource as BindingSource != null)
                {
                    this.CurrentBindingSource = _grid.DataSource as BindingSource;
                    return this.CurrentBindingSource.List as DataView;
                }
                else
                {
                    this.CurrentBindingSource = null;
                    return GetViewFromDataSource(_grid.DataSource, _grid.DataMember);
                }
            }
        }
        */
		
		/// <summary>
		/// Initiates a recalculation of the needed filter GUI elements and their positions.
		/// </summary>
        private void RecreateGridFilters()
        {
            if (_initCounter > 0)
                return;

            //first clean up what has beed done before
            foreach (DataGridViewColumn column in _columnToGridFilterHash.Keys)
            {
                IGridFilter gridFilter = _columnToGridFilterHash[column] as IGridFilter;
                gridFilter.Changed -= new EventHandler(OnFilterChanged);
                gridFilter.FilterControl.KeyPress -= new KeyPressEventHandler(OnFilterControlKeyPress);
                gridFilter.FilterControl.Leave -= new EventHandler(OnFilterControlLeave);
                if (this.Controls.Contains(gridFilter.FilterControl))
                {
                    this.Controls.Remove(gridFilter.FilterControl);
                    gridFilter.FilterControl.Dispose();
                }
                OnGridFilterUnbound(new GridFilterEventArgs(column, gridFilter));
            }
            _columnToGridFilterHash.Clear();

            //adjust the position for the filter GUI
            this.Height = _refBox.Height;

            if (_grid == null)
                return;

            int rowHeadersWidth = _grid.RowHeadersVisible ? _grid.RowHeadersWidth : 0;
            _lblFilter.Width = rowHeadersWidth;

            if (!HasView)
            {
                //provide a dummy representation when nothing is set
                //this allows better desing time support
                _refBox.Visible = true;
                _refBox.Left = rowHeadersWidth + 1;
                _refBox.Width = this.Width - rowHeadersWidth - 1;

                return;
            }
            _refBox.Visible = false;

            _filterFactory.BeginGridFilterCreation();
            try
            {
                for (int i = 0; i < _grid.Columns.Count; i++)
                {
                    DataGridViewColumn column = _grid.Columns[i];
                    Type dataType = column.ValueType;
                    //create a filter
                    IGridFilter gridFilter = _filterFactory.CreateGridFilter(column);
                    if (!gridFilter.UseCustomFilterPlacement)
                    {
                        //adjust the vertical positions
                        gridFilter.FilterControl.Top = 0;
                        gridFilter.FilterControl.Height = this.Height;
                        gridFilter.FilterControl.Visible = false;
                        //add the GUI element to our controls collection
                        this.Controls.Add(gridFilter.FilterControl);
                        gridFilter.FilterControl.BringToFront();
                    }
                    //notification needed when the filter settings are changed
                    gridFilter.Changed += new EventHandler(OnFilterChanged);
                    gridFilter.FilterControl.KeyPress += new KeyPressEventHandler(OnFilterControlKeyPress);
                    gridFilter.FilterControl.Leave += new EventHandler(OnFilterControlLeave);
                    //added to hash to provider fast access
                    _columnToGridFilterHash.Add(column, gridFilter);

                    OnGridFilterBound(new GridFilterEventArgs(column, gridFilter));
                }
            }
            finally
            {
                _filterFactory.EndGridFilterCreation();
            }
            if (_keepFilters && _keepFiltersHash.ContainsKey(GetTableName()))
                SetFilters((string[])_keepFiltersHash[GetTableName()]);

            RepositionGridFilters();
        }
        private void RepositionGridFilters()
        {
            if (_initCounter > 0)
                return;

            if (_grid == null || _grid.Columns == null || _grid.Columns.Count == 0)
                return;

            try
            {
                this.SuspendLayout();

                int rowHeadersWidth = _grid.RowHeadersVisible ? _grid.RowHeadersWidth : 0;
                int filterWidth = _grid.RowHeadersVisible ? _grid.RowHeadersWidth - 1 : 0;
                int curPos = rowHeadersWidth;

                if (filterWidth > 0)
                {
                    _lblFilter.Width = filterWidth;
                    _lblFilter.Visible = true;
                    curPos++;
                    if (base.RightToLeft == RightToLeft.Yes)
                    {
                        if (_lblFilter.Dock != DockStyle.Right)
                            _lblFilter.Dock = DockStyle.Right;
                    }
                    else
                    {
                        if (_lblFilter.Dock != DockStyle.Left)
                            _lblFilter.Dock = DockStyle.Left;
                    }
                }
                else
                {
                    if (_lblFilter.Visible)
                        _lblFilter.Visible = false;
                }

                //this loop goes through all column styles and iteratively sets 
                //their horizontal positions and widths
                List<DataGridViewColumn> sortedColumns = SortedColumns;
                for (int i = 0; i < sortedColumns.Count; i++)
                {
                    DataGridViewColumn column = sortedColumns[i];

                    IGridFilter gridFilter = _columnToGridFilterHash[column] as IGridFilter;
                    if (gridFilter != null && !gridFilter.UseCustomFilterPlacement)
                    {
                        if (!column.Visible)
                        {
                            if (gridFilter.FilterControl.Visible)
                                gridFilter.FilterControl.Visible = false;
                            continue;
                        }
                        int from = curPos - _grid.HorizontalScrollingOffset;
                        int width = column.Width + (i == 0 ? 1 : 0);

                        if (from < rowHeadersWidth)
                        {
                            width -= rowHeadersWidth - from;
                            from = rowHeadersWidth;
                        }

                        if (from + width > base.Width)
                            width = base.Width - from;

                        if (width < 4)
                        {
                            if (gridFilter.FilterControl.Visible)
                                gridFilter.FilterControl.Visible = false;
                        }
                        else
                        {
                            if (base.RightToLeft == RightToLeft.Yes)
                                from = base.Width - from - width;

                            if (gridFilter.FilterControl.Left != from || gridFilter.FilterControl.Width != width)
                                gridFilter.FilterControl.SetBounds(from, 0, width, 0, BoundsSpecified.X | BoundsSpecified.Width);

                            if (!gridFilter.FilterControl.Visible)
                                gridFilter.FilterControl.Visible = true;
                        }
                    }
                    curPos += column.Width + (i == 0 ? 1 : 0);
                }
            }
            finally
            {
                this.ResumeLayout();
            }

            RecreateRowFilter();
            this.Invalidate();
        }	

		private void RecreateRowFilter()
		{
			RecreateRowFilter(false);
		}

		private void RecreateRowFilter(bool ignoreAutoRefresh)
        {
            if (_refreshDisabled || _columnToGridFilterHash.Count == 0 || _initCounter > 0)
				return;

			if (_autoRefreshMode == RefreshMode.Off && !ignoreAutoRefresh)
				return;

			try 
			{
				string rowFilter;
				string operatorString = _operator == LogicalOperators.And ? " AND " : " OR ";
				
				switch (_operator) 
				{
					case LogicalOperators.And:
					case LogicalOperators.Or:
						rowFilter = "";

						foreach (DataGridViewColumn column in SortedColumns)
						{
							//ask every column for the set filter and concatenate them if needed
							IGridFilter gridFilter = _columnToGridFilterHash[column] as IGridFilter;
                            if (gridFilter == null)
                                return;
                            if (gridFilter.HasFilter && column.Visible) 
							{                                
								string filter = gridFilter.GetFilter(string.Format("[{0}]", column.DataPropertyName));
								rowFilter += ((rowFilter.Length > 0  && filter.Length > 0) ? operatorString : "") + filter;
							}
						}
						break;
					default:
						rowFilter = "";
						break;
                }

                string baseFilter = CurrentTableBaseFilter;
                bool hasBaseFilter = baseFilter != null && baseFilter.Length > 0;
                if (hasBaseFilter && _baseFilterEnabled)
                {
                    operatorString = _baseFilterOperator == LogicalOperators.And ? " AND " : " OR ";
                    if (rowFilter.Length > 0)
                        rowFilter = "(" + rowFilter + ")" + operatorString + "(" + CurrentTableBaseFilter + ")";
                    else
                        rowFilter += CurrentTableBaseFilter;
                }

                if (_lastRowFilter != rowFilter)
                {
                    _lastRowFilter = rowFilter;
                    SetRowFilter(rowFilter);
                }
			} 
			catch (Exception exc)
			{
				string text = GetMessageFromMode(_consoleErrorMode, exc);
				if (text.Length > 0)
					Console.WriteLine(text);
				text = GetMessageFromMode(_messageErrorMode, exc);
				if (text.Length > 0)
					MessageBox.Show(text, "Filter", MessageBoxButtons.OK, MessageBoxIcon.Warning);				
			}

            if (_keepFilters && HasView)
				_keepFiltersHash[GetTableName()] = GetFilters();
		}

        private List<DataGridViewColumn> SortedColumns
        {
            get
            {
                List<DataGridViewColumn> result = new List<DataGridViewColumn>();
                DataGridViewColumn column = _grid.Columns.GetFirstColumn(DataGridViewElementStates.None);
                if (column == null)
                    return result;
                result.Add(column);
                while ((column = _grid.Columns.GetNextColumn(column, DataGridViewElementStates.None, DataGridViewElementStates.None)) != null)
                    result.Add(column);

                return result;
            }
        }

		private string GetMessageFromMode(FilterErrorModes mode, Exception exc) 
		{
			string result = "";

			if ((mode & FilterErrorModes.General) == FilterErrorModes.General)
				result += "Invalid filter specified.";
			if ((mode & FilterErrorModes.ExceptionMessage) == FilterErrorModes.ExceptionMessage)
				result += (result.Length > 0 ? "\n" : "") + exc.Message;
			if ((mode & FilterErrorModes.StackTrace) == FilterErrorModes.StackTrace)
				result += (result.Length > 0 ? "\n" : "") + exc.StackTrace;

			return result;
		}

		#region Eventhandlers

		private void OnFilterFactoryChanged(object sender, EventArgs e)
		{
			RecreateGridFilters();
		}

        private void OnDataSourceChanged(object sender, System.EventArgs e)
        {
            _lastRowFilter = "";

            //this probably looks weird but the DataSourceChanged event of the grid
            //must complete before calling RecreateGridFilters, otherwise the DataGridView
            //has some real nasty behaviour (e.g. showing only 3 lines although
            //the view has 100 lines)
            if (_grid.Handle.ToInt32() > 0)
                _grid.BeginInvoke(new MethodInvoker(RecreateGridFilters));
        }

        private void OnGridScroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                RepositionGridFilters();
        }

		private void OnColumnStyleWidthChanged(object sender, EventArgs e)
		{
			RepositionGridFilters();
        }

        private void OnGridColumnsChanged(object sender, DataGridViewColumnEventArgs e)
        {
            RepositionGridFilters();
        }

        private void OnGridColumnsAddedRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            RecreateGridFilters();
        }

        private void OnGridColumnsStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Visible)
                RepositionGridFilters();
        }

		private void OnFilterChanged(object sender, EventArgs e)
        {
            if (_autoRefreshMode == RefreshMode.OnInput)
			    RecreateRowFilter();
        }

        private void OnFilterControlLeave(object sender, EventArgs e)
        {
            if (_autoRefreshMode == RefreshMode.OnLeave ||
                _autoRefreshMode == RefreshMode.OnEnterOrLeave)
            {
                RefreshFilters();
            }
        }

        private void OnFilterControlKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' && (_autoRefreshMode == RefreshMode.OnEnter ||
                _autoRefreshMode == RefreshMode.OnEnterOrLeave))
            {
                RefreshFilters();
            }
        }

		#endregion

        #endregion

        #region Protected interface

        /// <summary>
        /// Raises the <see cref="BeforeFiltersChanging"/> event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected virtual void OnBeforeFiltersChanging(EventArgs e)
        {
            if (BeforeFiltersChanging != null)
                BeforeFiltersChanging(this, e);
        }

        /// <summary>
        /// Raises the <see cref="AfterFiltersChanged"/> event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected virtual void OnAfterFiltersChanged(EventArgs e)
        {
            if (AfterFiltersChanged != null)
                AfterFiltersChanged(this, e);
        }

        /// <summary>
        /// Raises the <see cref="GridFilterBound"/> event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected virtual void OnGridFilterBound(GridFilterEventArgs e)
        {
            if (GridFilterBound != null)
                GridFilterBound(this, e);
        }

        /// <summary>
        /// Raises the <see cref="GridFilterUnbound"/> event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected virtual void OnGridFilterUnbound(GridFilterEventArgs e)
        {
            if (GridFilterUnbound != null)
                GridFilterUnbound(this, e);
        }

        #endregion

        #region ISupportInitialize Member

        public void BeginInit()
        {
            _initCounter++;
        }

        public void EndInit()
        {
            _initCounter--;
        }

        #endregion
    }
}
