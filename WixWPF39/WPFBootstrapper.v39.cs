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

        #region OnApplyPhaseCount
        /// <summary>Called right after OnApplyBegin.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        protected override void OnApplyPhaseCount(Wix.ApplyPhaseCountArgs args)
        {
            LogVerbose("Enter Method: OnApplyPhaseCount");
            WPFBootstrapperEventArgs<Wix.ApplyPhaseCountArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ApplyPhaseCountArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnApplyPhaseCount(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnApplyPhaseCount(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnApplyPhaseCount");
        }
        #endregion OnApplyPhaseCount

        #region OnDetectCompatiblePackage
        /// <summary>Called when a package was not detected but a package using the same provider key was.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        protected override void OnDetectCompatiblePackage(Wix.DetectCompatiblePackageEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectCompatiblePackage");
            WPFBootstrapperEventArgs<Wix.DetectCompatiblePackageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectCompatiblePackageEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnDetectCompatiblePackage(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnDetectCompatiblePackage(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectCompatiblePackage");
        }
        #endregion OnDetectCompatiblePackage

        #region OnDetectUpdate
        /// <summary>Fired when the update detection has found a potential update candidate.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        protected override void OnDetectUpdate(Wix.DetectUpdateEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectUpdate");
            WPFBootstrapperEventArgs<Wix.DetectUpdateEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectUpdateEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnDetectUpdate(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnDetectUpdate(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectUpdate");
        }
        #endregion OnDetectUpdate

        #region OnLaunchApprovedExeBegin
        /// <summary>Called by the engine before trying to launch the preapproved executable.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        protected override void OnLaunchApprovedExeBegin(Wix.LaunchApprovedExeBeginArgs args)
        {
            LogVerbose("Enter Method: OnLaunchApprovedExeBegin");
            WPFBootstrapperEventArgs<Wix.LaunchApprovedExeBeginArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.LaunchApprovedExeBeginArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnLaunchApprovedExeBegin(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnLaunchApprovedExeBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnLaunchApprovedExeBegin");
        }
        #endregion OnLaunchApprovedExeBegin

        #region OnLaunchApprovedExeComplete
        /// <summary>Called by the engine after trying to launch the preapproved executable.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        protected override void OnLaunchApprovedExeComplete(Wix.LaunchApprovedExeCompleteArgs args)
        {
            LogVerbose("Enter Method: OnLaunchApprovedExeComplete");
            WPFBootstrapperEventArgs<Wix.LaunchApprovedExeCompleteArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.LaunchApprovedExeCompleteArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnLaunchApprovedExeComplete(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnLaunchApprovedExeComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnLaunchApprovedExeComplete");
        }
        #endregion OnLaunchApprovedExeComplete

        #region OnPlanCompatiblePackage
        /// <summary>Called when the engine plans a new, compatible package using the same provider key.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        protected override void OnPlanCompatiblePackage(Wix.PlanCompatiblePackageEventArgs args)
        {
            LogVerbose("Enter Method: OnPlanCompatiblePackage");
            WPFBootstrapperEventArgs<Wix.PlanCompatiblePackageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanCompatiblePackageEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnPlanCompatiblePackage(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnPlanCompatiblePackage(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnPlanCompatiblePackage");
        }
        #endregion OnPlanCompatiblePackage
        
        #endregion Event Handlers
    }
}