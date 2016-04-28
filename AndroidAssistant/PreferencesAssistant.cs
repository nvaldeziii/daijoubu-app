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
using Android.Preferences;
using Android.Support.V4;

namespace AndroidAssistant
{
    /// <summary>
    /// Loads all the application resources that is needed
    /// </summary>
    public class PreferencesAssistant 
    {
        //Xamarin Android Tutorial 33 Shared Preferences
        ISharedPreferences Prefs;
        ISharedPreferencesEditor PrefsEditor;

        public PreferencesAssistant()
        {
            Prefs = Application.Context.GetSharedPreferences(ApplicationPreferenceTag, FileCreationMode.Private);
            PrefsEditor = Prefs.Edit();
        }

        /// <summary>
        /// Whether to bypass TTS installer notice
        /// </summary>
        public bool TTSInstallerBypass  {
            get
            {
                return Prefs.GetBoolean(TTSInstallerBypassTag, false);
            }
            set
            {
                PrefsEditor.PutBoolean(TTSInstallerBypassTag, value);
                PrefsEditor.Apply();
            }
        }

        /// <summary>
        /// How fast the speech is spoken
        /// </summary>
        public float TTSRate
        {
            get
            {

                return Prefs.GetFloat(TTSRateTag, 1);
            }
            set
            {
                PrefsEditor.PutFloat(TTSRateTag, value);
                PrefsEditor.Apply();
            }
        }

        /// <summary>
        /// adjust the pitch of the voice
        /// </summary>
        public float TTSPitch
        {
            get
            {

                return Prefs.GetFloat(TTSPitchTag, 1);
            }
            set
            {
                PrefsEditor.PutFloat(TTSPitchTag, value);
                PrefsEditor.Apply();
            }
        }

        public bool FreshInstall
        {
            get
            {
                return Prefs.GetBoolean(Fresh, true);
            }
        }

        const string ApplicationPreferenceTag = "daijoubu_prefs";
        const string Fresh = "Fresh";
        const string TTSInstallerBypassTag = "TTSInstallerBypass";
        const string TTSRateTag = "TTSRate";
        const string TTSPitchTag = "TTSPitch";

        ~PreferencesAssistant()
        {
            if (FreshInstall)
            {
                TTSInstallerBypass = true;
                PrefsEditor.PutBoolean(Fresh, false);
                PrefsEditor.Apply();
            }
        }
    }
}