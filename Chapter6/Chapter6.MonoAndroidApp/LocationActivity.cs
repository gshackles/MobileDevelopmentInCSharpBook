using Android.App;
using Android.GoogleMaps;
using Android.Locations;
using Android.OS;
using Android.Widget;

namespace Chapter6.MonoAndroidApp
{
    [Activity(Label = "Map", MainLauncher = true, Icon = "@drawable/icon")]
    public class LocationActivity : MapActivity, ILocationListener
    {
        private LocationManager _locationManager;
        private MapOverlay _mapOverlay;
        private MapView _map;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Map);

            _map = FindViewById<MapView>(Resource.Id.Map);
            _map.SetBuiltInZoomControls(true);

            var newYorkCity = new GeoPoint((int) (40.716667 * 1e6), (int) (-74 * 1e6));
            _map.Controller.SetCenter(newYorkCity);
            _map.Controller.SetZoom(14);

            _mapOverlay = new MapOverlay(Resources.GetDrawable(Resource.Drawable.Icon), this);
            _map.Overlays.Add(_mapOverlay);

            _mapOverlay.Add(newYorkCity, "New York City");

            _locationManager = (LocationManager)GetSystemService(LocationService);
        }

        protected override void OnResume()
        {
            base.OnResume();

            var criteria = new Criteria();
            criteria.PowerRequirement = Power.NoRequirement;
            criteria.Accuracy = Accuracy.Coarse;

            string bestProvider = _locationManager.GetBestProvider(criteria, true);

            _locationManager.RequestLocationUpdates(bestProvider, 5000, 20, this);
        }

        protected override void OnPause()
        {
            base.OnPause();

            _locationManager.RemoveUpdates(this);
        }

        protected override bool IsRouteDisplayed
        {
            get { return false; }
        }

        public void OnLocationChanged(Location location)
        {
            var currentLocation = new GeoPoint((int) (location.Latitude * 1e6), (int) (location.Longitude * 1e6));

            _mapOverlay.Add(currentLocation, "Current Location");

            _map.Controller.AnimateTo(currentLocation);
        }

        public void OnProviderDisabled(string provider)
        {
            // called when a provider is disabled
        }

        public void OnProviderEnabled(string provider)
        {
            // called when a provider is enabled
        }

        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {
            Toast
                .MakeText(this, "Status for " + provider + " changed to " + status, ToastLength.Short)
                .Show();
        }
    }
}