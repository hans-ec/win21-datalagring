using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_EntityFrameworkCore_CodeFirst_Recap.Models
{
    internal class AddressEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string StreetName { get; set; } = null!;
        
        [Required]
        [StringLength(50)]
        public string PostalCode { get; set; } = null!;
        
        [Required]
        [StringLength(50)]
        public string City { get; set; } = null!;
        
        [Required]
        [StringLength(50)]
        public string Country { get; set; } = null!;

        public virtual ICollection<CustomerEntity> Customers { get; set; } = new List<CustomerEntity>();
    }
}
