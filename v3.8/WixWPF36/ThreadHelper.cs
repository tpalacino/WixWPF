using System;

namespace WixWPF
{
    /// <summary>Provides functionality for invoking code on the main thread.</summary>
    internal static class ThreadHelper
    {
        #region Methods

        #region SafeInvoke
        /// <summary>Safely invokes the specified action.</summary>
        /// <param name="action">The action to invoke.</param>
        public static void SafeInvoke(Action action)
        {
            if (WPFBootstrapper.UIDispatcher != null)
            {
                if (WPFBootstrapper.UIDispatcher.CheckAccess()) { action.Invoke(); }
                else { WPFBootstrapper.UIDispatcher.BeginInvoke(action); }
            }
        }
        #endregion SafeInvoke

        #endregion Methods
    }
}