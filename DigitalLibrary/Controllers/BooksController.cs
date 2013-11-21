using System.Collections.Generic;
using System.Web.Http;
using DigitalLibrary.Models;

namespace DigitalLibrary.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        // GET api/books
        public IEnumerable<Book> Get()
        {
            return _bookRepository.GetAllBooks();
        }

        // GET api/books/5
        public Book Get(int id)
        {
            return _bookRepository.GetBook(id);
        }

        // POST api/books
        public void Post([FromBody]Book book)
        {
            _bookRepository.Save(book);
        }

        // PUT api/books/5
        public void Put(int id, [FromBody]Book book)
        {
            _bookRepository.Update(book);
        }

        // DELETE api/books/5
        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }

        [HttpPatch]
        public void Patch([FromBody] Book book)
        {
            _bookRepository.Update(book);
        }
    }
}
