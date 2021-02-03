using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GridViewExtensions.GridFilters
{
	/// <summary>
	/// A <see cref="IGridFilter"/> implementation for filtering date columns
	/// with a <see cref="DateGridFilterControl"/> to control the filter.
	/// </summary>
	public class DateGridFilter : GridFilterBase
	{
		#region Fields

		internal const string IN_BETWEEN = "<x<";

		private const string FILTER_FORMAT = @"{0} {1} #{2:MM\/dd\/yyyy}#";
		private const string FILTER_REGEX = @"\[[a-zA-Z].*\] (?<Operator>(<|>|<=|>=|=|<>|)) #(?<Month>[0-9]{2})/(?<Day>[0-9]{2})/(?<Year>[0-9]{4})#";

		private const string FILTER_FORMAT_BETWEEN = @"{0} >= #{1:MM\/dd\/yyyy}# AND {0} <= #{2:MM\/dd\/yyyy}#";
		private const string FILTER_REGEX_BETWEEN = @"\[[a-zA-Z].*\] (?<Operator1>(>=)) #(?<Month1>[0-9]{2})/(?<Day1>[0-9]{2})/(?<Year1>[0-9]{4})# AND \[[a-zA-Z].*\] (?<Operator2>(<=)) #(?<Month2>[0-9]{2})/(?<Day2>[0-9]{2})/(?<Year2>[0-9]{4})#";

		private DateGridFilterControl _dateGridFilterControl;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new instance with <see cref="GridFilterBase.UseCustomFilterPlacement"/>
		/// and <see cref="ShowInBetweenOperator"/> set to false.
		/// </summary>
		public DateGridFilter() : this(new DateGridFilterControl(), false, false) {}
		
		/// <summary>
		/// Creates a new instance with <see cref="GridFilterBase.UseCustomFilterPlacement"/>
		/// set to false.
		/// </summary>
		/// <param name="showInBetweenOperator">Determines whether the 'in between' operator is available.</param>
		public DateGridFilter(bool showInBetweenOperator) : this(new DateGridFilterControl(), false, showInBetweenOperator) {}

		/// <summary>
		/// Creates a new instance with <see cref="GridFilterBase.UseCustomFilterPlacement"/>
		/// set to true and not having the 'in between' operator.
		/// </summary>
		/// <param name="dateGridFilterControl">A <see cref="DateGridFilterControl"/> 
		/// instance which should be used by the filter.</param>
		public DateGridFilter(DateGridFilterControl dateGridFilterControl) : this(dateGridFilterControl, true, false) {}
		
		/// <summary>
		/// Creates a new instance with <see cref="GridFilterBase.UseCustomFilterPlacement"/>
		/// set to true.
		/// </summary>
		/// <param name="dateGridFilterControl">A <see cref="DateGridFilterControl"/> 
		/// instance which should be used by the filter.</param>
		/// <param name="showInBetweenOperator">Determines whether the 'in between' operator is available.</param>
		public DateGridFilter(DateGridFilterControl dateGridFilterControl, bool showInBetweenOperator) : this(dateGridFilterControl, true, showInBetweenOperator) {}

		private DateGridFilter(DateGridFilterControl dateGridFilterControl, bool useCustomFilterPlacement, bool showInBetweenOperator) : base(useCustomFilterPlacement)
		{
			_dateGridFilterControl = dateGridFilterControl;
			_dateGridFilterControl.Changed += new EventHandler(OnDateGridFilterControlChanged);
			ShowInBetweenOperator = showInBetweenOperator;
		}

		#endregion

		#region Public interface

		/// <summary>
		/// Sets or gets whether the 'in between' operator should be available.
		/// </summary>
		public bool ShowInBetweenOperator
		{
			get { return _dateGridFilterControl.ComboBox.Items.Contains(IN_BETWEEN); }
			set
			{
				if (value == ShowInBetweenOperator)
					return;

				if (value)
				{
					_dateGridFilterControl.ComboBox.Items.Add(IN_BETWEEN);
				} 
				else
				{
					_dateGridFilterControl.ComboBox.Items.Remove(IN_BETWEEN);
					if (this.Operator == IN_BETWEEN)
						_dateGridFilterControl.ComboBox.SelectedIndex = 0;
				}
			}
		}
		
		/// <summary>
		/// Gets or sets the current date of the first contained <see cref="DateTimePicker"/>.
		/// </summary>
		public DateTime Date1
		{
			get { return _dateGridFilterControl.DateTimePicker1.Value; }
			set { _dateGridFilterControl.DateTimePicker1.Value = value; }
		}
		
		/// <summary>
		/// Gets or sets the current date of the second contained <see cref="DateTimePicker"/>.
		/// </summary>
		public DateTime Date2
		{
			get { return _dateGridFilterControl.DateTimePicker2.Value; }
			set { _dateGridFilterControl.DateTimePicker2.Value = value; }
		}
		
		/// <summary>
		/// Gets or sets the current operator of the contained <see cref="ComboBox"/>.
		/// </summary>
		public string Operator
		{
			get { return (string)_dateGridFilterControl.ComboBox.SelectedItem; }
			set { _dateGridFilterControl.ComboBox.SelectedItem = value; }
		}

		#endregion

		#region Overridden from GridFilterBase

		/// <summary>
		/// Returns the instance itsself, which contains a <see cref="DateTimePicker"/>
		/// and a <see cref="ComboBox"/> to adjust the filter.
		/// </summary>
		public override Control FilterControl
		{
			get { return _dateGridFilterControl; }
		}

		/// <summary>
		/// Gets whether a filter is set.
		/// True, if the <see cref="ComboBox"/> is not empty.
		/// </summary>
		public override bool HasFilter
		{
            get { return _dateGridFilterControl.ComboBox.SelectedItem.ToString().Length > 0; }
		}

		/// <summary>
		/// Gets a filter with the current criteria in string representation.
		/// </summary>
		/// <param name="columnName">
		/// The name of the column for which the criteria should be generated.
		/// </param>
		/// <returns>A string representing the current filter criteria</returns>
		public override string GetFilter(string columnName)
		{
			try 
			{
				if (this.Operator == IN_BETWEEN)
					return string.Format(FILTER_FORMAT_BETWEEN, columnName, _dateGridFilterControl.DateTimePicker1.Value, _dateGridFilterControl.DateTimePicker2.Value);
				else
					return string.Format(FILTER_FORMAT, columnName, _dateGridFilterControl.ComboBox.SelectedItem.ToString(), _dateGridFilterControl.DateTimePicker1.Value);
			}
			catch 
			{
				return columnName + " = " + false.ToString();
			}
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
			Regex regex = new Regex(FILTER_REGEX_BETWEEN, RegexOptions.ExplicitCapture);
			if (ShowInBetweenOperator && regex.IsMatch(filter))
			{
				Match match = regex.Match(filter);
				_dateGridFilterControl.ComboBox.SelectedItem = IN_BETWEEN;
				_dateGridFilterControl.DateTimePicker1.Value = new DateTime(
					Convert.ToInt32(match.Groups["Year1"].Value), 
					Convert.ToInt32(match.Groups["Month1"].Value), 
					Convert.ToInt32(match.Groups["Day1"].Value));
				_dateGridFilterControl.DateTimePicker2.Value = new DateTime(
					Convert.ToInt32(match.Groups["Year2"].Value), 
					Convert.ToInt32(match.Groups["Month2"].Value), 
					Convert.ToInt32(match.Groups["Day2"].Value));
			}
			else
			{
				regex = new Regex(FILTER_REGEX, RegexOptions.ExplicitCapture);	
				if (regex.IsMatch(filter))
				{
					Match match = regex.Match(filter);
					_dateGridFilterControl.ComboBox.SelectedItem = match.Groups["Operator"].Value;
					_dateGridFilterControl.DateTimePicker1.Value = new DateTime(
						Convert.ToInt32(match.Groups["Year"].Value), 
						Convert.ToInt32(match.Groups["Month"].Value), 
						Convert.ToInt32(match.Groups["Day"].Value));
				}
			}
		}

		/// <summary>
		/// Clears the filter to its initial state.
		/// </summary>
		public override void Clear() 
		{
			_dateGridFilterControl.ComboBox.SelectedIndex = 0;
			_dateGridFilterControl.DateTimePicker1.Value = DateTime.Now;
			_dateGridFilterControl.DateTimePicker2.Value = DateTime.Now;
		}

		#endregion

		#region Privates

		private void OnDateGridFilterControlChanged(object sender, EventArgs e)
		{
			base.OnChanged();
		}

		#endregion
	}
}
