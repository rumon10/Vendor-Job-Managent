using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace GridViewExtensions.GridFilterFactories
{
	/// <summary>
	/// Implementation of <see cref="IGridFilterFactory"/> extending another
	/// <see cref="IGridFilterFactory"/> instance by overriding the default
	/// placement of the filter controls and placing them in a layouted way
	/// outside of the grid. 
	/// </summary>
	public class LayoutedGridFilterFactoryControl : System.Windows.Forms.UserControl, IGridFilterFactory
	{
		#region Field

		private LayoutedPanel _layoutedPanel;
		private IGridFilterFactory _innerGridFilterFactory;
		private System.ComponentModel.Container components = null;
		private ArrayList _createdLabels;
		private ArrayList _createdControls;
		private bool _showEmptyGridFilters;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		public LayoutedGridFilterFactoryControl()
		{
			InitializeComponent();
			_layoutedPanel = new LayoutedPanel();
			_layoutedPanel.Dock = DockStyle.Fill;
			this.Controls.Add(_layoutedPanel);
			this.InnerGridFilterFactory = new DefaultGridFilterFactory();
		}

		#endregion

		#region Overridden from UserControl

		/// <summary> 
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			this.InnerGridFilterFactory = null;

			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#endregion

		#region Vom Komponenten-Designer generierter Code
		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// LayoutedFilterFactoryControl
			// 
			this.Name = "LayoutedFilterFactoryControl";
			this.Size = new System.Drawing.Size(456, 296);

		}
		#endregion

		#region Public Interface

		/// <summary>
		/// Gets and sets the <see cref="IGridFilterFactory"/> instance which should
		/// be used for creating <see cref="IGridFilter"/>s.
		/// </summary>
		[Browsable(false)]
		public IGridFilterFactory InnerGridFilterFactory
		{
			get { return _innerGridFilterFactory; }
			set 
			{
				if (_innerGridFilterFactory != null)
					_innerGridFilterFactory.Changed -= new EventHandler(OnGridFilterFactoryChanged);

				_innerGridFilterFactory = value;
				
				if (_innerGridFilterFactory != null)
					_innerGridFilterFactory.Changed += new EventHandler(OnGridFilterFactoryChanged);

				OnChanged();
			}
		}

		/// <summary>
		/// Gets and sets the minimum width for the controls. If the panel isn't
		/// big enough scrollbars will be created.
		/// </summary>
		[Browsable(true), DefaultValue(40)]
		[Description("Gets and sets the minimum width for the controls. If the panel isn't "
			 + "big enough scrollbars will be created.")]
		public int ControlsMinimumWidth
		{
			get { return _layoutedPanel.ControlsMinimumWidth; }
			set { _layoutedPanel.ControlsMinimumWidth = value; }
		}

		/// <summary>
		/// Gets and sets the horizontal space between the labels and controls.
		/// </summary>
		[Browsable(true), DefaultValue(0)]
		[Description("Gets and sets the horizontal space between the labels and controls.")]
		public int HorizontalSpacing
		{
			get { return _layoutedPanel.HorizontalSpacing; }
			set { _layoutedPanel.HorizontalSpacing = value; }
		}

		/// <summary>
		/// Gets and sets the vertical space between the rows.
		/// </summary>
		[Browsable(true), DefaultValue(4)]
		[Description("Gets and sets the vertical space between the rows.")]
		public int VerticalSpacing
		{
			get { return _layoutedPanel.VerticalSpacing; }
			set { _layoutedPanel.VerticalSpacing = value; }
		}

		/// <summary>
		/// Gets and sets whether the labels are aligned to the right or to the left.
		/// </summary>
		[Browsable(true), DefaultValue(false)]
		[Description("Gets and sets whether the labels are aligned to the right or to the left.")]
		public bool RightAlignLabels
		{
			get { return _layoutedPanel.RightAlignLabels; }
			set { _layoutedPanel.RightAlignLabels = value; }
		}

		/// <summary>
		/// Gets and sets whether EmptyGridFilter instances should be shown.
		/// </summary>
		[Browsable(true), DefaultValue(false)]
		[Description("Gets and sets whether EmptyGridFilter instances should be shown.")]
		public bool ShowEmptyGridFilters
		{
			get { return _showEmptyGridFilters; }
			set 
			{
				_showEmptyGridFilters = value; 
				OnChanged();
			}
		}

		/// <summary>
		/// Notification method to this instance that the filter
		/// customization logic has changed and that the filters 
		/// need to be recreated
		/// </summary>
		public void HasChanged()
		{
			OnChanged();
		}

		#endregion

		#region Privates

		private void OnChanged()
		{
			if (Changed != null)
				Changed(this, EventArgs.Empty);
		}

		private void OnGridFilterFactoryChanged(object sender, EventArgs e)
		{
			OnChanged();
		}

		private void OnGridFilterFactoryGridFilterCreated(GridFilterEventArgs args)
		{
			if (GridFilterCreated != null)
				GridFilterCreated(this, args);
		}

		#endregion

		#region IGridFilterFactory Member

		/// <summary>
		/// Event for notification that the behaviour of this
		/// instance has changed.
		/// </summary>
		public event System.EventHandler Changed;

		/// <summary>
		/// Event for notification when a <see cref="IGridFilter"/> has been
		/// created in order to use it in a specific column and to allow
		/// custom modifications to it.
		/// </summary>
		public event GridViewExtensions.GridFilterEventHandler GridFilterCreated;

		/// <summary>
		/// Notifies this instance that the <see cref="IGridFilter"/> creation process
		/// is being started.
		/// </summary>
		public void BeginGridFilterCreation() 
		{
			if (_innerGridFilterFactory == null)
				return;

			_innerGridFilterFactory.BeginGridFilterCreation();

			_createdLabels = new ArrayList();
			_createdControls = new ArrayList();
		}

		/// <summary>
		/// Notifies this instance that the <see cref="IGridFilter"/> creation process
		/// has finished. After this call all created <see cref="IGridFilter"/>s should
		/// be in a usable state.
		/// </summary>
		public void EndGridFilterCreation() 
		{
			if (_innerGridFilterFactory == null)
				return;

			_innerGridFilterFactory.EndGridFilterCreation();

			if (_createdLabels == null || _createdControls == null)
				return;

			Label[] labels = new Label[_createdLabels.Count];
			_createdLabels.CopyTo(labels);
			Control[] controls = new Control[_createdControls.Count];
			_createdControls.CopyTo(controls);

			_layoutedPanel.Fill(labels, controls);

			_createdLabels = null;
			_createdControls = null;
		}

		/// <summary>
		/// Creates a new instance of <see cref="IGridFilter"/> by calling the 
		/// <see cref="InnerGridFilterFactory"/> and then modifying the default
		/// placement.
		/// </summary>
		/// <param name="column">The <see cref="DataColumn"/> for which the filter control should be created.</param>
		/// <returns>A <see cref="IGridFilter"/>.</returns>
		public IGridFilter CreateGridFilter(DataGridViewColumn column)
		{
			if (_innerGridFilterFactory == null)
				return new GridFilters.EmptyGridFilter();

			IGridFilter result = _innerGridFilterFactory.CreateGridFilter(column);
			result.UseCustomFilterPlacement = true;

			GridFilterEventArgs eventArgs = new GridFilterEventArgs(column, result);
			OnGridFilterFactoryGridFilterCreated(eventArgs);
			result = eventArgs.GridFilter;
			if (!result.UseCustomFilterPlacement)
				return result;
			
			if (_createdLabels == null || _createdControls == null)
				return result;

			if (result is GridFilters.EmptyGridFilter && !_showEmptyGridFilters)
				return result;

			Label label = new Label();
			label.Text = column.HeaderText + ":";
			_createdLabels.Add(label);
			_createdControls.Add(result.FilterControl);

			return result;
		}

		#endregion
	}
}
