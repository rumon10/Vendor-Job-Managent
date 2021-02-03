using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using GridViewExtensions.GridFilters.EnumerationSources;

namespace GridViewExtensions.GridFilters
{
	/// <summary>
	/// A <see cref="IGridFilter"/> implementation for filtering any columns
	/// with enmuration types. A <see cref="ComboBox"/> will show all
	/// possible enumeration values from which the user can select one.
	/// </summary>
	public class EnumerationGridFilter : GridFilterBase
	{
		#region Fields

		private const string FILTER_FORMAT = "{0} = {1}";
		private const string FILTER_REGEX = @"\[[a-zA-Z].*\] = (?<Value>(\+|-)?[0-9][0-9]*)";

		private ComboBox _combo;
		private IEnumerationSource _enumerationSource;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="enumerationSource">Source defining what values should
		/// be displayed and how they are filtered.</param>
		public EnumerationGridFilter(IEnumerationSource enumerationSource) : this(enumerationSource, new ComboBox(), false) {}
		
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="enumerationSource">Source defining what values should
		/// be displayed and how they are filtered.</param>
		/// <param name="comboBox">Control which should be used to display the enumeration values.</param>
		public EnumerationGridFilter(IEnumerationSource enumerationSource, ComboBox comboBox) : this(enumerationSource, comboBox, true) {}

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="dataType"><see cref="Type"/> of the enumeration which values
		/// should be displayed</param>
		public EnumerationGridFilter(Type dataType) : this (new TypeEnumerationSource(dataType)) {}

		private EnumerationGridFilter(IEnumerationSource enumerationSource, ComboBox comboBox, bool useCustomFilterPlacement) : base(useCustomFilterPlacement)
		{
			_enumerationSource = enumerationSource;

			_combo = comboBox;
			_combo.DropDownStyle = ComboBoxStyle.DropDownList;
			_combo.SelectedIndexChanged += new EventHandler(OnComboSelectedIndexChanged);

			_combo.Items.Clear();
			_combo.Items.Add("");
			_combo.SelectedIndex = 0;
			_combo.Items.AddRange(_enumerationSource.AllValues);

			_combo.Sorted = true;
		}

        #endregion

        #region Public interface

        /// <summary>
        /// Gets or sets the current value of the contained <see cref="ComboBox"/>.
        /// </summary>
        public object Value
        {
            get { return _combo.SelectedItem; }
            set
            {
                if (_combo.Items.Contains(value))
                    _combo.SelectedItem = value;
                else
                    _combo.SelectedIndex = 0;
            }
        }

        #endregion

		#region Overridden from GridFilterBase

		/// <summary>
		/// The <see cref="ComboBox"/> for the GUI.
		/// </summary>
		public override Control FilterControl
		{
			get { return _combo; }
		}

		/// <summary>
		/// Gets whether a filter is set.
		/// True, if the text of the <see cref="ComboBox"/> is not empty.
		/// </summary>
		public override bool HasFilter
		{
			get { return _combo.Text.Length > 0; }
		}

		/// <summary>
		/// Gets a filter with a criteria in string representation.
		/// </summary>
		/// <param name="columnName">
		/// The name of the column for which the criteria should be generated.
		/// </param>
		/// <returns>a string representing the current filter criteria</returns>
		public override string GetFilter(string columnName)
		{
			if (!HasFilter)
				return "";
			
			return string.Format(FILTER_FORMAT, columnName, _enumerationSource.GetFilterFromValue(_combo.SelectedItem));
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
				
				_combo.SelectedItem = _enumerationSource.GetValueFromFilter(match.Groups["Value"].Value);
			}
		}

		/// <summary>
		/// Clears the filter to its initial state.
		/// </summary>
		public override void Clear() 
		{
			_combo.SelectedIndex = 0;
		}

		#endregion

		#region Privates

		private void OnComboSelectedIndexChanged(object sender, EventArgs e)
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
			_combo.SelectedIndexChanged -= new EventHandler(OnComboSelectedIndexChanged);
			_combo.Dispose();
		}

		#endregion
	}
}
