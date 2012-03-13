using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SharedLibrary.Chapter4;

namespace Chapter4.MonoTouchApp
{
	public class TwitterTableViewSource : UITableViewSource
	{
		private readonly IList<Tweet> _tweets;
		private const string TweetCell = "TweetCell";
		
		public TwitterTableViewSource(IList<Tweet> tweets)
		{
			_tweets = tweets;
		}

		public override int RowsInSection(UITableView tableView, int section)
		{
			return _tweets.Count;
		}
		
		public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 60;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(TweetCell) 
						?? new UITableViewCell(UITableViewCellStyle.Subtitle, TweetCell);
			var tweet = _tweets[indexPath.Row];
			
			cell.TextLabel.Text = tweet.Text;
			cell.DetailTextLabel.Text = tweet.CreatedAt.ToLocalTime().ToString();
			
			return cell;
		}
		
		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			var selectedTweet = _tweets[indexPath.Row];
			new UIAlertView("Full Tweet", selectedTweet.Text, 
			                null, "Ok", null).Show();
		}
	}
}

