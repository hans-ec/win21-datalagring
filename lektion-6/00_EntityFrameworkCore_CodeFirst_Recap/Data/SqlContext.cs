using _00_EntityFrameworkCore_CodeFirst_Recap.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_EntityFrameworkCore_CodeFirst_Recap.Data
{
    internal class SqlContext : DbContext
    {
        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public virtual DbSet<AddressEntity> Addresses { get; set; } = null!;
        public virtual DbSet<CustomerEntity> Customers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN21\win21-datalagring\lektion-6\00_EntityFrameworkCore_CodeFirst_Recap\Data\efc_codefirst.mdf;Integrated Security=True;Connect Timeout=30");
        }
    }
}
