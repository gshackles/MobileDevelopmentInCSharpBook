using System;
using Android.App;
using Android.Runtime;
using SharedLibrary.Chapter5;

namespace Chapter5.MonoAndroidApp
{
    [Application]
    public class NoteApplication : Application
    {
        public static INoteRepository NoteRepository { get; private set; }

        public NoteApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            //NoteRepository = new AdoNoteRepository();
            NoteRepository = new XmlNoteRepository();
            NoteRepository.Add("Test", "Post");
        }
    }
}