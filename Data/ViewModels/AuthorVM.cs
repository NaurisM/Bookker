using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookker.Data.ViewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }
    }

    public class AuthorBooksVM
    {
        public string FullName { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
