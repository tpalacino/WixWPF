﻿using WixWPF;

namespace WixWPFUI
{
	/// <summary>The main installer data context.</summary>
	public class InstallerInfo : BaseBAObject
	{
		#region Member Variables

		/// <summary>Indicates if the product is installed.</summary>
		private bool _isInstalled = false;

		/// <summary>Indicates if the installer is busy.</summary>
		private bool _isBusy = true;

		/// <summary>Indicates if Wix Toolset v3.6 is installed.</summary>
		private bool _hasWix36 = false;

		/// <summary>Indicates if Wix Toolset v3.7 is installed.</summary>
		private bool _hasWix37 = false;

		/// <summary>Indicates if Wix Toolset v3.8 is installed.</summary>
		private bool _hasWix38 = false;

		/// <summary>Indicates if Wix Toolset v3.9 is installed.</summary>
		private bool _hasWix39 = false;

		/// <summary>Indicates if Wix Toolset v3.10 is installed.</summary>
		private bool _hasWix310 = false;

    /// <summary>Indicates if Wix Toolset v3.11 is installed.</summary>
    private bool _hasWix311 = false;

    /// <summary>Indicates if the old WixWPF v3.6 is installed.</summary>
    private bool _hasOldWixWPF36 = false;

		/// <summary>Indicates if the old WixWPF v3.7 is installed.</summary>
		private bool _hasOldWixWPF37 = false;

		/// <summary>Indicates if WixWPF v3.6 is installed.</summary>
		private bool _hasWixWPF36 = false;

		/// <summary>Indicates if WixWPF v3.7 is installed.</summary>
		private bool _hasWixWPF37 = false;

		/// <summary>Indicates if WixWPF v3.8 is installed.</summary>
		private bool _hasWixWPF38 = false;

		/// <summary>Indicates if WixWPF v3.9 is installed.</summary>
		private bool _hasWixWPF39 = false;

		/// <summary>Indicates if WixWPF v3.10 is installed.</summary>
		private bool _hasWixWPF310 = false;

    /// <summary>Indicates if WixWPF v3.11 is installed.</summary>
    private bool _hasWixWPF311 = false;

    /// <summary>The installation directory of Visual Studio 2010.</summary>
    private string _pathVS2010 = string.Empty;

		/// <summary>The installation directory of Visual Studio 2012.</summary>
		private string _pathVS2012 = string.Empty;

		/// <summary>The installation directory of Visual Studio 2013.</summary>
		private string _pathVS2013 = string.Empty;

		/// <summary>The installation directory of Visual Studio 2015.</summary>
		private string _pathVS2015 = string.Empty;

    /// <summary>The installation directory of Visual Studio 2017.</summary>
    private string _pathVS2017 = string.Empty;

    /// <summary>Indicates if Team Foundation Server 2010 is installed.</summary>
    private bool _hasTFS2010 = false;

		/// <summary>Indicates if Team Foundation Server 2012 is installed.</summary>
		private bool _hasTFS2012 = false;

		/// <summary>Indicates if Team Foundation Server 2015 is installed.</summary>
		private bool _hasTFS2015 = false;

		/// <summary>The progress message.</summary>
		private string _message = string.Empty;

		#endregion Member Variables

		#region Properties

		#region CanInstall

		/// <summary>Indicates if the product can be installed.</summary>
		public bool CanInstall { get { return !HasOldWixWPF && (HasWix && (HasVS || HasTFS) && !_isInstalled); } }

		#endregion CanInstall

		#region CanRepair

		/// <summary>Indicates if the product can be repaired.</summary>
		public bool CanRepair { get { return (HasWix && (HasVS || HasTFS) && _isInstalled); } }

		#endregion CanRepair

		#region CanUninstall

		/// <summary>Indicates if the product can be uninstalled.</summary>
		public bool CanUninstall { get { return (_isInstalled); } }

		#endregion CanUninstall

		#region IsInstalled

