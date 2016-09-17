using CoreLocation;
using MapKit;
using UIKit;

namespace Chapter6.MonoTouchApp
{
	public partial class MapViewController : UIViewController
	{
		private CLLocationManager _locationManager;
		
		public MapViewController() 
			: base ("MapViewController", null)
		{
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();
			
			var newYorkCity = new CLLocationCoordinate2D(40.716667, -74);
			
			Map.CenterCoordinate = newYorkCity;
			Map.Region = MKCoordinateRegion.FromDistance(newYorkCity, 5000, 5000);
			
			var annotation = new MapAnnotation("New York City", newYorkCity);
			Map.AddAnnotation(annotation);
			
			_locationManager = new CLLocationManager();
			_locationManager.UpdatedLocation += locationUpdated;
			_locationManager.DistanceFilter = 20;
			_locationManager.DesiredAccuracy = CLLocation.AccuracyHundredMeters;
			
			_locationManager.StartUpdatingLocation();
		}
		
		public override void ViewDidUnload()
		{
			base.ViewDidUnload ();
			
			_locationManager.StopUpdatingLocation();
		}

		private void locationUpdated (object sender, CLLocationUpdatedEventArgs e)
		{
			Map.CenterCoordinate = e.NewLocation.Coordinate;
			Map.Region = MKCoordinateRegion.FromDistance (e.NewLocation.Coordinate, 5000, 5000);
			
			var annotation = new MapAnnotation("Current Location", e.NewLocation.Coordinate);
			Map.AddAnnotation(annotation);
		}
	}
}

