using System;
using System.Collections.Generic;

namespace _01_EntityFramework_DatabaseFirst.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int SubCategoryId { get; set; }
        public int? Quantity { get; set; }

        public virtual SubCategory SubCategory { get; set; } = null!;
    }
}
