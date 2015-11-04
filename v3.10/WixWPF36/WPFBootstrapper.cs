using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using Threading = System.Windows.Threading;
using Wix = Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

namespace WixWPF
{
    /// <summary>The WPF managed bootstrap application.</summary>
    public partial class WPFBootstrapper : Wix.BootstrapperApplication
    {
        #region Member Variables

        /// <summary>The main user interface for the bootstrap application.</summary>
        private BaseBAWindow _mainWindow = null;

        /// <summary>The dispatcher from the UI implementation.</summary>
        internal static Threading.Dispatcher UIDispatcher = null;

        #endregion Member Variables

        #region Event Handlers

        #region OnApplyBegin
        /// <summary>Called when the engine has begun installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnApplyBegin(Wix.ApplyBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnApplyBegin");
            WPFBootstrapperEventArgs<Wix.ApplyBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ApplyBeginEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnApplyBegin(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnApplyBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnApplyBegin");
        }
        #endregion OnApplyBegin

        #region OnApplyComplete
        /// <summary>Called when the engine has completed installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnApplyComplete(Wix.ApplyCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnApplyComplete");
            WPFBootstrapperEventArgs<Wix.ApplyCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ApplyCompleteEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnApplyComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            {
                Threading.Dispatcher.ExitAllFrames();
                Engine.Quit(args.Status);
                base.OnApplyComplete(cancelArgs.Arguments);
            }
            LogVerbose("Leaving Method: OnApplyComplete");
        }
        #endregion OnApplyComplete

        #region OnCacheAcquireBegin
        /// <summary>Called when the engine begins to cache the container or payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCacheAcquireBegin(Wix.CacheAcquireBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnCacheAcquireBegin");
            WPFBootstrapperEventArgs<Wix.CacheAcquireBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CacheAcquireBeginEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnCacheAcquireBegin(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnCacheAcquireBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnCacheAcquireBegin");
        }
        #endregion OnCacheAcquireBegin

        #region OnCacheAcquireComplete
        /// <summary>Called when the engine completes caching of the container or payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCacheAcquireComplete(Wix.CacheAcquireCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnCacheAcquireComplete");
            WPFBootstrapperEventArgs<Wix.CacheAcquireCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CacheAcquireCompleteEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnCacheAcquireComplete(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnCacheAcquireComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnCacheAcquireComplete");
        }
        #endregion OnCacheAcquireComplete

