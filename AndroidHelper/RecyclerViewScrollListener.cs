using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace AndroidHelper
{
    public class RecyclerViewScrollListener : RecyclerView.OnScrollListener
    {

        //private LinearLayoutManager LayoutManager;
        public int OriginalY { get; set; }

        public delegate void OnMaxTopScrollHandler(object sender, EventArgs e);
        public delegate void OnScollDownHandler(object sender, EventArgs e);

        public event OnMaxTopScrollHandler OnMaxTopScrollEvent;
        public event OnScollDownHandler OnScrollDownEvent;

        public RecyclerViewScrollListener(int originalY)
        {
            //LayoutManager = lm;
            OriginalY = originalY;
        }

        public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
        {
            base.OnScrolled(recyclerView, dx, dy);

            if(dy>0)
            {
                //scrolled down
                OnScrollDownEvent(this, null);
                //Console.WriteLine(string.Format("dn dy={0}", dy));
            }
            else if(recyclerView.GetChildAt(0).Top == 0)
            {
                //scrolled up
                OnMaxTopScrollEvent(this, null);
                //Console.WriteLine(string.Format("up dy={0}", dy));
            }

        }
    }
}