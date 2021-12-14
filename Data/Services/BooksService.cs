using Bookker.Data.Models;
using Bookker.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Bookker.Data.Services
{
    public class BooksService
    {
        private readonly AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;        
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                CoverUrl = book.CoverUrl,
                IsRead = book.IsRead,
                Rate = book.IsRead ? book.Rate.Value : null,
                PublisherId = book.PublisherId
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.Books_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }

        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public BookWithAuthorsVM GetBookById(int bookId)
        {
            var _bookWithAuthors = _context.Books.Where(b => b.Id == bookId).Select(book => new BookWithAuthorsVM()
            {
                Title = book.Title,
                CoverUrl = book.CoverUrl,
                IsRead = book.IsRead,
                Rate = book.IsRead ? book.Rate.Value : null,
                PublisherName = book.Publisher.Name,
                AuthorNames = book.Book_Authors.Select(b => b.Author.FullName).ToList()
            }).FirstOrDefault();

            return _bookWithAuthors;
        }

        public Book UpdateBook(int bookId, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(b => b.Id == bookId);
            if(_book != null)
            {
                _book.Title = book.Title;
                _book.CoverUrl = book.CoverUrl;
                _book.IsRead = book.IsRead;
                _book.Rate = book.IsRead ? book.Rate.Value : null;

                _context.SaveChanges();
            }

            return _book;
        }
       
        public void DeleteBook(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(b => b.Id == bookId);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
