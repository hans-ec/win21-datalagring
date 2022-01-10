using System;
using System.Collections.Generic;

namespace _00_EntityFrameworkCore_DatabaseFirst_Recap.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int AddressId { get; set; }

        public virtual Address Address { get; set; } = null!;
    }
}
