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
using System.Text.RegularExpressions;

namespace AndroidHelper
{
    public static class StringHelper
    {
        /// <summary>
        /// returns true if the string contains only alphabet, space, and number
        /// </summary>
        /// <returns></returns>
        public static bool IsEnglishSpeakable(String str)
        {
            return Regex.IsMatch(str, @"^[a-z A-Z0-9]+$");
        }
    }
}