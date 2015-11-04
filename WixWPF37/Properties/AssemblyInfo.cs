using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using System.Reflection;
using System.Runtime.InteropServices;
using WixWPF;

[assembly: AssemblyVersion("3.7.0.0")]
[assembly: AssemblyFileVersion("3.7.0.0")]

[assembly: Guid("c50b32fe-08dd-418e-a4c6-0433d6619500")]

[assembly: BootstrapperApplication(typeof(WPFBootstrapper))]