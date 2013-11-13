﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Linq;
using WixWPF;
using Wix = Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

namespace WixWPFUI
{
  /// <summary>Interaction logic for MainWindow.xaml</summary>
  public partial class MainWindow : BaseBAWindow
  {
    #region Member Variables

    /// <summary>The detected package states.</summary>
    private Dictionary<string, Wix.PackageState> _packageStates = new Dictionary<string, Wix.PackageState>();

    #endregion Member Variables

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
      Button btn = sender as Button;

      if (btn != null && btn.Content != null)
      {
        Execute(btn.Content.ToString());
      }
    }
    #endregion OnButtonClick

    #region OnHyperlinkClick
    /// <summary>Handles the event of a hyperlink being clicked.</summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The arguments of the event.</param>
    private void OnHyperlinkClick(object sender, RoutedEventArgs e)
    {
      Hyperlink link = sender as Hyperlink;

      if (link != null && link.NavigateUri != null)
      {
        Process.Start(link.NavigateUri.ToString());
      }
    }
    #endregion OnHyperlinkClick

    #region OnApplyComplete
    /// <summary>Raised by the bootstrapper when the it is notified that the apply stage is complete.</summary>
    /// <param name="args">The arguments of the event.</param>
    public override void OnApplyComplete(WPFBootstrapperEventArgs<Wix.ApplyCompleteEventArgs> args)
    {
      if (IsValid(args) && Wix.Result.None.Equals(args.Arguments.Result))
      {
        if (Wix.RelationType.Upgrade.Equals(Bootstrapper.Command.Relation) && !InstallData.IsInstalled)
        {
          Close();
        }
        else
        {
          args.Cancel = true;
          Bootstrapper.Engine.Detect();
        }
      }
    }
    #endregion OnApplyComplete

