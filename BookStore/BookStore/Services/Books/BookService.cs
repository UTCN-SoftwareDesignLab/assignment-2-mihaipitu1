using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Books
{
    public interface IBookService
    {
        bool CreateBook(Book book);

        bool UpdateBook(Book book);

        bool DeleteBook(Book book);

        List<Book> GetBooks();

        List<Book> GetBooksBySpecification(string specification);

        List<Book> GetBooksByQuantity(int quantity);

        Book GetBookById(long id);
    }
}
