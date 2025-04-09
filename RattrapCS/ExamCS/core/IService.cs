using Gestion.Entities;

namespace Gestion.Core
{
    public interface IService<T>
    {
        void Create(T entity);
        List<T> Show();
        void Update(T entity);
        T GetById(int id);
        void Delete(T entity);
    }
}