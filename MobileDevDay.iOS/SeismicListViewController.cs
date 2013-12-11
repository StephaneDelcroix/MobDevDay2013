using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MobDevDay;

namespace MobileDevDay.iOS
{
	public partial class SeismicListViewController : UIViewController
	{
		public SeismicListViewController () : base ("SeismicListViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			Title = "Seismic Activity";

			var listVM = new SeismicEventsListViewModel ();
			listView.Source = new SeismicListDataSource (listVM, this.NavigationController);
			listVM.PropertyChanged += (sender, e) => {if (e.PropertyName == "Events") listView.ReloadData ();};

			refreshButton.TouchUpInside += (sender, e) => listVM.RefreshCommand.Execute (null);
		}
	}

}

