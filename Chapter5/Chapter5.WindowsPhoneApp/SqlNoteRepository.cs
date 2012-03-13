using System;
using System.Collections.Generic;
using System.Linq;
using SharedLibrary.Chapter5;

namespace Chapter5.WindowsPhoneApp
{
    public class SqlNoteRepository : INoteRepository
    {
        private readonly string _connectionString = "Data Source=isostore:/Notes.sdf";

        public SqlNoteRepository()
        {
            using (var db = new NoteContext(_connectionString))
            {
                if (!db.DatabaseExists())
                    db.CreateDatabase();
            }
        }

        public IList<Note> GetAllNotes()
        {
            using (var db = new NoteContext(_connectionString))
            {
                return db.Notes.ToList();
            }
        }

        public void Add(string title, string contents)
        {
            using (var db = new NoteContext(_connectionString))
            {
                db.Notes.InsertOnSubmit(
                    new Note
                    {
                        Title = title,
                        Contents = contents
                    });
                db.SubmitChanges();
            }
        }

        public void Delete(long id)
        {
            using (var db = new NoteContext(_connectionString))
            {
                var noteToDelete = db.Notes.First(note => note.Id == id);

                db.Notes.DeleteOnSubmit(noteToDelete);
                db.SubmitChanges();
            }
        }
    }
}
