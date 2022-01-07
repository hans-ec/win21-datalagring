using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Sql_Recap.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; } = 0;
        public string SubCategory { get; set; } = null!;
        public string Category { get; set; } = null!;

        public int SubCategoryId { get; set; }
    }
}
