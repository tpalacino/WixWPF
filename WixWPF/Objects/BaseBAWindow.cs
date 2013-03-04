using System;
using System.Windows;
using Wix = Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

namespace WixWPF
{
	/// <summary>Provides bootstrap application interaction functionality to derived classes.</summary>
	public class BaseBAWindow : Window
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
		/// <summary>No Summary Provided</summary>
		public virtual void OnApplyBegin(WPFBootstrapperEventArgs<Wix.ApplyBeginEventArgs> args) { }
		#endregion OnApplyBegin

		#region OnApplyComplete
		/// <summary>No Summary Provided</summary>
		public virtual void OnApplyComplete(WPFBootstrapperEventArgs<Wix.ApplyCompleteEventArgs> args) { }
		#endregion OnApplyComplete

		#region OnCacheAcquireBegin
		/// <summary>No Summary Provided</summary>
		public virtual void OnCacheAcquireBegin(WPFBootstrapperEventArgs<Wix.CacheAcquireBeginEventArgs> args) { }
		#endregion OnCacheAcquireBegin

		#region OnCacheAcquireComplete
		/// <summary>No Summary Provided</summary>
		public virtual void OnCacheAcquireComplete(WPFBootstrapperEventArgs<Wix.CacheAcquireCompleteEventArgs> args) { }
		#endregion OnCacheAcquireComplete

		#region OnCacheAcquireProgress
		/// <summary>No Summary Provided</summary>
		public virtual void OnCacheAcquireProgress(WPFBootstrapperEventArgs<Wix.CacheAcquireProgressEventArgs> args) { }
		#endregion OnCacheAcquireProgress

		#region OnCacheBegin
		/// <summary>No Summary Provided</summary>
		public virtual void OnCacheBegin(WPFBootstrapperEventArgs<Wix.CacheBeginEventArgs> args) { }
		#endregion OnCacheBegin

		#region OnCacheComplete
		/// <summary>No Summary Provided</summary>
		public virtual void OnCacheComplete(WPFBootstrapperEventArgs<Wix.CacheCompleteEventArgs> args) { }
		#endregion OnCacheComplete

		#region OnCachePackageBegin
		/// <summary>No Summary Provided</summary>
		public virtual void OnCachePackageBegin(WPFBootstrapperEventArgs<Wix.CachePackageBeginEventArgs> args) { }
		#endregion OnCachePackageBegin

		#region OnCachePackageComplete
		/// <summary>No Summary Provided</summary>
		public virtual void OnCachePackageComplete(WPFBootstrapperEventArgs<Wix.CachePackageCompleteEventArgs> args) { }
		#endregion OnCachePackageComplete

		#region OnCacheVerifyBegin
		/// <summary>No Summary Provided</summary>
		public virtual void OnCacheVerifyBegin(WPFBootstrapperEventArgs<Wix.CacheVerifyBeginEventArgs> args) { }
		#endregion OnCacheVerifyBegin

		#region OnCacheVerifyComplete
		/// <summary>No Summary Provided</summary>
		public virtual void OnCacheVerifyComplete(WPFBootstrapperEventArgs<Wix.CacheVerifyCompleteEventArgs> args) { }
		#endregion OnCacheVerifyComplete

		#region OnDetectBegin
		/// <summary>No Summary Provided</summary>
		public virtual void OnDetectBegin(WPFBootstrapperEventArgs<Wix.DetectBeginEventArgs> args) { }
		#endregion OnDetectBegin

		#region OnDetectComplete
		/// <summary>No Summary Provided</summary>
		public virtual void OnDetectComplete(WPFBootstrapperEventArgs<Wix.DetectCompleteEventArgs> args) { }
		#endregion OnDetectComplete

		#region OnDetectMsiFeature
		/// <summary>No Summary Provided</summary>
		public virtual void OnDetectMsiFeature(WPFBootstrapperEventArgs<Wix.DetectMsiFeatureEventArgs> args) { }
		#endregion OnDetectMsiFeature

		#region OnDetectPackageBegin
		/// <summary>No Summary Provided</summary>
		public virtual void OnDetectPackageBegin(WPFBootstrapperEventArgs<Wix.DetectPackageBeginEventArgs> args) { }
		#endregion OnDetectPackageBegin

