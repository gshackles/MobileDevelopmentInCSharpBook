using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Chapter2.MonoAndroidApp
{
    [Activity(Label = "Hello, Android!", MainLauncher = true, Icon = "@drawable/icon")]
    public class FirstActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.First);

            var button = FindViewById<Button>(Resource.Id.Button);
            button.Click += buttonClicked;
        }

        private void buttonClicked(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(SecondActivity));
            intent.PutExtra("text", DateTime.Now.ToLongTimeString());

            StartActivity(intent);
        }
    }

}