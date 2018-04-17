using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories.Books
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        List<Book> FindBySpecification(string specification);

        List<Book> FindByQuantity(int quantity);
    }
}
