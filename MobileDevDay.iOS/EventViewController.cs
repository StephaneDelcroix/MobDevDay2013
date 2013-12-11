using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MobDevDay;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;

namespace MobileDevDay.iOS
{
	public partial class EventViewController : UIViewController
	{
		SeismicEvent seismicEvent;
		public EventViewController (SeismicEvent ev) : base ("EventViewController", null)
		{
			seismicEvent = ev;
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			Title = seismicEvent.Title;
			map.SetRegion (new MKCoordinateRegion (new CLLocationCoordinate2D (seismicEvent.Latitude, seismicEvent.Longitude), new MKCoordinateSpan (0.2, 0.2)), true);
			dateLabel.Text = seismicEvent.Date.ToString ();
		}
	}
}

