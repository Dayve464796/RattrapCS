using System;
using Gestion.Entities;
using Gestion.Core;

namespace Gestion.Repository
{
    public interface IRepositoryClient : IRepository<Client>
    {
        Client GetByTel(string telephone);
    }
}