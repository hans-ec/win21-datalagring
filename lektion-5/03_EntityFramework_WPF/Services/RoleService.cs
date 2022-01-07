using _03_EntityFramework_WPF.Data;
using _03_EntityFramework_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_EntityFramework_WPF.Services
{
    internal interface IRoleService
    {
        bool Create(string roleName);
        IEnumerable<Role> GetAll();
    }

    internal class RoleService : IRoleService
    {
        private readonly SqlContext _context = new();

        public bool Create(string roleName)
        {
            var role = _context.Roles.Where(x => x.Name == roleName).FirstOrDefault();
            if(role == null)
            {
                _context.Roles.Add(new Role { Name = roleName });
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles;
        }
    }
}
