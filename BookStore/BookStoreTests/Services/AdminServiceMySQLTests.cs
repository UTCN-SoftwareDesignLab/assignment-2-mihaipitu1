using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Database;
using BookStore.Models;
using BookStore.Models.Builders;
using BookStore.Repositories.Users;
using BookStore.Services.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BookStoreTests.Services
{
    [TestClass]
    public class AdminServiceMySQLTests
    {
        private IAdminService adminService;

        public AdminServiceMySQLTests()
        {
            adminService = new AdminServiceMySQL(new UserRepositoryMySQL(new DBConnectionFactory().GetConnectionWrapper(true)));
        }

        public void RemoveAll()
        {
            List<User> users = adminService.GetUsers();

            foreach (var user in users)
            {
                adminService.DeleteUser(user);
            }
        }

        [TestMethod]
        public void TestFindAllUsers()
        {
            RemoveAll();
            List<User> users = adminService.GetUsers();
            Assert.AreEqual(users.Count, 0);
        }

        [TestMethod]
        public void TestCreateUserUser()
        {
            RemoveAll();
            User user = new UserBuilder()
                .SetId(1)
                .SetName("name")
                .SetUsername("User")
                .SetPassword("Password")
                .SetRole(new Role("admin", null))
                .Build();
            Assert.IsTrue(adminService.CreateUser(user));
            RemoveAll();
        }

        [TestMethod]
        public void TestEditUser()
        {
            RemoveAll();
            User user = new UserBuilder()
                .SetId(1)
                .SetName("name")
                .SetUsername("User")
                .SetPassword("Password")
                .SetRole(new Role("admin", null))
                .Build();
            adminService.CreateUser(user);
            Assert.IsTrue(adminService.UpdateUser(user));
            RemoveAll();
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            RemoveAll();
            User user = new UserBuilder()
                .SetId(1)
                .SetName("name")
                .SetUsername("User")
                .SetPassword("Password")
                .SetRole(new Role("admin", null))
                .Build();
            adminService.CreateUser(user);
            Assert.IsTrue(adminService.DeleteUser(user));
            RemoveAll();
        }

        [TestMethod]
        public void TestFindUserById()
        {
            User user = adminService.GetUserById(0);
            Assert.IsNull(user.GetName());
        }

        [TestMethod]
        public void TestFindAllUsersNotNull()
        {
            RemoveAll();
            User user = new UserBuilder()
                .SetId(1)
                .SetName("name")
                .SetUsername("User")
                .SetPassword("Password")
                .SetRole(new Role("admin", null))
                .Build();
            adminService.CreateUser(user);
            user.SetId(user.GetId() + 1);
            adminService.CreateUser(user);
            user.SetId(user.GetId() + 1);
            adminService.CreateUser(user);
            List<User> users = adminService.GetUsers();
            Assert.AreEqual(users.Count, 3);
            RemoveAll();
        }

        [TestMethod]
        public void TestFindUserByIdNotNull()
        {
            RemoveAll();
            User user = new UserBuilder()
                .SetId(1)
                .SetName("name")
                .SetUsername("User")
                .SetPassword("Password")
                .SetRole(new Role("admin", null))
                .Build();
            adminService.CreateUser(user);
            User users = adminService.GetUserById(1);
            Assert.IsNotNull(users);
            RemoveAll();
        }
    }
}
