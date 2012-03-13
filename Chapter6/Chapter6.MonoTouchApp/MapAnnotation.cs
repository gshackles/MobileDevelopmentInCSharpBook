using MonoTouch.CoreLocation;
using MonoTouch.MapKit;

namespace Chapter6.MonoTouchApp
{
	public class MapAnnotation : MKAnnotation
	{
		private readonly string _title;
		private CLLocationCoordinate2D _coordinate;
		
		public MapAnnotation(string title, CLLocationCoordinate2D coordinate)
		{
			_title = title;
			_coordinate = coordinate;
		}
		
		public override CLLocationCoordinate2D Coordinate 
		{
			get { return _coordinate; }
			set { _coordinate = value; }
		}
		
		public override string Title 
		{
			get { return _title; }
		}
	}
}

