using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Chapter5.MonoAndroidApp
{
    [Activity(Label = "Note")]
    public class ViewNoteActivity : Activity
    {
        private long _noteId;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.ViewNote);

            _noteId = Intent.GetLongExtra("Id", -1);
            
            FindViewById<TextView>(Resource.Id.Title).Text = Intent.GetStringExtra("Title");
            FindViewById<TextView>(Resource.Id.Contents).Text = Intent.GetStringExtra("Contents");
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.ViewNote, menu);

            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.Delete)
            {
                NoteApplication.NoteRepository.Delete(_noteId);

                Finish();
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}