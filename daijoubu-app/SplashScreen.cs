using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace daijoubu_app
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher =true,NoHistory =true)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Thread.Sleep(4000);
            StartActivity(typeof(MainActivity));
        }
    }
}