using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;

namespace GridViewExtensions.GridFilters
{
	/// <summary>
	/// A control with a <see cref="ComboBox"/> and two <see cref="TextBox"/>es
	/// needed in the <see cref="NumericGridFilter"/>.
	/// </summary>
	public class NumericGridFilterControl : System.Windows.Forms.UserControl
	{
		#region Fields

		private System.Windows.Forms.TextBox _textBox1;
		private System.Windows.Forms.TextBox _textBox2;
		private System.Windows.Forms.ComboBox _comboBox;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Events

		/// <summary>
		/// Event firing when either the <see cref="ComboBox"/> or
		/// the <see cref="TextBox"/> has changed.
		/// </summary>
		public event System.EventHandler Changed;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new instance
		/// </summary>
		public NumericGridFilterControl()
		{
			InitializeComponent();

			_comboBox.SelectedIndex = 0;
		}

		#endregion

		#region Overridden from UserControl

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
			RefreshTextBoxWidth();
		}

		#endregion

		#region Designer generated code
		/// <summary> 
		/// Erforderliche Methode f�r die Designerunterst�tzung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor ge�ndert werden.
		/// </summary>
		private void InitializeComponent()
		{
            this._textBox1 = new System.Windows.Forms.TextBox();
            this._textBox2 = new System.Windows.Forms.TextBox();
            this._comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // _textBox1
            // 
            this._textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._textBox1.Location = new System.Drawing.Point(40, 0);
            this._textBox1.Name = "_textBox1";
            this._textBox1.Size = new System.Drawing.Size(0, 20);
            this._textBox1.TabIndex = 1;
            this._textBox1.TextChanged += new System.EventHandler(this.OnChanged);
            this._textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this._textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this._textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            // 
            // _textBox2
            // 
            this._textBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this._textBox2.Location = new System.Drawing.Point(40, 0);
            this._textBox2.Name = "_textBox2";
            this._textBox2.Size = new System.Drawing.Size(104, 20);
            this._textBox2.TabIndex = 2;
            this._textBox2.TextChanged += new System.EventHandler(this.OnChanged);
            this._textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this._textBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this._textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            // 
            // _comboBox
            // 
            this._comboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this._comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBox.Items.AddRange(new object[] {
            "*",
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
            // NumericGridFilterControl
            // 
            this.Controls.Add(this._textBox1);
            this.Controls.Add(this._textBox2);
            this.Controls.Add(this._comboBox);
            this.Name = "NumericGridFilterControl";
            this.Size = new System.Drawing.Size(144, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Public interface

		/// <summary>
		/// Gets the first contained <see cref="TextBox"/> instance.
		/// </summary>
		public TextBox TextBox1
		{
			get { return _textBox1; }
		}

		/// <summary>
		/// Gets the second contained <see cref="TextBox"/> instance.
		/// </summary>
		public TextBox TextBox2
		{
			get { return _textBox2; }
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

		private void RefreshTextBoxWidth()
		{
			_textBox2.Width = (this.Width - _comboBox.Width) / 2;
		}

		private void OnChanged(object sender, System.EventArgs e)
		{
			this._textBox2.Visible = _comboBox.Text == NumericGridFilter.IN_BETWEEN;

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
