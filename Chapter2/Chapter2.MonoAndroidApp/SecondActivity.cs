using Android.App;
using Android.OS;
using Android.Widget;

namespace Chapter2.MonoAndroidApp
{
    [Activity(Label = "Second Activity")]
    public class SecondActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Second);

            var text = FindViewById<TextView>(Resource.Id.Text);
            text.Text = Intent.GetStringExtra("text");
        }
    }
}