using System.Reflection;
using System.Runtime.InteropServices;
using WixWPF;
using WixWPFUI;

[assembly: AssemblyTitle("WixWPFUI")]
[assembly: AssemblyDescription("Contains the user interface implementation for the WixWPF installer.")]

[assembly: Guid("55f5a736-500b-4311-8a57-81597b36ac90")]

[assembly: StartupWindow(typeof(MainWindow))]