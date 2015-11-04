using System;
using System.Windows;
using Wix = Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

namespace WixWPF
{
    /// <summary>Provides bootstrap application interaction functionality to derived classes.</summary>
    public partial class BaseBAWindow : Window
    {
        #region Properties

        #region Bootstrapper
        /// <summary>Gets or sets Bootstrapper</summary>
        public virtual WPFBootstrapper Bootstrapper { get; internal set; }
        #endregion Bootstrapper

        #endregion Properties

        #region Methods

        #region IsValid
        /// <summary>Determines if the specified <paramref name="arguments"/> is valid.</summary>
        /// <typeparam name="T">The type of arguments.</typeparam>
        /// <param name="arguments">The arguments.</param>
        /// <returns>True if the arguments are valid, otherwise false.</returns>
        protected bool IsValid<T>(WPFBootstrapperEventArgs<T> arguments) where T : EventArgs
        {
            return (arguments != null && arguments.Arguments != null);
        }
        #endregion IsValid

        #region OnApplyBegin
        /// <summary>Called when the engine has begun installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnApplyBegin(WPFBootstrapperEventArgs<Wix.ApplyBeginEventArgs> args) { }
        #endregion OnApplyBegin

        #region OnApplyComplete
        /// <summary>Called when the engine has completed installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnApplyComplete(WPFBootstrapperEventArgs<Wix.ApplyCompleteEventArgs> args) { }
        #endregion OnApplyComplete

        #region OnCacheAcquireBegin
        /// <summary>Called when the engine begins to cache the container or payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnCacheAcquireBegin(WPFBootstrapperEventArgs<Wix.CacheAcquireBeginEventArgs> args) { }
        #endregion OnCacheAcquireBegin

        #region OnCacheAcquireComplete
        /// <summary>Called when the engine completes caching of the container or payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnCacheAcquireComplete(WPFBootstrapperEventArgs<Wix.CacheAcquireCompleteEventArgs> args) { }
        #endregion OnCacheAcquireComplete

        #region OnCacheAcquireProgress
        /// <summary>Called when the engine has progressed on caching the container or payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnCacheAcquireProgress(WPFBootstrapperEventArgs<Wix.CacheAcquireProgressEventArgs> args) { }
        #endregion OnCacheAcquireProgress

        #region OnCacheBegin
        /// <summary>Called when the engine begins to cache the installation sources.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnCacheBegin(WPFBootstrapperEventArgs<Wix.CacheBeginEventArgs> args) { }
        #endregion OnCacheBegin

        #region OnCacheComplete
        /// <summary>Called after the engine has cached the installation sources.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnCacheComplete(WPFBootstrapperEventArgs<Wix.CacheCompleteEventArgs> args) { }
        #endregion OnCacheComplete

        #region OnCachePackageBegin
        /// <summary>Called by the engine when it begins to cache a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnCachePackageBegin(WPFBootstrapperEventArgs<Wix.CachePackageBeginEventArgs> args) { }
        #endregion OnCachePackageBegin

        #region OnCachePackageComplete
        /// <summary>Called when the engine completes caching a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnCachePackageComplete(WPFBootstrapperEventArgs<Wix.CachePackageCompleteEventArgs> args) { }
        #endregion OnCachePackageComplete

        #region OnCacheVerifyBegin
        /// <summary>Called when the engine has started verify the payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnCacheVerifyBegin(WPFBootstrapperEventArgs<Wix.CacheVerifyBeginEventArgs> args) { }
        #endregion OnCacheVerifyBegin

        #region OnCacheVerifyComplete
        /// <summary>Called when the engine completes verification of the payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnCacheVerifyComplete(WPFBootstrapperEventArgs<Wix.CacheVerifyCompleteEventArgs> args) { }
        #endregion OnCacheVerifyComplete

        #region OnDetectBegin
        /// <summary>Called when the overall detection phase has begun.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnDetectBegin(WPFBootstrapperEventArgs<Wix.DetectBeginEventArgs> args) { }
        #endregion OnDetectBegin

        #region OnDetectComplete
        /// <summary>Called when the detection phase has completed.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnDetectComplete(WPFBootstrapperEventArgs<Wix.DetectCompleteEventArgs> args) { }
        #endregion OnDetectComplete

        #region OnDetectMsiFeature
        /// <summary>Called when an MSI feature has been detected for a package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnDetectMsiFeature(WPFBootstrapperEventArgs<Wix.DetectMsiFeatureEventArgs> args) { }
        #endregion OnDetectMsiFeature

