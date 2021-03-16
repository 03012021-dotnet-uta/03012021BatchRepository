using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirstDemo.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? AddressId { get; set; }
        public DateTime? LastOrderDate { get; set; }
        public string Remarks { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
