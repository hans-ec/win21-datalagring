using _01_EntityFramework_DatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_EntityFramework_DatabaseFirst.Services
{
    internal interface ISubCategoryService
    {
        void Create(SubCategory subcategory);
        SubCategory Get(int id);
        IEnumerable<SubCategory> GetAll();
    }

    internal class SubCategoryService : ISubCategoryService
    {
        private readonly SqlContext _context = new SqlContext();

        public void Create(SubCategory subcategory)
        {
            try
            {
                var _subcategory = _context.Categories.Where(x => x.Name == subcategory.Name).FirstOrDefault();

                if (_subcategory == null)
                {
                    _context.SubCategories.Add(subcategory);
                    _context.SaveChanges();
                }
            }
            catch { }
        }

        public SubCategory Get(int id)
        {
            return _context.SubCategories.Include(x => x.Category).Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<SubCategory> GetAll()
        {
            return _context.SubCategories.Include(x => x.Category);
        }
    }
}
