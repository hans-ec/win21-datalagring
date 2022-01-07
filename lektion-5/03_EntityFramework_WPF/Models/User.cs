using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_EntityFramework_WPF.Models
{
    [Index(nameof(Email), IsUnique = true)]
    internal class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }


        public string DisplayName => $"{FirstName} {LastName}";
    }
}
