using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirstDemo.Models
{
    public partial class Address
    {
        public Address()
        {
            Customers = new HashSet<Customer>();
        }

        public int Addressid { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
