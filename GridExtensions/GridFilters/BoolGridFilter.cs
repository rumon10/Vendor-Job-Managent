using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GridViewExtensions.GridFilters
{
	/// <summary>
	/// A <see cref="IGridFilter"/> implementation for filtering boolean columns
	/// with a <see cref="CheckBox"/> to control the filter.
	/// It allows three states: 
	/// In intermediate state no filter will be set.
	/// In checked state the filter will show only true values.
	/// In unchecked state the filter will only show false values.
	/// </summary>
	public class BoolGridFilter : GridFilterBase
	{
		#region Fields

		private const string FILTER_FORMAT = "{0} = {1}";
		private const string FILTER_REGEX = @"\[[a-zA-Z].*\] = (?<Value>(True|False))";

		private CheckBox _checkBox;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new instance
		/// </summary>
		public BoolGridFilter() : this(new CheckBox(), false)
		{
			_checkBox.CheckAlign = ContentAlignment.MiddleCenter;
		}

		/// <summary>
		/// Creates a new instance with <see cref="GridFilterBase.UseCustomFilterPlacement"/>
		/// set to true.
		/// </summary>
		/// <param name="checkBox">A <see cref="CheckBox"/> instance which
		/// should be used by the filter.</param>
		public BoolGridFilter(CheckBox checkBox) : this(checkBox, true) {}

		private BoolGridFilter(CheckBox checkBox, bool useCustomFilterPlacement) : base(useCustomFilterPlacement)
		{
			_checkBox = checkBox;
			_checkBox.ThreeState = true;
			_checkBox.CheckState = CheckState.Indeterminate;
			_checkBox.CheckStateChanged += new EventHandler(OnCheckBoxCheckStateChanged);
		}

        #endregion

        #region Public interface

        /// <summary>
        /// Gets or sets the current state of the contained <see cref="CheckBox"/>.
        /// </summary>
        public CheckState CheckState
        {
            get { return _checkBox.CheckState; }
            set { _checkBox.CheckState = value; }
        }

        #endregion

		#region Overridden from GridFilterBase

		/// <summary>
		/// The <see cref="CheckBox"/> for the GUI.
		/// </summary>
		public override Control FilterControl
		{
			get { return _checkBox; }
		}

		/// <summary>
		/// Gets whether a filter is set.
		/// True, if the <see cref="CheckBox"/> is not intermediate.
		/// </summary>
		public override bool HasFilter
		{
			get { return _checkBox.CheckState != CheckState.Indeterminate; }
		}

		/// <summary>
		/// Gets a simple boolean filter criteria in string representation
		/// </summary>
		/// <param name="columnName">
		/// The name of the column for which the criteria should be generated.
		/// </param>
		/// <returns>a string representing the current filter criteria</returns>
		public override string GetFilter(string columnName)
		{
			if (!HasFilter)
				return "";
			else
				return string.Format(FILTER_FORMAT, columnName, _checkBox.Checked);
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
				_checkBox.CheckState = CheckState.Unchecked;
				_checkBox.Checked = bool.Parse(match.Groups["Value"].Value);
			}
		}

		/// <summary>
		/// Clears the filter to its initial state.
		/// </summary>
		public override void Clear() 
		{
			_checkBox.CheckState = CheckState.Indeterminate;
		}

		#endregion

		#region Privates

		private void OnCheckBoxCheckStateChanged(object sender, EventArgs e)
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
			_checkBox.CheckStateChanged -= new EventHandler(OnCheckBoxCheckStateChanged);
			_checkBox.Dispose();
		}

		#endregion
	}
}
