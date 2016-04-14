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


namespace AndroidHelper
{
    public class ListViewAdapter<T> : BaseAdapter<T>
    {
        Context _context;
        List<T> _items;

        public ListViewAdapter(Context context, List<T> items)
        {
            _items = items;
            _context = context;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(_context).Inflate(Resource.Layout.listview, null, false);
            }
            TextView item = row.FindViewById<TextView>(Resource.Id.ListItem);
            item.Text = _items[position].ToString();

            return row;
        }

        #region Required
        public override T this[int position]
        {
            get
            {
                return _items[position];
            }
        }

        public override int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        #endregion

    }


}
