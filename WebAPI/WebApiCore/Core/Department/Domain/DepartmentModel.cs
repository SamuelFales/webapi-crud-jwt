using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Models;

namespace WebApiCore.Core.Department.Domain
{
    public class DepartmentModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        private DepartmentModel(long id, string name)
        {
            Id = id;
            Name = name;
        }

        private DepartmentModel(string name)
        {
            Name = name;
        }

        public static DepartmentModel New(string name) => new DepartmentModel(name);
        public static DepartmentModel Load(long id, string name) => new DepartmentModel(id, name);
        public static Departments Map(DepartmentModel model)
        {
            return new Departments()
            {
                Id = model.Id,
                Name = model.Name
            };
        }


    }
}
