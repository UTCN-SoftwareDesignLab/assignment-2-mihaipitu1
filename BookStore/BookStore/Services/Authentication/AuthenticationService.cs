using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Authentication
{
    public interface IAuthenticationService
    {
        User Login(string username, string password);
    }
}
