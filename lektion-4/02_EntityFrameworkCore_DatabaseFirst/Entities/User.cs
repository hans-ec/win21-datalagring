using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _02_EntityFrameworkCore_DatabaseFirst.Entities
{
    [Index(nameof(Email), Name = "UQ__Users__A9D10534ABB8B38C", IsUnique = true)]
    public partial class User
    {
        [Key]
        public int Id { get; set; }


        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        
        
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        
        
        [StringLength(100)]
        [Unicode(false)]
        public string Email { get; set; } = null!;
        
        public int AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Users")]
        public virtual Address Address { get; set; } = null!;
    }
}
