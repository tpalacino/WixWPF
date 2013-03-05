using System;

namespace Product
{
	/// <summary>The example product application.</summary>
	class Program
	{
		#region Member Variables

		/// <summary>The format used to print the parameters that were specified.</summary>
		private const string FORMAT = "  {0} | {1}";

		#endregion Member Variables

		#region Methods

		#region Main
		/// <summary>The main entry point of the application.</summary>
		/// <param name="args">The command line arguments.</param>
		static void Main(string[] args)
		{
			if (args != null && args.Length > 0)
			{
				Console.WriteLine(FORMAT, "ArgIndex", "ArgValue");
				Console.WriteLine(" ----------|----------");
				string arg = null;
				for (int i = 0; i < args.Length; i++)
				{
					arg = args[i];
					if (!string.IsNullOrEmpty(arg))
					{
						Console.WriteLine(FORMAT, i.ToString().PadLeft(8, ' '), arg);
					}
				}
				Console.WriteLine("Please press enter to exit.");
				Console.ReadLine();
			}
		}
		#endregion Main

		#endregion Methods
	}
}