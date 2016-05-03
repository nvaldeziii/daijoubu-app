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
using Android.Support.V7.Widget;

namespace AndroidHelper
{
    public class CardListHelper<T>
    {
        private List<T> Items;
        private RecyclerView.Adapter mAdapter;

        public CardListHelper()
        {
            Items = new List<T>();
        }

        public RecyclerView.Adapter Adapter { get { return mAdapter; } set { mAdapter = value; } }

        public void Add(T item)
        {
            Items.Add(item);
            if (Adapter != null)
            {
                Adapter.NotifyItemInserted(0);
            }
        }

        public void Remove(int position)
        {
            Items.RemoveAt(position);
            if (Adapter != null)
            {
                Adapter.NotifyItemRemoved(position);
            }
        }

        public void RemoveSpecific(T i)
        {

            if (Items.Remove(i))
            {
                if (Adapter != null)
                {
                    Adapter.NotifyDataSetChanged();
                }
            }

        }

        public void Sort()
        {
            Items.Sort();
            if (Adapter != null)
            {
                Adapter.NotifyDataSetChanged();
            }
        }

        public T this[int position]
        {
            get { return Items[position]; }
            set { Items[position] = value; }
        }

        public int Count
        {
            get { return Items.Count; }
        }

    }
}