using System;
using System.Collections;
using System.ComponentModel;
using System.Text;

namespace GridViewExtensions
{
    /// <summary>
    /// Implementation of the <see cref="IComparer"/> interface which
    /// compares according to a given <see cref="ListSortDescriptionCollection"/>.
    /// </summary>
    public class GenericComparer : IComparer
    {
        #region Fields

        private ListSortDescriptionCollection _sortDescriptions;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="sortDescriptions">
        /// The <see cref="ListSortDescriptionCollection"/> which should be
        /// used as the bassi for comparison.
        /// </param>
        public GenericComparer(ListSortDescriptionCollection sortDescriptions)
        {
            _sortDescriptions = sortDescriptions;
        }

        #endregion

        #region IComparer Member

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less 
        /// than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            for (int i = 0; i < _sortDescriptions.Count; i++)
            {
                PropertyDescriptor propertyDescriptor = _sortDescriptions[i].PropertyDescriptor;

                object valueX = propertyDescriptor.GetValue(x);
                object valueY = propertyDescriptor.GetValue(y);

                bool xIsNull = valueX == DBNull.Value || valueX == null;
                bool yIsNull = valueY == DBNull.Value || valueY == null;

                int result;
                if (xIsNull)
                {
                    if (yIsNull)
                        result = 0;
                    else
                        result = -1;
                }
                else
                {
                    if (yIsNull)
                        result = 1;
                    else
                    {
                        IComparable comparableX = valueX as IComparable;
                        IComparable comparableY = valueY as IComparable;

                        result = comparableX.CompareTo(comparableY);
                    }
                }

                if (result != 0)
                    return _sortDescriptions[i].SortDirection == ListSortDirection.Ascending ? result : -result;
            }

            return 0;
        }

        #endregion
    }
}
