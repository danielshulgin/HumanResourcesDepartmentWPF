using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesDepartment.Domain.Sercices
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Create(T entity);

        Task<T> Get(int id);

        Task<T> Update(int id, T entity);

        Task<bool> Delete(int id);
    }
}
