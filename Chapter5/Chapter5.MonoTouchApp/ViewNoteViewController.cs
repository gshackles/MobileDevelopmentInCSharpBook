using UIKit;
using SharedLibrary.Chapter5;

namespace Chapter5.MonoTouchApp
{
	public partial class ViewNoteViewController : UIViewController
	{
		private readonly Note _note;
		
		public ViewNoteViewController(Note note) 
			: base ("ViewNoteViewController", null)
		{
			_note = note;
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();
			
			Title = "Note";
			
			NoteTitle.Text = _note.Title;
			NoteContents.Text = _note.Contents;
			NoteContents.SizeToFit();
			
			var deleteButton = 
				new UIBarButtonItem(UIBarButtonSystemItem.Trash,
	                    			delegate
				                   	{
										AppDelegate.NoteRepository.Delete(_note.Id);

                                        NavigationController.PopViewController(true);
									});
			
			NavigationItem.RightBarButtonItem = deleteButton;
		}
	}
}