		/// <summary>Indicates if the product is installed.</summary>
		public bool IsInstalled { get { return _isInstalled; } set { _isInstalled = value; OnPropertiesChanged("IsInstalled", "CanInstall", "CanRepair", "CanUninstall"); } }

		#endregion IsInstalled

		#region IsBusy

		/// <summary>Indicates if the installer is busy.</summary>
		public bool IsBusy { get { return _isBusy; } set { _isBusy = value; OnPropertiesChanged("IsBusy", "IsNotBusy"); } }

		#endregion IsBusy

		#region IsNotBusy

		/// <summary>Indicates if the installer is not busy.</summary>
		public bool IsNotBusy { get { return !_isBusy; } }

		#endregion IsNotBusy

		#region HasWix

		/// <summary>Indicates if Wix Toolset is installed.</summary>
		public bool HasWix { get { return HasWix36 || HasWix37 || HasWix38 || HasWix39 || HasWix310 || HasWix311; } }

		#endregion HasWix

		#region HasWix36

		/// <summary>Indicates if Wix Toolset v3.6 is installed.</summary>
		public bool HasWix36 { get { return _hasWix36; } set { _hasWix36 = value; OnPropertiesChanged("HasWix36", "HasWix", "CanInstall", "CanRepair", "HasPreReqs"); } }

		#endregion HasWix36

		#region HasWix37

		/// <summary>Indicates if Wix Toolset v3.7 is installed.</summary>
		public bool HasWix37 { get { return _hasWix37; } set { _hasWix37 = value; OnPropertiesChanged("HasWix37", "HasWix", "CanInstall", "CanRepair", "HasPreReqs"); } }

		#endregion HasWix37

		#region HasWix38

		/// <summary>Indicates if Wix Toolset v3.8 is installed.</summary>
		public bool HasWix38 { get { return _hasWix38; } set { _hasWix38 = value; OnPropertiesChanged("HasWix38", "HasWix", "CanInstall", "CanRepair", "HasPreReqs"); } }

		#endregion HasWix38

		#region HasWix39

		/// <summary>Indicates if Wix Toolset v3.9 is installed.</summary>
		public bool HasWix39 { get { return _hasWix39; } set { _hasWix39 = value; OnPropertiesChanged("HasWix39", "HasWix", "CanInstall", "CanRepair", "HasPreReqs"); } }

		#endregion HasWix39

		#region HasWix310

		/// <summary>Indicates if Wix Toolset v3.10 is installed.</summary>
		public bool HasWix310 { get { return _hasWix310; } set { _hasWix310 = value; OnPropertiesChanged("HasWix310", "HasWix", "CanInstall", "CanRepair", "HasPreReqs"); } }

    #endregion HasWix310

    #region HasWix311

    /// <summary>Indicates if Wix Toolset v3.11 is installed.</summary>
    public bool HasWix311 { get { return _hasWix311; } set { _hasWix311 = value; OnPropertiesChanged("HasWix311", "HasWix", "CanInstall", "CanRepair", "HasPreReqs"); } }

    #endregion HasWix311

    #region HasBuildTools

    /// <summary>Indicates if a is installed.</summary>
    public bool HasBuildTools { get { return HasVS || HasTFS; } }

		#endregion HasBuildTools

		#region HasVS

		/// <summary>Indicates if Visual Studio is installed.</summary>
		public bool HasVS { get { return HasVS2010 || HasVS2012 || HasVS2013 || HasVS2015 || HasVS2017; } }

		#endregion HasVS

		#region HasVS2010

		/// <summary>Indicates if Visual Studio 2010 is installed.</summary>
		public bool HasVS2010 { get { return !string.IsNullOrEmpty(PathVS2010); } }

		#endregion HasVS2010

		#region HasVS2012

		/// <summary>Indicates if Visual Studio 2012 is installed.</summary>
		public bool HasVS2012 { get { return !string.IsNullOrEmpty(PathVS2012); } }

		#endregion HasVS2012

		#region HasVS2013

		/// <summary>Indicates if Visual Studio 2013 is installed.</summary>
		public bool HasVS2013 { get { return !string.IsNullOrEmpty(PathVS2013); } }

