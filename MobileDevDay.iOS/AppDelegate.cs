//
// AppDelegate.cs
//
// Author:
//       Stephane Delcroix <stephane@mi8.be>
//
// Copyright (c) 2013 mobile inception
//
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MobileDevDay.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.RootViewController = new UINavigationController (new SeismicListViewController ());
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}