using System;

namespace WixWPF
{
    /// <summary>Used to identify the startup window class.</summary>
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    public class StartupWindowAttribute : Attribute
    {
        #region Member Variables

        /// <summary>The <see cref="Type"/> of the startup window.</summary>
        private Type _startupWindowType = null;

        #endregion Member Variables

        #region Constructors

        /// <summary>Creates a new instance of <see cref="StartupWindowAttribute"/>></summary>
        /// <param name="startupWindowType">The <see cref="Type"/> of the startup window.</param>
        public StartupWindowAttribute(Type startupWindowType)
        {
            _startupWindowType = startupWindowType;
        }

        #endregion Constructors

        #region Properties

        #region StartupWindowType
        /// <summary>The <see cref="Type"/> of the startup window.</summary>
        public Type StartupWindowType { get { return _startupWindowType; } }
        #endregion StartupWindowType

        #endregion Properties
    }
}
