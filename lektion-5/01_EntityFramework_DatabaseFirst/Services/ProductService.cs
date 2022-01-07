using _01_EntityFramework_DatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_EntityFramework_DatabaseFirst.Services
{
    internal interface IProductService
    {
        void Create(Product product);
        Product Get(int id);
        IEnumerable<Product> GetAll();
    }

    internal class ProductService : IProductService
    {
        private readonly SqlContext _context = new SqlContext();

        public void Create(Product product)
        {
            var _product = _context.Products.Where(x => x.Name == product.Name).FirstOrDefault();

            if (_product == null)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
        }

        public Product Get(int id)
        {
            return _context.Products.Include(x => x.SubCategory).ThenInclude(x => x.Category).Where(x => x.Id == id).FirstOrDefault() ?? null!;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.Include(x => x.SubCategory).ThenInclude(x => x.Category);
        }
    }
}
