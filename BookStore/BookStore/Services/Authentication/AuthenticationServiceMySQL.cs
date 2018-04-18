using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Repositories.Users;

namespace BookStore.Services.Authentication
{
    public class AuthenticationServiceMySQL : IAuthenticationService
    {
        private IUserRepository userRepo;
        public AuthenticationServiceMySQL(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }
        public User Login(string username,string password)
        {
            return userRepo.FindByUsernameAndPassword(username, EncodePassword(password));
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
