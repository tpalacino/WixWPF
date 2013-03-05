using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using System.Reflection;
using System.Runtime.InteropServices;
using WixWPF;

[assembly: AssemblyTitle("WixWPF")]
[assembly: AssemblyDescription("Provides a managed bootstrapper application that allows completely custom user interface with minimal requirements.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Troy Palacino")]
[assembly: AssemblyProduct("WixWPF")]
[assembly: AssemblyCopyright("Copyright (c) 2013 Troy Palacino")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]

[assembly: Guid("5abb66a2-3ff9-4009-9df5-81af340d964c")]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: BootstrapperApplication(typeof(WPFBootstrapper))]