using System;
using Gestion.Entities;
using Gestion.Core;
using Gestion.Service;
using Gestion.Repository;

namespace Gestion.Service.Impl
{
    public class ClientService : IServiceClient<Client>
    {
        private readonly IRepository<Client> repository;

        public ClientService(IRepository<Client> repository)
        {
            this.repository = repository;
        }

        public void Create(Client client)
        {
            repository.Save(client);
        }

        public List<Client> Show()
        {
            return repository.FindAll();
        }

        public void Update(Client client)
        {
            repository.Update(client);
        }

        public Client GetById(int id)
        {
            return repository.FindById(id);
        }
        
        public Client GetByTel(string telephone)
        {
            return ((IRepositoryClient)repository).GetByTel(telephone);
        }

        public Client GetUser(User user)
        {
            return ((IRepositoryClient)repository).GetClientByUser(user);
        }

        public void Delete(Client client)
        {
            repository.Delete(client.Id);
        }
    }
}