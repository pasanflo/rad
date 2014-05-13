using System;
using Gtk;

namespace Serpis.Ad
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow window = new MainWindow ();
			window.Show ();
			Application.Run ();
		}
	}
}
