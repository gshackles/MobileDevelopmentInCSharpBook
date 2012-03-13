using Android.App;
using Android.OS;
using Android.Widget;
using SharedLibrary.Chapter4;

namespace Chapter4.MonoAndroidApp
{
    [Activity(Label = "\\@OReillyMedia", MainLauncher = true)]
    public class TwitterActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Twitter);

            var client = new TwitterClient();

            var loading = ProgressDialog.Show(this, "Downloading Tweets", "Please wait...", true);

            client.GetTweetsForUser("OReillyMedia", tweets =>
            {
                RunOnUiThread(() =>
                {
                    var tweetList = FindViewById<ListView>(Resource.Id.Tweets);
                    tweetList.Adapter = new TweetListAdapter(this, tweets);
                    tweetList.ItemClick += (object sender, ItemEventArgs e) =>
                    {
                        var selectedTweet = tweets[e.Position];

                        new AlertDialog.Builder(this)
                            .SetTitle("Full Tweet")
                            .SetMessage(selectedTweet.Text)
                            .SetPositiveButton("Ok", delegate { })
                            .Show();
                    };

                    loading.Hide();
                });
            });

            client.MentionReceived += (object sender, MentionEventArgs args) =>
            {
                RunOnUiThread(() =>
                {
                    new AlertDialog.Builder(this)
                        .SetTitle("Mention Received")
                        .SetMessage(args.Tweet.Text)
                        .SetPositiveButton("Ok", delegate { })
                        .Show();
                });
            };
        }
    }
}