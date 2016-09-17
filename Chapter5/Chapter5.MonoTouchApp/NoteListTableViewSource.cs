using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using SharedLibrary.Chapter5;

namespace Chapter5.MonoTouchApp
{
	public class NoteListTableViewSource : UITableViewSource
	{
		private readonly IList<Note> _notes;
		private readonly UIViewController _controller;
		private const string NoteCell = "NoteCell";
		
		public NoteListTableViewSource(UIViewController controller, IList<Note> notes)
		{
			_controller = controller;
			_notes = notes;
		}
		
		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return _notes.Count;
		}
		
		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 60;
		}
		
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(NoteCell)
						?? new UITableViewCell(UITableViewCellStyle.Default, NoteCell);
			var note = _notes[indexPath.Row];
			
			cell.TextLabel.Text = note.Title;
			
			return cell;
		}
		
		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			var note = _notes[indexPath.Row];
			
			_controller.NavigationController.PushViewController(
				new ViewNoteViewController(note), true);
		}
		
		public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
		{
			if (editingStyle == UITableViewCellEditingStyle.Delete)
			{
				var note = _notes[indexPath.Row];
				
				AppDelegate.NoteRepository.Delete(note.Id);
				
				_notes.Remove(note);
				
				tableView.DeleteRows(new[] { indexPath }, UITableViewRowAnimation.Fade);
			}
		}
	}
}

