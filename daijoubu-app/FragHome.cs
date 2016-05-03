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
using Android.Graphics;
using Android.Support.V7.Widget;
using AndroidHelper;

namespace daijoubu_app
{
    public class FragHome : Android.Support.V4.App.Fragment
    {
        private RecyclerView mRecyclerView;
        private RecyclerView.LayoutManager mLayoutManager;
        private RecyclerView.Adapter mAdapter;

        private CardListHelper<CardViewHelper> Cards;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here


        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.Home, container, false);

            //Create Notigication Card recylcer biew
            mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.layout_main_recycler);

            mLayoutManager = new LinearLayoutManager(Application.Context);
            Cards = new CardListHelper<CardViewHelper>();
            

            mAdapter = new AndroidHelper.CardRecyclerHelper(Cards, mRecyclerView);
            Cards.Adapter = mAdapter;

            mRecyclerView.SetLayoutManager(mLayoutManager);
            mRecyclerView.SetAdapter(mAdapter);


            Cards.Add(new CardViewHelper() { Title = string.Format("hello {0}", Cards.Count), SubTitle = string.Format("hello card {0}", Cards.Count), Time = DateTime.Now.ToLocalTime().ToString() });
            Cards.Add(new CardViewHelper() { Title = string.Format("hello {0}", Cards.Count), SubTitle = string.Format("hello card {0}", Cards.Count), Time = DateTime.Now.ToLocalTime().ToString() });
            Cards.Add(new CardViewHelper() { Title = string.Format("hello {0}", Cards.Count), SubTitle = string.Format("hello card {0}", Cards.Count), Time = DateTime.Now.ToLocalTime().ToString() });

            //tmp button to add cards
            Button btnadd = view.FindViewById<Button>(Resource.Id.button_addcard);
            btnadd.Click += (o, e) =>
            {
                Cards.Add(new CardViewHelper() { Title = string.Format("hello {0}", Cards.Count), SubTitle = string.Format("hello card {0}", Cards.Count), Time = DateTime.Now.ToLocalTime().ToString() });
           
            };

            return view;

        }

        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    switch (item.ItemId)
        //    {
        //        case Resource.Id.cardview_button_check:
        //            Cards.Add(new AndroidHelper.CardViewHelper() { Title="added", SubTitle="why", Time="Just Now" });
        //            mAdapter.NotifyDataSetChanged();
        //            return true;
        //        case Resource.Id.cardview_button_trash:
        //            Cards.RemoveAt(Cards.Count - 1);
        //            mAdapter.NotifyDataSetChanged();

        //            return true;
        //        default:
        //            return base.OnOptionsItemSelected(item);
        //    }
        //}

    }
}