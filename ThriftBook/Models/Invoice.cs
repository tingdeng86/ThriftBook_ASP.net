using System;
using System.Collections.Generic;

#nullable disable

namespace ThriftBook.Models
{
    public partial class Invoice
    {
        public int TransactionId { get; set; }
        public int? BuyerId { get; set; }
        public double? TotalPrice { get; set; }
        public DateTime? DateOfTransaction { get; set; }

        public virtual BookDetail Buyer { get; set; }
    }
}
