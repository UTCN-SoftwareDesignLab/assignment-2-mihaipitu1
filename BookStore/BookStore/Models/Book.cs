using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
        private long id;
        private string title;
        private string author;
        private string genre;
        private int quantity;
        private double price;

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

        public string GetTitle()
        {
            return title;
        }
        public void SetTitle(string title)
        {
            this.title = title;
        }
        public string Title
        {
            get { return GetTitle(); }
            set { SetTitle(value); }
        }

        public string GetAuthor()
        {
            return author;
        }
        public void SetAuthor(string author)
        {
            this.author = author;
        }
        public string Author
        {
            get { return GetAuthor(); }
            set { SetAuthor(value); }
        }

        public string GetGenre()
        {
            return genre;
        }
        public void SetGenre(string genre)
        {
            this.genre = genre;
        }
        public string Genre
        {
            get { return GetGenre(); }
            set { SetGenre(value); }
        }

        public int GetQuantity()
        {
            return quantity;
        }
        public void SetQuantity(int quantity)
        {
            this.quantity = quantity;
        }
        public int Quantity
        {
            get { return GetQuantity(); }
            set { SetQuantity(value); }
        }

        public double GetPrice()
        {
            return price;
        }
        public void SetPrice(double price)
        {
            this.price = price;
        }
        public double Price
        {
            get { return GetPrice(); }
            set { SetPrice(value); }
        }
    }
}
