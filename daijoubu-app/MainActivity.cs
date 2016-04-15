﻿using System;
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
        ListViewAssistant ListviewAssistant;
        FragmentTransaction Frag;

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
            Frag = FragmentManager.BeginTransaction();
            Frag.Add(Resource.Id.FragmentContainer, new HomeFrag(), "HomeFrag");
            Frag.Commit();

            //Manage The fragment here
            ListviewAssistant.ItemClick += ListviewAssistant_ItemClick;

                      SetSupportActionBar(mToolbar);

            mDrawerToggle = new MyActionBarDrawerToggle(this, mDrawerLayout,
                Resource.String.openDrawer,     //top bar title when string is opened
                Resource.String.ApplicationName //top bar title when closed
                );

            mDrawerLayout.SetDrawerListener(mDrawerToggle);
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


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            mDrawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }

        /// <summary>
        /// Saved state
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

        protected override void OnPostCreate(Bundle savedInstanceState)
        {

            base.OnPostCreate(savedInstanceState);
            mDrawerToggle.SyncState();
        }

        private void ListviewAssistant_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //lvItems.Add("Home");
            //lvItems.Add("Multiple Choise");
            //lvItems.Add("Profile");
            Console.WriteLine(string.Format("PRESSED KEY!!! -->  {0}", e.Position));
            switch (e.Position)
            {
                case 0:
                    MainFragmentChanger(new HomeFrag());
                    
                    break;
                case 1:
                    MainFragmentChanger(new ModuleFrag());
                    break;
                case 2:
                    break;
            }

            // (done) close drawer toggle when a list item is clicked
            mDrawerLayout.CloseDrawers();
        }

        private void MainFragmentChanger(Fragment newFrag)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();

            transaction.Replace(Resource.Id.FragmentContainer, newFrag);
            transaction.AddToBackStack(null);
            transaction.Commit();
        }
    }
}

