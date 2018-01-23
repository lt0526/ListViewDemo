using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace ListViewDemo.iOS
{
    public class MyListViewCell : UITableViewCell
    {

        public UISwitch switchBtn;


        public delegate void RefreshHanle(MyListViewCell cell, bool isOn);
        public event RefreshHanle RefreshEvent;

        public MyListViewCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Gray;


            switchBtn = new UISwitch();
            switchBtn.AddTarget((sender, args) =>
            {
                UISwitch mySwitch = sender as UISwitch;
                RefreshEvent(this, mySwitch.On);
            }, UIControlEvent.ValueChanged);


            switchBtn.TranslatesAutoresizingMaskIntoConstraints = false;

            ContentView.Add(switchBtn);

            this.ContentView.AddConstraint(NSLayoutConstraint.Create(switchBtn, NSLayoutAttribute.Left, NSLayoutRelation.Equal, this.ContentView, NSLayoutAttribute.Left, 1, 0));
            this.ContentView.AddConstraint(NSLayoutConstraint.Create(switchBtn, NSLayoutAttribute.Right, NSLayoutRelation.Equal, this.ContentView, NSLayoutAttribute.Right, 1, 0));
            this.ContentView.AddConstraint(NSLayoutConstraint.Create(switchBtn, NSLayoutAttribute.Top, NSLayoutRelation.Equal, this.ContentView, NSLayoutAttribute.Top, 1, 0));
            this.ContentView.AddConstraint(NSLayoutConstraint.Create(switchBtn, NSLayoutAttribute.Bottom, NSLayoutRelation.GreaterThanOrEqual, this.ContentView, NSLayoutAttribute.Bottom, 1, 0));
  
        }

        
    }
}