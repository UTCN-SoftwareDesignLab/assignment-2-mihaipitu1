using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Database;
using BookStore.Models;
using BookStore.Models.Builders;
using MySql.Data.MySqlClient;

namespace BookStore.Repositories.Books
{
    public class BookRepositoryMySQL : IBookRepository
    {
        private DBConnectionWrapper connectionWrapper;

        public BookRepositoryMySQL(DBConnectionWrapper connectionWrapper)
        {
            this.connectionWrapper = connectionWrapper;
        }

        public Book BuildFromReader(MySqlDataReader reader)
        {
            return new BookBuilder()
                .SetId(reader.GetInt64(0))
                .SetTitle(reader.GetString(1))
                .SetAuthor(reader.GetString(2))
                .SetGenre(reader.GetString(3))
                .SetQuantity(reader.GetInt32(4))
                .SetPrice(reader.GetDouble(5))
                .Build();
        }

        public bool Create(Book t)
        {
            if (t == null)
                return false;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("INSERT INTO book (id,title,author,genre,quantity,price) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}');",t.GetId(),t.GetTitle(),t.GetAuthor(),t.GetGenre(),t.GetQuantity(),t.GetPrice());
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        public bool Delete(Book t)
        {
            if (t == null)
                return false;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("DELETE FROM book where id = '{0}';", t.GetId());
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }

        public List<Book> FindAll()
        {
            List<Book> books = new List<Book>();
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("SELECT * FROM book");
                    MySqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        books.Add(BuildFromReader(reader));
                    }
                }
                connection.Close();
            }
            return books;
        }

        public List<Book> FindBySpecification(string specification)
        {
            List<Book> books = new List<Book>();
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("SELECT * FROM book WHERE author LIKE '%{0}%' OR title LIKE '%{0}%' OR genre LIKE '%{0}%",specification);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        books.Add(BuildFromReader(reader));
                    }
                }
                connection.Close();
            }
            return books;
        }

        public Book FindById(long id)
        {
            Book book = new Book();
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("SELECT * FROM book WHERE id = {0}",id);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        book = BuildFromReader(reader);
                    }
                }
                connection.Close();
            }
            return book;
        }

        public List<Book> FindByQuantity(int quantity)
        {
            List<Book> books = new List<Book>();
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("SELECT * FROM book WHERE quantity = {0}",quantity);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        books.Add(BuildFromReader(reader));
                    }
                }
                connection.Close();
            }
            return books;
        }

        public bool Update(Book t)
        {
            if (t == null)
                return false;
            using (MySqlConnection connection = connectionWrapper.GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("UPDATE book SET title = '{0}', author = '{1}', genre = '{2}', quantity = '{3}', price = '{4}' WHERE id = '{5}'", t.GetTitle(), t.GetAuthor(), t.GetGenre(), t.GetQuantity(), t.GetPrice(), t.GetId());
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return true;
        }
    }
}
