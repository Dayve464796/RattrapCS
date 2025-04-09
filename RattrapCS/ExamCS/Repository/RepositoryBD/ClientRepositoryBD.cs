using Npgsql;
using System;
using System.Collections.Generic;
using Gestion.Entities;
using Gestion.Repository;
using Gestion.Core;


namespace Gestion.Repository.Impl
{
    public class ClientRepositoryBD : RepositoryBDImpl<Client>, IRepositoryClient
    {
        public ClientRepositoryBD(IDataAccess dataAccess){
            this.dataAccess=dataAccess;
        }
        public List<Client> FindAll()
        {
            return dataAccess.Clients.ToList();
        }

        public Client FindById(int id)
        {
            return dataAccess.Clients.FirstOrDefault(c => c.Id == id);
        }

        public void Save(Client entity)
        {
            dataAccess.Clients.Add(entity);
            dataAccess.SaveChanges();
        }


        public void Delete(int id)
        {
            var client = dataAccess.Clients.Find(id);
            if (client != null)
            {
                dataAccess.Clients.Remove(client);
                dataAccess.SaveChanges();
            }
        }

        public void Update(Client entity)
        {
            dataAccess.Clients.Update(entity);
            dataAccess.SaveChanges();
        }

        public Client? GetByTel(string telephone)
        {
            return dataAccess.Clients.FirstOrDefault(c => c.Telephone == telephone);
        }
    }
}

