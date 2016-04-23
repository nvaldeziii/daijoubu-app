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
    public class PreferencesAssistant 
    {
        ISharedPreferences Prefs;
        ISharedPreferencesEditor PrefsEditor;
        public PreferencesAssistant()
        {
            Prefs = Application.Context.GetSharedPreferences(ApplicationPreferenceTag, FileCreationMode.Private);
            PrefsEditor = Prefs.Edit();


        }

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

        const string ApplicationPreferenceTag = "daijoubu_prefs";
        const string TTSInstallerBypassTag = "TTSInstallerBypass";
        const string TTSRateTag = "TTSRate";
        const string TTSPitchTag = "TTSPitch";
    }
}