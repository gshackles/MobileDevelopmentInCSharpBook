using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Chapter4.MonoTouchApp
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		private UIWindow _window;
		private TwitterViewController _twitterViewController;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			_window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			_twitterViewController = new TwitterViewController();
			_window.RootViewController = _twitterViewController;
			
			_window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

