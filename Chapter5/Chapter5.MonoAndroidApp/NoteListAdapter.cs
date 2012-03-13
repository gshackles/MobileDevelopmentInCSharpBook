using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using SharedLibrary.Chapter5;

namespace Chapter5.MonoAndroidApp
{
    public class NoteListAdapter : BaseAdapter<Note>
    {
        private readonly Activity _context;
        private readonly IList<Note> _notes;

        public NoteListAdapter(Activity context, IList<Note> notes)
        {
            _context = context;
            _notes = notes;
        }

        public override long GetItemId(int position)
        {
            return _notes[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView
                       ?? _context.LayoutInflater.Inflate(Resource.Layout.NoteListItem, null);

            view.FindViewById<TextView>(Resource.Id.Title).Text = _notes[position].Title;

            return view;
        }

        public override int Count
        {
            get { return _notes == null ? 0 : _notes.Count; }
        }

        public override Note this[int position]
        {
            get { return _notes[position]; }
        }
    }
}