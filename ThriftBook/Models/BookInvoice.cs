using System;
using System.Collections.Generic;

#nullable disable

namespace ThriftBook.Models
{
    public partial class BookInvoice
    {
        public int TransactionId { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Invoice Transaction { get; set; }
    }
}
