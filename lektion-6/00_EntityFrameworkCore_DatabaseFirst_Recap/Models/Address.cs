using System;
using System.Collections.Generic;

namespace _00_EntityFrameworkCore_DatabaseFirst_Recap.Models
{
    public partial class Address
    {
        public Address()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
