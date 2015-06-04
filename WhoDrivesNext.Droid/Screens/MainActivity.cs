using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace WhoDrivesNext.Droid.Screens
{
    [Activity(Label = "WhoDrivesNext.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button personButton = FindViewById<Button>(Resource.Id.personsButton);

            personButton.Click += PersonButtonOnClick;
        }

        private void PersonButtonOnClick(object sender, EventArgs eventArgs)
        {
            StartActivity(typeof(PersonsActivity));
        }
    }
}

