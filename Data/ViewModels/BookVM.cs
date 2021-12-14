using System.Collections.Generic;

namespace Bookker.Data.ViewModels
{
    public class BookVM
    {
        public string Title { get; set; }
        public string CoverUrl { get; set; }
        public bool IsRead { get; set; }
        public int? Rate { get; set; }

        public int PublisherId { get; set; }
        public List<int> AuthorIds { get; set; }
    }

    public class BookWithAuthorsVM
    {
        public string Title { get; set; }
        public string CoverUrl { get; set; }
        public bool IsRead { get; set; }
        public int? Rate { get; set; }

        public string PublisherName { get; set; }
        public List<string> AuthorNames { get; set; }
    }
}
