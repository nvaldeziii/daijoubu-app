using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using AndroidHelper;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.Widget;
using Android.Support.V7.App;

namespace daijoubu_app
{
    [Activity(Label = "daijoubu_app", MainLauncher = true, Icon = "@drawable/icon", Theme="@style/MainTheme")]
    public class MainActivity : ActionBarActivity
    {

        private SupportToolbar mToolbar;
        private MyActionBarDrawerToggle mDrawerToggle;
        private DrawerLayout mDrawerLayout;
        private ListView mLeftDrawer;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //FragmentTransaction Frag = FragmentManager.BeginTransaction();
            //Frag.Add(Resource.Id.FragmentContainer, new MenuFrag(this), "MenuFrag");
            //Frag.Commit();

            //toolbar
            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);

            SetSupportActionBar(mToolbar);

            mDrawerToggle = new MyActionBarDrawerToggle(this, mDrawerLayout, Resource.String.openDrawer, Resource.String.closeDrawer);

            mDrawerLayout.SetDrawerListener(mDrawerToggle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            //SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            mDrawerToggle.SyncState();
        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            mDrawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }
    }
}

