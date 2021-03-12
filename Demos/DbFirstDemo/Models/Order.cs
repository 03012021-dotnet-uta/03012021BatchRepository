using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirstDemo.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
