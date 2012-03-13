using MonoTouch.UIKit;
using SharedLibrary.Chapter4;

namespace Chapter4.MonoTouchApp
{
	public class TwitterViewController : UITableViewController
	{
		private TwitterClient _client;
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			_client = new TwitterClient();
			
			var loading = new UIAlertView("Downloading Tweets", "Please wait...", null, null, null);
			loading.Show();
			
			var indicator = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.WhiteLarge);
			indicator.Center = new System.Drawing.PointF(loading.Bounds.Width / 2, loading.Bounds.Size.Height - 40);
			indicator.StartAnimating();
			loading.AddSubview (indicator);
			
			_client.GetTweetsForUser ("OReillyMedia", tweets => 
            {
				InvokeOnMainThread(() =>
              	{
					TableView.Source = new TwitterTableViewSource(tweets);	
					TableView.ReloadData();
					loading.DismissWithClickedButtonIndex (0, true);
				});
			});
			
			_client.MentionReceived += (object sender, MentionEventArgs args) => 
			{
				InvokeOnMainThread(() =>
					new UIAlertView("Mention Received", args.Tweet.Text, 
					                null, "Ok", null).Show());
			};
		}
	}
}

