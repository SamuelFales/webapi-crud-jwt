using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Core.Department.Domain;

namespace WebApiCore.Core.Department.Service.Interfaces
{
    public interface IDepartmentService
    {
        DepartmentModel Add(DepartmentModel dep);

        DepartmentModel Update(DepartmentModel dep);

        bool Delete(int id);

        Task<DepartmentModel> GetByIdAsync(long id);

        Task<IEnumerable<DepartmentModel>> GetAllAsync();
    }
}
