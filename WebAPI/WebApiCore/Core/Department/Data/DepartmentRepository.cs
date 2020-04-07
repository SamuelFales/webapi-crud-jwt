using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Core.Department.Data.Interfaces;
using WebApiCore.Models;

namespace WebApiCore.Core.Department.Data
{
    public class DepartmentRepository : IDepartmentReposiory
    {
        private EmployeeDBContext _context;
        public DepartmentRepository(EmployeeDBContext context)
        {
            _context = context;
        }

        public bool Delete(long id)
        {
            var dep = _context.Departments.Find(id);
            if (dep == null)
            {
                return false;
            }

            _context.Departments.Remove(dep);
           var result =   _context.SaveChanges();

            return result >= 1;
        }

        public async Task<IEnumerable<Departments>> GetAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Departments> GetByIdAsync(long id)
        {
            return await _context.Departments.FindAsync(id);
        }
    
        public Departments Save(Departments entity)
        {
            _context.Departments.Add(entity);
            _context.SaveChanges();

            return _context.Departments.Find(entity.Id);
        }

        public Departments Update(Departments entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
                return _context.Departments.Find(entity.Id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return entity;
            }
        }
    }
}
