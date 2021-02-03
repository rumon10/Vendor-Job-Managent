using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GridViewExtensions.GridFilterFactories
{
	/// <summary>
	/// A panel which positions <see cref="Control"/>s with their 
	/// corresponding <see cref="Label"/>s in a layouted way.
	/// </summary>
	public class LayoutedPanel : Panel
	{
		#region Fields

		private Label[] _labels;
		private Control[] _controls;
		private int _horizontalSpacing = 0;
		private int _verticalSpacing = 4;
		private int _controlsMinimumWidth = 40;
		private bool _rightAlignLabels = false;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new instance
		/// </summary>
		public LayoutedPanel() 
		{
			this.AutoScroll = true;
		}

		#endregion

		#region Public interface

		/// <summary>
		/// Gets and sets the minimum width for the controls. If the panel isn't
		/// big enough scrollbars will be created.
		/// </summary>
		[Browsable(true), DefaultValue(40)]
		[Description("Gets and sets the minimum width for the controls. If the panel isn't "
			+ "big enough scrollbars will be created.")]
		public int ControlsMinimumWidth
		{
			get { return _controlsMinimumWidth; }
			set 
			{
				if (value < 1)
					throw new ArgumentException("Value must not be smaller 0", "ControlsMinimumWidth");
				if (value != _controlsMinimumWidth)
				{
					_controlsMinimumWidth = value;
					RefreshLayout();
				}
			}
		}

		/// <summary>
		/// Gets and sets the horizontal space between the labels and controls.
		/// </summary>
		[Browsable(true), DefaultValue(0)]
		[Description("Gets and sets the horizontal space between the labels and controls.")]
		public int HorizontalSpacing
		{
			get { return _horizontalSpacing; }
			set 
			{
				if (value != _horizontalSpacing)
				{
					_horizontalSpacing = value;
					RefreshLayout();
				}
			}
		}

		/// <summary>
		/// Gets and sets the vertical space between the rows.
		/// </summary>
		[Browsable(true), DefaultValue(4)]
		[Description("Gets and sets the vertical space between the rows.")]
		public int VerticalSpacing
		{
			get { return _verticalSpacing; }
			set 
			{
				if (value != _verticalSpacing)
				{
					_verticalSpacing = value;
					RefreshLayout();
				}
			}
		}

		/// <summary>
		/// Gets and sets whether the labels are aligned to the right or to the left.
		/// </summary>
		[Browsable(true), DefaultValue(false)]
		[Description("Gets and sets whether the labels are aligned to the right or to the left.")]
		public bool RightAlignLabels
		{
			get { return _rightAlignLabels; }
			set 
			{
				if (value != _rightAlignLabels)
				{
					_rightAlignLabels = value;
					RefreshLayout();
				}
			}
		}

		/// <summary>
		/// Clear the contents of this instance.
		/// </summary>
		public void Clear()
		{
			_labels = null;
			_controls = null;
			this.Controls.Clear();
		}

		/// <summary>
		/// Fills the instance with the given controls in the two arrays.
		/// Both arrays must have the same size. Otherwise an <see cref="ArgumentException"/>
		/// will be thrown.
		/// </summary>
		/// <param name="labels">Array with <see cref="Label"/> objects</param>
		/// <param name="controls">Array with <see cref="Control"/> objects</param>
		public void Fill(Label[] labels, Control[] controls)
		{
			if (labels.Length != controls.Length)
				throw new ArgumentException("Number of specified labels must match the number of specified controls.", "labels");

			Clear();

			_labels = new Label[labels.Length];
			labels.CopyTo(_labels, 0);
			_controls = new Control[controls.Length];
			controls.CopyTo(_controls, 0);

			for (int i = 0; i < _labels.Length; i++)
				this.Controls.Add(_labels[i]);
			for (int i = 0; i < _controls.Length; i++)
				this.Controls.Add(_controls[i]);

			RefreshLayout();
		}

		#endregion

		#region Privates

		private void RefreshLayout()
		{
			if (_labels == null || _controls == null)
				return;

			int maximumLabelWidth = 0;
			for (int i = 0; i < _labels.Length; i++)
			{
				_labels[i].AutoSize = true;
				maximumLabelWidth = Math.Max(maximumLabelWidth, _labels[i].Width);
			}

			int currentVerticalPosition = 0;
			for (int i = 0; i < _labels.Length; i++)
			{
				int currentHeight = Math.Max(_controls[i].Height, _labels[i].Height);

				_controls[i].Location = new Point(maximumLabelWidth + _horizontalSpacing, currentVerticalPosition + (currentHeight - _controls[i].Height) / 2);
				_controls[i].Width = Math.Max(_controlsMinimumWidth, this.ClientSize.Width - _controls[i].Left);
				_controls[i].Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

				if (_rightAlignLabels)
					_labels[i].Location = new Point(maximumLabelWidth - _labels[i].Width, currentVerticalPosition + (currentHeight - _labels[i].Height) / 2);
				else
					_labels[i].Location = new Point(0, currentVerticalPosition + (currentHeight - _labels[i].Height) / 2);

				currentVerticalPosition += currentHeight + _verticalSpacing;
			}
			base.AutoScrollMinSize = new Size(maximumLabelWidth + _horizontalSpacing + _controlsMinimumWidth, 20);
		}

		#endregion

		#region Overridden from Panel

		/// <summary>
		/// Repositions the contents after the control has been resized.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			RefreshLayout();
		}

		#endregion

	}
}
