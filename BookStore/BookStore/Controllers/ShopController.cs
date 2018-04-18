using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Services.Books;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class ShopController : Controller
    {
        private IBookService bookService;
        public ShopController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        public ActionResult Index(string description)
        {
            var books = bookService.GetBooks();
            if(!String.IsNullOrEmpty(description))
            {
                books = bookService.GetBooksBySpecification(description);
            }
            return View(books);
        }
        public ActionResult Sell(int id)
        {
            var book = bookService.GetBookById(id);
            return View(book);
        }

        [HttpPost]
        public ActionResult Sell(Book book, int quantity)
        {
            var newBook = bookService.GetBookById(book.GetId());
            if(quantity > newBook.GetQuantity())
            {
                return StatusCode(404);
            }
            newBook.SetQuantity(newBook.GetQuantity() - quantity);
            bookService.UpdateBook(newBook);
            return RedirectToAction("Index", "Shop");
        }
    }
}