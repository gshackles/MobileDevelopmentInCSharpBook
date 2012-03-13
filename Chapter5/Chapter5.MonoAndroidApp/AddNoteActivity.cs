using Android.App;
using Android.OS;
using Android.Widget;

namespace Chapter5.MonoAndroidApp
{
    [Activity(Label = "Add Note")]
    public class AddNoteActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.AddNote);

            FindViewById<Button>(Resource.Id.Save).Click +=
                delegate
                {
                    NoteApplication.NoteRepository.Add(
                        FindViewById<EditText>(Resource.Id.Title).Text,
                        FindViewById<EditText>(Resource.Id.Contents).Text);

                    Finish();
                };
        }
    }
}