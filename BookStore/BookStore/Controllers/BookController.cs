using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Services.Books;
using BookStore.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        public ActionResult Index()
        {
            var books = bookService.GetBooks();
            return View(books);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            bookService.CreateBook(book);
            return RedirectToAction("Index", "Book");
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookService.GetBookById(id);
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            bookService.UpdateBook(book);
            return RedirectToAction("Index", "Book");
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            var book = bookService.GetBookById(id);
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Book book)
        {
            bookService.DeleteBook(book);
            return RedirectToAction("Index", "Book");
        }

        public ActionResult Report()
        {
            return View();
        }

        public ActionResult GenerateReport(string fileType)
        {
            var books = bookService.GetBooksByQuantity(0);
            return new ConcreteFileFactory().GetFile(books, fileType);
        }
    }
}