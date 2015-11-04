using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using System.Reflection;
using System.Runtime.InteropServices;
using WixWPF;

[assembly: Guid("77a28ac9-8e9d-430b-b691-fd7df713fbd8")]

[assembly: AssemblyVersion("3.8.0.0")]
[assembly: AssemblyFileVersion("3.8.0.0")]

[assembly: BootstrapperApplication(typeof(WPFBootstrapper))]