		#region OnDetectPackageComplete
		/// <summary>No Summary Provided</summary>
		public virtual void OnDetectPackageComplete(WPFBootstrapperEventArgs<Wix.DetectPackageCompleteEventArgs> args) { }
		#endregion OnDetectPackageComplete

		#region OnDetectPriorBundle
		/// <summary>No Summary Provided</summary>
		public virtual void OnDetectPriorBundle(WPFBootstrapperEventArgs<Wix.DetectPriorBundleEventArgs> args) { }
		#endregion OnDetectPriorBundle

		#region OnDetectRelatedBundle
		/// <summary>No Summary Provided</summary>
		public virtual void OnDetectRelatedBundle(WPFBootstrapperEventArgs<Wix.DetectRelatedBundleEventArgs> args) { }
		#endregion OnDetectRelatedBundle

		#region OnDetectRelatedMsiPackage
		/// <summary>No Summary Provided</summary>
		public virtual void OnDetectRelatedMsiPackage(WPFBootstrapperEventArgs<Wix.DetectRelatedMsiPackageEventArgs> args) { }
		#endregion OnDetectRelatedMsiPackage

		#region OnDetectTargetMsiPackage
		/// <summary>No Summary Provided</summary>
		public virtual void OnDetectTargetMsiPackage(WPFBootstrapperEventArgs<Wix.DetectTargetMsiPackageEventArgs> args) { }
		#endregion OnDetectTargetMsiPackage

		#region OnElevate
		/// <summary>No Summary Provided</summary>
		public virtual void OnElevate(WPFBootstrapperEventArgs<Wix.ElevateEventArgs> args) { }
		#endregion OnElevate

		#region OnError
		/// <summary>No Summary Provided</summary>
		public virtual void OnError(WPFBootstrapperEventArgs<Wix.ErrorEventArgs> args) { }
		#endregion OnError

		#region OnExecuteBegin
		/// <summary>No Summary Provided</summary>
		public virtual void OnExecuteBegin(WPFBootstrapperEventArgs<Wix.ExecuteBeginEventArgs> args) { }
		#endregion OnExecuteBegin

		#region OnExecuteComplete
		/// <summary>No Summary Provided</summary>
		public virtual void OnExecuteComplete(WPFBootstrapperEventArgs<Wix.ExecuteCompleteEventArgs> args) { }
		#endregion OnExecuteComplete

		#region OnExecuteFilesInUse
		/// <summary>No Summary Provided</summary>
		public virtual void OnExecuteFilesInUse(WPFBootstrapperEventArgs<Wix.ExecuteFilesInUseEventArgs> args) { }
		#endregion OnExecuteFilesInUse

		#region OnExecuteMsiMessage
		/// <summary>No Summary Provided</summary>
		public virtual void OnExecuteMsiMessage(WPFBootstrapperEventArgs<Wix.ExecuteMsiMessageEventArgs> args) { }
		#endregion OnExecuteMsiMessage

		#region OnExecutePackageBegin
		/// <summary>No Summary Provided</summary>
		public virtual void OnExecutePackageBegin(WPFBootstrapperEventArgs<Wix.ExecutePackageBeginEventArgs> args) { }
		#endregion OnExecutePackageBegin

		#region OnExecutePackageComplete
		/// <summary>No Summary Provided</summary>
		public virtual void OnExecutePackageComplete(WPFBootstrapperEventArgs<Wix.ExecutePackageCompleteEventArgs> args) { }
		#endregion OnExecutePackageComplete

		#region OnExecutePatchTarget
		/// <summary>No Summary Provided</summary>
		public virtual void OnExecutePatchTarget(WPFBootstrapperEventArgs<Wix.ExecutePatchTargetEventArgs> args) { }
		#endregion OnExecutePatchTarget

		#region OnExecuteProgress
		/// <summary>No Summary Provided</summary>
		public virtual void OnExecuteProgress(WPFBootstrapperEventArgs<Wix.ExecuteProgressEventArgs> args) { }
		#endregion OnExecuteProgress

		#region OnPlanBegin
		/// <summary>No Summary Provided</summary>
		public virtual void OnPlanBegin(WPFBootstrapperEventArgs<Wix.PlanBeginEventArgs> args) { }
		#endregion OnPlanBegin

