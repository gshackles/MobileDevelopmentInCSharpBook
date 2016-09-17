using Foundation;
using UIKit;
using SharedLibrary.Chapter5;

namespace Chapter5.MonoTouchApp
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		private UIWindow _window;
		private UINavigationController _navigationController;
		
		public static INoteRepository NoteRepository { get; private set; }

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			NoteRepository = new AdoNoteRepository();
			
			_window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			_navigationController = new UINavigationController();
			_navigationController.PushViewController(new NoteListViewController(), false);
			
			_window.RootViewController = _navigationController;
			
			_window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

