using System.Collections.Generic;
using System.Linq;
using DigitalLibrary.Models;

namespace DigitalLibrary
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBook(int id);
        void Save(Book book);
        void Update(Book book);
        void Delete(int id);
    }

    public class BookRepository : IBookRepository
    {
        private readonly BooksDB _booksDB;
        //private readonly List<Book> _books;

        public BookRepository()
        {
            _booksDB=new BooksDB();
            
        }


        public IEnumerable<Book> GetAllBooks()
        {
            return _booksDB.Books;
           
        }

        public Book GetBook(int id)
        {
            return _booksDB.Books.FirstOrDefault(b => b.Id == id);
            
        }

        public void Save(Book book)
        {
            //book.Id = new BooksDB().Books.Count() + 1;

            _booksDB.Books.Add(book);
            _booksDB.SaveChanges();
        }

        public void Update(Book book)
        {
            var existingBook = _booksDB.Books.FirstOrDefault(b => b.Id == book.Id);
            _booksDB.Books.Remove(existingBook);

            //TODO: change below code to use AutoMapper
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Keywords = book.Keywords;
            existingBook.CoverImage = book.CoverImage;
            existingBook.ReleaseDate = book.ReleaseDate;
            _booksDB.Books.Add(existingBook);

        }

        public void Delete(int id)
        {
            var book = _booksDB.Books.FirstOrDefault(b => b.Id == id);
            _booksDB.Books.Remove(book);
        }
    }
}