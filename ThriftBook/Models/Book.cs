using System;
using System.Collections.Generic;

#nullable disable

namespace ThriftBook.Models
{
    public partial class Book
    {
        public Book()
        {
            BookInvoices = new HashSet<BookInvoice>();
            BookRatings = new HashSet<BookRating>();
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string BookQuality { get; set; }
        public int? BookQuantity { get; set; }
        public string BookPhoto { get; set; }
        public decimal? Price { get; set; }
        public string StoreName { get; set; }

        public virtual Store StoreNameNavigation { get; set; }
        public virtual ICollection<BookInvoice> BookInvoices { get; set; }
        public virtual ICollection<BookRating> BookRatings { get; set; }
    }
}
