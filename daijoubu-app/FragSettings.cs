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
    public class FragSettings : Android.Support.V4.App.Fragment
    {
        AndroidAssistant.PreferencesAssistant Prefs;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.Settings, container, false);

            Prefs = new AndroidAssistant.PreferencesAssistant();

            Switch settings_tts_bypass_switch = view.FindViewById<Switch>(Resource.Id.settings_tts_bypass_switch);
            SeekBar settings_tts_rate_seekBar = view.FindViewById<SeekBar>(Resource.Id.settings_tts_rate_seekBar);
            SeekBar settings_tts_pitch_seekbar = view.FindViewById<SeekBar>(Resource.Id.settings_tts_pitch_seekBar);

            settings_tts_bypass_switch.Checked = Prefs.TTSInstallerBypass;
            settings_tts_rate_seekBar.Progress = Convert.ToInt32(Prefs.TTSRate * 100);
            settings_tts_pitch_seekbar.Progress = Convert.ToInt32(Prefs.TTSPitch * 100);

            settings_tts_bypass_switch.CheckedChange += Settings_tts_bypass_switch_CheckedChange;
            settings_tts_rate_seekBar.ProgressChanged += Settings_tts_rate_seekBar_ProgressChanged;
            settings_tts_pitch_seekbar.ProgressChanged += Settings_tts_pitch_seekbar_ProgressChanged;

            return view;
        }

        private void Settings_tts_bypass_switch_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            Prefs.TTSInstallerBypass = e.IsChecked;
        }

        private void Settings_tts_pitch_seekbar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            Prefs.TTSPitch = (float)(e.Progress / 100.0);
        }

        private void Settings_tts_rate_seekBar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            Prefs.TTSRate = (float)(e.Progress / 100.0);
        }

        
    }
}