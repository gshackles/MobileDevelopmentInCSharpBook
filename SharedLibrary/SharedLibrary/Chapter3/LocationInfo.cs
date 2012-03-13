namespace SharedLibrary.Chapter3
{
	public class LocationInfo
	{
		public double Latitude { get; private set; }
		public double Longitude { get; private set; }
		
		public LocationInfo (double latitude, double longitude)
		{
			Latitude = latitude;
			Longitude = longitude;
		}
		
		public double DistanceInMetersFrom(LocationInfo point)
		{
			return 42;
		}
	}
}

