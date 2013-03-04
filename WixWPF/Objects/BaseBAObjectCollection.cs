using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Threading;

namespace WixWPF
{
	/// <summary>Provides collection changed notification when a property on an item in the collection changes.</summary>
	public class BaseBAObjectCollection<T> : ObservableCollection<T> where T : BaseBAObject
	{
		#region Events

		#region CollectionChanged
		/// <summary>No Summary Provided</summary>
		public override event NotifyCollectionChangedEventHandler CollectionChanged;
		#endregion CollectionChanged

		#endregion Events

		#region Constructors

		/// <summary>Creates a new instance of <see cref="BaseBAObjectCollection&lt;T&gt;"/>.</summary>
		public BaseBAObjectCollection() : base() { }

		/// <summary>Creates a new instance of <see cref="BaseBAObjectCollection&lt;T&gt;"/>.</summary>
		public BaseBAObjectCollection(IEnumerable<T> items) : base(items) { }

		/// <summary>Creates a new instance of <see cref="BaseBAObjectCollection&lt;T&gt;"/>.</summary>
		public BaseBAObjectCollection(List<T> items) : base(items) { }

		#endregion Constructors

		#region Event Handlers

		#region OnCollectionChanged
		/// <summary>No Summary Provided</summary>
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
		/// <summary>No Summary Provided</summary>
		private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			var arg = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, sender, sender);
			OnCollectionChanged(arg);
		}
		#endregion ItemPropertyChanged

		#endregion Event Handlers

		#region Methods

		#region ClearItems
		/// <summary>No Summary Provided</summary>
		protected override void ClearItems()
		{
			foreach (T item in Items) { if (item != null) { item.PropertyChanged -= ItemPropertyChanged; } }
			base.ClearItems();
		}
		#endregion ClearItems

		#region InsertItem
		/// <summary>No Summary Provided</summary>
		protected override void InsertItem(int index, T item)
		{
			if (item != null) { item.PropertyChanged += ItemPropertyChanged; }
			base.InsertItem(index, item);
		}
		#endregion InsertItem

		#region RemoveItem
		/// <summary>No Summary Provided</summary>
		protected override void RemoveItem(int index)
		{
			if (Items[index] != null) { Items[index].PropertyChanged -= ItemPropertyChanged; }
			base.RemoveItem(index);
		}
		#endregion RemoveItem

		#region SetItem
		/// <summary>No Summary Provided</summary>
		protected override void SetItem(int index, T item)
		{
			if (item != null) { item.PropertyChanged += ItemPropertyChanged; }
			base.SetItem(index, item);
		}
		#endregion SetItem

		#endregion Methods
	}
}
