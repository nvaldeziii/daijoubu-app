using Android.Content;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Views;

using Android.App;

using Android.Runtime;

using Android.OS;
using Android.Graphics;

namespace AndroidHelper
{
    public class ListViewAdapter<T> : BaseAdapter<T>
    {
        Context context;
        List<T> items;
        List<string> FontAwesome;

   

        public ListViewAdapter(Context c, List<T> listitem)
        {
            items = listitem;
            context = c;
        }

        public ListViewAdapter(Context context, List<T> items, List<string> fontawesome, Context c)
        {
            this.items = items;
            this.context = c;
            if(this.items.Count == fontawesome.Count)
            {
                FontAwesome = fontawesome;
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.listview, null, false);
            }
            TextView item = row.FindViewById<TextView>(Resource.Id.ListItem);
            TextView fa = row.FindViewById<TextView>(Resource.Id.ListItem_fa);

            item.Text = items[position].ToString();
            if (FontAwesome != null)
            {

                Typeface font = Typeface.CreateFromAsset(context.Assets, "FontAwesome.ttf");
                fa.Text = FontAwesome[position];
                fa.SetTypeface(font, TypefaceStyle.Normal);
            }
            else
            {
                fa.Text = " ";
                //fa.Visibility = Android.Views.ViewStates.Gone;
            }
            return row;
        }

        

        #region Required
        public override T this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        #endregion

    }


}
