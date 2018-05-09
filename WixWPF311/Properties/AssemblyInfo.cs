using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using System.Reflection;
using System.Runtime.InteropServices;
using WixWPF;

[assembly: Guid("8e09008a-ada5-4f17-8243-bbfd52424a49")]

[assembly: AssemblyVersion("3.11.0.0")]
[assembly: AssemblyFileVersion("3.11.0.0")]

[assembly: BootstrapperApplication(typeof(WPFBootstrapper))]

