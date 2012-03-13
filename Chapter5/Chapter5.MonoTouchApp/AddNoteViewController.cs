using MonoTouch.UIKit;

namespace Chapter5.MonoTouchApp
{
	public partial class AddNoteViewController : UIViewController
	{
		public AddNoteViewController() 
			: base ("AddNoteViewController", null)
		{
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();
			
			Title = "Add Note";
			
			NoteTitle.ShouldReturn = 
				(textField) => 
				{
					NoteContents.BecomeFirstResponder();
				
					return true;
				};
			
			NoteContents.ShouldReturn = 
				(textField) => 
				{
					textField.ResignFirstResponder();
				
					return true;
				};
			
			SaveNote.TouchUpInside += delegate 
			{
				AppDelegate.NoteRepository.Add(
					NoteTitle.Text, NoteContents.Text);
				
				NavigationController.PopViewControllerAnimated(true);
			};
		}
	}
}