		#endregion HasVS2013

		#region HasVS2015

		/// <summary>Indicates if Visual Studio 2015 is installed.</summary>
		public bool HasVS2015 { get { return !string.IsNullOrEmpty(PathVS2015); } }

    #endregion HasVS2015

    #region HasVS2017

    /// <summary>Indicates if Visual Studio 2017 is installed.</summary>
    public bool HasVS2017 { get { return !string.IsNullOrEmpty(PathVS2017); } }

    #endregion HasVS2017

    #region PathVS2010

    /// <summary>The installation directory of Visual Studio 2010.</summary>
    public string PathVS2010 { get { return _pathVS2010; } set { _pathVS2010 = value; OnPropertiesChanged("PathVS2010", "HasVS2010", "HasVS", "CanInstall", "CanRepair", "HasBuildTools", "HasPreReqs"); } }

		#endregion PathVS2010

		#region PathVS2012

		/// <summary>The installation directory of Visual Studio 2012.</summary>
		public string PathVS2012 { get { return _pathVS2012; } set { _pathVS2012 = value; OnPropertiesChanged("PathVS2012", "HasVS2012", "HasVS", "CanInstall", "CanRepair", "HasBuildTools", "HasPreReqs"); } }

		#endregion PathVS2012

		#region PathVS2013

		/// <summary>The installation directory of Visual Studio 2013.</summary>
		public string PathVS2013 { get { return _pathVS2013; } set { _pathVS2013 = value; OnPropertiesChanged("PathVS2013", "HasVS2013", "HasVS", "CanInstall", "CanRepair", "HasBuildTools", "HasPreReqs"); } }

		#endregion PathVS2013

		#region PathVS2015

		/// <summary>The installation directory of Visual Studio 2015.</summary>
		public string PathVS2015 { get { return _pathVS2015; } set { _pathVS2015 = value; OnPropertiesChanged("PathVS2015", "HasVS2015", "HasVS", "CanInstall", "CanRepair", "HasBuildTools", "HasPreReqs"); } }

    #endregion PathVS2015

    #region PathVS2017

    /// <summary>The installation directory of Visual Studio 2017.</summary>
    public string PathVS2017 { get { return _pathVS2017; } set { _pathVS2017 = value; OnPropertiesChanged("PathVS2017", "HasVS2017", "HasVS", "CanInstall", "CanRepair", "HasBuildTools", "HasPreReqs"); } }

    #endregion PathVS2017
    
    #region HasTFS

    /// <summary>Indicates if Team Foundation Server is installed.</summary>
    public bool HasTFS { get { return HasTFS2010 || HasTFS2012 || HasTFS2015; } }

		#endregion HasTFS

		#region HasTFS2010

		/// <summary>Indicates if Team Foundation Server 2010 is installed.</summary>
		public bool HasTFS2010 { get { return _hasTFS2010; } set { _hasTFS2010 = value; OnPropertiesChanged("HasTFS2010", "HasTFS", "CanInstall", "CanRepair", "HasBuildTools", "HasPreReqs"); } }

		#endregion HasTFS2010

		#region HasTFS2012

		/// <summary>Indicates if Team Foundation Server 2012 is installed.</summary>
		public bool HasTFS2012 { get { return _hasTFS2012; } set { _hasTFS2012 = value; OnPropertiesChanged("HasTFS2012", "HasTFS", "CanInstall", "CanRepair", "HasBuildTools", "HasPreReqs"); } }

		#endregion HasTFS2012

		#region HasTFS2015

		/// <summary>Indicates if Team Foundation Server 2015 is installed.</summary>
		public bool HasTFS2015 { get { return _hasTFS2015; } set { _hasTFS2015 = value; OnPropertiesChanged("HasTFS2015", "HasTFS", "CanInstall", "CanRepair", "HasBuildTools", "HasPreReqs"); } }

		#endregion HasTFS2015

		#region HasOldWixWPF

