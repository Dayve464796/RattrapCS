using System;
using System.Collections.Generic;
using System.Linq;
using Npgsql;
using System.Threading.Tasks;

namespace Gestion.Core
{
    public class DatabaseConnexion : IDataAccess
    {
        protected readonly string connectionString = "Host=localhost;Port=5432;Database=gestion_commandes;Username=postgres;Password=seventeen;";

        public NpgsqlConnection GetConnection(){
            var conn=new NpgsqlConnection(connectionString);
            conn.Open();
            return conn;
        }


    }
}