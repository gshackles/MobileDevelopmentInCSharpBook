#if __ANDROID_8__ || MONOTOUCH
using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.IO;

namespace SharedLibrary.Chapter5
{
    public class AdoNoteRepository : INoteRepository
    {
        private readonly string _databasePath;

        public AdoNoteRepository()
        {
            _databasePath = Path.Combine(
                                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                                "Notes.db");

            setupDatabase();
        }

        private void setupDatabase()
        {
            using (var connection = getConnection())
            using (var command = connection.CreateCommand())
            {
                if (!File.Exists(_databasePath))
                    SqliteConnection.CreateFile(_databasePath);

                connection.Open();
                command.CommandText =
                    @"CREATE TABLE IF NOT EXISTS Notes (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Contents TEXT NOT NULL
                    )";

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private SqliteConnection getConnection()
        {
            return new SqliteConnection("Data Source=" + _databasePath);
        }

        public IList<Note> GetAllNotes()
        {
            var notes = new List<Note>();

            using (var connection = getConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT * FROM Notes";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        notes.Add(
                            new Note
                            {
                                Id = (long)reader["Id"],
                                Title = (string)reader["Title"],
                                Contents = (string)reader["Contents"]
                            });
                    }
                }

                connection.Close();
            }

            return notes;
        }

        public void Add(string title, string contents)
        {
            using (var connection = getConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "INSERT INTO Notes (Title, Contents) VALUES (@title, @contents)";
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@contents", contents);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void Delete(long id)
        {
            using (var connection = getConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "DELETE FROM Notes WHERE Id=@id";
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
#endif