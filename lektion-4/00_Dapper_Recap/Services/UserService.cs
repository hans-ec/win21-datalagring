using _00_Dapper_Recap.Entitites;
using _00_Dapper_Recap.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Dapper_Recap.Services
{
    internal interface IUserService
    {
        bool CreateUser(User user);
        IEnumerable<User> GetUsers();
    }
    internal class UserService : IUserService
    {
        private SqlHandler _sql = new SqlHandler();


        public bool CreateUser(User user)
        {
            var _user = _sql.GetUserByEmail(user.Email);
            if (_user == null)
            {
                _sql.CreateUser(user);
                return true;
            }

            return false;
        }

        public IEnumerable<User> GetUsers()
        {
            return _sql.GetUsers();
        }
    }
}
