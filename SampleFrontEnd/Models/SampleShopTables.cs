using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleFrontEnd.Models
{
    public class Author
    {
        public Author()
        {
            this.Books = new List<Book>();
        }

        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual IEnumerable<Book> Books { get; set; }
    }

    public class Book
    {
        public Book()
        {
            this.OrderDetails = new List<OrderDetail>();
            this.Reviews = new List<Review>();
            this.ShoppingCarts = new List<ShoppingCart>();
        }

        public int BookID { get; set; }
        public int? AuthorID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string ISBN { get; set; }
        public string CoverImage { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }

        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
        public virtual IEnumerable<Review> Reviews { get; set; }
        public virtual IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
    }

    public class Category
    {
        public Category()
        {
            this.Books = new List<Book>();
        }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public virtual IEnumerable<Book> Books { get; set; }
    }

    public class OrderDetail
    {
        public int Id { get; set; }
        public int? OrderID { get; set; }
        public int? BookID { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }

        public virtual Order Order { get; set; }
        public virtual Book Book { get; set; }
    }

    public class Order
    {
        public Order()
        {
            this.OrderDetails = new List<OrderDetail>();
        }

        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }

        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }

    public class Review
    {
        public int ReviewID { get; set; }
        public int BookID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }

        public virtual Book Book { get; set; }
    }

    public class ShoppingCart
    {
        public int RecordID { get; set; }
        public string CartID { get; set; }
        public int Quantity { get; set; }
        public int BookID { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Book Book { get; set; }
    }



}