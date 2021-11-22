using System;
using System.Collections.Generic;

#nullable disable

namespace ThriftBook.Models
{
    public partial class Profile
    {
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? BuyerId { get; set; }

        public virtual Buyer Buyer { get; set; }
    }
}
