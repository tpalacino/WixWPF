using System;

namespace WixWPF
{
	/// <summary>A event arguments wrapper used when notifying WPF UI implementation of events.</summary>
	public class WPFBootstrapperEventArgs<T> where T : EventArgs
	{
		#region Constructors

		/// <summary>Creates a new instance of <see cref="WPFBootstrapperEventArgs&lt;T&gt;"/> with the specified <paramref name="args"/>.</summary>
		/// <param name="args">The original event arguments.</param>
		public WPFBootstrapperEventArgs(T args)
		{
			Arguments = args;
			Cancel = false;
		}

		#endregion Constructors

		#region Properties

		#region Arguments
		/// <summary>The original event arguments.</summary>
		public T Arguments { get; set; }
		#endregion Arguments

		#region Cancel
		/// <summary>True to cancel the event, otherwise false.</summary>
		public bool Cancel { get; set; }
		#endregion Cancel

		#endregion Properties
	}
}