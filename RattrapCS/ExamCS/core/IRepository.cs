using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestion.Entities;

namespace Gestion.Core
{
    public interface IRepository<T> where T : IEntity
    {
        List<T> FindAll();
        T FindById(int id);
        void Save(T entity);
        void Delete(int id);
        void Update(T entity);

    }
}