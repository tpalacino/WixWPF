using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wix = Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

namespace WixWPF
{
    /// <summary>The WPF managed bootstrap application.</summary>
    public partial class WPFBootstrapper : Wix.BootstrapperApplication
    {
        #region Event Handlers

        #region OnDetectUpdateBegin
        /// <summary>Called when the engine has begun installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectUpdateBegin(Wix.DetectUpdateBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectUpdateBegin");
            WPFBootstrapperEventArgs<Wix.DetectUpdateBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectUpdateBeginEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnDetectUpdateBegin(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnDetectUpdateBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectUpdateBegin");
        }
        #endregion OnDetectUpdateBegin

        #region OnDetectUpdateComplete
        /// <summary>Called when the engine has begun installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectUpdateComplete(Wix.DetectUpdateCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectUpdateComplete");
            WPFBootstrapperEventArgs<Wix.DetectUpdateCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectUpdateCompleteEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnDetectUpdateComplete(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnDetectUpdateComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectUpdateComplete");
        }
        #endregion OnDetectUpdateComplete

        #region OnDetectForwardCompatibleBundle
        /// <summary>Called when the engine has begun installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectForwardCompatibleBundle(Wix.DetectForwardCompatibleBundleEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectForwardCompatibleBundle");
            WPFBootstrapperEventArgs<Wix.DetectForwardCompatibleBundleEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectForwardCompatibleBundleEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnDetectForwardCompatibleBundle(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnDetectForwardCompatibleBundle(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectForwardCompatibleBundle");
        }
        #endregion OnDetectForwardCompatibleBundle

        #endregion Event Handlers
    }
}
