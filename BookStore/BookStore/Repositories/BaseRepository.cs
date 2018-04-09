using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
    public interface IBaseRepository<T>
    {
        bool Create(T t);

        List<T> FindAll();

        bool Update(T t);

        bool Delete(T t);

        T FindById(long id);

        T BuildFromReader(MySqlDataReader reader);
    }
}
