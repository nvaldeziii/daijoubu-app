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

namespace AndroidAssistant
{
    public class LoadedPreferences
    {
        PreferencesAssistant Prefs;
        SimpleTTS.SimpleAndroidTTS JapaneseTTS;

        public LoadedPreferences()
        {
            Prefs = new PreferencesAssistant();
        }

        public SimpleTTS.SimpleAndroidTTS GetJapaneseTTS(Activity a)
        {
            if (JapaneseTTS == null)
            {
                JapaneseTTS = new SimpleTTS.SimpleAndroidTTS(a);
                JapaneseTTS.Settings.BypasslanguageCheck = Prefs.TTSInstallerBypass;
                JapaneseTTS.Settings.Pitch = Prefs.TTSPitch;
                JapaneseTTS.Settings.Rate = Prefs.TTSRate;

                JapaneseTTS.SetLanguage(Java.Util.Locale.Japanese);
            }

            return JapaneseTTS;
        }
    }
}