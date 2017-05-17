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

namespace App_With_Listener
{
    [Activity(Label = "ActivityWithMethods")]
    public class ActivityWithMethods : Activity
    {

        protected Button clickMe, activityWithImplements, activityWithMethods;
        protected EditText editText;
        protected SeekBar seekBar;
        protected TextView editTextPreview, seekBarPreview;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            initializeButtons();
            initializeEditText();
            initializeSeekBar();
            initializeTextViews();
        }


        /// <summary>
        ///     Méthode d'initialisation des boutons
        /// </summary>
        private void initializeButtons()
        {
            // Etape 1 : On récupére les références des éléments graphiques via Resource
            clickMe = FindViewById<Button>(Resource.Id.button_click_me);
            activityWithImplements = FindViewById<Button>(Resource.Id.button_activity_with_implements);
            activityWithMethods = FindViewById<Button>(Resource.Id.button_activity_with_methods);
            // Etape 2 : On attache les listeners aux différents éléments
            clickMe.Click += delegate { Toast.MakeText(this, "Clicked !!!", ToastLength.Short).Show(); };
            activityWithMethods.Click += delegate { /** YOUR CODE HERE **/ };
            activityWithImplements.Click += delegate { StartActivity(typeof(ActivityWithImplements)); };
        }

        /// <summary>
        ///     Méthode d'initialisation des TextView
        /// </summary>
        private void initializeTextViews()
        {
            editTextPreview = FindViewById<TextView>(Resource.Id.apercu_edittext);
            seekBarPreview = FindViewById<TextView>(Resource.Id.apercu_seekbar);
        }

        /// <summary>
        ///     Méthode d'initialisation des EditText
        /// </summary>
        private void initializeEditText()
        {
            // Etape 1 : On récupére les références des éléments graphiques via Resource
            editText = FindViewById<EditText>(Resource.Id.edittext);
            // Etape 2 : On attache les listeners aux différents éléments
            editText.TextChanged += delegate { editTextPreview.Text = editText.Text; };
        }

        /// <summary>
        ///     Méthode d'initialisation des SeekBar
        /// </summary>
        private void initializeSeekBar()
        {
            // Etape 1 : On récupére les références des éléments graphiques via Resource
            seekBar = FindViewById<SeekBar>(Resource.Id.seekbar);
            // Etape 2 : On attache les listeners aux différents éléments
            seekBar.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) => {
                if (e.FromUser)
                {
                    seekBarPreview.Text = seekBar.Progress.ToString();
                }
            };
        }

    }
}