        #region OnCacheAcquireProgress
        /// <summary>Called when the engine has progressed on caching the container or payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCacheAcquireProgress(Wix.CacheAcquireProgressEventArgs args)
        {
            LogVerbose("Enter Method: OnCacheAcquireProgress");
            WPFBootstrapperEventArgs<Wix.CacheAcquireProgressEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CacheAcquireProgressEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnCacheAcquireProgress(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnCacheAcquireProgress(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnCacheAcquireProgress");
        }
        #endregion OnCacheAcquireProgress

        #region OnCacheBegin
        /// <summary>Called when the engine begins to cache the installation sources.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCacheBegin(Wix.CacheBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnCacheBegin");
            WPFBootstrapperEventArgs<Wix.CacheBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CacheBeginEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnCacheBegin(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnCacheBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnCacheBegin");
        }
        #endregion OnCacheBegin

        #region OnCacheComplete
        /// <summary>Called after the engine has cached the installation sources.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCacheComplete(Wix.CacheCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnCacheComplete");
            WPFBootstrapperEventArgs<Wix.CacheCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CacheCompleteEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnCacheComplete(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnCacheComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnCacheComplete");
        }
        #endregion OnCacheComplete

        #region OnCachePackageBegin
        /// <summary>Called by the engine when it begins to cache a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCachePackageBegin(Wix.CachePackageBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnCachePackageBegin");
            WPFBootstrapperEventArgs<Wix.CachePackageBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CachePackageBeginEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnCachePackageBegin(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnCachePackageBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnCachePackageBegin");
        }
        #endregion OnCachePackageBegin

        #region OnCachePackageComplete
        /// <summary>Called when the engine completes caching a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCachePackageComplete(Wix.CachePackageCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnCachePackageComplete");
            WPFBootstrapperEventArgs<Wix.CachePackageCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CachePackageCompleteEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnCachePackageComplete(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnCachePackageComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnCachePackageComplete");
        }
        #endregion OnCachePackageComplete

        #region OnCacheVerifyBegin
        /// <summary>Called when the engine has started verify the payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCacheVerifyBegin(Wix.CacheVerifyBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnCacheVerifyBegin");
            WPFBootstrapperEventArgs<Wix.CacheVerifyBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CacheVerifyBeginEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnCacheVerifyBegin(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnCacheVerifyBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnCacheVerifyBegin");
        }
        #endregion OnCacheVerifyBegin

        #region OnCacheVerifyComplete
        /// <summary>Called when the engine completes verification of the payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCacheVerifyComplete(Wix.CacheVerifyCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnCacheVerifyComplete");
            WPFBootstrapperEventArgs<Wix.CacheVerifyCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CacheVerifyCompleteEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnCacheVerifyComplete(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnCacheVerifyComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnCacheVerifyComplete");
        }
        #endregion OnCacheVerifyComplete

        #region OnDetectBegin
        /// <summary>Called when the overall detection phase has begun.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectBegin(Wix.DetectBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectBegin");
            WPFBootstrapperEventArgs<Wix.DetectBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectBeginEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnDetectBegin(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnDetectBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectBegin");
        }
        #endregion OnDetectBegin

        #region OnDetectComplete
        /// <summary>Called when the detection phase has completed.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectComplete(Wix.DetectCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectComplete");
            WPFBootstrapperEventArgs<Wix.DetectCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectCompleteEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnDetectComplete(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnDetectComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectComplete");
        }
        #endregion OnDetectComplete

        #region OnDetectMsiFeature
        /// <summary>Called when an MSI feature has been detected for a package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectMsiFeature(Wix.DetectMsiFeatureEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectMsiFeature");
            WPFBootstrapperEventArgs<Wix.DetectMsiFeatureEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectMsiFeatureEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnDetectMsiFeature(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnDetectMsiFeature(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectMsiFeature");
        }
        #endregion OnDetectMsiFeature

        #region OnDetectPackageBegin
        /// <summary>Called when the detection for a specific package has begun.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectPackageBegin(Wix.DetectPackageBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectPackageBegin");
            WPFBootstrapperEventArgs<Wix.DetectPackageBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectPackageBeginEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnDetectPackageBegin(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnDetectPackageBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectPackageBegin");
        }
        #endregion OnDetectPackageBegin

        #region OnDetectPackageComplete
        /// <summary>Called when the detection for a specific package has completed.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectPackageComplete(Wix.DetectPackageCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectPackageComplete");
            WPFBootstrapperEventArgs<Wix.DetectPackageCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectPackageCompleteEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnDetectPackageComplete(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnDetectPackageComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectPackageComplete");
        }
        #endregion OnDetectPackageComplete

        #region OnDetectPriorBundle
        /// <summary>Called when the detection for a prior bundle has begun.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectPriorBundle(Wix.DetectPriorBundleEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectPriorBundle");
            WPFBootstrapperEventArgs<Wix.DetectPriorBundleEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectPriorBundleEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnDetectPriorBundle(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnDetectPriorBundle(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectPriorBundle");
        }
        #endregion OnDetectPriorBundle

        #region OnDetectRelatedBundle
        /// <summary>Called when a related bundle has been detected for a bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectRelatedBundle(Wix.DetectRelatedBundleEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectRelatedBundle");
            WPFBootstrapperEventArgs<Wix.DetectRelatedBundleEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectRelatedBundleEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnDetectRelatedBundle(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnDetectRelatedBundle(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectRelatedBundle");
        }
        #endregion OnDetectRelatedBundle

        #region OnDetectRelatedMsiPackage
        /// <summary>Called when a related MSI package has been detected for a package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectRelatedMsiPackage(Wix.DetectRelatedMsiPackageEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectRelatedMsiPackage");
            WPFBootstrapperEventArgs<Wix.DetectRelatedMsiPackageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectRelatedMsiPackageEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnDetectRelatedMsiPackage(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnDetectRelatedMsiPackage(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectRelatedMsiPackage");
        }
        #endregion OnDetectRelatedMsiPackage

        #region OnDetectTargetMsiPackage
        /// <summary>Called when an MSP package detects a target MSI has been detected.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectTargetMsiPackage(Wix.DetectTargetMsiPackageEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectTargetMsiPackage");
            WPFBootstrapperEventArgs<Wix.DetectTargetMsiPackageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectTargetMsiPackageEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnDetectTargetMsiPackage(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnDetectTargetMsiPackage(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectTargetMsiPackage");
        }
        #endregion OnDetectTargetMsiPackage

        #region OnElevate
        /// <summary>Called when the engine is about to start the elevated process.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnElevate(Wix.ElevateEventArgs args)
        {
            LogVerbose("Enter Method: OnElevate");
            WPFBootstrapperEventArgs<Wix.ElevateEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ElevateEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnElevate(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnElevate(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnElevate");
        }
        #endregion OnElevate

        #region OnError
        /// <summary>Called when the engine has encountered an error.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnError(Wix.ErrorEventArgs args)
        {
            LogVerbose("Enter Method: OnError");
            WPFBootstrapperEventArgs<Wix.ErrorEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ErrorEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnError(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnError(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnError");
        }
        #endregion OnError

        #region OnExecuteBegin
        /// <summary>Called when the engine has begun installing packages.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecuteBegin(Wix.ExecuteBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnExecuteBegin");
            WPFBootstrapperEventArgs<Wix.ExecuteBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecuteBeginEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnExecuteBegin(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnExecuteBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnExecuteBegin");
        }
        #endregion OnExecuteBegin

        #region OnExecuteComplete
        /// <summary>Called when the engine has completed installing packages.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecuteComplete(Wix.ExecuteCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnExecuteComplete");
            WPFBootstrapperEventArgs<Wix.ExecuteCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecuteCompleteEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnExecuteComplete(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnExecuteComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnExecuteComplete");
        }
        #endregion OnExecuteComplete

        #region OnExecuteFilesInUse
        /// <summary>Called when Windows Installer sends a file in use installation message.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecuteFilesInUse(Wix.ExecuteFilesInUseEventArgs args)
        {
            LogVerbose("Enter Method: OnExecuteFilesInUse");
            WPFBootstrapperEventArgs<Wix.ExecuteFilesInUseEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecuteFilesInUseEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnExecuteFilesInUse(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnExecuteFilesInUse(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnExecuteFilesInUse");
        }
        #endregion OnExecuteFilesInUse

        #region OnExecuteMsiMessage
        /// <summary>Called when Windows Installer sends an installation message.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecuteMsiMessage(Wix.ExecuteMsiMessageEventArgs args)
        {
            LogVerbose("Enter Method: OnExecuteMsiMessage");
            WPFBootstrapperEventArgs<Wix.ExecuteMsiMessageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecuteMsiMessageEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnExecuteMsiMessage(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnExecuteMsiMessage(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnExecuteMsiMessage");
        }
        #endregion OnExecuteMsiMessage

        #region OnExecutePackageBegin
        /// <summary>Called when the engine has begun installing a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecutePackageBegin(Wix.ExecutePackageBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnExecutePackageBegin");
            WPFBootstrapperEventArgs<Wix.ExecutePackageBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecutePackageBeginEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnExecutePackageBegin(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnExecutePackageBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnExecutePackageBegin");
        }
        #endregion OnExecutePackageBegin

        #region OnExecutePackageComplete
        /// <summary>Called when the engine has completed installing a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecutePackageComplete(Wix.ExecutePackageCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnExecutePackageComplete");
            WPFBootstrapperEventArgs<Wix.ExecutePackageCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecutePackageCompleteEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnExecutePackageComplete(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnExecutePackageComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnExecutePackageComplete");
        }
        #endregion OnExecutePackageComplete

        #region OnExecutePatchTarget
        /// <summary>Called when the engine executes one or more patches targeting a product.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecutePatchTarget(Wix.ExecutePatchTargetEventArgs args)
        {
            LogVerbose("Enter Method: OnExecutePatchTarget");
            WPFBootstrapperEventArgs<Wix.ExecutePatchTargetEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecutePatchTargetEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnExecutePatchTarget(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnExecutePatchTarget(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnExecutePatchTarget");
        }
        #endregion OnExecutePatchTarget

        #region OnExecuteProgress
        /// <summary>Called by the engine while executing on payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecuteProgress(Wix.ExecuteProgressEventArgs args)
        {
            LogVerbose("Enter Method: OnExecuteProgress");
            WPFBootstrapperEventArgs<Wix.ExecuteProgressEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecuteProgressEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnExecuteProgress(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnExecuteProgress(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnExecuteProgress");
        }
        #endregion OnExecuteProgress

        #region OnPlanBegin
        /// <summary>Called when the engine has begun planning the installation.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnPlanBegin(Wix.PlanBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnPlanBegin");
            WPFBootstrapperEventArgs<Wix.PlanBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanBeginEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnPlanBegin(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnPlanBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnPlanBegin");
        }
        #endregion OnPlanBegin

        #region OnPlanComplete
        /// <summary>Called when the engine has completed planning the installation.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnPlanComplete(Wix.PlanCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnPlanComplete");
            WPFBootstrapperEventArgs<Wix.PlanCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanCompleteEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnPlanComplete(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnPlanComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnPlanComplete");
        }
        #endregion OnPlanComplete

        #region OnPlanMsiFeature
        /// <summary>Called when the engine is about to plan an MSI feature of a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnPlanMsiFeature(Wix.PlanMsiFeatureEventArgs args)
        {
            LogVerbose("Enter Method: OnPlanMsiFeature");
            WPFBootstrapperEventArgs<Wix.PlanMsiFeatureEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanMsiFeatureEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnPlanMsiFeature(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnPlanMsiFeature(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnPlanMsiFeature");
        }
        #endregion OnPlanMsiFeature

        #region OnPlanPackageBegin
        /// <summary>Called when the engine has begun planning the installation of a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnPlanPackageBegin(Wix.PlanPackageBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnPlanPackageBegin");
            WPFBootstrapperEventArgs<Wix.PlanPackageBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanPackageBeginEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnPlanPackageBegin(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnPlanPackageBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnPlanPackageBegin");
        }
        #endregion OnPlanPackageBegin

        #region OnPlanPackageComplete
        /// <summary>Called when then engine has completed planning the installation of a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnPlanPackageComplete(Wix.PlanPackageCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnPlanPackageComplete");
            WPFBootstrapperEventArgs<Wix.PlanPackageCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanPackageCompleteEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnPlanPackageComplete(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnPlanPackageComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnPlanPackageComplete");
        }
        #endregion OnPlanPackageComplete

        #region OnPlanRelatedBundle
        /// <summary>Called when the engine has begun planning for a prior bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnPlanRelatedBundle(Wix.PlanRelatedBundleEventArgs args)
        {
            LogVerbose("Enter Method: OnPlanRelatedBundle");
            WPFBootstrapperEventArgs<Wix.PlanRelatedBundleEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanRelatedBundleEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnPlanRelatedBundle(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnPlanRelatedBundle(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnPlanRelatedBundle");
        }
        #endregion OnPlanRelatedBundle

        #region OnPlanTargetMsiPackage
        /// <summary>Called when the engine is about to plan the target MSI of a MSP package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnPlanTargetMsiPackage(Wix.PlanTargetMsiPackageEventArgs args)
        {
            LogVerbose("Enter Method: OnPlanTargetMsiPackage");
            WPFBootstrapperEventArgs<Wix.PlanTargetMsiPackageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanTargetMsiPackageEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnPlanTargetMsiPackage(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnPlanTargetMsiPackage(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnPlanTargetMsiPackage");
        }
        #endregion OnPlanTargetMsiPackage

        #region OnProgress
        /// <summary>Called when the engine has changed progress for the bundle installation.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnProgress(Wix.ProgressEventArgs args)
        {
            LogVerbose("Enter Method: OnProgress");
            WPFBootstrapperEventArgs<Wix.ProgressEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ProgressEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnProgress(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnProgress(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnProgress");
        }
        #endregion OnProgress

        #region OnRegisterBegin
        /// <summary>Called when the engine has begun registering the location and visibility of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnRegisterBegin(Wix.RegisterBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnRegisterBegin");
            WPFBootstrapperEventArgs<Wix.RegisterBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.RegisterBeginEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnRegisterBegin(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnRegisterBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnRegisterBegin");
        }
        #endregion OnRegisterBegin

        #region OnRegisterComplete
        /// <summary>Called when the engine has completed registering the location and visilibity of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnRegisterComplete(Wix.RegisterCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnRegisterComplete");
            WPFBootstrapperEventArgs<Wix.RegisterCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.RegisterCompleteEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnRegisterComplete(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnRegisterComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnRegisterComplete");
        }
        #endregion OnRegisterComplete

        #region OnResolveSource
        /// <summary>Called by the engine to allow the user experience to change the source using <see cref="M:Engine.SetLocalSource"/> or <see cref="M:Engine.SetDownloadSource"/>.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnResolveSource(Wix.ResolveSourceEventArgs args)
        {
            LogVerbose("Enter Method: OnResolveSource");
            WPFBootstrapperEventArgs<Wix.ResolveSourceEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ResolveSourceEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnResolveSource(cancelArgs); }));
            if (!cancelArgs.Cancel)
            {
                args.Result = !string.IsNullOrEmpty(args.DownloadSource) ? Wix.Result.Download : Wix.Result.Ok;
                base.OnResolveSource(cancelArgs.Arguments);
            }
            LogVerbose("Leaving Method: OnResolveSource");
        }
        #endregion OnResolveSource

        #region OnRestartRequired
        /// <summary>Called by the engine to request a restart now or inform the user a manual restart is required later.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnRestartRequired(Wix.RestartRequiredEventArgs args)
        {
            LogVerbose("Enter Method: OnRestartRequired");
            WPFBootstrapperEventArgs<Wix.RestartRequiredEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.RestartRequiredEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnRestartRequired(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnRestartRequired(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnRestartRequired");
        }
        #endregion OnRestartRequired

        #region OnShutdown
        /// <summary>Called by the engine to uninitialize the user experience.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnShutdown(Wix.ShutdownEventArgs args)
        {
            LogVerbose("Enter Method: OnShutdown");
            WPFBootstrapperEventArgs<Wix.ShutdownEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ShutdownEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnShutdown(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnShutdown(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnShutdown");
        }
        #endregion OnShutdown

        #region OnStartup
        /// <summary>Called by the engine on startup of the bootstrapper application.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnStartup(Wix.StartupEventArgs args)
        {
            LogVerbose("Enter Method: OnStartup");
            WPFBootstrapperEventArgs<Wix.StartupEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.StartupEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnStartup(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnStartup(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnStartup");
        }
        #endregion OnStartup

        #region OnSystemShutdown
        /// <summary>Called when the system is shutting down or the user is logging off.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnSystemShutdown(Wix.SystemShutdownEventArgs args)
        {
            LogVerbose("Enter Method: OnSystemShutdown");
            WPFBootstrapperEventArgs<Wix.SystemShutdownEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.SystemShutdownEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnSystemShutdown(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnSystemShutdown(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnSystemShutdown");
        }
        #endregion OnSystemShutdown

        #region OnUnregisterBegin
        /// <summary>Called when the engine has begun removing the registration for the location and visibility of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnUnregisterBegin(Wix.UnregisterBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnUnregisterBegin");
            WPFBootstrapperEventArgs<Wix.UnregisterBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.UnregisterBeginEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnUnregisterBegin(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnUnregisterBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnUnregisterBegin");
        }
        #endregion OnUnregisterBegin

        #region OnUnregisterComplete
        /// <summary>Called when the engine has completed removing the registration for the location and visibility of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnUnregisterComplete(Wix.UnregisterCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnUnregisterComplete");
            WPFBootstrapperEventArgs<Wix.UnregisterCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.UnregisterCompleteEventArgs>(args);
            TryInvoke(new Action(() => { _mainWindow.OnUnregisterComplete(cancelArgs); }));
            if (!cancelArgs.Cancel) { base.OnUnregisterComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnUnregisterComplete");
        }
        #endregion OnUnregisterComplete

        #region OnWindowClosed
        /// <summary>Raised when the main window of the bootstrapper is closed.</summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void OnWindowClosed(object sender, EventArgs e)
        {
            Engine.Quit(0);
        }
        #endregion OnWindowClosed

        #endregion Event Handlers

        #region Methods

        #region GetApplicationUI
        /// <summary>Gets the <see cref="BaseBAWindow" /> derivation from the configured UI implementation assembly.</summary>
        /// <returns>A BaseBAWindow instance or null.</returns>
        private BaseBAWindow GetApplicationUI()
        {
            BaseBAWindow retVal = null;
            string implType = GetAppSetting("BootstrapperUI");
            Type type = null;

            if (!string.IsNullOrEmpty(implType))
            {
                LogVerbose("configured implementation = " + implType);
                try { type = GetUITypeFromAssembly(implType); }
                catch (Exception e) { LogError(e); }
            }

            if (type != null)
            {
                LogVerbose("full type name = " + type.AssemblyQualifiedName);
                try { retVal = Activator.CreateInstance(type) as BaseBAWindow; }
                catch (Exception e) { LogError(e); }
            }

            if (retVal != null)
            {
                retVal.Bootstrapper = this;
            }

            return retVal;
        }
        #endregion GetApplicationUI

        #region GetApplicationUIType
        /// <summary>Gets the application user interface implementation type.</summary>
        /// <param name="assemblyName">The name of the assembly that should defines the <see cref="StartupWindowAttribute"/>.</param>
        /// <returns>The type specified by the first assembly that has the <see cref="StartupWindowAttribute"/>.</returns>
        private Type GetUITypeFromAssembly(string assemblyName)
        {
            Type baType = null;
            Assembly asm = null;
            StartupWindowAttribute[] attrs = null;

            if (!string.IsNullOrEmpty(assemblyName))
            {
                try
                {
                    asm = AppDomain.CurrentDomain.Load(assemblyName);
                }
                catch (Exception ex)
                {
                    LogError("An error occurred loading assembly {0}. Details: {1}", assemblyName, ex);
                }
            }

            if (asm != null)
            {
                attrs = (StartupWindowAttribute[])asm.GetCustomAttributes(typeof(StartupWindowAttribute), false);
                if (attrs != null && attrs.Length > 0 && attrs[0] != null)
                {
                    baType = attrs[0].StartupWindowType;
                }
            }

            return baType;
        }
        #endregion GetApplicationUIType

        #region GetAppSetting
        /// <summary>Attempts to get the value of the application settings with the specified <paramref name="key" />.</summary>
        /// <param name="key">The key of the setting.</param>
        /// <returns>The value of the settings or null.</returns>
        private string GetAppSetting(string key)
        {
            string value = null;

            if (ConfigurationManager.AppSettings != null && !string.IsNullOrEmpty(key))
            {
                try { value = ConfigurationManager.AppSettings[key]; }
                catch { value = null; }
            }

            return value;
        }
        #endregion GetAppSetting

        #region SetMainWindow
        /// <summary>Sets the main window to the specified <paramref name="window"/>.</summary>
        /// <param name="window">The new main window.</param>
        public void SetMainWindow(BaseBAWindow window)
        {
            if (window == null)
            {
                Exception error = new ArgumentNullException("window");
                LogError(error);
                throw error;
            }
            _mainWindow.Closed -= OnWindowClosed;
            _mainWindow = window;
            _mainWindow.Closed += OnWindowClosed;
            UIDispatcher = _mainWindow.Dispatcher;
        }
        #endregion SetMainWindow

        #region Run
        /// <summary>Called when the bootstrap application is run.</summary>
        protected override void Run()
        {
            _mainWindow = GetApplicationUI();

            if (_mainWindow != null)
            {
                if (Threading.Dispatcher.CurrentDispatcher != null)
                {
                    try
                    {
                        UIDispatcher = _mainWindow.Dispatcher;
                        _mainWindow.Closed += OnWindowClosed;
                        _mainWindow.Show();

                        Engine.Detect();

                        Threading.Dispatcher.Run();
                    }
                    catch (Exception ex)
                    {
                        LogError(ex);
                        Engine.Quit(400);
                    }
                }
                else
                {
                    LogError("No current dispatcher.");
                    Engine.Quit(400);
                }
            }
            else
            {
                LogError("Failed to get an UI implementation.");
                Engine.Quit(404);
            }
        }
        #endregion Run

        #region LogVerbose
        /// <summary>Writes the specified <paramref name="message"/> to the log file.</summary>
        /// <param name="message">The message to write.</param>
        public void LogVerbose(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                WriteToLog(Wix.LogLevel.Verbose, message);
            }
        }
        #endregion LogVerbose

        #region LogError
        /// <summary>Writes a log entry for the specified <paramref name="error"/>.</summary>
        /// <param name="error">The error.</param>
        public void LogError(Exception error)
        {
            if (error != null)
            {
                LogError(string.Format("An error occurred. Detail: {0}", error));
            }
        }
        #endregion LogError

        #region LogError
        /// <summary>Writes a log entry for the specified <paramref name="args"/> using the specified <paramref name="format"/>.</summary>
        /// <param name="format">The string format.</param>
        /// <param name="args">The arguments.</param>
        public void LogError(string format, params object[] args)
        {
            if (!string.IsNullOrEmpty(format) && args != null)
            {
                try { LogError(string.Format(format, args)); }
                catch (Exception e)
                {
                    LogError(string.Format("An error occurred formatting the original message. Detail: {0}\r\nOriginal Error: {1}",
                      e, string.Join(";", (from a in args select a.ToString()).ToArray())));
                }
            }
        }
        #endregion LogError

        #region LogError
        /// <summary>Writes the specified <paramref name="message"/> to the log file.</summary>
        /// <param name="message">The message to write.</param>
        public void LogError(string message)
        {
            WriteToLog(Wix.LogLevel.Error, message ?? "An unknown error occurred in WPFBootstrapper");
        }
        #endregion LogError

        #region WriteToLog
        /// <summary>Write the specified <paramref name="message"/> to the log using the specified log <paramref name="level"/>.</summary>
        /// <param name="level">The log level.</param>
        /// <param name="message">The message to log.</param>
        public void WriteToLog(Wix.LogLevel level, string message)
        {
            Engine.Log(level, string.Format("WixWPF: {0}", message ?? string.Empty));
        }
        #endregion WriteToLog

        #region TryInvoke
        /// <summary>Attempts to invoke the specified <paramref name="action" /> on the main window dispatcher.</summary>
        /// <param name="action">The action to invoke.</param>
        internal void TryInvoke(Action action)
        {
            try
            {
                if (_mainWindow != null && _mainWindow.Dispatcher != null)
                {
                    _mainWindow.Dispatcher.Invoke(action, null);
                }
            }
            catch (Exception e) { LogError("An error occurred invoking an action. Details: {0}", e); }
        }
        #endregion TryInvoke

        #endregion Methods
    }
}