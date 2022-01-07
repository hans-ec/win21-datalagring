using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EntityFramework_CodeFirst.Models
{
    [Index(nameof(Name), IsUnique = true)]
    internal class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = null!;
        
        public string? Description { get; set; }
        
        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }


        public int? Quantity { get; set; }

        
        [Required]
        public int SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; } = null!;
    }
}
