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
    public class RecyclerHelper : RecyclerView.Adapter
    {
        private List<CardViewHelper> Cards;

        public RecyclerHelper(List<CardViewHelper> ncards)
        {
            Cards = ncards;
        }

        public override int ItemCount
        {
            get
            {
                return Cards.Count;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyView myHolder = holder as MyView;

            myHolder.tvTitle.Text = Cards[position].Title;
            myHolder.tvSubTitle.Text = Cards[position].SubTitle;
            myHolder.tvTime.Text = Cards[position].Time;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.CardView_proto,parent,false);

            TextView Title = row.FindViewById<TextView>(Resource.Id.cardview_textView_main);
            TextView Subtitle = row.FindViewById<TextView>(Resource.Id.cardview_textView_subtitle);
            TextView Time = row.FindViewById<TextView>(Resource.Id.cardview_textView_timestamp);

            MyView view = new MyView(row)
            {
                tvTitle = Title, tvSubTitle = Subtitle, tvTime = Time
            };

            return view;

        }

        public class MyView : RecyclerView.ViewHolder
        {
            public View mMainView { get; set; }
            public TextView tvTitle { get; set; }
            public TextView tvSubTitle { get; set; }
            public TextView tvTime { get; set; }
            public Button btnCheck { get; set; }
            public Button btnTrash { get; set; }

            public  MyView(View view) : base(view)
            {
                mMainView = view;
            }
        }

    }
}