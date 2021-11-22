using System;
using System.Collections.Generic;

#nullable disable

namespace ThriftBook.Models
{
    public partial class Store
    {
        public Store()
        {
            BookDetails = new HashSet<BookDetail>();
        }

        public string StoreName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<BookDetail> BookDetails { get; set; }
    }
}
