using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Core.Base
{
    public interface IRepositoryBase<T>
    {
        T Save(T entity);

        T Update(T entity);

        bool Delete(long id);

        Task<T> GetByIdAsync(long id);

        Task<IEnumerable<T>> GetAllAsync();

    }
}
