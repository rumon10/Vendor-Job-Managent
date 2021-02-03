using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GridViewExtensions
{
    /// <summary>
    /// Wrapper for any <see cref="IList"/> which implements
    /// <see cref="IBindingListView"/> and <see cref="ITypedList"/>
    /// for usage in the <see cref="DataGridView"/>.
    /// The contained <see cref="IList"/> can explicitely be specified,
    /// otherwise a normal <see cref="ArrayList"/> is created internally.
    /// If changes to this list are made calling <see cref="RaiseListChanged()"/>
    /// will raise a notification for the change. Using the list
    /// manipulation methods in this class will do this automatically.
    /// The <see cref="IBindingListView"/> will operate on lists of
    /// a certain type which must be specified. If the list contains instances
    /// of other types than the one specified then it will not work correctly.
    /// Searching and indexing operations are not implemented.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BindingListView<T> : IBindingListView, ITypedList
    {
        #region Fields

        private IList _innerList;
        private ListSortDescriptionCollection _sortDescriptions;
        private int[] _sortIndices;
        private int[] _filterIndices;
        private DataTable _filterTable;
        private string _currentFilterExpression = string.Empty;
        private PropertyDescriptorCollection _properties;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance with an empty <see cref="InnerList"/>.
        /// </summary>
        public BindingListView() : this(new ArrayList()) {}

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="list">The <see cref="InnerList"/> to be used.</param>
        public BindingListView(IList list)
        {
            _innerList = list;
            RemoveSort();

            InitializeFiltering();
        }

        #endregion

        #region Public interface

        /// <summary>
        /// Gets the contained <see cref="IList"/> actually
        /// holding the data.
        /// </summary>
        public IList InnerList
        {
            get { return _innerList; }
        }

        /// <summary>
        /// Raises the <see cref="ListChanged"/> event with <see cref="ListChangedType.Reset"/>.
        /// </summary>
        public void RaiseListChanged()
        {
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
        }

        /// <summary>
        /// Raises the <see cref="ListChanged"/> event with the specified arguments.
        /// </summary>
        /// <param name="args">Event arguments.</param>
        public void RaiseListChanged(ListChangedEventArgs args)
        {
            OnListChanged(args);
        }

        #endregion

        #region Protected interface

        /// <summary>
        /// Raises the <see cref="ListChanged"/> event.
        /// </summary>
        /// <param name="args">Event arguments.</param>
        protected virtual void OnListChanged(ListChangedEventArgs args)
        {
            if (ListChanged != null)
                ListChanged(this, args);
        }

        #endregion

        #region Privates

        private void InitializeFiltering()
        {
            _properties = ListBindingHelper.GetListItemProperties(typeof(T));
            _filterTable = new DataTable("FilterTable");
            foreach (PropertyDescriptor property in _properties)
                _filterTable.Columns.Add(property.Name, property.PropertyType);
        }

        #endregion

        #region IBindingListView Member

        /// <summary>
        /// Sorts the data source based on the given <see cref="ListSortDescriptionCollection"/>.
        /// </summary>
        /// <param name="sorts">
        /// The <see cref="ListSortDescriptionCollection"/> containing 
        /// the sorts to apply to the data source.
        /// </param>
        public void ApplySort(ListSortDescriptionCollection sorts)
        {
            _sortDescriptions = sorts;
            _sortIndices = new int[_innerList.Count];
            object[] items = new object[_innerList.Count];
            for (int i = 0; i < _sortIndices.Length; i++)
            {
                _sortIndices[i] = i;
                items[i] = _innerList[i];
            }
            Array.Sort(items, _sortIndices, new GenericComparer(sorts));
            this.Filter = _currentFilterExpression;
        }

        /// <summary>
        /// Gets or sets the filter to be used to exclude items from the collection 
        /// of items returned by the data source.
        /// </summary>
        public string Filter
        {
            get { return _currentFilterExpression; }
            set
            {
                _filterIndices = null;
                _currentFilterExpression = string.Empty;

                if (value.Length > 0)
                {
                    DataFilter dataFilter = new DataFilter(value, _filterTable);
                    List<int> filteredIndices = new List<int>();

                    int count = this.Count;
                    int propertiesCount = _properties.Count;
                    DataRow row = _filterTable.NewRow();
                    for (int i = 0; i < Count; i++)
                    {
                        object item = this[i];
                        for (int j = 0; j < propertiesCount; j++)
                            row[j] = _properties[j].GetValue(item);
                        if (dataFilter.Invoke(row))
                            filteredIndices.Add(i);
                    }

                    _filterIndices = filteredIndices.ToArray();
                    _currentFilterExpression = value;
                }

                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
            }
        }

        /// <summary>
        /// Removes the current filter applied to the data source.
        /// </summary>
        public void RemoveFilter()
        {
            this.Filter = string.Empty;
        }

        /// <summary>
        /// Gets the collection of sort descriptions currently applied to the data source.
        /// </summary>
        public ListSortDescriptionCollection SortDescriptions
        {
            get { return _sortDescriptions; }
        }

        /// <summary>
        /// Gets a value indicating whether the data source supports advanced sorting.
        /// </summary>
        public bool SupportsAdvancedSorting
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether the data source supports filtering.
        /// </summary>
        public bool SupportsFiltering
        {
            get { return true; }
        }

        #endregion

        #region IBindingList Member

        /// <summary>
        /// Occurs when the list changes or an item in the list changes.
        /// </summary>
        public event ListChangedEventHandler ListChanged;

        /// <summary>
        /// Gets whether you can update items in the list.
        /// </summary>
        public bool AllowEdit
        {
            get { return true; }
        }

        /// <summary>
        /// Gets whether you can add items to the list using <see cref="AddNew()"/>.
        /// </summary>
        public bool AllowNew
        {
            get { return false; }
        }

        /// <summary>
        /// Gets whether you can remove items from the list, using 
        /// <see cref="Remove"/> or <see cref="RemoveAt"/>.
        /// </summary>
        public bool AllowRemove
        {
            get { return true; }
        }

        /// <summary>
        /// Sorts the list based on a PropertyDescriptor and a ListSortDirection.
        /// </summary>
        /// <param name="property">The <see cref="PropertyDescriptor"/> to sort by.</param>
        /// <param name="direction">One of the <see cref="ListSortDirection"/> values.</param>
        public void ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            ListSortDescription listSortDescription = new ListSortDescription(property, direction);
            ListSortDescription[] listSortDescriptions = new ListSortDescription[] { listSortDescription };
            ListSortDescriptionCollection sorts = new ListSortDescriptionCollection(listSortDescriptions);

            ApplySort(sorts);
        }

        /// <summary>
        /// Gets whether the items in the list are sorted.
        /// </summary>
        public bool IsSorted
        {
            get { return _sortDescriptions.Count > 0; }
        }

        /// <summary>
        /// Removes any sort applied using <see cref="ApplySort(PropertyDescriptor, ListSortDirection)"/>.
        /// </summary>
        public void RemoveSort()
        {
            _sortDescriptions = new ListSortDescriptionCollection();
            _sortIndices = null;
        }

        /// <summary>
        /// Gets the direction of the sort.
        /// </summary>
        public ListSortDirection SortDirection
        {
            get { return _sortDescriptions.Count == 1 ? _sortDescriptions[0].SortDirection : ListSortDirection.Ascending; ; }
        }

        /// <summary>
        /// Gets the <see cref="PropertyDescriptor"/> that is being used for sorting.
        /// </summary>
        public PropertyDescriptor SortProperty
        {
            get { return _sortDescriptions.Count == 1 ? _sortDescriptions[0].PropertyDescriptor : null; }
        }

        /// <summary>
        /// Gets whether a <see cref="ListChanged"/> event is raised when the 
        /// list changes or an item in the list changes.
        /// </summary>
        public bool SupportsChangeNotification
        {
            get { return true; }
        }

        /// <summary>
        /// Gets whether the list supports searching using the <see cref="Find"/> method.
        /// </summary>
        public bool SupportsSearching
        {
            get { return false; }
        }

        /// <summary>
        /// Gets whether the list supports sorting.
        /// </summary>
        public bool SupportsSorting
        {
            get { return true; }
        }

        #region Not Implemented

        /// <summary>
        /// Adds the <see cref="PropertyDescriptor"/> to the indexes used for searching.
        /// NOT IMPLEMENTED!
        /// </summary>
        /// <param name="property">
        /// The <see cref="PropertyDescriptor"/> to add to the indexes used for searching.
        /// </param>
        public void AddIndex(PropertyDescriptor property)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// Adds a new item to the list.
        /// NOT IMPLEMENTED!
        /// </summary>
        /// <returns>The item added to the list.</returns>
        public object AddNew()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// Returns the index of the row that has the given <see cref="PropertyDescriptor"/>.
        /// NOT IMPLEMENTED!
        /// </summary>
        /// <param name="property">The <see cref="PropertyDescriptor"/> to search on.</param>
        /// <param name="key">The value of the property parameter to search for.</param>
        /// <returns>The index of the row that has the given <see cref="PropertyDescriptor"/>.</returns>
        public int Find(PropertyDescriptor property, object key)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// Removes the <see cref="PropertyDescriptor"/> from the indexes used for searching.
        /// NOT IMPLEMENTED!
        /// </summary>
        /// <param name="property">
        /// The <see cref="PropertyDescriptor"/> to remove from the indexes used for searching.
        /// </param>
        public void RemoveIndex(PropertyDescriptor property)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #endregion

        #region IList Member

        /// <summary>
        /// Adds an item to the <see cref="IList"/>.  
        /// </summary>
        /// <param name="value">The instance to add to the <see cref="IList"/>.</param>
        /// <returns>The position into which the new element was inserted.</returns>
        public int Add(object value)
        {
            if (value != null && !typeof(T).IsAssignableFrom(value.GetType()))
                throw new ArgumentException("Given instance doesn't match needed type.");

            int result = _innerList.Add(value);
            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, result));
            return result;
        }

        /// <summary>
        /// Removes all items from the <see cref="IList"/>.  
        /// </summary>
        public void Clear()
        {
            _innerList.Clear();
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
        }

        /// <summary>
        /// Determines whether the <see cref="IList"/> contains a specific value.
        /// </summary>
        /// <param name="value">The instance to locate in the <see cref="IList"/>.</param>
        /// <returns>true if the instance is found in the <see cref="IList"/>; otherwise, false.</returns>
        public bool Contains(object value)
        {
            return _innerList.Contains(value);
        }

        /// <summary>
        /// Determines the index of a specific item in the <see cref="IList"/>. 
        /// </summary>
        /// <param name="value">The instance to locate in the <see cref="IList"/>.</param>
        /// <returns>The index of value if found in the list; otherwise, -1.</returns>
        public int IndexOf(object value)
        {
            return _innerList.IndexOf(value);
        }

        /// <summary>
        /// Inserts an item to the <see cref="IList"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which value should be inserted.</param>
        /// <param name="value">The instance to insert into the <see cref="IList"/>.</param>
        public void Insert(int index, object value)
        {
            if (value != null && !typeof(T).IsAssignableFrom(value.GetType()))
                throw new ArgumentException("Given instance doesn't match needed type.");

            _innerList.Insert(index, value);
            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="IList"/> has a fixed size. 
        /// </summary>
        public bool IsFixedSize
        {
            get { return _innerList.IsFixedSize; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="IList"/> is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get { return _innerList.IsReadOnly; }
        }
        
        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="IList"/>. 
        /// </summary>
        /// <param name="value">The instance to remove from the <see cref="IList"/>.</param>
        public void Remove(object value)
        {
            int index = IndexOf(value);
            _innerList.Remove(value);
            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
        }

        /// <summary>
        /// Removes the <see cref="IList"/> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        public void RemoveAt(int index)
        {
            _innerList.RemoveAt(index);
            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
        }

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        public object this[int index]
        {
            get
            {
                if (_filterIndices != null)
                    index = _filterIndices[index];

                if (_sortIndices != null && index < _sortIndices.Length)
                    index = _sortIndices[index];

                return _innerList[index];
            }
            set
            {
                _innerList[index] = value;
                OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, index));
            }
        }

        #endregion

        #region ICollection Member

        /// <summary>
        /// Copies the elements of the <see cref="ICollection"/> to an <see cref="Array"/>, 
        /// starting at a particular <see cref="Array"/> index.
        /// </summary>
        /// <param name="array">
        /// The one-dimensional <see cref="Array"/> that is the destination of the elements copied from 
        /// <see cref="ICollection"/>. The <see cref="Array"/> must have zero-based indexing.
        /// </param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        public void CopyTo(Array array, int index)
        {
            _innerList.CopyTo(array, index);
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="ICollection"/>. 
        /// </summary>
        public int Count
        {
            get { return _filterIndices == null ? _innerList.Count : _filterIndices.Length; }
        }

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="ICollection"/> is 
        /// synchronized (thread safe). 
        /// </summary>
        public bool IsSynchronized
        {
            get { return _innerList.IsSynchronized; }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="ICollection"/>. 
        /// </summary>
        public object SyncRoot
        {
            get { return _innerList.SyncRoot; }
        }

        #endregion

        #region IEnumerable Member

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerator"/> object that can be used to iterate 
        /// through the collection.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }

        #endregion

        #region ITypedList Member

        /// <summary>
        /// Returns the <see cref="PropertyDescriptorCollection"/> that represents the 
        /// properties on each item used to bind data.
        /// </summary>
        /// <param name="listAccessors">
        /// An array of <see cref="PropertyDescriptor"/> objects to find in the collection 
        /// as bindable. This can be a null reference.
        /// </param>
        /// <returns>The <see cref="PropertyDescriptorCollection"/> that represents the 
        /// properties on each item used to bind data.</returns>
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            return ListBindingHelper.GetListItemProperties(typeof(T));
        }

        /// <summary>
        /// Returns the name of the list.
        /// </summary>
        /// <param name="listAccessors">
        /// An array of <see cref="PropertyDescriptor"/> objects, for which the list 
        /// name is returned. This can be a null reference.
        /// </param>
        /// <returns>The name of the list.</returns>
        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return this.GetType().Name;
        }

        #endregion
    }
}
