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

namespace daijoubu_app
{
    public class FragHome : Android.Support.V4.App.Fragment
    {
        private RecyclerView mRecyclerView;
        private RecyclerView.LayoutManager mLayoutManager;
        private RecyclerView.Adapter mAdapter;

        private List<AndroidHelper.CardViewHelper> Cards;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
           
            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.Home, container, false);

            //test codes
            Button testb = view.FindViewById<Button>(Resource.Id.button_test);
            testb.Click += Testb_Click;


            //Create Notigication Card recylcer biew
            mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.layout_main_recycler);

            mLayoutManager = new LinearLayoutManager(Application.Context);
            Cards = new List<AndroidHelper.CardViewHelper>();

            //create tmp cards
            Cards.Add(new AndroidHelper.CardViewHelper()
            {
                Title = "hi", SubTitle = "hello"
            });
            Cards.Add(new AndroidHelper.CardViewHelper()
            {
                Title = "hi2",
                SubTitle = "hello2"
            });

            mAdapter = new AndroidHelper.RecyclerHelper(Cards);

            mRecyclerView.SetLayoutManager(mLayoutManager);
            mRecyclerView.SetAdapter(mAdapter);

            return view;

        }

       


        private void Testb_Click(object sender, EventArgs e)
        {
            Toast.MakeText(Application.Context, "cheers!", ToastLength.Long).Show();
        }
    }
}