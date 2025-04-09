using System;
using System.Collections.Generic;
using System.Linq;
using Gestion.Core;
using Npgsql;
using Gestion.Entities;

namespace Gestion.Repository.Impl
{
    public class RepositoryBDImpl<T> : IRepository<T> where T : IEntity
    {
        protected String table;
        protected IDataAccess dataAccess;

        public List<T> FindAll()
        {
            return new List<T>();
        }

        public T FindById(int id)
        {
            return default!;
        }

        public void Save(T entity)
        {
        }

        public void Delete(int id)
        {
        }

        public void Update(T entity)
        {
        }
    }
}