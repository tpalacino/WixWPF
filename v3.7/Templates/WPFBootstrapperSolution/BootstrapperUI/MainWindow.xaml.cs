using System;
using System.Windows;
using System.Windows.Controls;
using WixWPF;
using Wix = Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

namespace $globalsafeprojectname$UI
{
	/// <summary>Interaction logic for MainWindow.xaml</summary>
	public partial class MainWindow : BaseBAWindow
	{
		#region Constructors

		/// <summary>Creates a new instance of <see cref="MainWindow" />.</summary>
		public MainWindow()
		{
			InitializeComponent();
			InstallData = new InstallerInfo();
		}

		#endregion Constructors

		#region Event Handlers

		#region OnButtonClick
		/// <summary>Handles the event of a button being clicked.</summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The arguments of the event.</param>
		private void OnButtonClick(object sender, RoutedEventArgs e)
		{
			InstallData.IsBusy = true;
			Button btn = sender as Button;

			if (btn != null && btn.Content != null && Bootstrapper != null && Bootstrapper.Engine != null)
			{
				switch (btn.Content.ToString().ToUpperInvariant())
				{
					case "INSTALL": { Bootstrapper.Engine.Plan(Wix.LaunchAction.Install); } break;
					case "UNINSTALL": { Bootstrapper.Engine.Plan(Wix.LaunchAction.Uninstall); } break;
					case "QUIT": { Close(); } break;
					default: break;
				}
			}
			else { InstallData.IsBusy = false; }
		}
		#endregion OnButtonClick

		#region OnWindowLoaded
		/// <summary>Raised after the window has been loaded.</summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The arguments of the event.</param>
		private void OnWindowLoaded(object sender, RoutedEventArgs e)
		{
			// TODO : Handle window load wire ups
		}
		#endregion OnWindowLoaded

		#region OnApplyComplete
		/// <summary>Raised by the bootstrapper when the it is notified that the apply stage is complete.</summary>
		/// <param name="args">The arguments of the event.</param>
		public override void OnApplyComplete(WPFBootstrapperEventArgs<Wix.ApplyCompleteEventArgs> args)
		{
			if (IsValid(args) && Wix.Result.None.Equals(args.Arguments.Result))
			{
				args.Cancel = true;
				Bootstrapper.Engine.Detect();
			}
		}
		#endregion OnApplyComplete

		#region OnDetectComplete
		/// <summary>Raised by the bootstrapper when the it is notified that the detection stage is complete.</summary>
		/// <param name="args">The arguments of the event.</param>
		public override void OnDetectComplete(WPFBootstrapperEventArgs<Wix.DetectCompleteEventArgs> args)
		{
			InstallData.IsBusy = false;
		}
		#endregion OnDetectComplete

		#region OnDetectPackageComplete
		/// <summary>Called when a packages source is being resolved.</summary>
		/// <param name="args">The arguments of the event.</param>
		public override void OnDetectPackageComplete(WPFBootstrapperEventArgs<Wix.DetectPackageCompleteEventArgs> args)
		{
			if (IsValid(args) && "PRODUCT_PACKAGE_ID".Equals(args.Arguments.PackageId, StringComparison.OrdinalIgnoreCase))
			{
				InstallData.IsInstalled = Wix.PackageState.Present.Equals(args.Arguments.State);
			}
		}
		#endregion OnDetectPackageComplete

		#region OnExecuteMsiMessage
		/// <summary>Called when Windows Installer sends an installation message.</summary>
		/// <param name="args">The arguments of the event.</param>
		public override void OnExecuteMsiMessage(WPFBootstrapperEventArgs<Wix.ExecuteMsiMessageEventArgs> args)
		{
			if (IsValid(args))
			{
				InstallData.Message = args.Arguments.Message;
			}
		}
		#endregion OnExecuteMsiMessage

		#region OnPlanComplete
		/// <summary>Called when the engine has completed planning the installation.</summary>
		/// <param name="args">The arguments of the event.</param>
		public override void OnPlanComplete(WPFBootstrapperEventArgs<Wix.PlanCompleteEventArgs> args)
		{
			if (IsValid(args) && args.Arguments.Status >= 0 && Bootstrapper != null && Bootstrapper.Engine != null)
			{
				Bootstrapper.Engine.Apply(IntPtr.Zero);
			}
			else { InstallData.IsBusy = false; }
		}
		#endregion OnPlanComplete

		#endregion Event Handlers

		#region Properties

		#region InstallData
		/// <summary>The installer data.</summary>
		public InstallerInfo InstallData { get { return (DataContext as InstallerInfo); } set { DataContext = value; } }
		#endregion InstallData

		#endregion Properties
	}
}