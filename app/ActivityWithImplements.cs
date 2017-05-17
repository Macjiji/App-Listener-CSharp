using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Views;
using Android.Text;
using Java.Lang;

namespace App_With_Listener
{
    [Activity(Label = "App_With_Listener", MainLauncher = true, Icon = "@drawable/icon")]
    public class ActivityWithImplements : Activity, SeekBar.IOnSeekBarChangeListener, View.IOnClickListener
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
            initializeTextViews();
            initializeEditText();
            initializeSeekBar();
        }

        /// <summary>
        ///     Méthode issue de l'interface IOnSeekBarChangeListener
        /// </summary>
        /// <see cref="IOnSeekBarChangeListener"/>
        /// <param name="seekBar"></param>
        /// <param name="progress"></param>
        /// <param name="fromUser"></param>
        public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
        {
            seekBarPreview.Text = seekBar.Progress.ToString();
        }

        /// <summary>
        ///     Méthode issue de l'interface IOnSeekBarChangeListener
        /// </summary>
        /// <see cref="IOnSeekBarChangeListener"/>
        /// <param name="seekBar"></param>
        public void OnStartTrackingTouch(SeekBar seekBar)
        {
            // YOUR CODE HERE
        }

        /// <summary>
        ///     Méthode issue de l'interface IOnSeekBarChangeListener
        /// </summary>
        /// <see cref="IOnSeekBarChangeListener"/>
        /// <param name="seekBar"></param>
        public void OnStopTrackingTouch(SeekBar seekBar)
        {
            // YOUR CODE HERE
        }

        /// <summary>
        ///     Méthode issue de l'interface IOnClickListener
        /// </summary>
        /// <see cref="View.IOnClickListener"/>
        /// <param name="v"></param>
        public void OnClick(View v)
        {
            switch (v.Id)
            {
                case Resource.Id.button_click_me:
                    Toast.MakeText(this, "Clicked !!!!", ToastLength.Short).Show();
                    break;
                case Resource.Id.button_activity_with_implements:
                    // YOUR CODE HERE
                    break;
                case Resource.Id.button_activity_with_methods:
                    StartActivity(typeof(ActivityWithMethods));
                    break;
            }
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
            clickMe.SetOnClickListener(this);
            activityWithMethods.SetOnClickListener(this);
            activityWithImplements.SetOnClickListener(this);
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
            editText.AddTextChangedListener(new OwnTextWatcher(editText, editTextPreview));
        }

        /// <summary>
        ///     Méthode d'initialisation des SeekBar
        /// </summary>
        private void initializeSeekBar()
        {
            // Etape 1 : On récupére les références des éléments graphiques via Resource
            seekBar = FindViewById<SeekBar>(Resource.Id.seekbar);
            // Etape 2 : On attache les listeners aux différents éléments
            seekBar.SetOnSeekBarChangeListener(this);
        }

        /// <summary>
        ///     Classe permettant de gérer TextWatcher sur les EditText
        /// </summary>
        /// <see cref="Java.Lang.Object"/>
        /// <see cref="ITextWatcher"/>
        private class OwnTextWatcher : Java.Lang.Object, ITextWatcher
        {

            private EditText view;
            private TextView preview;

            public OwnTextWatcher(EditText view, TextView preview)
            {
                this.view = view;
                this.preview = preview;
            }

            public void AfterTextChanged(IEditable s)
            {
                // YOUR CODE HERE
            }

            public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
            {
                // YOUR CODE HERE
            }

            public void OnTextChanged(ICharSequence s, int start, int before, int count)
            {
                switch (view.Id)
                {
                    case Resource.Id.edittext:
                        preview.Text = s.ToString();
                        break;
                }
            }
        }


    }
}

