using _02_EntityFrameworkCore_DatabaseFirst.Data;
using _02_EntityFrameworkCore_DatabaseFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EntityFrameworkCore_DatabaseFirst.Services
{
    internal class ProductService
    {
        SqlContext _context = new SqlContext();

        public void CreateProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products;
        }

        public Product GetProduct(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateProduct(int id, string productName)
        {
            var product = _context.Products.Find(id);
            if(product != null)
            {
                product.Name = productName;
                _context.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if(product != null)
            {
                _context.Remove(product);
                _context.SaveChanges();
            }
                
        }
    }
}
