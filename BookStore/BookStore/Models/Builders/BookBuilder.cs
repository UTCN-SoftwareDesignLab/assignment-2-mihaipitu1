using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Builders
{
    public class BookBuilder
    {
        private Book book;

        public BookBuilder()
        {
            book = new Book();
        }

        public BookBuilder SetId(long id)
        {
            book.SetId(id);
            return this;
        }

        public BookBuilder SetTitle(string title)
        {
            book.SetTitle(title);
            return this;
        }

        public BookBuilder SetAuthor(string author)
        {
            book.SetAuthor(author);
            return this;
        }

        public BookBuilder SetGenre(string genre)
        {
            book.SetGenre(genre);
            return this;
        }

        public BookBuilder SetQuantity(int quantity)
        {
            book.SetQuantity(quantity);
            return this;
        }

        public BookBuilder SetPrice(double price)
        {
            book.SetPrice(price);
            return this;
        }

        public Book Build()
        {
            return book;
        }
    }
}
