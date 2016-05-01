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

namespace AndroidHelper
{
    public class CardViewHelper
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Time { get; set; }
        public bool Seen { get; set; }
        public bool NewCard {get; set;}

        public CardViewHelper()
        {
            
        }
    }
}