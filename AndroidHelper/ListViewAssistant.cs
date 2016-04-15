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

namespace AndroidHelper
{
    public class ListViewAssistant
    {
        Context _context;

        List<string> lvItems;
        ListViewAdapter<string> adapter;

        ListView _listview;

        public ListViewAssistant(Context context, ListView lv)
        {
            _context = context;
            _listview = lv;

            lvItems = new List<string>();
            lvItems.Add("Home");
            lvItems.Add("Multiple Choise");
            //lvItems.Add("Profile");
            //lvItems.Add("Exit");

            adapter = new ListViewAdapter<string>(_context, lvItems);
            _listview.Adapter = adapter;

            
            
        }

        private void _listview_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        public EventHandler<AdapterView.ItemClickEventArgs> ItemClick {
            set
            {
                _listview.ItemClick += value;
            }
            get
            {
                return null;
            }
        }


    }
}