using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Chapter6.MonoTouchApp
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		private UIWindow _window;
		private MapViewController _mapViewController;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			_window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			_mapViewController = new MapViewController();
			
			_window.RootViewController = _mapViewController;
			
			_window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

