using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using System.Reflection;
using System.Runtime.InteropServices;
using WixWPF;

[assembly: AssemblyVersion("3.6.0.0")]
[assembly: AssemblyFileVersion("3.6.0.0")]

[assembly: Guid("5abb66a2-3ff9-4009-9df5-81af340d964c")]

[assembly: BootstrapperApplication(typeof(WPFBootstrapper))]