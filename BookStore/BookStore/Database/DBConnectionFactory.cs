using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Database
{
    public class DBConnectionFactory
    {
        public DBConnectionWrapper GetConnectionWrapper(bool test)
        {
            if (test)
            {
                return new DBConnectionWrapper("bookstore_test");
            }
            return new DBConnectionWrapper("bookstore");
        }
    }
}
