using UIKit;

namespace Chapter5.MonoTouchApp
{
	public class NoteListViewController : UITableViewController
	{
		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();
			
			Title = "Notes";
			
			var addNoteButton = 
				new UIBarButtonItem(UIBarButtonSystemItem.Add, 
                                    delegate
                                   	{
										NavigationController.PushViewController(new AddNoteViewController(), true);
									});
			
			NavigationItem.RightBarButtonItem = addNoteButton;
		}
		
		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear (animated);
			
			var notes = AppDelegate.NoteRepository.GetAllNotes();
			
			TableView.Source = new NoteListTableViewSource(this, notes);
			TableView.ReloadData();
		}
	}
}

