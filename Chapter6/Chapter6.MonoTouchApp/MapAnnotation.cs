using CoreLocation;
using MapKit;

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

        public override void SetCoordinate(CLLocationCoordinate2D value)
        {
            base.SetCoordinate(value);

            _coordinate = value;
        }
		
		public override CLLocationCoordinate2D Coordinate 
		{
			get { return _coordinate; }
		}
		
		public override string Title 
		{
			get { return _title; }
		}
	}
}

