using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Xml.Serialization;

namespace SharedLibrary.Chapter5
{
    public class XmlNoteRepository : INoteRepository
    {
        private const string DatabaseFile = "Notes.db";
        private List<Note> _notes;

        public XmlNoteRepository()
        {
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!store.FileExists(DatabaseFile))
                {
                    _notes = new List<Note>();
                    saveNotesFile();
                }
                else
                {
                    loadNotesFromFile();
                }
            }
        }

        private void loadNotesFromFile()
        {
            var serializer = new XmlSerializer(typeof(List<Note>));

            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            using (var reader = store.OpenFile(DatabaseFile, FileMode.Open))
            {
                _notes = (List<Note>)serializer.Deserialize(reader);
            }
        }

        private void saveNotesFile()
        {
            var serializer = new XmlSerializer(typeof(List<Note>));

            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            using (var writer = store.OpenFile(DatabaseFile, FileMode.Create))
            {
                serializer.Serialize(writer, _notes);
            }
        }

        public IList<Note> GetAllNotes()
        {
            return _notes;
        }

        public void Add(string title, string contents)
        {
            _notes.Add(
                new Note
                {
                    Id = _notes.Count == 0 
                            ? 1 
                            : _notes.Max(note => note.Id) + 1,
                    Title = title,
                    Contents = contents
                });

            saveNotesFile();
        }

        public void Delete(long id)
        {
            _notes = _notes.Where(note => note.Id != id).ToList();

            saveNotesFile();
        }
    }
}
