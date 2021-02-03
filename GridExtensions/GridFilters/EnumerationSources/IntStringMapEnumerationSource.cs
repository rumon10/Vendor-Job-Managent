using System;
using System.Collections;

namespace GridViewExtensions.GridFilters.EnumerationSources
{
	/// <summary>
	/// <see cref="IEnumerationSource"/> implementation which supports userdefined
	/// matching between <see cref="Int32"/> values in the datasource and <see cref="String"/>
	/// values which should be displayed in the filter.
	/// </summary>
	public class IntStringMapEnumerationSource : IEnumerationSource
	{
		#region Fields

		private Hashtable _hash;
		private object[] _allValues;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new instance with no mapping.
		/// </summary>
		public IntStringMapEnumerationSource()
		{
			_hash = new Hashtable();
		}

		/// <summary>
		/// Creates a new instance mapping the given <see cref="Int32"/> values to
		/// the given <see cref="String"/> values.
		/// </summary>
		/// <param name="integerValues"></param>
		/// <param name="stringValues"></param>
		public IntStringMapEnumerationSource(int[] integerValues, string[] stringValues) : this()
		{
			if (integerValues.Length != stringValues.Length)
				throw new ArgumentException("Number of integers and strings must match.");

			for (int i = 0; i < integerValues.Length; i++)
				_hash.Add(stringValues[i], integerValues[i]);			
		}

		#endregion

		#region Public interface

		/// <summary>
		/// Adds a mapping
		/// </summary>
		/// <param name="integerValue"></param>
		/// <param name="stringValue"></param>
		public void AddMapping(int integerValue, string stringValue)
		{
			_hash.Add(stringValue, integerValue);	
			_allValues = null;
		}

		/// <summary>
		/// Removes a mapping
		/// </summary>
		/// <param name="stringValue"></param>
		public void RemoveMapping(string stringValue)
		{
			_hash.Remove(stringValue);
			_allValues = null;
		}

		#endregion

		#region IEnumerationSource Member

		/// <summary>
		/// Gets all values which should be displayed.
		/// </summary>
		public object[] AllValues
		{
			get
			{
				if (_allValues == null) 
				{
					ICollection keys = _hash.Keys;
					_allValues = new object[keys.Count];
					keys.CopyTo(_allValues, 0);
				}
				
				return _allValues;
			}
		}

		/// <summary>
		/// Build the filter criteria from the given input.
		/// </summary>
		/// <param name="value">The selected value for which the criteria is created.</param>
		/// <returns>A <see cref="string"/> representing the criteria.</returns>
		public string GetFilterFromValue(object value)
		{
			return _hash[value].ToString();
		}

		/// <summary>
		/// Gets the object value for a specified filter.
		/// </summary>
		/// <param name="filter">The filter value to be searched</param>
		/// <returns>object value for the specified filter</returns>
		public object GetValueFromFilter(string filter)
		{
			int integerValue = Convert.ToInt32(filter);

			foreach (string stringValue in AllValues)
				if ((int)_hash[stringValue] == integerValue)
					return stringValue;

			throw new ArgumentException("Unexpected filter.", "filter");
		}

		#endregion
	}
}
