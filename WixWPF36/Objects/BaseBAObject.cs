using System.ComponentModel;

namespace WixWPF
{
    /// <summary>
    /// Provides a wrapper for the obscure but documented case of a null value passed to the property notification argument.
    /// This permits all properties to be notified of changes.
    /// </summary>
    public class AllPropertiesChangedEventArgs : PropertyChangedEventArgs
    {
        public AllPropertiesChangedEventArgs()
           : base(null)
        { }
    }

    /// <summary>Provides a thread safe <see cref="INotifyPropertyChanged"/> implementation to derived classes.</summary>
    public abstract class BaseBAObject : INotifyPropertyChanged
    {
        #region Events

        #region PropertyChanged
        /// <summary>Represents the method that handles the event of a property having changed.</summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion PropertyChanged

        #endregion Events

        #region Methods

        #region OnAllPropertiesChanged
        /// <summary>Called by property setters in derived classes to notify listeners that all values should be refreshed.</summary>
        protected void OnAllPropertiesChanged()
        {
            if (PropertyChanged != null)
            {
                ThreadHelper.SafeInvoke(() =>
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new AllPropertiesChangedEventArgs());
                    }
                });
            }
        }
        #endregion OnAllPropertiesChanged

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

        #region OnPropertiesChanged
        /// <summary>Called to notify listeners that the value of the specified <paramref name="propertyNames"/> has changed.</summary>
        /// <param name="propertyNames">The names of the properties that changed.</param>
        protected void OnPropertiesChanged(params string[] propertyNames)
        {
            if (propertyNames != null && PropertyChanged != null)
            {
                foreach (string propertyName in propertyNames)
                {
                    OnPropertyChanged(propertyName);
                }
            }
        }
        #endregion OnPropertiesChanged

        #endregion Methods
    }
}
