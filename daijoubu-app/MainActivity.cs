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
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using Android.Support.V4.Widget;
using Android.Support.V7.App;

namespace daijoubu_app
{
   [Activity(Label = "daijoubu_app", Theme="@style/MainTheme")]
    public class MainActivity : ActionBarActivity
    {

        private SupportToolbar mToolbar;
        private MyActionBarDrawerToggle mDrawerToggle;
        private DrawerLayout mDrawerLayout;
        private ListView mLeftDrawer;
        ListViewAssistant ListviewAssistant;

        FragmentHelper MainFragment;
        SupportFragmentManager SFragmanager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            

            //toolbar
            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);

            //init leftdrawer items here ####
            ListviewAssistant = new ListViewAssistant(this, mLeftDrawer);

           
            //make sure fragment is init
            // add all the possible fragments
            MainFragment = new FragmentHelper(new FragHome(),"FragHome", Resource.Id.FragmentContainer);
            MainFragment.Add(new FragAbout(), "FragAbout");
            MainFragment.Add(new FragModule(), "FragModule");
            MainFragment.Add(new FragProfile(), "FragProfile");
            MainFragment.Add(new FragSettings(), "FragSettings");
            MainFragment.FinalizeAdd(SupportFragmentManager.BeginTransaction());
            //Manage The fragment here
            ListviewAssistant.ItemClick += ListviewAssistant_ItemClick;

                      SetSupportActionBar(mToolbar);

            mDrawerToggle = new MyActionBarDrawerToggle(this, mDrawerLayout,
                Resource.String.openDrawer,     //top bar title when string is opened
                Resource.String.ApplicationName //top bar title when closed
                );

            mDrawerLayout.SetDrawerListener(mDrawerToggle);
            //SupportActionBar.SetTitle(Resource.String.ApplicationName);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true); //this replace the next' lines code because it is depreciated in 22 
            //SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            mDrawerToggle.SyncState();

            if(bundle != null) //first time
            {
                if(bundle.GetString("DrawerState") == "Opened")
                {
                    SupportActionBar.SetTitle(Resource.String.openDrawer);
                }
                else
                {
                    SupportActionBar.SetTitle(Resource.String.ApplicationName);
                }
            }
            else
            {
                SupportActionBar.SetTitle(Resource.String.ApplicationName);
            }
        }

        /// <summary>
        /// this is where the action bar clicks are handled
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            mDrawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }

        /// <summary>
        /// Saved the current state of the app
        /// usefull when handling screen orientation as it kind of
        /// restarts the whole activity
        /// </summary>
        /// <param name="outState"> i have no  idea what this is --noli </param>
        protected override void OnSaveInstanceState(Bundle outState)
        {
            if (mDrawerLayout.IsDrawerOpen((int)GravityFlags.Left))
            {
                outState.PutString("DrawerState", "Opened");
            }
            else
            {
                outState.PutString("DrawerState", "Closed");
            }
            base.OnSaveInstanceState(outState);
        }

        /// <summary>
        /// Tutorial #48-49 says that just do this
        /// </summary>
        protected override void OnPostCreate(Bundle savedInstanceState)
        {

            base.OnPostCreate(savedInstanceState);
            mDrawerToggle.SyncState();
        }

        /// <summary>
        /// Handle the left navigation bar clicks over here
        /// </summary>
        private void ListviewAssistant_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            switch (e.Position)
            {
                case 0:
                    MainFragment.Switch(SupportFragmentManager.BeginTransaction(), "FragHome");  
                    break;
                case 1:
                    MainFragment.Switch(SupportFragmentManager.BeginTransaction(), "FragProfile");
                    break; 
                case 2:
                    MainFragment.Switch(SupportFragmentManager.BeginTransaction(), "FragModule");
                    break;
                case 3:
                    MainFragment.Switch(SupportFragmentManager.BeginTransaction(), "FragSettings");
                    break;
                case 4:
                    MainFragment.Switch(SupportFragmentManager.BeginTransaction(), "FragAbout");
                    break;
            }

            // (done) close drawer toggle when a list item is clicked
            mDrawerLayout.CloseDrawers();
        }

    }
}

