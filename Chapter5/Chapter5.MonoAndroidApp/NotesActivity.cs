using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using SharedLibrary.Chapter5;

namespace Chapter5.MonoAndroidApp
{
    [Activity(Label = "Notes", MainLauncher = true, Icon = "@drawable/icon")]
    public class NotesActivity : Activity
    {
        private ListView _noteList;
        private IList<Note> _notes;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Notes);
            
            _noteList = FindViewById<ListView>(Resource.Id.Notes);
            _noteList.ItemClick += (sender, args) =>
                                       {
                                           var note = _notes[args.Position];

                                           var intent = new Intent(this, typeof (ViewNoteActivity));
                                           intent.PutExtra("Id", note.Id);
                                           intent.PutExtra("Title", note.Title);
                                           intent.PutExtra("Contents", note.Contents);

                                           StartActivity(intent);
                                       };
        }

        protected override void OnResume()
        {
            base.OnResume();

            _notes = NoteApplication.NoteRepository.GetAllNotes();
            _noteList.Adapter = new NoteListAdapter(this, _notes);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.Notes, menu);

            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.Add)
            {
                StartActivity(typeof(AddNoteActivity));

                return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}

