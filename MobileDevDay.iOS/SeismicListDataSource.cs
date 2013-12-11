//
// SeismicListDataSource.cs
//
// Author:
//       Stephane Delcroix <stephane@mi8.be>
//
// Copyright (c) 2013 mobile inception
//

using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MobDevDay;

namespace MobileDevDay.iOS
{

	public class SeismicListDataSource : UITableViewSource
	{
		string cellId = "cellID";
		SeismicEventsListViewModel listVM;
		UINavigationController navigationController;

		public SeismicListDataSource (SeismicEventsListViewModel listVM, UINavigationController navigationController)
		{
			this.listVM = listVM;
			this.navigationController = navigationController;
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

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var item = listVM.Events [indexPath.Row];
			navigationController.PushViewController (new EventViewController (item), true); 
		}
	}
}
