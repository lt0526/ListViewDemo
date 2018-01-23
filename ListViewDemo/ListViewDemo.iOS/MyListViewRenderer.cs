using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using ListViewDemo;
using ListViewDemo.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyListView), typeof(MyListViewRenderer))]
namespace ListViewDemo.iOS
{
    public class MyListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                
                Control.Source = new MyListViewSource(e.NewElement as MyListView);

            }
        }
    }
}