        #region OnDetectPackageBegin
        /// <summary>Called when the detection for a specific package has begun.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnDetectPackageBegin(WPFBootstrapperEventArgs<Wix.DetectPackageBeginEventArgs> args) { }
        #endregion OnDetectPackageBegin

        #region OnDetectPackageComplete
        /// <summary>Called when the detection for a specific package has completed.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnDetectPackageComplete(WPFBootstrapperEventArgs<Wix.DetectPackageCompleteEventArgs> args) { }
        #endregion OnDetectPackageComplete

        #region OnDetectPriorBundle
        /// <summary>Called when the detection for a prior bundle has begun.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnDetectPriorBundle(WPFBootstrapperEventArgs<Wix.DetectPriorBundleEventArgs> args) { }
        #endregion OnDetectPriorBundle

        #region OnDetectRelatedBundle
        /// <summary>Called when a related bundle has been detected for a bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnDetectRelatedBundle(WPFBootstrapperEventArgs<Wix.DetectRelatedBundleEventArgs> args) { }
        #endregion OnDetectRelatedBundle

        #region OnDetectRelatedMsiPackage
        /// <summary>Called when a related MSI package has been detected for a package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnDetectRelatedMsiPackage(WPFBootstrapperEventArgs<Wix.DetectRelatedMsiPackageEventArgs> args) { }
        #endregion OnDetectRelatedMsiPackage

        #region OnDetectTargetMsiPackage
        /// <summary>Called when an MSP package detects a target MSI has been detected.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnDetectTargetMsiPackage(WPFBootstrapperEventArgs<Wix.DetectTargetMsiPackageEventArgs> args) { }
        #endregion OnDetectTargetMsiPackage

        #region OnElevate
        /// <summary>Called when the engine is about to start the elevated process.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnElevate(WPFBootstrapperEventArgs<Wix.ElevateEventArgs> args) { }
        #endregion OnElevate

        #region OnError
        /// <summary>Called when the engine has encountered an error.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnError(WPFBootstrapperEventArgs<Wix.ErrorEventArgs> args) { }
        #endregion OnError

        #region OnExecuteBegin
        /// <summary>Called when the engine has begun installing packages.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnExecuteBegin(WPFBootstrapperEventArgs<Wix.ExecuteBeginEventArgs> args) { }
        #endregion OnExecuteBegin

        #region OnExecuteComplete
        /// <summary>Called when the engine has completed installing packages.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnExecuteComplete(WPFBootstrapperEventArgs<Wix.ExecuteCompleteEventArgs> args) { }
        #endregion OnExecuteComplete

        #region OnExecuteFilesInUse
        /// <summary>Called when Windows Installer sends a file in use installation message.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnExecuteFilesInUse(WPFBootstrapperEventArgs<Wix.ExecuteFilesInUseEventArgs> args) { }
        #endregion OnExecuteFilesInUse

        #region OnExecuteMsiMessage
        /// <summary>Called when Windows Installer sends an installation message.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnExecuteMsiMessage(WPFBootstrapperEventArgs<Wix.ExecuteMsiMessageEventArgs> args) { }
        #endregion OnExecuteMsiMessage

        #region OnExecutePackageBegin
        /// <summary>Called when the engine has begun installing a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnExecutePackageBegin(WPFBootstrapperEventArgs<Wix.ExecutePackageBeginEventArgs> args) { }
        #endregion OnExecutePackageBegin

        #region OnExecutePackageComplete
        /// <summary>Called when the engine has completed installing a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnExecutePackageComplete(WPFBootstrapperEventArgs<Wix.ExecutePackageCompleteEventArgs> args) { }
        #endregion OnExecutePackageComplete

        #region OnExecutePatchTarget
        /// <summary>Called when the engine executes one or more patches targeting a product.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnExecutePatchTarget(WPFBootstrapperEventArgs<Wix.ExecutePatchTargetEventArgs> args) { }
        #endregion OnExecutePatchTarget

        #region OnExecuteProgress
        /// <summary>Called by the engine while executing on payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnExecuteProgress(WPFBootstrapperEventArgs<Wix.ExecuteProgressEventArgs> args) { }
        #endregion OnExecuteProgress

