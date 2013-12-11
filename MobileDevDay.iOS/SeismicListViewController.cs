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
			var listVM = new SeismicEventsListViewModel ();
			listView.Source = new SeismicListDataSource (listVM);
			refreshButton.TouchUpInside += (sender, e) => listVM.RefreshCommand.Execute (null);
			listVM.PropertyChanged += (sender, e) => {if (e.PropertyName == "Events") listView.ReloadData ();};
			Title = "Seismic Activity";
		}
	}

	public class SeismicListDataSource : UITableViewSource
	{
		string cellId = "cellID";
		SeismicEventsListViewModel listVM;
		public SeismicListDataSource (SeismicEventsListViewModel listVM)
		{
			this.listVM = listVM;
		}

		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			if (listVM.Events == null)
				return 0;
			return listVM.Events.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellId);
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellId);
			var item = listVM.Events [indexPath.Row];
			cell.TextLabel.Text = item.Title;

			return cell;
		}
	}
}

