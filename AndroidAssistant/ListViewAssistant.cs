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
using AndroidHelper;

namespace AndroidAssistant//we will use android helper namespace since the assistant mainly uses helper 
{
    public class ListViewAssistant
    {
        Context context;

        List<string> ListViewItems;
        List<string> ListView_FontAwesome;

        ListViewAdapter<string> adapter;

        ListView _listview;

        public ListViewAssistant(Context c, ListView lv)
        {
            context = c;
            _listview = lv;

            ListViewItems = new List<string>();
            ListView_FontAwesome = new List<string>();

            ListViewItems.Add(context.Resources.GetString(Resource.String.listview_home));
            ListView_FontAwesome.Add( context.Resources.GetString(Resource.String.listview_fa_home) );

            ListViewItems.Add(context.Resources.GetString(Resource.String.listview_profile));
            ListView_FontAwesome.Add(context.Resources.GetString(Resource.String.listview_fa_profile));

            ListViewItems.Add(context.Resources.GetString(Resource.String.listview_module));
            ListView_FontAwesome.Add(context.Resources.GetString(Resource.String.listview_fa_module));

            ListViewItems.Add(context.Resources.GetString(Resource.String.listview_settings));
            ListView_FontAwesome.Add(context.Resources.GetString(Resource.String.listview_fa_settings));

            ListViewItems.Add(context.Resources.GetString(Resource.String.listview_about));
            ListView_FontAwesome.Add(context.Resources.GetString(Resource.String.listview_fa_about));

            adapter = new ListViewAdapter<string>(context, ListViewItems,ListView_FontAwesome,context);
            _listview.Adapter = adapter;



        }

        public EventHandler<AdapterView.ItemClickEventArgs> ItemClick
        {
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