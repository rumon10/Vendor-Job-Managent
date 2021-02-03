using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace GridViewExtensions
{
    /// <summary>
    /// Public Wrapper for the internal DataExpression class in the .Net framework.
    /// The purpose of this class is to test if single <see cref="DataRow"/>s match
    /// a given filter expression.
    /// </summary>
    public class DataFilter
    {
        #region Fields

        private static Type _internalDataFilterType;
        private static ConstructorInfo _constructorInfo;
        private static MethodInfo _methodInvokeInfo;
        private object _internalDataFilter;

        #endregion

        #region Constructors

        static DataFilter()
        {
            _internalDataFilterType = typeof(DataTable).Assembly.GetType("System.Data.DataExpression");
            _constructorInfo = _internalDataFilterType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, CallingConventions.Any, new Type[] { typeof(DataTable), typeof(string) }, null);
            _methodInvokeInfo = _internalDataFilterType.GetMethod("Invoke", BindingFlags.Public | BindingFlags.Instance, null, new Type[] { typeof(DataRow), typeof(DataRowVersion) }, null);
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="expression">Filter expression string.</param>
        /// <param name="dataTable"><see cref="DataTable"/> of the rows to be tested.</param>
        public DataFilter(string expression, DataTable dataTable)
        {
            _internalDataFilter = _constructorInfo.Invoke(new object[] { dataTable, expression });
        }

        #endregion

        #region Public interface

        /// <summary>
        /// Tests whether a single <see cref="DataRow"/> matches the filter expression.
        /// </summary>
        /// <param name="row"><see cref="DataRow"/> to be tested.</param>
        /// <returns>True if the row matches the filter expression, otherwise false.</returns>
        public bool Invoke(DataRow row)
        {
            return Invoke(row, DataRowVersion.Default);
        }

        /// <summary>
        /// Tests whether a single <see cref="DataRow"/> matches the filter expression.
        /// </summary>
        /// <param name="row"><see cref="DataRow"/> to be tested.</param>
        /// <param name="version">The row version to use.</param>
        /// <returns>True if the row matches the filter expression, otherwise false.</returns>
        public bool Invoke(DataRow row, DataRowVersion version)
        {
            return (bool)_methodInvokeInfo.Invoke(_internalDataFilter, new object[] { row, version });
        }

        #endregion
    }
}
