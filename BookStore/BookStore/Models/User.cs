using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class User
    {
        private long id;
        private string name;
        private string username;
        private string password;
        private Role role;

        public long GetId()
        {
            return id;
        }
        public void SetId(long id)
        {
            this.id = id;
        }
        public long Id
        {
            get { return GetId(); }
            set { SetId(value); }
        }

        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return GetName(); }
            set { SetName(value); }
        }

        public string GetUsername()
        {
            return username;
        }
        public void SetUsername(string username)
        {
            this.username = username;
        }
        public string Username
        {
            get { return GetUsername(); }
            set { SetUsername(value); }
        }

        public string GetPassword()
        {
            return password;
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }
        public string Password
        {
            get { return GetPassword(); }
            set { SetPassword(value); }
        }

        public Role GetRole()
        {
            return role;
        }
        public void SetRole(Role role)
        {
            this.role = role;
        }
        public Role Role
        {
            get { return GetRole(); }
            set { SetRole(value); }
        }
    }
}
