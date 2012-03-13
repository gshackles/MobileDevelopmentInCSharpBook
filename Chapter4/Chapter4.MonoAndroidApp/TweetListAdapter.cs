using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using SharedLibrary.Chapter4;

namespace Chapter4.MonoAndroidApp
{
    public class TweetListAdapter : BaseAdapter<Tweet>
    {
		private readonly Activity _context;
		private readonly IList<Tweet> _tweets;
		
		public TweetListAdapter(Activity context, IList<Tweet> tweets)
		{
			_context = context;
			_tweets = tweets;
		}
		
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
			var view = convertView
						?? _context.LayoutInflater.Inflate(Resource.Layout.Tweet, null);
			var tweet = _tweets[position];
			
			view.FindViewById<TextView>(Resource.Id.Text).Text = tweet.Text;
			view.FindViewById<TextView>(Resource.Id.CreatedAt).Text =
				tweet.CreatedAt.ToLocalTime().ToString();
			
			return view;
        }

        public override int Count
        {
            get { return _tweets.Count; }
        }
		
        public override long GetItemId(int position)
        {
            return position;
        }

        public override Tweet this[int position]
        {
            get { return _tweets[position]; }
        }
    }
}
