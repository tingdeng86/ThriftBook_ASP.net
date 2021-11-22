using System;
using System.Collections.Generic;

#nullable disable

namespace ThriftBook.Models
{
    public partial class OrderDetail
    {
        public int TransactionId { get; set; }
        public int BookId { get; set; }
        public int? BookQuantity { get; set; }

        public virtual BookDetail Book { get; set; }
    }
}
