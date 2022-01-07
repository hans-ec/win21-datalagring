using _02_EntityFramework_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_EntityFramework_CodeFirst.Services
{
    internal interface ICategoryService
    {
        void Create(Category category);
        Category Get(int id);
        IEnumerable<Category> GetAll();
    }

    internal class CategoryService : ICategoryService
    {
        private readonly SqlContext _context = new SqlContext();


        public void Create(Category category)
        {
            try
            {
                var _category = _context.Categories.Where(x => x.Name == category.Name).FirstOrDefault();

                if (_category == null)
                {
                    _context.Categories.Add(category);
                    _context.SaveChanges();
                }
            }
            catch { }

        }

        public Category Get(int id)
        {
            return _context.Categories.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories;
        }
    }
}
