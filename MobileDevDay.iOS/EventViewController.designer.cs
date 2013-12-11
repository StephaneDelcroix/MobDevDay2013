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
	[Register ("EventViewController")]
	partial class EventViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel dateLabel { get; set; }

		[Outlet]
		MonoTouch.MapKit.MKMapView map { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (dateLabel != null) {
				dateLabel.Dispose ();
				dateLabel = null;
			}

			if (map != null) {
				map.Dispose ();
				map = null;
			}
		}
	}
}
