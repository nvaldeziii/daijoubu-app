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

using SupportFragment = Android.Support.V4.App.Fragment;
using SupportTransaction = Android.Support.V4.App.FragmentTransaction;

namespace AndroidHelper
{
    public class FragmentHelper
    {
        int FrameContainer;
        int CurrentFrag;

        List<SupportFragment> FragContainer;
        List<string> FragTag;

        public FragmentHelper(SupportFragment initialfrag, string tag,int container)
        {

            FragContainer = new List<SupportFragment>();
            FragTag = new List<string>();

            FrameContainer = container;

            FragContainer.Add(initialfrag);
            FragTag.Add(tag);

            CurrentFrag = 0;
         
        }

        public void Add(SupportFragment frag, string tag)
        {
            FragContainer.Add(frag);
            FragTag.Add(tag); 
        }

        public void FinalizeAdd(SupportTransaction m)
        {
            SupportTransaction Transaction = m;
            for(int i = 0; i < FragContainer.Count; i++)
            {
                Transaction.Add(FrameContainer, FragContainer[i], FragTag[i]);
                Transaction.Hide(FragContainer[i]);
            }
            Transaction.Show(FragContainer[CurrentFrag]);
            Transaction.Commit();
        }

        public void Replace(SupportFragment frag,SupportTransaction m)
        {
            if (frag.IsVisible)
            {
                return;
            }

            FragContainer[CurrentFrag] = frag;

            SupportTransaction trans = m;
            trans.Replace(FrameContainer, FragContainer[CurrentFrag]);
            trans.Commit();

            
        }

        public void Switch(SupportTransaction m, string tag)
        {
            SupportTransaction Transaction = m;

            Transaction.Hide(FragContainer[CurrentFrag]);
            Transaction.Show(FragContainer[FragTag.IndexOf(tag)]);
            CurrentFrag = FragTag.IndexOf(tag);
            Transaction.Commit();
           
        }

        public void Switch(SupportTransaction m,string tag, bool IsAddToStack)
        {
            SupportTransaction Transaction = m;

            Transaction.Hide(FragContainer[CurrentFrag]);
            Transaction.Show(FragContainer[FragTag.IndexOf(tag)]);
            CurrentFrag = FragTag.IndexOf(tag);
            if (IsAddToStack)
            {
                Transaction.AddToBackStack(null);
            }
            Transaction.Commit();
            
        }
    }
}