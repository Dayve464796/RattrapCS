using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion.Core.Factory
{
    public interface IRepositoryFactory
    {
        IRepositoryClient CreateClientRepository();
        IRepositoryProduit CreateProduitRepository();
        IRepositoryCommande CreateCommandeRepository();
        IRepositoryUser CreateUserRepository();
    }
}