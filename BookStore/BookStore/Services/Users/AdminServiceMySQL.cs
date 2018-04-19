using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Repositories.Users;

namespace BookStore.Services.Users
{
    public class AdminServiceMySQL : IAdminService
    {
        private IUserRepository userRepo;
        public AdminServiceMySQL(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        public bool CreateUser(User user)
        {
            user.SetId(GetMaxId());
            user.SetPassword(EncodePassword(user.GetPassword()));
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
            user.SetPassword(EncodePassword(user.GetPassword()));
            return userRepo.Update(user);
        }
        
        private long GetMaxId()
        {
            var users = userRepo.FindAll();
            long id = 0;
            foreach(var user in users)
            {
                if (user.GetId() > id)
                    id = user.GetId();
            }
            return id+1;
        }

        private string EncodePassword(string password)
        {
            SHA256 sha256 = new SHA256Managed();
            byte[] sha256Bytes = System.Text.Encoding.Default.GetBytes(password);
            byte[] cryString = sha256.ComputeHash(sha256Bytes);
            string sha256Str = string.Empty;
            foreach (byte b in cryString)
            {
                sha256Str += b.ToString("x");
            }
            return sha256Str;
        }
    }
}