		/// <summary>Indicates if an old WixWPF version is installed.</summary>
		public bool HasOldWixWPF { get { return (HasOldWixWPF36 || HasOldWixWPF37) && !(HasWixWPF); } }

		#endregion HasOldWixWPF

		#region HasOldWixWPF36

		/// <summary>Indicates if the old WixWPF v3.6 is installed.</summary>
		public bool HasOldWixWPF36 { get { return _hasOldWixWPF36; } set { _hasOldWixWPF36 = value; OnPropertiesChanged("HasOldWixWPF36", "HasOldWixWPF", "CanInstall"); } }

		#endregion HasOldWixWPF36

		#region HasOldWixWPF37

		/// <summary>Indicates if the old WixWPF v3.7 is installed.</summary>
		public bool HasOldWixWPF37 { get { return _hasOldWixWPF37; } set { _hasOldWixWPF37 = value; OnPropertiesChanged("HasOldWixWPF37", "HasOldWixWPF", "CanInstall"); } }

		#endregion HasOldWixWPF37

		#region HasWixWPF

		/// <summary>Indicates if WixWPF installed.</summary>
		public bool HasWixWPF { get { return HasWixWPF36 || HasWixWPF37 || HasWixWPF38 || HasWixWPF39 || HasWixWPF310; } }

		#endregion HasWixWPF

		#region HasWixWPF36

		/// <summary>Indicates if WixWPF v3.6 is installed.</summary>
		public bool HasWixWPF36 { get { return _hasWixWPF36; } set { _hasWixWPF36 = value; OnPropertiesChanged("HasWixWPF36", "HasWixWPF", "CanInstall", "CanRepair", "HasPreReqs"); } }

		#endregion HasWixWPF36

		#region HasWixWPF37

		/// <summary>Indicates if WixWPF v3.7 is installed.</summary>
		public bool HasWixWPF37 { get { return _hasWixWPF37; } set { _hasWixWPF37 = value; OnPropertiesChanged("HasWixWPF37", "HasWixWPF", "CanInstall", "CanRepair", "HasPreReqs"); } }

		#endregion HasWixWPF37

		#region HasWixWPF38

		/// <summary>Indicates if WixWPF v3.8 is installed.</summary>
		public bool HasWixWPF38 { get { return _hasWixWPF38; } set { _hasWixWPF38 = value; OnPropertiesChanged("HasWixWPF38", "HasWixWPF", "CanInstall", "CanRepair", "HasPreReqs"); } }

		#endregion HasWixWPF38

		#region HasWixWPF39

		/// <summary>Indicates if WixWPF v3.9 is installed.</summary>
		public bool HasWixWPF39 { get { return _hasWixWPF39; } set { _hasWixWPF39 = value; OnPropertiesChanged("HasWixWPF39", "HasWixWPF", "CanInstall", "CanRepair", "HasPreReqs"); } }

		#endregion HasWixWPF39

		#region HasWixWPF310

		/// <summary>Indicates if WixWPF v3.10 is installed.</summary>
		public bool HasWixWPF310 { get { return _hasWixWPF39; } set { _hasWixWPF310 = value; OnPropertiesChanged("HasWixWPF39", "HasWixWPF", "CanInstall", "CanRepair", "HasPreReqs"); } }

    #endregion HasWixWPF310

    #region HasWixWPF311

    /// <summary>Indicates if WixWPF v3.11 is installed.</summary>
    public bool HasWixWPF311 { get { return _hasWixWPF311; } set { _hasWixWPF311 = value; OnPropertiesChanged("HasWixWPF311", "HasWixWPF", "CanInstall", "CanRepair", "HasPreReqs"); } }

    #endregion HasWixWPF311

    #region HasPreReqs

    /// <summary>Indicates if the prerequisites are present.</summary>
    public bool HasPreReqs { get { return HasWixWPF || (HasWix && HasVS); } }

		#endregion HasPreReqs

		#region Message

		/// <summary>The progress message.</summary>
		public string Message { get { return _message; } set { _message = value; OnPropertiesChanged("Message"); } }

		#endregion Message

		#endregion Properties
	}
}