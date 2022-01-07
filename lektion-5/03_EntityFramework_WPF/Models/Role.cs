using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_EntityFramework_WPF.Models
{
    [Index(nameof(Name), IsUnique = true)]
    internal class Role
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
