using System;

namespace SharedLibrary.Chapter3
{
	public class SpotDetectedNearbyEventArgs : EventArgs
	{
		public double Distance { get; private set; }
		
		public SpotDetectedNearbyEventArgs(double distance)
		{
			Distance = distance;
		}
	}
}

