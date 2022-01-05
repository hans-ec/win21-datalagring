using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _02_EntityFrameworkCore_DatabaseFirst.Entities
{
    public partial class Address
    {
        public Address()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }
        
        
        [StringLength(50)]
        public string StreetName { get; set; } = null!;
        
        
        [StringLength(5)]
        [Unicode(false)]
        public string PostalCode { get; set; } = null!;
        
        
        [StringLength(50)]
        public string City { get; set; } = null!;

        
        
        [InverseProperty(nameof(User.Address))]
        public virtual ICollection<User> Users { get; set; }
    }
}
