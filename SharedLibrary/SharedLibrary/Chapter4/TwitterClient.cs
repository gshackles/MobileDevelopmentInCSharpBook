using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Xml.Linq;

namespace SharedLibrary.Chapter4
{
	public class TwitterClient
	{
		private const string _baseUrl = "https://mobiledevelopmentwithcs.blob.core.windows.net/twitter/";

		public event EventHandler<MentionEventArgs> MentionReceived;
	
		public TwitterClient()
		{
			new Timer(delegate
			{
				var mention = new Tweet
				{
					Id = 42,
					CreatedAt = DateTime.Now,
					Text = "This is a fake mention"
				};
				
				if (MentionReceived != null)
				{
					MentionReceived(this, new MentionEventArgs(mention));
				}
			}, null, 15 * 1000, Timeout.Infinite);
		}
	
		public void GetTweetsForUser(string user, Action<IList<Tweet>> callback)
		{
			string url = _baseUrl + "user_timeline.xml?screen_name=" + Uri.EscapeUriString(user);
			var client = new WebClient();
			
			client.DownloadStringCompleted += 
				(sender, args) => 
				{
                    var tweets =
                        XDocument
                            .Parse(args.Result)
                            .Root
                            .Elements("status")
                            .Select(status => new Tweet
                            {
                                Id = long.Parse(status.Element("id").Value),
                                CreatedAt = DateTime.ParseExact(status.Element("created_at").Value, 
                                                                "ddd MMM dd HH:mm:ss zz00 yyyy", null),
                                Text = status.Element("text").Value
                            })
                            .ToList();
				
					callback(tweets);
				};
				
			client.DownloadStringAsync(new Uri(url));
		}
	}
}

