﻿namespace HumanResourcesDepartment.Domain.Sercices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Create(T entity);

        Task<T> Get(int id);

        Task<T> Update(int id, T entity);

        Task<bool> Delete(int id);
    }
}