    #region OnDetectComplete
    /// <summary>Raised by the bootstrapper when the it is notified that the detection stage is complete.</summary>
    /// <param name="args">The arguments of the event.</param>
    public override void OnDetectComplete(WPFBootstrapperEventArgs<Wix.DetectCompleteEventArgs> args)
    {
      bool isBusy = false;
      InstallData.IsInstalled = _packageStates.All(x => Wix.PackageState.Present.Equals(x.Value));

      if (Bootstrapper != null && Bootstrapper.Engine != null)
      {
        if (Bootstrapper.Engine.NumericVariables != null)
        {
          // Read the detected information so we can present the correct options to the user.
          InstallData.HasWix36 = (Bootstrapper.Engine.NumericVariables.Contains("HasWix36") && Bootstrapper.Engine.NumericVariables["HasWix36"] == 1L);
          InstallData.HasWix37 = (Bootstrapper.Engine.NumericVariables.Contains("HasWix37") && Bootstrapper.Engine.NumericVariables["HasWix37"] == 1L);
          InstallData.HasWix38 = (Bootstrapper.Engine.NumericVariables.Contains("HasWix38") && Bootstrapper.Engine.NumericVariables["HasWix38"] == 1L);
          InstallData.HasTFS2010 = (Bootstrapper.Engine.NumericVariables.Contains("HasTFS2010") && Bootstrapper.Engine.NumericVariables["HasTFS2010"] == 1L);
          InstallData.HasTFS2012 = (Bootstrapper.Engine.NumericVariables.Contains("HasTFS2012") && Bootstrapper.Engine.NumericVariables["HasTFS2012"] == 1L);
          InstallData.HasWixWPF36 = (Bootstrapper.Engine.NumericVariables.Contains("HasWixWPF36") && Bootstrapper.Engine.NumericVariables["HasWixWPF36"] == 1L);
          InstallData.HasWixWPF37 = (Bootstrapper.Engine.NumericVariables.Contains("HasWixWPF37") && Bootstrapper.Engine.NumericVariables["HasWixWPF37"] == 1L);
          InstallData.HasWixWPF38 = (Bootstrapper.Engine.NumericVariables.Contains("HasWixWPF38") && Bootstrapper.Engine.NumericVariables["HasWixWPF38"] == 1L);
          InstallData.PathVS2010 = Bootstrapper.Engine.StringVariables.Contains("PathVS2010") ? Bootstrapper.Engine.StringVariables["PathVS2010"] : string.Empty;
          InstallData.PathVS2012 = Bootstrapper.Engine.StringVariables.Contains("PathVS2012") ? Bootstrapper.Engine.StringVariables["PathVS2012"] : string.Empty;
          InstallData.PathVS2013 = Bootstrapper.Engine.StringVariables.Contains("PathVS2013") ? Bootstrapper.Engine.StringVariables["PathVS2013"] : string.Empty;
          InstallData.HasOldWixWPF36 = (Bootstrapper.Engine.NumericVariables.Contains("HasOldWixWPF36") && Bootstrapper.Engine.NumericVariables["HasOldWixWPF36"] == 1L);
          InstallData.HasOldWixWPF37 = (Bootstrapper.Engine.NumericVariables.Contains("HasOldWixWPF37") && Bootstrapper.Engine.NumericVariables["HasOldWixWPF37"] == 1L);
          InstallData.Enable36 = (InstallData.HasBuildTools && InstallData.HasWix36);
          InstallData.Enable37 = (InstallData.HasBuildTools && InstallData.HasWix37);
          InstallData.Enable38 = (InstallData.HasBuildTools && InstallData.HasWix38);

          // Write Overridable Properties here for MSI to use
          Bootstrapper.Engine.NumericVariables["Enable36"] = (InstallData.Enable36) ? 1L : 0L;
          Bootstrapper.Engine.NumericVariables["Enable37"] = (InstallData.Enable37) ? 1L : 0L;
          Bootstrapper.Engine.NumericVariables["Enable38"] = (InstallData.Enable38) ? 1L : 0L;
          Bootstrapper.Engine.NumericVariables["DeployVS"] = InstallData.HasVS ? 1L : 0L;
          Bootstrapper.Engine.StringVariables["PathVS2010"] = InstallData.HasVS2010 ? InstallData.PathVS2010 : string.Empty;
          Bootstrapper.Engine.StringVariables["PathVS2012"] = InstallData.HasVS2012 ? InstallData.PathVS2012 : string.Empty;
          Bootstrapper.Engine.StringVariables["PathVS2013"] = InstallData.HasVS2013 ? InstallData.PathVS2013 : string.Empty;
        }

        if (InstallData.IsRepairing)
        {
          isBusy = true;
          InstallData.IsRepairing = false;
          Execute(Wix.LaunchAction.Install.ToString());
        }
        else if (Wix.RelationType.Upgrade.Equals(Bootstrapper.Command.Relation) && !InstallData.IsInstalled)
        {
          Execute(Wix.LaunchAction.Uninstall.ToString());
        }
      }

      InstallData.IsBusy = isBusy;
    }
    #endregion OnDetectComplete

    #region OnDetectPackageComplete
    /// <summary>Called when a packages source is being resolved.</summary>
    /// <param name="args">The arguments of the event.</param>
    public override void OnDetectPackageComplete(WPFBootstrapperEventArgs<Wix.DetectPackageCompleteEventArgs> args)
    {
      if (IsValid(args))
      {
        _packageStates[args.Arguments.PackageId] = args.Arguments.State;
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

    #region Methods

    #region Execute
    /// <summary>Executes the specified <paramref name="action"/>.</summary>
    /// <param name="action">The action to execute.</param>
    private void Execute(string action)
    {
      InstallData.IsBusy = true;

      if (!string.IsNullOrEmpty(action))
      {
        switch (action.ToUpperInvariant())
        {
          case "INSTALL": { Bootstrapper.Engine.Plan(Wix.LaunchAction.Install); } break;
          case "QUIT": { Close(); } break;
          case "RECHECK": { Bootstrapper.Engine.Detect(); } break;
          case "REPAIR":
            {
              InstallData.IsRepairing = true;
              InstallData.Enable36 = InstallData.HasWixWPF36;
              InstallData.Enable37 = InstallData.HasWixWPF37;
              InstallData.Enable38 = InstallData.HasWixWPF38;
              Bootstrapper.Engine.Plan(Wix.LaunchAction.Uninstall);
            }
            break;
          case "UNINSTALL": { Bootstrapper.Engine.Plan(Wix.LaunchAction.Uninstall); } break;
        }
      }
      else { InstallData.IsBusy = false; }
    }
    #endregion Execute

    #endregion Methods
  }
}