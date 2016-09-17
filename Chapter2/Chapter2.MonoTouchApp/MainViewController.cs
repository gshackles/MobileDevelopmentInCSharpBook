using System;
using Foundation;
using UIKit;

namespace Chapter2.MonoTouchApp
{
	public partial class MainViewController : UIViewController
	{
		public MainViewController() : base ("MainViewController", null)
		{
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();
			
			Title = "Hello, iOS!";
			
			Button.SetTitleColor(UIColor.Red, UIControlState.Normal);
		}
		
		partial void ButtonTapped(NSObject sender)
		{
			NavigationController.PushViewController(
				new SecondViewController(DateTime.Now.ToLongTimeString()), true);
		}
	}
}