        #region OnPlanBegin
        /// <summary>Called when the engine has begun planning the installation.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnPlanBegin(WPFBootstrapperEventArgs<Wix.PlanBeginEventArgs> args) { }
        #endregion OnPlanBegin

        #region OnPlanComplete
        /// <summary>Called when the engine has completed planning the installation.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnPlanComplete(WPFBootstrapperEventArgs<Wix.PlanCompleteEventArgs> args) { }
        #endregion OnPlanComplete

        #region OnPlanMsiFeature
        /// <summary>Called when the engine is about to plan an MSI feature of a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnPlanMsiFeature(WPFBootstrapperEventArgs<Wix.PlanMsiFeatureEventArgs> args) { }
        #endregion OnPlanMsiFeature

        #region OnPlanPackageBegin
        /// <summary>Called when the engine has begun planning the installation of a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnPlanPackageBegin(WPFBootstrapperEventArgs<Wix.PlanPackageBeginEventArgs> args) { }
        #endregion OnPlanPackageBegin

        #region OnPlanPackageComplete
        /// <summary>Called when then engine has completed planning the installation of a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnPlanPackageComplete(WPFBootstrapperEventArgs<Wix.PlanPackageCompleteEventArgs> args) { }
        #endregion OnPlanPackageComplete

        #region OnPlanRelatedBundle
        /// <summary>Called when the engine has begun planning for a prior bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnPlanRelatedBundle(WPFBootstrapperEventArgs<Wix.PlanRelatedBundleEventArgs> args) { }
        #endregion OnPlanRelatedBundle

        #region OnPlanTargetMsiPackage
        /// <summary>Called when the engine is about to plan the target MSI of a MSP package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnPlanTargetMsiPackage(WPFBootstrapperEventArgs<Wix.PlanTargetMsiPackageEventArgs> args) { }
        #endregion OnPlanTargetMsiPackage

        #region OnProgress
        /// <summary>Called when the engine has changed progress for the bundle installation.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnProgress(WPFBootstrapperEventArgs<Wix.ProgressEventArgs> args) { }
        #endregion OnProgress

        #region OnRegisterBegin
        /// <summary>Called when the engine has begun registering the location and visibility of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnRegisterBegin(WPFBootstrapperEventArgs<Wix.RegisterBeginEventArgs> args) { }
        #endregion OnRegisterBegin

        #region OnRegisterComplete
        /// <summary>Called when the engine has completed registering the location and visilibity of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnRegisterComplete(WPFBootstrapperEventArgs<Wix.RegisterCompleteEventArgs> args) { }
        #endregion OnRegisterComplete

        #region OnResolveSource
        /// <summary>Called by the engine to allow the user experience to change the source using <see cref="M:Engine.SetLocalSource"/> or <see cref="M:Engine.SetDownloadSource"/>.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnResolveSource(WPFBootstrapperEventArgs<Wix.ResolveSourceEventArgs> args) { }
        #endregion OnResolveSource

        #region OnRestartRequired
        /// <summary>Called by the engine to request a restart now or inform the user a manual restart is required later.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnRestartRequired(WPFBootstrapperEventArgs<Wix.RestartRequiredEventArgs> args) { }
        #endregion OnRestartRequired

        #region OnShutdown
        /// <summary>Called by the engine to uninitialize the user experience.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnShutdown(WPFBootstrapperEventArgs<Wix.ShutdownEventArgs> args) { }
        #endregion OnShutdown

        #region OnStartup
        /// <summary>Called by the engine on startup of the bootstrapper application.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnStartup(WPFBootstrapperEventArgs<Wix.StartupEventArgs> args) { }
        #endregion OnStartup

        #region OnSystemShutdown
        /// <summary>Called when the system is shutting down or the user is logging off.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnSystemShutdown(WPFBootstrapperEventArgs<Wix.SystemShutdownEventArgs> args) { }
        #endregion OnSystemShutdown

        #region OnUnregisterBegin
        /// <summary>Called when the engine has begun removing the registration for the location and visibility of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnUnregisterBegin(WPFBootstrapperEventArgs<Wix.UnregisterBeginEventArgs> args) { }
        #endregion OnUnregisterBegin

        #region OnUnregisterComplete
        /// <summary>Called when the engine has completed removing the registration for the location and visibility of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnUnregisterComplete(WPFBootstrapperEventArgs<Wix.UnregisterCompleteEventArgs> args) { }
        #endregion OnUnregisterComplete

        #endregion Methods
    }
}