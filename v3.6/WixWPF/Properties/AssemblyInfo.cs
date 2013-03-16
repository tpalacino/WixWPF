using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using System.Reflection;
using System.Runtime.InteropServices;
using WixWPF;

[assembly: AssemblyTitle("WixWPF")]
[assembly: AssemblyDescription("Managed bootstrapper application for completely custom user interface with minimal effort.")]

[assembly: Guid("5abb66a2-3ff9-4009-9df5-81af340d964c")]

[assembly: BootstrapperApplication(typeof(WPFBootstrapper))]