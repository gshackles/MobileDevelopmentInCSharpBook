using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Chapter2.MonoTouchApp
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		private UIWindow _window;
		private UINavigationController _navigationController;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			_window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			_navigationController = new UINavigationController();
			_navigationController.PushViewController(new MainViewController(), false);
			
			_window.RootViewController = _navigationController;
			
			_window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

