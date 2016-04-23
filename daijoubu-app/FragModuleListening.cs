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

namespace daijoubu_app
{
    public class FragModuleListening : Android.Support.V4.App.Fragment
    {
        //Loaded prefs is where all application assets are loaded
        AndroidAssistant.LoadedPreferences LoadedPrefs;
        SimpleTTS.SimpleAndroidTTS JapaneseTTS;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            LoadedPrefs = new AndroidAssistant.LoadedPreferences();
            JapaneseTTS = LoadedPrefs.GetJapaneseTTS(Activity);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.Module_Listening, container, false);

            Button Listening_button_speaker = view.FindViewById<Button>(Resource.Id.listening_button_speaker);
            Listening_button_speaker.Click += Listening_button_speaker_Click;

            return view;
        }

        /// <summary>
        /// Just a test function
        /// </summary>
        private void Listening_button_speaker_Click(object sender, EventArgs e)
        {
            string what = Context.ApplicationContext.Resources.GetString(Resource.String.Test_speak);
            JapaneseTTS.Speak(what);
        }
    }
}