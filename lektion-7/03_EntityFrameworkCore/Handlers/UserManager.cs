using _03_EntityFrameworkCore.Contexts;
using _03_EntityFrameworkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_EntityFrameworkCore.Handlers
{
    internal class UserManager
    {
        private SqlContext _context;

        public UserManager()
        {
            _context = new SqlContext();
        }


        public void Add(UserModel user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<UserModel> Get()
        {
            return _context.Users;
        }
    }
}
