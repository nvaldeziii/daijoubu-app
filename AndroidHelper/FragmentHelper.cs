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

        /// <summary>
        /// Simplify handling of fragments
        /// </summary>
        /// <param name="initialfrag">The first Fragment to load</param>
        /// <param name="tag">Name of the fragment</param>
        /// <param name="container">Container to put the fragment in this handler</param>
        public FragmentHelper(SupportFragment initialfrag, string tag,int container)
        {

            FragContainer = new List<SupportFragment>();
            FragTag = new List<string>();

            FrameContainer = container;

            FragContainer.Add(initialfrag);
            FragTag.Add(tag);

            CurrentFrag = 0;
         
        }

        /// <summary>
        /// Add a fragment to the list
        /// </summary>
        /// <param name="frag">the fragment to add</param>
        /// <param name="tag">name of the fragment</param>
        public void Add(SupportFragment frag, string tag)
        {
            FragContainer.Add(frag);
            FragTag.Add(tag); 
        }

        /// <summary>
        /// Finalize the addition of fragments
        /// </summary>
        /// <param name="m">pass a transaction</param>
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

        /// <summary>
        /// replace the current fragment in the Fragment Container
        /// </summary>
        /// <param name="frag">The fragment to replace</param>
        /// <param name="m">Pass a Support Transaction</param>
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

        /// <summary>
        /// Switch a fragment from the list
        /// </summary>
        /// <param name="m"> pass a transaction </param>
        /// <param name="tag">name of the tag from the list</param>
        public void Switch(SupportTransaction m, string tag)
        {
            SupportTransaction Transaction = m;

            if(FragContainer[CurrentFrag] != null)
                Transaction.Hide(FragContainer[CurrentFrag]);

            Transaction.Show(FragContainer[FragTag.IndexOf(tag)]);
            CurrentFrag = FragTag.IndexOf(tag);
            Transaction.Commit();
           
        }
        /// <summary>
        /// Switch a fragment from the list
        /// </summary>
        /// <param name="m"> pass a transaction </param>
        /// <param name="tag">name of the tag from the list</param>
        /// <param name="IsAddToStack"> if the previous fragment will be added to stack </param>
        public void Switch(SupportTransaction m,string tag, bool IsAddToStack)
        {
            SupportTransaction Transaction = m;
            if (FragContainer[CurrentFrag] != null)
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