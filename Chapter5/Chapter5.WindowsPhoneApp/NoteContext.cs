using System;
using System.Data.Linq;
using SharedLibrary.Chapter5;

namespace Chapter5.WindowsPhoneApp
{
    public class NoteContext : DataContext
    {
        public NoteContext(string connectionString)
            : base(connectionString)
        {
        }

        public Table<Note> Notes
        {
            get { return GetTable<Note>(); }
        }
    }
}
