using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Repositories.Books;

namespace BookStore.Services.Books
{
    public class BookServiceMySQL : IBookService
    {
        private IBookRepository bookRepo;
        public BookServiceMySQL(IBookRepository bookRepo)
        {
            this.bookRepo = bookRepo;
        }

        public bool CreateBook(Book book)
        {
            return bookRepo.Create(book);
        }

        public bool DeleteBook(Book book)
        {
            return bookRepo.Delete(book);
        }

        public Book GetBookById(long id)
        {
            return bookRepo.FindById(id);
        }

        public List<Book> GetBooks()
        {
            return bookRepo.FindAll();
        }

        public List<Book> GetBooksBySpecification(string specification)
        {
            return bookRepo.FindBySpecification(specification);
        }

        public List<Book> GetBooksByQuantity(int quantity)
        {
            return bookRepo.FindByQuantity(quantity);
        }

        public bool UpdateBook(Book book)
        {
            return bookRepo.Update(book);
        }
    }
}
