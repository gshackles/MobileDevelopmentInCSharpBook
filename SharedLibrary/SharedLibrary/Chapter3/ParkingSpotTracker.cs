using System;

namespace SharedLibrary.Chapter3
{
	public partial class ParkingSpotTracker
	{
		private readonly ILocationProvider _locationProvider;
		
		public event EventHandler<SpotDetectedNearbyEventArgs> SpotDetectedNearby;
		
		public ParkingSpotTracker(ILocationProvider locationProvider)
		{
			_locationProvider = locationProvider;
		}
		
		public void ParkHere()
		{
			var currentLocation = _locationProvider.GetCurrentLocation();
			
			// save a new parking spot using currentLocation
		}
		
		private void checkCurrentLocation()
		{
			var currentLocation = _locationProvider.GetCurrentLocation();
			var newYorkCity = new LocationInfo(40.716667, -74);
			
			double distance = currentLocation.DistanceInMetersFrom(newYorkCity);
			
			if (distance < 100 && SpotDetectedNearby != null)
			{
				SpotDetectedNearby(this, new SpotDetectedNearbyEventArgs(distance));
			}
		}
		
		public int UpdateIntervalSeconds
		{
			get
			{
#if __ANDROID__
				return 30;
#elif MONOTOUCH
				return 45;
#elif WINDOWS_PHONE
				return 60;
#else
				return 120;
#endif
			}
		}
	}
}

