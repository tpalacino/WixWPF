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

        #region OnApplyPhaseCount
        /// <summary>Called right after OnApplyBegin.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        public virtual void OnApplyPhaseCount(WPFBootstrapperEventArgs<Wix.ApplyPhaseCountArgs> args) { }
        #endregion OnApplyPhaseCount

        #region OnDetectCompatiblePackage
        /// <summary>Called when a package was not detected but a package using the same provider key was.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        public virtual void OnDetectCompatiblePackage(WPFBootstrapperEventArgs<Wix.DetectCompatiblePackageEventArgs> args) { }
        #endregion OnDetectCompatiblePackage

        #region OnDetectUpdate
        /// <summary>Fired when the update detection has found a potential update candidate.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        public virtual void OnDetectUpdate(WPFBootstrapperEventArgs<Wix.DetectUpdateEventArgs> args) { }
        #endregion OnDetectUpdate

        #region OnLaunchApprovedExeBegin
        /// <summary>Called by the engine before trying to launch the preapproved executable.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        public virtual void OnLaunchApprovedExeBegin(WPFBootstrapperEventArgs<Wix.LaunchApprovedExeBeginArgs> args) { }
        #endregion OnLaunchApprovedExeBegin

        #region OnLaunchApprovedExeComplete
        /// <summary>Called by the engine after trying to launch the preapproved executable.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        public virtual void OnLaunchApprovedExeComplete(WPFBootstrapperEventArgs<Wix.LaunchApprovedExeCompleteArgs> args) { }
        #endregion OnLaunchApprovedExeComplete

        #region OnPlanCompatiblePackage
        /// <summary>Called when the engine plans a new, compatible package using the same provider key.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        public virtual void OnPlanCompatiblePackage(WPFBootstrapperEventArgs<Wix.PlanCompatiblePackageEventArgs> args) { }
        #endregion OnPlanCompatiblePackage

        #endregion Event Handlers
    }
}