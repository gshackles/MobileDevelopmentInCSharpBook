using System.Device.Location;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Controls.Maps;

namespace Chapter6.WindowsPhoneApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        private GeoCoordinateWatcher _locationWatcher;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var newYorkCity = new GeoCoordinate(40.716667, -74);
            Map.SetView(newYorkCity, 7);

            var pin = new Pushpin();
            pin.Location = newYorkCity;
            pin.Tap += delegate
                           {
                               MessageBox.Show("New York City");
                           };

            Map.Children.Add(pin);

            _locationWatcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default);
            _locationWatcher.MovementThreshold = 20;
            _locationWatcher.PositionChanged += positionChanged;
            _locationWatcher.StatusChanged += statusChanged;
            _locationWatcher.Start();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            _locationWatcher.Stop();
        }

        private void statusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            MessageBox.Show("Status changed to: " + e.Status);
        }

        private void positionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            var newPositionPin = new Pushpin();
            newPositionPin.Location = e.Position.Location;
            newPositionPin.Tap += delegate
                                      {
                                          MessageBox.Show("Current Location");
                                      };

            Map.Children.Add(newPositionPin);

            Map.SetView(e.Position.Location, 7);
        }
    }
}