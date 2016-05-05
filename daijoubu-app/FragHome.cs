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
        private RecyclerViewScrollListener RecyclerviewScrollListener;

        private RecyclerView.LayoutManager mLayoutManager;
        private RecyclerView.Adapter mAdapter;

        private ImageView TopCover;
        private RelativeLayout TopLayout;
        private LinearLayout ProgressLayout;
        private Button btn;
        private View v;

        private bool CoverVisible;
        private bool CoverAnimating;

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

            ////cover test
            TopCover = view.FindViewById<ImageView>(Resource.Id.imageView_home_topcover);
            TopLayout = view.FindViewById<RelativeLayout>(Resource.Id.layout_home_reltopcover);
            ProgressLayout = view.FindViewById<LinearLayout>(Resource.Id.linearLayout_home_progress);
            btn = view.FindViewById<Button>(Resource.Id.button_addcard);
            v = view.FindViewById<View>(Resource.Id.view_home_layoutseparator1);

            CoverVisible = true;

            mLayoutManager = new LinearLayoutManager(Application.Context);
            Cards = new CardListHelper<CardViewHelper>();


            mAdapter = new AndroidHelper.CardRecyclerHelper(Cards, mRecyclerView);
            Cards.Adapter = mAdapter;

            mRecyclerView.SetLayoutManager(mLayoutManager);
            mRecyclerView.SetAdapter(mAdapter);

            //custom scroll events https://gist.github.com/martijn00/a45a238c5452a273e602
            RecyclerviewScrollListener = new RecyclerViewScrollListener(mRecyclerView.ScrollY);
            mRecyclerView.AddOnScrollListener(RecyclerviewScrollListener);
            RecyclerviewScrollListener.OnMaxTopScrollEvent += RecyclerviewScrollListener_OnMaxTopScrollEvent;
            RecyclerviewScrollListener.OnScrollDownEvent += RecyclerviewScrollListener_OnScrollDownEvent;


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

        

        private void RecyclerviewScrollListener_OnScrollDownEvent(object sender, EventArgs e)
        {
            if (CoverVisible)
            {
                TranslatePosition(-TopCover.Height, false);
                Toast.MakeText(Application.Context.ApplicationContext, "Reached Top", ToastLength.Short);
            }
            //scrolled top
        }

        private void RecyclerviewScrollListener_OnMaxTopScrollEvent(object sender, EventArgs e)
        {
            if (!CoverVisible)
            {
                TranslatePosition(0, true);
            }
        }

        private void TopLayout_Animation_AnimationEnd(object sender, Android.Views.Animations.Animation.AnimationEndEventArgs e)
        {
            //Console.WriteLine(string.Format("cover animating={0}", CoverAnimating));
            CoverAnimating = false;
            Console.WriteLine(string.Format("cover animating={0} || anim end called", CoverAnimating));
        }

        private void TranslatePosition(int translation, bool visibility)
        {
            //if (!CoverAnimating)
            {
                Console.WriteLine(string.Format("up cover animating={0} ||trans start", CoverAnimating));
                CoverAnimating = true;


                TopLayout.Animate().TranslationY(translation).SetDuration(500).Start();
                mRecyclerView.Animate().TranslationY(translation).SetDuration(500).Start();
                mRecyclerView.RequestLayout();

                btn.Animate().TranslationY(translation).SetDuration(500).Start();
                v.Animate().TranslationY(translation).SetDuration(500).Start();
                ProgressLayout.Animate().TranslationY(translation).SetDuration(500).Start();

                TopLayout.AnimationEnd += TopLayout_Animation_AnimationEnd;


                //ViewGroup.LayoutParams param = WholeLayout.LayoutParameters;
                //param.Height += translation;
                //WholeLayout.LayoutParameters = param;

                CoverVisible = visibility;
                Console.WriteLine(string.Format("up cover animating={0}  || trans end", CoverAnimating));
            }
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