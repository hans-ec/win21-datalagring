using System;
using System.Collections.Generic;

namespace _01_EntityFramework_DatabaseFirst.Models
{
    public partial class Category
    {
        public Category()
        {
            SubCategories = new HashSet<SubCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
