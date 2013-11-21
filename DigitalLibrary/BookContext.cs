using System.Data.Entity;
using DigitalLibrary.Models;

namespace DigitalLibrary
{
    public class BooksDB:DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}