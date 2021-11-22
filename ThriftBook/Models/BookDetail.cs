using System;
using System.Collections.Generic;

#nullable disable

namespace ThriftBook.Models
{
    public partial class BookDetail
    {
        public BookDetail()
        {
            BookRatings = new HashSet<BookRating>();
            Invoices = new HashSet<Invoice>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Gennre { get; set; }
        public string BookQuality { get; set; }
        public int? BookQuantity { get; set; }
        public string BookPhoto { get; set; }
        public decimal? Price { get; set; }
        public string StoreName { get; set; }

        public virtual Store StoreNameNavigation { get; set; }
        public virtual ICollection<BookRating> BookRatings { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
