using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCore.Core.User.Data.Interfaces;
using WebApiCore.Models;

namespace WebApiCore.Core.User.Data
{
    public class UserRepository : IUserRepository
    {
        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Users>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Users> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Users Save(Users entity)
        {
            throw new NotImplementedException();
        }

        public Users Update(Users entity)
        {
            throw new NotImplementedException();
        }
    }
}