		#region OnPlanComplete
		/// <summary>No Summary Provided</summary>
		public virtual void OnPlanComplete(WPFBootstrapperEventArgs<Wix.PlanCompleteEventArgs> args) { }
		#endregion OnPlanComplete

		#region OnPlanMsiFeature
		/// <summary>No Summary Provided</summary>
		public virtual void OnPlanMsiFeature(WPFBootstrapperEventArgs<Wix.PlanMsiFeatureEventArgs> args) { }
		#endregion OnPlanMsiFeature

		#region OnPlanPackageBegin
		/// <summary>No Summary Provided</summary>
		public virtual void OnPlanPackageBegin(WPFBootstrapperEventArgs<Wix.PlanPackageBeginEventArgs> args) { }
		#endregion OnPlanPackageBegin

		#region OnPlanPackageComplete
		/// <summary>No Summary Provided</summary>
		public virtual void OnPlanPackageComplete(WPFBootstrapperEventArgs<Wix.PlanPackageCompleteEventArgs> args) { }
		#endregion OnPlanPackageComplete

		#region OnPlanRelatedBundle
		/// <summary>No Summary Provided</summary>
		public virtual void OnPlanRelatedBundle(WPFBootstrapperEventArgs<Wix.PlanRelatedBundleEventArgs> args) { }
		#endregion OnPlanRelatedBundle

		#region OnPlanTargetMsiPackage
		/// <summary>No Summary Provided</summary>
		public virtual void OnPlanTargetMsiPackage(WPFBootstrapperEventArgs<Wix.PlanTargetMsiPackageEventArgs> args) { }
		#endregion OnPlanTargetMsiPackage

		#region OnProgress
		/// <summary>No Summary Provided</summary>
		public virtual void OnProgress(WPFBootstrapperEventArgs<Wix.ProgressEventArgs> args) { }
		#endregion OnProgress

		#region OnRegisterBegin
		/// <summary>No Summary Provided</summary>
		public virtual void OnRegisterBegin(WPFBootstrapperEventArgs<Wix.RegisterBeginEventArgs> args) { }
		#endregion OnRegisterBegin

		#region OnRegisterComplete
		/// <summary>No Summary Provided</summary>
		public virtual void OnRegisterComplete(WPFBootstrapperEventArgs<Wix.RegisterCompleteEventArgs> args) { }
		#endregion OnRegisterComplete

		#region OnResolveSource
		/// <summary>No Summary Provided</summary>
		public virtual void OnResolveSource(WPFBootstrapperEventArgs<Wix.ResolveSourceEventArgs> args) { }
		#endregion OnResolveSource

		#region OnRestartRequired
		/// <summary>No Summary Provided</summary>
		public virtual void OnRestartRequired(WPFBootstrapperEventArgs<Wix.RestartRequiredEventArgs> args) { }
		#endregion OnRestartRequired

		#region OnShutdown
		/// <summary>No Summary Provided</summary>
		public virtual void OnShutdown(WPFBootstrapperEventArgs<Wix.ShutdownEventArgs> args) { }
		#endregion OnShutdown

		#region OnStartup
		/// <summary>No Summary Provided</summary>
		public virtual void OnStartup(WPFBootstrapperEventArgs<Wix.StartupEventArgs> args) { }
		#endregion OnStartup

		#region OnSystemShutdown
		/// <summary>No Summary Provided</summary>
		public virtual void OnSystemShutdown(WPFBootstrapperEventArgs<Wix.SystemShutdownEventArgs> args) { }
		#endregion OnSystemShutdown

		#region OnUnregisterBegin
		/// <summary>No Summary Provided</summary>
		public virtual void OnUnregisterBegin(WPFBootstrapperEventArgs<Wix.UnregisterBeginEventArgs> args) { }
		#endregion OnUnregisterBegin

		#region OnUnregisterComplete
		/// <summary>No Summary Provided</summary>
		public virtual void OnUnregisterComplete(WPFBootstrapperEventArgs<Wix.UnregisterCompleteEventArgs> args) { }
		#endregion OnUnregisterComplete

		#endregion Methods
	}
}