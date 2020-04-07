using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Core.Department.Domain;
using WebApiCore.Core.Department.Data.Interfaces;
using WebApiCore.Core.Department.Service.Interfaces;

namespace WebApiCore.Core.Department.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentReposiory _departmentReposiory;

        public DepartmentService(IDepartmentReposiory departmentReposiory)
        {
            _departmentReposiory = departmentReposiory;
        }
        public bool Delete(int id)
        {
            return _departmentReposiory.Delete(id);
        }

        public async Task<IEnumerable<DepartmentModel>> GetAllAsync()
        {
            var allDeps =  await _departmentReposiory.GetAllAsync();
            var listOfDepsModel = new List<DepartmentModel>();

            if (allDeps.Count() > 0)
            {
                foreach (var dep in allDeps)
                {
                    listOfDepsModel.Add(DepartmentModel.Load(dep.Id, dep.Name));
                }
            }

            return listOfDepsModel;

        }

        public async Task<DepartmentModel> GetByIdAsync(long id)
        {
            var dep = await _departmentReposiory.GetByIdAsync(id);

            if (dep != null)
                return DepartmentModel.Load(dep.Id, dep.Name);
            else
                return null;
        }

        public DepartmentModel Add(DepartmentModel dep)
        {
            var depEntity = DepartmentModel.Map(dep);

            _departmentReposiory.Save(depEntity);

            return DepartmentModel.Load(depEntity.Id, depEntity.Name);
        }

        public DepartmentModel Update(DepartmentModel dep)
        {
            var depEntity = DepartmentModel.Map(dep);

            _departmentReposiory.Update(depEntity);

            return DepartmentModel.Load(depEntity.Id, depEntity.Name);
        }
    }
}
