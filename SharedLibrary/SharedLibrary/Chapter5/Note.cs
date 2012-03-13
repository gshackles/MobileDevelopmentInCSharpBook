#if WINDOWS_PHONE
using System.Data.Linq.Mapping;
#endif

namespace SharedLibrary.Chapter5
{
    
#if WINDOWS_PHONE
    [Table]
    public class Note
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public long Id { get; set; }

        [Column]
        public string Title { get; set; }

        [Column]
        public string Contents { get; set; }
    }
#else
    public class Note
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
    }
#endif
}
