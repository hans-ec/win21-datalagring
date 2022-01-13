using _03_EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_EntityFrameworkCore.Contexts
{
    internal class SqlContext : DbContext
    {
        public SqlContext()
        {            
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public virtual DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HansMattin-Lassei\Documents\Utbildning\WIN21\win21-datalagring\lektion-7\03_EntityFrameworkCore\Data\sql_efc_db.mdf;Integrated Security=True;Connect Timeout=30");
        }
    }
}
