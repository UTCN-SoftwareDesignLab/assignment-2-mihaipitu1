using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Repositories.Users;

namespace BookStore.Services.Users
{
    public class AdminServiceMySQL : AdminService
    {
        private IUserRepository userRepo;
        public AdminServiceMySQL(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        public bool CreateUser(User user)
        {
            return userRepo.Create(user);
        }

        public bool DeleteUser(User user)
        {
            return userRepo.Delete(user);
        }

        public User GetUserById(long id)
        {
            return userRepo.FindById(id);
        }

        public List<User> GetUsers()
        {
            return userRepo.FindAll();
        }

        public bool UpdateUser(User user)
        {
            return userRepo.Update(user);
        }
    }
}
