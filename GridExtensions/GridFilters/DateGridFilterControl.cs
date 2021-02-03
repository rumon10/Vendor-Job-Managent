using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Globalization;
using System.ComponentModel;

namespace GridViewExtensions.GridFilters
{
	/// <summary>
	/// A control with a <see cref="ComboBox"/> and two <see cref="DateTimePicker"/>s
	/// needed in the <see cref="DateGridFilter"/>.
	/// </summary>
	public class DateGridFilterControl : System.Windows.Forms.UserControl
	{
		#region Fields

		private System.Windows.Forms.DateTimePicker _picker1;
		private System.Windows.Forms.DateTimePicker _picker2;
		private System.Windows.Forms.ComboBox _comboBox;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Events

		/// <summary>
		/// Event firing when either the <see cref="ComboBox"/> or
		/// the <see cref="DateTimePicker"/> has changed.
		/// </summary>
		public event System.EventHandler Changed;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new instance
		/// </summary>
		public DateGridFilterControl()
		{
			InitializeComponent();

			_picker1.Format = DateTimePickerFormat.Short;
			_picker2.Format = DateTimePickerFormat.Short;
			_comboBox.SelectedIndex = 0;
			RefreshPickerWidth();
		}

		#endregion

		#region Overriden from UserControl

		/// <summary> 
		/// Cleans up.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
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
		/// Resizes the contained <see cref="DateTimePicker"/>s so that they
		/// have the same width.
		/// </summary>
		/// <param name="e">Event arguments.</param>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			RefreshPickerWidth();
		}

		#endregion

		#region Designer generated code
		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
            this._picker1 = new System.Windows.Forms.DateTimePicker();
            this._picker2 = new System.Windows.Forms.DateTimePicker();
            this._comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // _picker1
            // 
            this._picker1.Checked = false;
            this._picker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._picker1.Location = new System.Drawing.Point(40, 0);
            this._picker1.Name = "_picker1";
            this._picker1.Size = new System.Drawing.Size(64, 20);
            this._picker1.TabIndex = 1;
            this._picker1.TextChanged += new System.EventHandler(this.OnChanged);
            this._picker1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this._picker1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this._picker1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // _picker2
            // 
            this._picker2.Checked = false;
            this._picker2.Dock = System.Windows.Forms.DockStyle.Right;
            this._picker2.Location = new System.Drawing.Point(104, 0);
            this._picker2.Name = "_picker2";
            this._picker2.Size = new System.Drawing.Size(40, 20);
            this._picker2.TabIndex = 2;
            this._picker2.TextChanged += new System.EventHandler(this.OnChanged);
            this._picker2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this._picker2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this._picker2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // _comboBox
            // 
            this._comboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this._comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBox.Items.AddRange(new object[] {
            "",
            "=",
            "<>",
            ">",
            "<",
            ">=",
            "<="});
            this._comboBox.Location = new System.Drawing.Point(0, 0);
            this._comboBox.Name = "_comboBox";
            this._comboBox.Size = new System.Drawing.Size(40, 21);
            this._comboBox.TabIndex = 0;
            this._comboBox.SelectedIndexChanged += new System.EventHandler(this.OnChanged);
            this._comboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this._comboBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this._comboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // DateGridFilterControl
            // 
            this.Controls.Add(this._picker1);
            this.Controls.Add(this._picker2);
            this.Controls.Add(this._comboBox);
            this.Name = "DateGridFilterControl";
            this.Size = new System.Drawing.Size(144, 21);
            this.ResumeLayout(false);

		}
		#endregion

		#region Public Interface

		/// <summary>
		/// Gets the first contained <see cref="DateTimePicker"/> instance.
		/// </summary>
		public DateTimePicker DateTimePicker1
		{
			get { return _picker1; }
		}

		/// <summary>
		/// Gets the second contained <see cref="DateTimePicker"/> instance.
		/// </summary>
		public DateTimePicker DateTimePicker2
		{
			get { return _picker2; }
		}

		/// <summary>
		/// Gets the contained <see cref="ComboBox"/> instance.
		/// </summary>
		public ComboBox ComboBox
		{
			get { return _comboBox; }
		}

		#endregion

		#region Privates

		private void RefreshPickerWidth()
		{
			_picker2.Width = (this.Width - _comboBox.Width) / 2;
		}

		private void OnChanged(object sender, System.EventArgs e)
		{
			this._picker2.Visible = _comboBox.Text == DateGridFilter.IN_BETWEEN;

			if (Changed != null)
				Changed(this, e);
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            base.OnKeyUp(e);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }

		#endregion
	}
}
