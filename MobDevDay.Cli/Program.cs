//
// Program.cs
//
// Author:
//       Stephane Delcroix <stephane@mi8.be>
//
// Copyright (c) 2013 mobile inception
//
using System;

namespace MobDevDay.Cli
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			DisplayEvents ();
		}

		public static async void DisplayEvents ()
		{
			var listvm = new SeismicEventsListViewModel ();
			listvm.Refresh ();

			foreach (var ev in listvm.Events) {
				Console.WriteLine (ev.Title);
			}
		}
	}
}
