using System;
using System.Collections.Generic;

#nullable disable

namespace ThriftBook.Models
{
    public partial class Buyer
    {
        public Buyer()
        {
            BookRatings = new HashSet<BookRating>();
            Invoices = new HashSet<Invoice>();
        }

        public int BuyerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public int? PhoneNumber { get; set; }

        public virtual ICollection<BookRating> BookRatings { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
