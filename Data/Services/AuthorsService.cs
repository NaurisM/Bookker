using Bookker.Data.Models;
using Bookker.Data.ViewModels;
using System.Linq;

namespace Bookker.Data.Services
{
    public class AuthorsService
    {
        private readonly AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }
        
        public AuthorBooksVM GetAuthorBooks(int authorId)
        {
            var _author = _context.Authors.Where(a => a.Id == authorId).Select(author => new AuthorBooksVM()
            {
                FullName = author.FullName,
                BookTitles = author.Book_Authors.Select(b => b.Book.Title).ToList()
            }).FirstOrDefault();

            return _author;
        }
    }
}
