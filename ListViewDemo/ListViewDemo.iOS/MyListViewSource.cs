using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;

namespace ListViewDemo.iOS
{
    public class MyListViewSource : UITableViewSource
    {

        List<bool> isExpanded = new List<bool>();
        MyListView listView;

        public MyListViewSource(MyListView view)
        {

            for(int i=0; i<10; i++)
            {
                isExpanded.Add(false);
            }
            listView = view;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {

            MyListViewCell cell = tableView.DequeueReusableCell("Cell") as MyListViewCell;

            if (cell == null)
            {
                cell = new MyListViewCell(new NSString("Cell"));

                cell.RefreshEvent += (refreshCell, isOn) =>
                {
                    NSIndexPath index = tableView.IndexPathForCell(refreshCell);
                    isExpanded[index.Row] = isOn;
                    tableView.ReloadRows(new NSIndexPath[] { index }, UITableViewRowAnimation.Automatic);
                };
            }

            cell.switchBtn.On = isExpanded[indexPath.Row];

            return cell;
        }

        

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return isExpanded.Count;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            if (isExpanded[indexPath.Row])
            {
                return 80;
            }
            return 40;
        }
    }
}
