using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Database;
using BookStore.Models;
using BookStore.Repositories.Users;
using BookStore.Services.Authentication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStoreTests.Services
{
    [TestClass]
    public class AutheticationServiceMySQLTest
    {
        private IAuthenticationService authService;

        public AutheticationServiceMySQLTest()
        {
            authService = new AuthenticationServiceMySQL(new UserRepositoryMySQL(new DBConnectionFactory().GetConnectionWrapper(true)));
        }

        [TestMethod]
        public void TestLoginUser()
        {
            User user = authService.Login("user", "pass");
            Assert.IsNull(user.GetName());
        }
    }
}
