using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Users
{
    public interface AdminService
    {
        bool CreateUser(User user);

        bool UpdateUser(User user);

        bool DeleteUser(User user);

        List<User> GetUsers();

        User GetUserById(long id);
    }
}
