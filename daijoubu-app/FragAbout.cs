using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.Reflection;

namespace daijoubu_app
{
    public class FragAbout : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.About, container, false);

            //beautify this...
            TextView VersionInfo = view.FindViewById<TextView>(Resource.Id.textView_about_versioninfo);

            VersionInfo.Text = string.Format( VersionInfo.Text, Assembly.GetExecutingAssembly().GetName().Version.ToString() );

            //int _major = Assembly.GetExecutingAssembly().GetName().Version.Major;
            //int _minor = Assembly.GetExecutingAssembly().GetName().Version.Minor;
            int _build = Assembly.GetExecutingAssembly().GetName().Version.Build;
            int _rev = Assembly.GetExecutingAssembly().GetName().Version.Revision;

            DateTime startDate = new DateTime(2000, 1, 1);

            DateTime computedDate = startDate.AddDays(_build).AddSeconds(_rev*2);

            TextView builddate = view.FindViewById<TextView>(Resource.Id.textView_about_builddate);
            builddate.Text = string.Format("Build Date: {0} \nTime: {1}", computedDate.ToLongDateString(), computedDate.ToLongTimeString());

            return view;
        }
    }
}