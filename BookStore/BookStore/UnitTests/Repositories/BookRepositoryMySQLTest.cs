using BookStore.Database;
using BookStore.Models;
using BookStore.Models.Builders;
using BookStore.Repositories.Books;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.UnitTests.Repositories
{
    [TestFixture]
    public class BookRepositoryMySQLTest
    {
        private static IBookRepository bookRepo;

        [SetUp()]
        public static void SetUpClass()
        {
            bookRepo = new BookRepositoryMySQL( new DBConnectionFactory().GetConnectionWrapper(true));
        }

        public void CleanUp()
        {
            List<Book> books = bookRepo.FindAll();
            foreach(var book in books)
            {
                bookRepo.Delete(book);
            }
        }

        [Test]
        public void FindAll()
        {
            List<Book> books = bookRepo.FindAll();
            Assert.AreEqual(books.Count, 0);
        }

        [Test]
        public void FindAllWhenDbNotEmpty()
        {
            Book book = new BookBuilder()
                .SetTitle("Title")
                .SetAuthor("Author")
                .SetGenre("Genre")
                .SetQuantity(0)
                .SetPrice(1.0f)
                .Build();
            bookRepo.Create(book);
            bookRepo.Create(book);
            List<Book> books = bookRepo.FindAll();
            Assert.AreEqual(books.Count, 2);
        }

        [Test]
        public void CreateBook()
        {
            Book book = new BookBuilder()
                .SetTitle("Title")
                .SetAuthor("Author")
                .SetGenre("Genre")
                .SetQuantity(0)
                .SetPrice(1.0f)
                .Build();
            Assert.IsTrue(bookRepo.Create(book));
        }
    }
}
