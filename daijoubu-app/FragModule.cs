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

using SupportFragment = Android.Support.V4.App.Fragment;
using SupportTransaction = Android.Support.V4.App.FragmentTransaction;

namespace daijoubu_app
{
    public class FragModule : Android.Support.V4.App.Fragment
    {
        private FrameLayout FragContainer;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Module_Home, container, false);

            Button btn1 = view.FindViewById<Button>(Resource.Id.button1);
            Button btn2 = view.FindViewById<Button>(Resource.Id.button2);
            Button btn3 = view.FindViewById<Button>(Resource.Id.button3);

            FragContainer = view.FindViewById<FrameLayout>(Resource.Id.FragmentChildContainer);

            var trans = ChildFragmentManager.BeginTransaction();
            trans.Add(FragContainer.Id, new FragModuleMultipleChoise(), "FragModuleListening");
            
            trans.Commit();

            btn1.Click += delegate { ChildFragReplace(new FragModuleListening(), "FragModuleListening"); };
            btn2.Click += delegate { ChildFragReplace(new FragModuleMultipleChoise(), "FragModuleMultipleChoise"); };
            btn3.Click += delegate { ChildFragReplace(new FragModuleTyping(), "FragModuleTyping"); };

            return view;
            
        }

  

        public void ChildFragReplace(SupportFragment frag, string tag)
        {
            if (frag.IsVisible)
            {
                return;
            }

            var trans = ChildFragmentManager.BeginTransaction();
            trans.Replace(FragContainer.Id, frag);
            trans.Commit();

        }
    }
}