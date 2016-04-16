
/*
 * Unused for now
 * 
 * will try to implement this feature later.
 * 
 */ 

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

using AndroidHelper;

namespace daijoubu_app
{
    public class FragMenu : Fragment
    {
        private View FragView;

        Context _context;
        public FragMenu(Context context)
        {
            _context = context;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            
            FragView = inflater.Inflate(Resource.Layout.Menu, container, false);

            ListView Listview_Menu = FragView.FindViewById<ListView>(Resource.Id.listView_menu);
       

            List<string> lvItems = new List<string>();
            lvItems.Add("Home");
            lvItems.Add("Multiple Choise");
            lvItems.Add("Profile");
            lvItems.Add("Exit");

            ListViewAdapter<string> adapter = new ListViewAdapter<string>(_context, lvItems);
            Listview_Menu.Adapter = adapter;

            return FragView;
        }

      
    }
}