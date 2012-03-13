using System.Collections.Generic;

namespace SharedLibrary.Chapter5
{
    public interface INoteRepository
    {
        IList<Note> GetAllNotes();
        void Add(string title, string contents);
        void Delete(long id);
    }
}
