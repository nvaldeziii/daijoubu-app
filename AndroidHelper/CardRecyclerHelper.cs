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
using Android.Graphics;

namespace AndroidHelper
{
    public class CardRecyclerHelper : RecyclerView.Adapter
    {
        private CardListHelper<CardViewHelper> Cards;
        private const string FontAwesomFilename = "FontAwesome.ttf";
        private RecyclerView mRecyclerView;

        public CardRecyclerHelper(CardListHelper<CardViewHelper> ncards, RecyclerView recyclerView)
        {
            Cards = ncards;
            mRecyclerView = recyclerView;
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

            int IndexPosition = (Cards.Count - 1) - position;

            myHolder.tvTitle.Text = Cards[IndexPosition].Title;
            myHolder.tvSubTitle.Text = Cards[IndexPosition].SubTitle;
            myHolder.tvTime.Text = Cards[IndexPosition].Time;

            
     
        }

       

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.CardView_proto,parent,false);

            TextView Title = row.FindViewById<TextView>(Resource.Id.cardview_textView_main);
            TextView Subtitle = row.FindViewById<TextView>(Resource.Id.cardview_textView_subtitle);//sum ting wong
            TextView Time = row.FindViewById<TextView>(Resource.Id.cardview_textView_timestamp);

            Button buttonCheck = row.FindViewById<Button>(Resource.Id.cardview_button_check);
            Button buttonTrash = row.FindViewById<Button>(Resource.Id.cardview_button_trash);

            //enable fontawesome
            Typeface font = Typeface.CreateFromAsset(Application.Context.Assets, FontAwesomFilename );
            buttonCheck.SetTypeface(font, TypefaceStyle.Normal);
            buttonTrash.SetTypeface(font, TypefaceStyle.Normal);

            MyView view = new MyView(row)
            {
                tvTitle = Title, tvSubTitle = Subtitle, tvTime = Time
            };

            view.mMainView.Click += MMainView_Click;
            //test

            return view;

        }

        private void MMainView_Click(object sender, EventArgs e)
        {
            int IndexPosition = (Cards.Count - 1) - mRecyclerView.GetChildPosition((View)sender);
            Console.WriteLine("  1pos: " + Cards[IndexPosition].Title);

            Cards.RemoveSpecific(Cards[IndexPosition]);
            Toast.MakeText(Application.Context, string.Format("card {0} is removed", IndexPosition), ToastLength.Short);
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