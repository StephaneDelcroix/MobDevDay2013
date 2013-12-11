// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace MobileDevDay.iOS
{
	[Register ("SeismicListViewController")]
	partial class SeismicListViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITableView listView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton refreshButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (listView != null) {
				listView.Dispose ();
				listView = null;
			}

			if (refreshButton != null) {
				refreshButton.Dispose ();
				refreshButton = null;
			}
		}
	}
}
