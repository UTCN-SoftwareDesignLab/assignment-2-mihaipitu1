using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories.Books
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        List<Book> FindByTitle(string title);

        List<Book> FindByAuthor(string author);

        List<Book> FindByGenre(string genre);

        List<Book> FindByQuantity(int quantity);
    }
}
