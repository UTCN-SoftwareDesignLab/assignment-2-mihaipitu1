﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Builders
{
    public class UserBuilder
    {
        private User user;

        public UserBuilder()
        {
            user = new User();
        }

        public UserBuilder SetId(long id)
        {
            user.SetId(id);
            return this;
        }

        public UserBuilder SetName(string name)
        {
            user.SetName(name);
            return this;
        }

        public UserBuilder SetUsername(string username)
        {
            user.SetUsername(username);
            return this;
        }

        public UserBuilder SetPassword(string password)
        {
            user.SetPassword(password);
            return this;
        }

        public UserBuilder SetRole(Role role)
        {
            user.SetRole(role);
            return this;
        }

        public User Build()
        {
            return user;
        }
    }
}
