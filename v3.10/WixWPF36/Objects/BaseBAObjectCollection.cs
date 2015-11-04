using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Threading;

namespace WixWPF
{
    /// <summary>Provides collection changed notification when a property on an item in the collection changes.</summary>
    /// <typeparam name="T">Any derivation of <see cref="BaseBAObject"/>.</typeparam>
    public class BaseBAObjectCollection<T> : ObservableCollection<T> where T : BaseBAObject
    {
        #region Events

        #region CollectionChanged
        /// <summary>Represents the method that handles the event of the collection having changed.</summary>
        public override event NotifyCollectionChangedEventHandler CollectionChanged;
        #endregion CollectionChanged

        #endregion Events

        #region Constructors

        /// <summary>Creates a new instance of <see cref="BaseBAObjectCollection&lt;T&gt;"/>.</summary>
        public BaseBAObjectCollection() : base() { }

        /// <summary>Creates a new instance of <see cref="BaseBAObjectCollection&lt;T&gt;"/>.</summary>
        /// <param name="items">The items to populate the new collection with.</param>
        public BaseBAObjectCollection(IEnumerable<T> items) : base(items) { }

        /// <summary>Creates a new instance of <see cref="BaseBAObjectCollection&lt;T&gt;"/>.</summary>
        /// <param name="items">The items to populate the new collection with.</param>
        public BaseBAObjectCollection(List<T> items) : base(items) { }

        #endregion Constructors

        #region Event Handlers

        #region OnCollectionChanged
        /// <summary>Raised when there is a change in the collection.</summary>
        /// <param name="e">The arguments of the event.</param>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            // Be nice - use BlockReentrancy like MSDN said
            using (BlockReentrancy())
            {
                NotifyCollectionChangedEventHandler eventHandler = CollectionChanged;
                if (eventHandler == null)
                    return;

                Delegate[] delegates = eventHandler.GetInvocationList();
                // Walk thru invocation list
                foreach (NotifyCollectionChangedEventHandler handler in delegates)
                {
                    DispatcherObject dispatcherObject = handler.Target as DispatcherObject;
                    // If the subscriber is a DispatcherObject and different thread
                    if (dispatcherObject != null && dispatcherObject.CheckAccess() == false)
                    {
                        // Invoke handler in the target dispatcher's thread
                        dispatcherObject.Dispatcher.Invoke(DispatcherPriority.DataBind, handler, this, e);
                    }
                    else // Execute handler as is
                        handler(this, e);
                }
            }
        }
        #endregion OnCollectionChanged

        #region ItemPropertyChanged
        /// <summary>Raised when a property on an item in this collection changes.</summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var arg = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, sender, sender);
            OnCollectionChanged(arg);
        }
        #endregion ItemPropertyChanged

        #endregion Event Handlers

        #region Methods

        #region ClearItems
        /// <summary>Removes all items from the collection.</summary>
        protected override void ClearItems()
        {
            foreach (T item in Items) { if (item != null) { item.PropertyChanged -= ItemPropertyChanged; } }
            base.ClearItems();
        }
        #endregion ClearItems

        #region InsertItem
        /// <summary>Inserts an item into the collection at the specified index.</summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert.</param>
        protected override void InsertItem(int index, T item)
        {
            if (item != null) { item.PropertyChanged += ItemPropertyChanged; }
            base.InsertItem(index, item);
        }
        #endregion InsertItem

        #region RemoveItem
        /// <summary>Removes the item at the specified index of the collection.</summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        protected override void RemoveItem(int index)
        {
            if (Items[index] != null) { Items[index].PropertyChanged -= ItemPropertyChanged; }
            base.RemoveItem(index);
        }
        #endregion RemoveItem

        #region SetItem
        /// <summary>Replaces the element at the specified index.</summary>
        /// <param name="index">The zero-based index of the element to replace.</param>
        /// <param name="item">The new value for the element at the specified index.</param>
        protected override void SetItem(int index, T item)
        {
            if (item != null) { item.PropertyChanged += ItemPropertyChanged; }
            base.SetItem(index, item);
        }
        #endregion SetItem

        #endregion Methods
    }
}
