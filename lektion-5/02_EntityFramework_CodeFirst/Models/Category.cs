using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EntityFramework_CodeFirst.Models
{

    [Index(nameof(Name), IsUnique = true)]
    internal class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = null!;

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
