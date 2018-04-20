using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Database;
using BookStore.Models;
using BookStore.Models.Builders;
using BookStore.Repositories.Books;
using BookStore.Services.Books;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStoreTests.Services
{
    [TestClass]
    public class BookServiceMySQLTest
    {
        private IBookService bookService;

        public BookServiceMySQLTest()
        {
            bookService = new BookServiceMySQL(new BookRepositoryMySQL(new DBConnectionFactory().GetConnectionWrapper(true)));
        }

        public void RemoveAll()
        {
            List<Book> books = bookService.GetBooks();

            foreach (var book in books)
            {
                bookService.DeleteBook(book);
            }
        }

        [TestMethod]
        public void TestFindAllBooks()
        {
            List<Book> books = bookService.GetBooks();
            Assert.AreEqual(books.Count, 0);
        }

        [TestMethod]
        public void TestCreateBook()
        {
            Book book = new BookBuilder()
                .SetId(1)
                .SetTitle("Title")
                .SetAuthor("Author")
                .SetGenre("Genre")
                .SetQuantity(123)
                .SetPrice(12.3)
                .Build();
            Assert.IsTrue(bookService.CreateBook(book));
            RemoveAll();
        }

        [TestMethod]
        public void TestEditBook()
        {
            Book book = new BookBuilder()
                .SetId(1)
                .SetTitle("Title")
                .SetAuthor("Author")
                .SetGenre("Genre")
                .SetQuantity(123)
                .SetPrice(12.3)
                .Build();
            bookService.CreateBook(book);
            Assert.IsTrue(bookService.UpdateBook(book));
            RemoveAll();
        }

        [TestMethod]
        public void TestDeleteBook()
        {
            Book book = new BookBuilder()
                .SetId(1)
                .SetTitle("Title")
                .SetAuthor("Author")
                .SetGenre("Genre")
                .SetQuantity(123)
                .SetPrice(12.3)
                .Build();
            bookService.CreateBook(book);
            Assert.IsTrue(bookService.DeleteBook(book));
            RemoveAll();
        }


        [TestMethod]
        public void TestFindBookById()
        {
            Book books = bookService.GetBookById(0);
            Assert.IsNull(books.GetTitle());
        }


        [TestMethod]
        public void TestFindBooksByQuantity()
        {
            List<Book> books = bookService.GetBooksByQuantity(3);
            Assert.AreEqual(books.Count, 0);
        }


        [TestMethod]
        public void TestFindBooksBySpecification()
        {
            List<Book> books = bookService.GetBooksBySpecification(null);
            Assert.AreEqual(books.Count, 0);
        }


        [TestMethod]
        public void TestFindAllNotNull()
        {
            Book book = new BookBuilder()
                .SetId(1)
                .SetTitle("Title")
                .SetAuthor("Author")
                .SetGenre("Genre")
                .SetQuantity(123)
                .SetPrice(12.3)
                .Build();
            bookService.CreateBook(book);
            book.SetId(book.GetId() + 1);
            bookService.CreateBook(book);
            book.SetId(book.GetId() + 1);
            bookService.CreateBook(book);
            List<Book> books = bookService.GetBooks();
            Assert.AreEqual(books.Count, 3);
            RemoveAll();
        }

        [TestMethod]
        public void TestFindBookByIdNotNull()
        {
            Book book = new BookBuilder()
                .SetId(1)
                .SetTitle("Title")
                .SetAuthor("Author")
                .SetGenre("Genre")
                .SetQuantity(123)
                .SetPrice(12.3)
                .Build();
            bookService.CreateBook(book);
            Book books = bookService.GetBookById(1);
            Assert.IsNotNull(books);
            RemoveAll();
        }

        [TestMethod]
        public void TestFindBookByQuantityNotNull()
        {
            Book book = new BookBuilder()
                .SetId(1)
                .SetTitle("Title")
                .SetAuthor("Author")
                .SetGenre("Genre")
                .SetQuantity(123)
                .SetPrice(12.3)
                .Build();
            bookService.CreateBook(book);
            List<Book> books = bookService.GetBooksByQuantity(123);
            Assert.AreEqual(books.Count, 1);
            RemoveAll();
        }

        [TestMethod]
        public void TestFindBookByTitleNotNull()
        {
            Book book = new BookBuilder()
                .SetId(1)
                .SetTitle("Title")
                .SetAuthor("Author")
                .SetGenre("Genre")
                .SetQuantity(123)
                .SetPrice(12.3)
                .Build();
            bookService.CreateBook(book);
            List<Book> books = bookService.GetBooksBySpecification("Title");
            Assert.AreEqual(books.Count, 1);
            RemoveAll();
        }

        [TestMethod]
        public void TestFindBookByAuthorNotNull()
        {
            Book book = new BookBuilder()
                .SetId(1)
                .SetTitle("Title")
                .SetAuthor("Author")
                .SetGenre("Genre")
                .SetQuantity(123)
                .SetPrice(12.3)
                .Build();
            bookService.CreateBook(book);
            List<Book> books = bookService.GetBooksBySpecification("Author");
            Assert.AreEqual(books.Count, 1);
            RemoveAll();
        }

        [TestMethod]
        public void TestFindBookByGenreNotNull()
        {
            Book book = new BookBuilder()
                .SetId(1)
                .SetTitle("Title")
                .SetAuthor("Author")
                .SetGenre("Genre")
                .SetQuantity(123)
                .SetPrice(12.3)
                .Build();
            bookService.CreateBook(book);
            List<Book> books = bookService.GetBooksBySpecification("Genre");
            Assert.AreEqual(books.Count, 1);
            RemoveAll();
        }
    }
}
