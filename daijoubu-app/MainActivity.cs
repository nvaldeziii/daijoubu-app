using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using AndroidHelper;

namespace daijoubu_app
{
    [Activity(Label = "daijoubu_app", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            //hard coded
            SetContentView(Resource.Layout.Menu);
            ListView Listview_Menu = FindViewById<ListView>(Resource.Id.listView_menu);
            Listview_Menu.ItemClick += Listview_Menu_ItemClick;

            List<string> lvItems = new List<string>();
            lvItems.Add("Home");
            lvItems.Add("Multiple Choise");
            lvItems.Add("Profile");
            lvItems.Add("Exit");

            ListViewAdapter<string> adapter = new ListViewAdapter<string>(this, lvItems);
            Listview_Menu.Adapter = adapter;
            ///////////// --end hard code


        }

        private void Listview_Menu_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            switch(e.Position)
            {
                case 0:
                    SetContentView(Resource.Layout.Main);
                    break;
                case 1:
                    SetContentView(Resource.Layout.Module_MultipleChoise);
                    break;
                case 2:
                    SetContentView(Resource.Layout.Profile);
                    break;
                case 3:
                    Intent main = new Intent(Intent.ActionMain);
                    main.AddCategory(Intent.CategoryHome);
                    StartActivity(main);
                    break;
            }
        }
    }
}

