using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _02_EntityFrameworkCore_DatabaseFirst.Entities
{
    public partial class Product
    {
        [Key]
        public int Id { get; set; }
        
        
        [StringLength(200)]
        public string Name { get; set; } = null!;
        
        
        public string? Description { get; set; }
        
        
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
