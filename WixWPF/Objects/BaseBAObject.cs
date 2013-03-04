using System.ComponentModel;

namespace WixWPF
{
	/// <summary>Provides a thread safe <see cref="INotifyPropertyChanged"/> implementation to derived classes.</summary>
	public abstract class BaseBAObject : INotifyPropertyChanged
	{
		#region Events

		#region PropertyChanged
		/// <summary>The event that will be raised when a property on a derived class changes.</summary>
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion PropertyChanged

		#endregion Events

		#region Methods

		#region OnPropertyChanged
		/// <summary>Called by property setters in derived classes to notify listeners that the value has changed.</summary>
		/// <param name="propertyName">The name of the property that changed.</param>
		protected void OnPropertyChanged(string propertyName)
		{
			if (!string.IsNullOrEmpty(propertyName) && PropertyChanged != null)
			{
				ThreadHelper.SafeInvoke(() =>
				{
					if (!string.IsNullOrEmpty(propertyName) && PropertyChanged != null)
					{
						PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
					}
				});
			}
		}
		#endregion OnPropertyChanged

		#endregion Methods
	}
}
