using WixWPF;

namespace $safeprojectname$
{
	/// <summary>The main installer data context.</summary>
	public class InstallerInfo : BaseBAObject
	{
		#region Member Variables

		/// <summary>Indicates if the product</summary>
		private bool _isInstalled = false;

		/// <summary>Indicates if the installer is busy.</summary>
		private bool _isBusy = false;

		/// <summary>The progress message.</summary>
		private string _message = string.Empty;

		#endregion Member Variables

		#region Properties

		#region CanInstall
		/// <summary>Indicates if the product can be installed.</summary>
		public bool CanInstall { get { return !(IsInstalled); } }
		#endregion CanInstall

		#region CanUninstall
		/// <summary>Indicates if the product can be uninstalled.</summary>
		public bool CanUninstall { get { return (IsInstalled); } }
		#endregion CanUninstall

		#region IsInstalled
		/// <summary>Indicates if the product is installed.</summary>
		public bool IsInstalled { get { return _isInstalled; } set { _isInstalled = value; OnPropertiesChanged("IsInstalled", "CanInstall", "CanUninstall"); } }
		#endregion IsInstalled

		#region IsBusy
		/// <summary>Indicates if the installer is busy.</summary>
		public bool IsBusy { get { return _isBusy; } set { _isBusy = value; OnPropertiesChanged("IsBusy"); } }
		#endregion IsBusy

		#region Message
		/// <summary>The progress message.</summary>
		public string Message { get { return _message; } set { _message = value; OnPropertiesChanged("Message"); } }
		#endregion Message

		#endregion Properties
	}
}
