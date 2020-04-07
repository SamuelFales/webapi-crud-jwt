using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCore.Core.Employee.Data.Interfaces;
using WebApiCore.Models;

namespace WebApiCore.Core.Employee.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employees>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employees> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Employees Save(Employees entity)
        {
            throw new NotImplementedException();
        }

        public Employees Update(Employees entity)
        {
            throw new NotImplementedException();
        }
    }
}
