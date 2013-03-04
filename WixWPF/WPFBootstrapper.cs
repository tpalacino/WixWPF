using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Threading = System.Windows.Threading;

namespace WixWPF
{
	/// <summary>The core managed bootstrap application.</summary>
	public class WPFBootstrapper : BootstrapperApplication
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
		protected override void OnApplyBegin(ApplyBeginEventArgs args)
		{
			LogVerbose("Enter Method: OnApplyBegin");
			WPFBootstrapperEventArgs<ApplyBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<ApplyBeginEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnApplyBegin(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnApplyBegin(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnApplyBegin");
		}
		#endregion OnApplyBegin

		#region OnApplyComplete
		/// <summary>Called when the engine has completed installing the bundle.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnApplyComplete(ApplyCompleteEventArgs args)
		{
			LogVerbose("Enter Method: OnApplyComplete");
			WPFBootstrapperEventArgs<ApplyCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<ApplyCompleteEventArgs>(args);
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
		protected override void OnCacheAcquireBegin(CacheAcquireBeginEventArgs args)
		{
			LogVerbose("Enter Method: OnCacheAcquireBegin");
			WPFBootstrapperEventArgs<CacheAcquireBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<CacheAcquireBeginEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnCacheAcquireBegin(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnCacheAcquireBegin(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnCacheAcquireBegin");
		}
		#endregion OnCacheAcquireBegin

		#region OnCacheAcquireComplete
		/// <summary>Called when the engine completes caching of the container or payload.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnCacheAcquireComplete(CacheAcquireCompleteEventArgs args)
		{
			LogVerbose("Enter Method: OnCacheAcquireComplete");
			WPFBootstrapperEventArgs<CacheAcquireCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<CacheAcquireCompleteEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnCacheAcquireComplete(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnCacheAcquireComplete(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnCacheAcquireComplete");
		}
		#endregion OnCacheAcquireComplete

		#region OnCacheAcquireProgress
		/// <summary>Called when the engine has progressed on caching the container or payload.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnCacheAcquireProgress(CacheAcquireProgressEventArgs args)
		{
			LogVerbose("Enter Method: OnCacheAcquireProgress");
			WPFBootstrapperEventArgs<CacheAcquireProgressEventArgs> cancelArgs = new WPFBootstrapperEventArgs<CacheAcquireProgressEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnCacheAcquireProgress(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnCacheAcquireProgress(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnCacheAcquireProgress");
		}
		#endregion OnCacheAcquireProgress

		#region OnCacheBegin
		/// <summary>Called when the engine begins to cache the installation sources.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnCacheBegin(CacheBeginEventArgs args)
		{
			LogVerbose("Enter Method: OnCacheBegin");
			WPFBootstrapperEventArgs<CacheBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<CacheBeginEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnCacheBegin(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnCacheBegin(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnCacheBegin");
		}
		#endregion OnCacheBegin

		#region OnCacheComplete
		/// <summary>Called after the engine has cached the installation sources.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnCacheComplete(CacheCompleteEventArgs args)
		{
			LogVerbose("Enter Method: OnCacheComplete");
			WPFBootstrapperEventArgs<CacheCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<CacheCompleteEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnCacheComplete(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnCacheComplete(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnCacheComplete");
		}
		#endregion OnCacheComplete

		#region OnCachePackageBegin
		/// <summary>Called by the engine when it begins to cache a specific package.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnCachePackageBegin(CachePackageBeginEventArgs args)
		{
			LogVerbose("Enter Method: OnCachePackageBegin");
			WPFBootstrapperEventArgs<CachePackageBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<CachePackageBeginEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnCachePackageBegin(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnCachePackageBegin(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnCachePackageBegin");
		}
		#endregion OnCachePackageBegin

		#region OnCachePackageComplete
		/// <summary>Called when the engine completes caching a specific package.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnCachePackageComplete(CachePackageCompleteEventArgs args)
		{
			LogVerbose("Enter Method: OnCachePackageComplete");
			WPFBootstrapperEventArgs<CachePackageCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<CachePackageCompleteEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnCachePackageComplete(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnCachePackageComplete(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnCachePackageComplete");
		}
		#endregion OnCachePackageComplete

		#region OnCacheVerifyBegin
		/// <summary>Called when the engine has started verify the payload.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnCacheVerifyBegin(CacheVerifyBeginEventArgs args)
		{
			LogVerbose("Enter Method: OnCacheVerifyBegin");
			WPFBootstrapperEventArgs<CacheVerifyBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<CacheVerifyBeginEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnCacheVerifyBegin(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnCacheVerifyBegin(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnCacheVerifyBegin");
		}
		#endregion OnCacheVerifyBegin

		#region OnCacheVerifyComplete
		/// <summary>Called when the engine completes verification of the payload.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnCacheVerifyComplete(CacheVerifyCompleteEventArgs args)
		{
			LogVerbose("Enter Method: OnCacheVerifyComplete");
			WPFBootstrapperEventArgs<CacheVerifyCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<CacheVerifyCompleteEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnCacheVerifyComplete(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnCacheVerifyComplete(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnCacheVerifyComplete");
		}
		#endregion OnCacheVerifyComplete

		#region OnDetectBegin
		/// <summary>Called when the overall detection phase has begun.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnDetectBegin(DetectBeginEventArgs args)
		{
			LogVerbose("Enter Method: OnDetectBegin");
			WPFBootstrapperEventArgs<DetectBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<DetectBeginEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnDetectBegin(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnDetectBegin(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnDetectBegin");
		}
		#endregion OnDetectBegin

		#region OnDetectComplete
		/// <summary>Called when the detection phase has completed.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnDetectComplete(DetectCompleteEventArgs args)
		{
			LogVerbose("Enter Method: OnDetectComplete");
			WPFBootstrapperEventArgs<DetectCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<DetectCompleteEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnDetectComplete(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnDetectComplete(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnDetectComplete");
		}
		#endregion OnDetectComplete

		#region OnDetectMsiFeature
		/// <summary>Called when an MSI feature has been detected for a package.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnDetectMsiFeature(DetectMsiFeatureEventArgs args)
		{
			LogVerbose("Enter Method: OnDetectMsiFeature");
			WPFBootstrapperEventArgs<DetectMsiFeatureEventArgs> cancelArgs = new WPFBootstrapperEventArgs<DetectMsiFeatureEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnDetectMsiFeature(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnDetectMsiFeature(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnDetectMsiFeature");
		}
		#endregion OnDetectMsiFeature

		#region OnDetectPackageBegin
		/// <summary>Called when the detection for a specific package has begun.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnDetectPackageBegin(DetectPackageBeginEventArgs args)
		{
			LogVerbose("Enter Method: OnDetectPackageBegin");
			WPFBootstrapperEventArgs<DetectPackageBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<DetectPackageBeginEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnDetectPackageBegin(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnDetectPackageBegin(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnDetectPackageBegin");
		}
		#endregion OnDetectPackageBegin

		#region OnDetectPackageComplete
		/// <summary>Called when the detection for a specific package has completed.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnDetectPackageComplete(DetectPackageCompleteEventArgs args)
		{
			LogVerbose("Enter Method: OnDetectPackageComplete");
			WPFBootstrapperEventArgs<DetectPackageCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<DetectPackageCompleteEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnDetectPackageComplete(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnDetectPackageComplete(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnDetectPackageComplete");
		}
		#endregion OnDetectPackageComplete

		#region OnDetectPriorBundle
		/// <summary>Called when the detection for a prior bundle has begun.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnDetectPriorBundle(DetectPriorBundleEventArgs args)
		{
			LogVerbose("Enter Method: OnDetectPriorBundle");
			WPFBootstrapperEventArgs<DetectPriorBundleEventArgs> cancelArgs = new WPFBootstrapperEventArgs<DetectPriorBundleEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnDetectPriorBundle(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnDetectPriorBundle(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnDetectPriorBundle");
		}
		#endregion OnDetectPriorBundle

		#region OnDetectRelatedBundle
		/// <summary>Called when a related bundle has been detected for a bundle.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnDetectRelatedBundle(DetectRelatedBundleEventArgs args)
		{
			LogVerbose("Enter Method: OnDetectRelatedBundle");
			WPFBootstrapperEventArgs<DetectRelatedBundleEventArgs> cancelArgs = new WPFBootstrapperEventArgs<DetectRelatedBundleEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnDetectRelatedBundle(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnDetectRelatedBundle(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnDetectRelatedBundle");
		}
		#endregion OnDetectRelatedBundle

		#region OnDetectRelatedMsiPackage
		/// <summary>Called when a related MSI package has been detected for a package.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnDetectRelatedMsiPackage(DetectRelatedMsiPackageEventArgs args)
		{
			LogVerbose("Enter Method: OnDetectRelatedMsiPackage");
			WPFBootstrapperEventArgs<DetectRelatedMsiPackageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<DetectRelatedMsiPackageEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnDetectRelatedMsiPackage(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnDetectRelatedMsiPackage(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnDetectRelatedMsiPackage");
		}
		#endregion OnDetectRelatedMsiPackage

		#region OnDetectTargetMsiPackage
		/// <summary>Called when an MSP package detects a target MSI has been detected.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnDetectTargetMsiPackage(DetectTargetMsiPackageEventArgs args)
		{
			LogVerbose("Enter Method: OnDetectTargetMsiPackage");
			WPFBootstrapperEventArgs<DetectTargetMsiPackageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<DetectTargetMsiPackageEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnDetectTargetMsiPackage(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnDetectTargetMsiPackage(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnDetectTargetMsiPackage");
		}
		#endregion OnDetectTargetMsiPackage

		#region OnElevate
		/// <summary>Called when the engine is about to start the elevated process.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnElevate(ElevateEventArgs args)
		{
			LogVerbose("Enter Method: OnElevate");
			WPFBootstrapperEventArgs<ElevateEventArgs> cancelArgs = new WPFBootstrapperEventArgs<ElevateEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnElevate(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnElevate(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnElevate");
		}
		#endregion OnElevate

		#region OnError
		/// <summary>Called when the engine has encountered an error.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnError(ErrorEventArgs args)
		{
			LogVerbose("Enter Method: OnError");
			WPFBootstrapperEventArgs<ErrorEventArgs> cancelArgs = new WPFBootstrapperEventArgs<ErrorEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnError(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnError(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnError");
		}
		#endregion OnError

		#region OnExecuteBegin
		/// <summary>Called when the engine has begun installing packages.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnExecuteBegin(ExecuteBeginEventArgs args)
		{
			LogVerbose("Enter Method: OnExecuteBegin");
			WPFBootstrapperEventArgs<ExecuteBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<ExecuteBeginEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnExecuteBegin(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnExecuteBegin(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnExecuteBegin");
		}
		#endregion OnExecuteBegin

		#region OnExecuteComplete
		/// <summary>Called when the engine has completed installing packages.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnExecuteComplete(ExecuteCompleteEventArgs args)
		{
			LogVerbose("Enter Method: OnExecuteComplete");
			WPFBootstrapperEventArgs<ExecuteCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<ExecuteCompleteEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnExecuteComplete(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnExecuteComplete(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnExecuteComplete");
		}
		#endregion OnExecuteComplete

		#region OnExecuteFilesInUse
		/// <summary>Called when Windows Installer sends a file in use installation message.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnExecuteFilesInUse(ExecuteFilesInUseEventArgs args)
		{
			LogVerbose("Enter Method: OnExecuteFilesInUse");
			WPFBootstrapperEventArgs<ExecuteFilesInUseEventArgs> cancelArgs = new WPFBootstrapperEventArgs<ExecuteFilesInUseEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnExecuteFilesInUse(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnExecuteFilesInUse(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnExecuteFilesInUse");
		}
		#endregion OnExecuteFilesInUse

		#region OnExecuteMsiMessage
		/// <summary>Called when Windows Installer sends an installation message.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnExecuteMsiMessage(ExecuteMsiMessageEventArgs args)
		{
			LogVerbose("Enter Method: OnExecuteMsiMessage");
			WPFBootstrapperEventArgs<ExecuteMsiMessageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<ExecuteMsiMessageEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnExecuteMsiMessage(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnExecuteMsiMessage(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnExecuteMsiMessage");
		}
		#endregion OnExecuteMsiMessage

		#region OnExecutePackageBegin
		/// <summary>Called when the engine has begun installing a specific package.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnExecutePackageBegin(ExecutePackageBeginEventArgs args)
		{
			LogVerbose("Enter Method: OnExecutePackageBegin");
			WPFBootstrapperEventArgs<ExecutePackageBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<ExecutePackageBeginEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnExecutePackageBegin(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnExecutePackageBegin(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnExecutePackageBegin");
		}
		#endregion OnExecutePackageBegin

		#region OnExecutePackageComplete
		/// <summary>Called when the engine has completed installing a specific package.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnExecutePackageComplete(ExecutePackageCompleteEventArgs args)
		{
			LogVerbose("Enter Method: OnExecutePackageComplete");
			WPFBootstrapperEventArgs<ExecutePackageCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<ExecutePackageCompleteEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnExecutePackageComplete(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnExecutePackageComplete(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnExecutePackageComplete");
		}
		#endregion OnExecutePackageComplete

		#region OnExecutePatchTarget
		/// <summary>Called when the engine executes one or more patches targeting a product.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnExecutePatchTarget(ExecutePatchTargetEventArgs args)
		{
			LogVerbose("Enter Method: OnExecutePatchTarget");
			WPFBootstrapperEventArgs<ExecutePatchTargetEventArgs> cancelArgs = new WPFBootstrapperEventArgs<ExecutePatchTargetEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnExecutePatchTarget(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnExecutePatchTarget(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnExecutePatchTarget");
		}
		#endregion OnExecutePatchTarget

		#region OnExecuteProgress
		/// <summary>Called by the engine while executing on payload.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnExecuteProgress(ExecuteProgressEventArgs args)
		{
			LogVerbose("Enter Method: OnExecuteProgress");
			WPFBootstrapperEventArgs<ExecuteProgressEventArgs> cancelArgs = new WPFBootstrapperEventArgs<ExecuteProgressEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnExecuteProgress(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnExecuteProgress(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnExecuteProgress");
		}
		#endregion OnExecuteProgress

		#region OnPlanBegin
		/// <summary>Called when the engine has begun planning the installation.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnPlanBegin(PlanBeginEventArgs args)
		{
			LogVerbose("Enter Method: OnPlanBegin");
			WPFBootstrapperEventArgs<PlanBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<PlanBeginEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnPlanBegin(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnPlanBegin(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnPlanBegin");
		}
		#endregion OnPlanBegin

		#region OnPlanComplete
		/// <summary>Called when the engine has completed planning the installation.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnPlanComplete(PlanCompleteEventArgs args)
		{
			LogVerbose("Enter Method: OnPlanComplete");
			WPFBootstrapperEventArgs<PlanCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<PlanCompleteEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnPlanComplete(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnPlanComplete(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnPlanComplete");
		}
		#endregion OnPlanComplete

		#region OnPlanMsiFeature
		/// <summary>Called when the engine is about to plan an MSI feature of a specific package.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnPlanMsiFeature(PlanMsiFeatureEventArgs args)
		{
			LogVerbose("Enter Method: OnPlanMsiFeature");
			WPFBootstrapperEventArgs<PlanMsiFeatureEventArgs> cancelArgs = new WPFBootstrapperEventArgs<PlanMsiFeatureEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnPlanMsiFeature(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnPlanMsiFeature(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnPlanMsiFeature");
		}
		#endregion OnPlanMsiFeature

		#region OnPlanPackageBegin
		/// <summary>Called when the engine has begun planning the installation of a specific package.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnPlanPackageBegin(PlanPackageBeginEventArgs args)
		{
			LogVerbose("Enter Method: OnPlanPackageBegin");
			WPFBootstrapperEventArgs<PlanPackageBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<PlanPackageBeginEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnPlanPackageBegin(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnPlanPackageBegin(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnPlanPackageBegin");
		}
		#endregion OnPlanPackageBegin

		#region OnPlanPackageComplete
		/// <summary>Called when then engine has completed planning the installation of a specific package.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnPlanPackageComplete(PlanPackageCompleteEventArgs args)
		{
			LogVerbose("Enter Method: OnPlanPackageComplete");
			WPFBootstrapperEventArgs<PlanPackageCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<PlanPackageCompleteEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnPlanPackageComplete(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnPlanPackageComplete(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnPlanPackageComplete");
		}
		#endregion OnPlanPackageComplete

		#region OnPlanRelatedBundle
		/// <summary>Called when the engine has begun planning for a prior bundle.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnPlanRelatedBundle(PlanRelatedBundleEventArgs args)
		{
			LogVerbose("Enter Method: OnPlanRelatedBundle");
			WPFBootstrapperEventArgs<PlanRelatedBundleEventArgs> cancelArgs = new WPFBootstrapperEventArgs<PlanRelatedBundleEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnPlanRelatedBundle(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnPlanRelatedBundle(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnPlanRelatedBundle");
		}
		#endregion OnPlanRelatedBundle

		#region OnPlanTargetMsiPackage
		/// <summary>Called when the engine is about to plan the target MSI of a MSP package.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnPlanTargetMsiPackage(PlanTargetMsiPackageEventArgs args)
		{
			LogVerbose("Enter Method: OnPlanTargetMsiPackage");
			WPFBootstrapperEventArgs<PlanTargetMsiPackageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<PlanTargetMsiPackageEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnPlanTargetMsiPackage(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnPlanTargetMsiPackage(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnPlanTargetMsiPackage");
		}
		#endregion OnPlanTargetMsiPackage

		#region OnProgress
		/// <summary>Called when the engine has changed progress for the bundle installation.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnProgress(ProgressEventArgs args)
		{
			LogVerbose("Enter Method: OnProgress");
			WPFBootstrapperEventArgs<ProgressEventArgs> cancelArgs = new WPFBootstrapperEventArgs<ProgressEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnProgress(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnProgress(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnProgress");
		}
		#endregion OnProgress

		#region OnRegisterBegin
		/// <summary>Called when the engine has begun registering the location and visibility of the bundle.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnRegisterBegin(RegisterBeginEventArgs args)
		{
			LogVerbose("Enter Method: OnRegisterBegin");
			WPFBootstrapperEventArgs<RegisterBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<RegisterBeginEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnRegisterBegin(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnRegisterBegin(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnRegisterBegin");
		}
		#endregion OnRegisterBegin

		#region OnRegisterComplete
		/// <summary>Called when the engine has completed registering the location and visilibity of the bundle.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnRegisterComplete(RegisterCompleteEventArgs args)
		{
			LogVerbose("Enter Method: OnRegisterComplete");
			WPFBootstrapperEventArgs<RegisterCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<RegisterCompleteEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnRegisterComplete(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnRegisterComplete(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnRegisterComplete");
		}
		#endregion OnRegisterComplete

		#region OnResolveSource
		/// <summary>Called by the engine to allow the user experience to change the source using <see cref="M:Engine.SetLocalSource"/> or <see cref="M:Engine.SetDownloadSource"/>.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnResolveSource(ResolveSourceEventArgs args)
		{
			LogVerbose("Enter Method: OnResolveSource");
			WPFBootstrapperEventArgs<ResolveSourceEventArgs> cancelArgs = new WPFBootstrapperEventArgs<ResolveSourceEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnResolveSource(cancelArgs); }));
			if (!cancelArgs.Cancel)
			{
				if (!string.IsNullOrEmpty(args.DownloadSource))
				{
					args.Result = Result.Download;
				}
				else
				{
					args.Result = Result.Ok;
				}
				base.OnResolveSource(cancelArgs.Arguments);
			}
			LogVerbose("Leaving Method: OnResolveSource");
		}
		#endregion OnResolveSource

		#region OnRestartRequired
		/// <summary>Called by the engine to request a restart now or inform the user a manual restart is required later.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnRestartRequired(RestartRequiredEventArgs args)
		{
			LogVerbose("Enter Method: OnRestartRequired");
			WPFBootstrapperEventArgs<RestartRequiredEventArgs> cancelArgs = new WPFBootstrapperEventArgs<RestartRequiredEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnRestartRequired(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnRestartRequired(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnRestartRequired");
		}
		#endregion OnRestartRequired

		#region OnShutdown
		/// <summary>Called by the engine to uninitialize the user experience.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnShutdown(ShutdownEventArgs args)
		{
			LogVerbose("Enter Method: OnShutdown");
			WPFBootstrapperEventArgs<ShutdownEventArgs> cancelArgs = new WPFBootstrapperEventArgs<ShutdownEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnShutdown(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnShutdown(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnShutdown");
		}
		#endregion OnShutdown

		#region OnStartup
		/// <summary>Called by the engine on startup of the bootstrapper application.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnStartup(StartupEventArgs args)
		{
			LogVerbose("Enter Method: OnStartup");
			WPFBootstrapperEventArgs<StartupEventArgs> cancelArgs = new WPFBootstrapperEventArgs<StartupEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnStartup(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnStartup(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnStartup");
		}
		#endregion OnStartup

		#region OnSystemShutdown
		/// <summary>Called when the system is shutting down or the user is logging off.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnSystemShutdown(SystemShutdownEventArgs args)
		{
			LogVerbose("Enter Method: OnSystemShutdown");
			WPFBootstrapperEventArgs<SystemShutdownEventArgs> cancelArgs = new WPFBootstrapperEventArgs<SystemShutdownEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnSystemShutdown(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnSystemShutdown(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnSystemShutdown");
		}
		#endregion OnSystemShutdown

		#region OnUnregisterBegin
		/// <summary>Called when the engine has begun removing the registration for the location and visibility of the bundle.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnUnregisterBegin(UnregisterBeginEventArgs args)
		{
			LogVerbose("Enter Method: OnUnregisterBegin");
			WPFBootstrapperEventArgs<UnregisterBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<UnregisterBeginEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnUnregisterBegin(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnUnregisterBegin(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnUnregisterBegin");
		}
		#endregion OnUnregisterBegin

		#region OnUnregisterComplete
		/// <summary>Called when the engine has completed removing the registration for the location and visibility of the bundle.</summary>
		/// <param name="args">The arguments of the event.</param>
		protected override void OnUnregisterComplete(UnregisterCompleteEventArgs args)
		{
			LogVerbose("Enter Method: OnUnregisterComplete");
			WPFBootstrapperEventArgs<UnregisterCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<UnregisterCompleteEventArgs>(args);
			TryInvoke(new Action(() => { _mainWindow.OnUnregisterComplete(cancelArgs); }));
			if (!cancelArgs.Cancel) { base.OnUnregisterComplete(cancelArgs.Arguments); }
			LogVerbose("Leaving Method: OnUnregisterComplete");
		}
		#endregion OnUnregisterComplete

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
			ConstructorInfo ctor = null;

			if (!string.IsNullOrEmpty(implType))
			{
				LogVerbose("configured implementation = " + implType ?? string.Empty);
				try { type = Type.GetType(implType); }
				catch (Exception e) { LogError(e); }
			}

			if (type != null)
			{
				LogVerbose("full type name = " + type.AssemblyQualifiedName);
				try { ctor = type.GetConstructor(new Type[] { this.GetType() }); }
				catch (Exception e) { LogError(e); }
			}

			if (ctor != null)
			{
				LogVerbose("got a constructor");
				try { retVal = ctor.Invoke(new object[] { this }) as BaseBAWindow; }
				catch (Exception e) { LogError(e); }
			}

			return retVal;
		}
		#endregion GetApplicationUI

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
						_mainWindow.Closed += (s, e) => { Engine.Quit(0); };
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
				WriteToLog(LogLevel.Verbose, message);
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
			WriteToLog(LogLevel.Error, message ?? "An unknown error occurred in CoreMBA");
		}
		#endregion LogError

		#region WriteToLog
		/// <summary>Write the specified <paramref name="message"/> to the log using the specified log <paramref name="level"/>.</summary>
		/// <param name="level">The log level.</param>
		/// <param name="message">The message to log.</param>
		public void WriteToLog(LogLevel level, string message)
		{
			Engine.Log(level, string.Format("CoreMBA Entry: {0}", message ?? string.Empty));
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