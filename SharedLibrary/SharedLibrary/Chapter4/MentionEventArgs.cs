using System;

namespace SharedLibrary.Chapter4
{
	public class MentionEventArgs : EventArgs
	{
		public Tweet Tweet { get; private set; }
	
		public MentionEventArgs(Tweet tweet)
		{
			Tweet = tweet;
		}
	}
}

