using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Database;
using BookStore.Models;
using BookStore.Models.Builders;
using BookStore.Repositories.Books;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStoreTests.Repositories
{
    [TestClass]
    public class BookRepositoryMySQLTest
    {
        private IBookRepository bookRepo;

        public BookRepositoryMySQLTest()
        {
            bookRepo = new BookRepositoryMySQL(new DBConnectionFactory().GetConnectionWrapper(true));
        }
        
        public void RemoveAll()
        {
            List<Book> books = bookRepo.FindAll();

            foreach(var book in books)
            {
                bookRepo.Delete(book);
            }
        }

        [TestMethod]
        public void TestFindAllBooks()
        {
            List<Book> books = bookRepo.FindAll();
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
            Assert.IsTrue(bookRepo.Create(book));
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
            bookRepo.Create(book);
            Assert.IsTrue(bookRepo.Update(book));
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
            bookRepo.Create(book);
            Assert.IsTrue(bookRepo.Delete(book));
            RemoveAll();
        }


        [TestMethod]
        public void TestFindBookById()
        {
            Book books = bookRepo.FindById(0);
            Assert.IsNull(books.GetTitle());
        }


        [TestMethod]
        public void TestFindBooksByQuantity()
        {
            List<Book> books = bookRepo.FindByQuantity(3);
            Assert.AreEqual(books.Count, 0);
        }


        [TestMethod]
        public void TestFindBooksBySpecification()
        {
            List<Book> books = bookRepo.FindBySpecification(null);
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
            bookRepo.Create(book);
            book.SetId(book.GetId() + 1);
            bookRepo.Create(book);
            book.SetId(book.GetId() + 1);
            bookRepo.Create(book);
            List<Book> books = bookRepo.FindAll();
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
            bookRepo.Create(book);
            Book books = bookRepo.FindById(1);
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
            bookRepo.Create(book);
            List<Book> books = bookRepo.FindByQuantity(123);
            Assert.AreEqual(books.Count,1);
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
            bookRepo.Create(book);
            List<Book> books = bookRepo.FindBySpecification("Title");
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
            bookRepo.Create(book);
            List<Book> books = bookRepo.FindBySpecification("Author");
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
            bookRepo.Create(book);
            List<Book> books = bookRepo.FindBySpecification("Genre");
            Assert.AreEqual(books.Count, 1);
            RemoveAll();
        }
    }
}
