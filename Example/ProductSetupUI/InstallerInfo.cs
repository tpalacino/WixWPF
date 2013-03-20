using WixWPF;

namespace ProductSetupUI
{
	/// <summary>The information for the installer.</summary>
	public class InstallerInfo : BaseBAObject
	{
		#region Member Variables

		/// <summary>The arguments to send to the program.</summary>
		private string _commandArgs = string.Empty;

		/// <summary>Indicates if the product is installed.</summary>
		private bool _isInstalled = false;

		/// <summary>Indicates if the installer is busy processing.</summary>
		private bool _isBusy = false;

		#endregion Member Variables

		#region Properties

		#region CommandArgs
		/// <summary>The arguments to send to the program.</summary>
		public string CommandArgs
		{
			get { return _commandArgs; }
			set
			{
				_commandArgs = value;
				OnPropertiesChanged("CommandArgs", "CanUninstall", "CanInstall");
			}
		}
		#endregion CommandArgs

		#region CanInstall
		/// <summary>Indicates if the product can be installed.</summary>
		public bool CanInstall { get { return !IsInstalled && !string.IsNullOrEmpty(CommandArgs); } }
		#endregion CanInstall

		#region IsBusy
		/// <summary>Indicates if the installer is busy processing.</summary>
		public bool IsBusy { get { return _isBusy; } set { _isBusy = value; OnPropertyChanged("IsBusy"); } }
		#endregion IsBusy

		#region IsInstalled
		/// <summary>Indicates if the product is installed.</summary>
		public bool IsInstalled
		{
			get { return _isInstalled; }
			set
			{
				_isInstalled = value;
				OnPropertiesChanged("IsInstalled", "CanInstall", "CanUninstall");
			}
		}
		#endregion IsInstalled

		#region CanUninstall
		/// <summary>Indicates if the product is not installed.</summary>
		public bool CanUninstall { get { return IsInstalled; } }
		#endregion CanUninstall

		#endregion Properties
	}
}
