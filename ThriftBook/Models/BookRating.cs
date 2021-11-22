using System;
using System.Collections.Generic;

#nullable disable

namespace ThriftBook.Models
{
    public partial class BookRating
    {
        public int BookId { get; set; }
        public int BuyerId { get; set; }
        public decimal? BookRating1 { get; set; }
        public string Comments { get; set; }

        public virtual BookDetail Book { get; set; }
        public virtual Buyer Buyer { get; set; }
    }
}
