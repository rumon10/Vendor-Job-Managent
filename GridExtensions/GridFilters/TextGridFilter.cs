using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GridViewExtensions.GridFilters
{
	/// <summary>
	/// A <see cref="IGridFilter"/> implementation for filtering any columns
	/// with a <see cref="TextBox"/> to control the filter.
	/// All rows not beginning with the specified text are filtered out.
	/// </summary>
	public class TextGridFilter: GridFilterBase
	{
		#region Fields

		private const string FILTER_FORMAT = "Convert({0}, 'System.String') LIKE '{1}*'";
		private const string FILTER_REGEX = @"Convert\(\[[a-zA-Z].*\],\s'System.String'\)\sLIKE\s'(?<Value>.*)\*'";

		private TextBox _textBox;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new instance
		/// </summary>
		public TextGridFilter(TextBox textBox) : this(textBox, true) {}

		/// <summary>
		/// Creates a new instance
		/// </summary>
		public TextGridFilter() : this(new TextBox(), false) {}

		private TextGridFilter(TextBox textBox, bool useCustomFilterPlacement) : base(useCustomFilterPlacement)
		{
			_textBox = textBox;
			_textBox.TextChanged += new EventHandler(OnTextBoxTextChanged);
		}

        #endregion

        #region Public interface

        /// <summary>
        /// Gets or sets the current text of the contained <see cref="TextBox"/>.
        /// </summary>
        public string Text
        {
            get { return _textBox.Text; }
            set { _textBox.Text = value; }
        }

        #endregion

		#region Overridden from GridFilterBase

		/// <summary>
		/// The <see cref="TextBox"/> for the GUI.
		/// </summary>
		public override Control FilterControl
		{
			get { return _textBox; }
		}

		/// <summary>
		/// Gets whether a filter is set.
		/// True, if the text of the <see cref="CheckBox"/> is not empty.
		/// </summary>
		public override bool HasFilter
		{
			get { return _textBox.Text.Length > 0; }
		}

		/// <summary>
		/// Gets a filter with a like criteria in string representation
		/// </summary>
		/// <param name="columnName">
		/// The name of the column for which the criteria should be generated.
		/// </param>
		/// <returns>a string representing the current filter criteria</returns>
		public override string GetFilter(string columnName)
		{
			return string.Format(FILTER_FORMAT, columnName, _textBox.Text);
		}
		
		/// <summary>
		/// Sets a string which a a previous result of <see cref="GetFilter"/>
		/// in order to configure the <see cref="FilterControl"/> to match the
		/// given filter criteria.
		/// </summary>
		/// <param name="filter">filter criteria</param>
		/// <returns></returns>
		public override void SetFilter(string filter)
		{
			Regex regex = new Regex(FILTER_REGEX);
			if (regex.IsMatch(filter))
			{
				Match match = regex.Match(filter);
				_textBox.Text = match.Groups["Value"].Value;
			}
		}

		/// <summary>
		/// Clears the filter to its initial state.
		/// </summary>
		public override void Clear() 
		{
			_textBox.Text = "";
		}

		#endregion

		#region Privates

		private void OnTextBoxTextChanged(object sender, EventArgs e)
		{
			base.OnChanged();
		}

		#endregion

		#region IDisposable Member

		/// <summary>
		/// Cleans up
		/// </summary>
		public override void Dispose()
		{
			_textBox.TextChanged -= new EventHandler(OnTextBoxTextChanged);
			_textBox.Dispose();
		}

		#endregion
	}
}
