using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion.Core.Factory
{
    public class DatabaseRepositoryFactory : IRepositoryFactory
{
    public IRepositoryClient CreateClientRepository()
    {
        return new ClientRepositoryBD(new DatabaseConnexion());
    }


    public IRepositoryProduit CreateProduitRepository()
    {
        return new ProduitRepositoryBD(new DatabaseConnexion());
    }

    public IRepositoryCommande CreateCommandeRepository()
    {
        return new CommandeRepositoryBD(CreateClientRepository(), new DatabaseConnexion());
    }

    public IRepositoryUser CreateUserRepository()
    {
        return new UserRepositoryBD(new DatabaseConnexion());
    }
}
}