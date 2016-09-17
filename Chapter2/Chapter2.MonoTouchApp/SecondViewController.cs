using UIKit;

namespace Chapter2.MonoTouchApp
{
	public partial class SecondViewController : UIViewController
	{
		private readonly string _text;
		
		public SecondViewController(string text) 
			: base ("SecondViewController", null)
		{
			_text = text;
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();
			
			Title = "Second View";
			
			ReceivedText.Text = _text;
		}
	}
}

