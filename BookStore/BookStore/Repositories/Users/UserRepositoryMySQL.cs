using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Database;
using BookStore.Models;
using BookStore.Models.Builders;
using MySql.Data.MySqlClient;

namespace BookStore.Repositories.Users
{
    public class UserRepositoryMySQL : IUserRepository
    {
        private DBConnectionWrapper connectionWrapper;

        public UserRepositoryMySQL(DBConnectionWrapper connectionWrapper)
        {
            this.connectionWrapper = connectionWrapper;
        }

        public bool Create(User t)
        {
            if (t == null)
                return false;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    bool isAdmin = false;
                    if (t.GetRole().RoleName == Constants.Roles.ADMIN)
                        isAdmin = true;
                    command.CommandText = String.Format("Insert into user(id, name, username, password, isAdmin) VALUES('{0}', '{1}', '{2}', '{3}', '{4}'); ", t.GetId(), t.GetName(), t.GetUsername(), t.GetPassword(), isAdmin ? 1 : 0);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
                return true;
        }

        public bool Delete(User t)
        {
            if (t == null)
                return false;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("delete from user where id = {0};", t.GetId());
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        public List<User> FindAll()
        {
            List<User> users = new List<User>();
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Select * from user");
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Add(BuildFromReader(reader));
                    }
                }
                connection.Close();
            }
            return users;
        }

        public User FindById(long id)
        {
            User user = new User();
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Select * from user where id = {0}", id);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user = BuildFromReader(reader);
                    }
                }
                connection.Close();
            }
            return user;
        }

        public User FindByUsernameAndPassword(string username, string password)
        {
            User user = new User();
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("Select * from user where username = '{0}' and password = '{1}' ", username, password);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user = BuildFromReader(reader);
                    }
                }
                connection.Close();
            }
            return user;
        }

        public bool Update(User t)
        {
            if (FindById(t.GetId()) == null)
                return false;
            else
            {
                using (MySqlConnection connection = connectionWrapper.GetConnection())
                {
                    connection.Open();
                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = String.Format("UPDATE user SET name = '{0}' ,username = '{1}' ,password = '{2}' WHERE id = '{3}';", t.GetName(), t.GetUsername(), t.GetPassword(), t.GetId());
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                return true;
            }
        }


        public User BuildFromReader(MySqlDataReader reader)
        {
            Role role = new Role(null,null);
            if (reader.GetBoolean(4))
            {
                role = GetRoleFromRights(Constants.Roles.ADMIN);
            }
            else
            {
                role = GetRoleFromRights(Constants.Roles.EMPLOYEE);
            }
            return new UserBuilder()
                .SetId(reader.GetInt64(0))
                .SetName(reader.GetString(1))
                .SetUsername(reader.GetString(2))
                .SetPassword(reader.GetString(3))
                .SetRole(role)
                .Build();
        }

        private Role GetRoleFromRights(string role)
        {
            List<Right> rights = new List<Right>();
            if (role == Constants.Roles.ADMIN)
            {
                foreach (var right in Constants.Rights.ADMIN_RIGHTS)
                {
                    rights.Add(new Right(right));
                }
            }
            else
            {
                foreach (var right in Constants.Rights.USER_RIGHTS)
                {
                    rights.Add(new Right(right));
                }
            }
            return new Role(role, rights);
        }
    }
}

