using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Sql_Dapper_Recap.Models
{
    internal class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;

        public int CategoryId { get; set; }
    }
}
