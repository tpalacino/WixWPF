using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Wix = Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

namespace WixWPF
{
  /// <summary>Provides bootstrap application interaction functionality to derived classes.</summary>
  public partial class BaseBAWindow : Window
  {
    #region Event Handlers

    #region OnDetectUpdateBegin
    /// <summary>Called when the engine has begun installing the bundle.</summary>
    /// <param name="args">The arguments of the event.</param>
    public virtual void OnDetectUpdateBegin(WPFBootstrapperEventArgs<Wix.DetectUpdateBeginEventArgs> args) { }
    #endregion OnDetectUpdateBegin

    #region OnDetectUpdateComplete
    /// <summary>Called when the engine has begun installing the bundle.</summary>
    /// <param name="args">The arguments of the event.</param>
    public virtual void OnDetectUpdateComplete(WPFBootstrapperEventArgs<Wix.DetectUpdateCompleteEventArgs> args) { }
    #endregion OnDetectUpdateComplete

    #region OnDetectForwardCompatibleBundle
    /// <summary>Called when the engine has begun installing the bundle.</summary>
    /// <param name="args">The arguments of the event.</param>
    public virtual void OnDetectForwardCompatibleBundle(WPFBootstrapperEventArgs<Wix.DetectForwardCompatibleBundleEventArgs> args) { }
    #endregion OnDetectForwardCompatibleBundle

    #endregion Event Handlers
  }
}