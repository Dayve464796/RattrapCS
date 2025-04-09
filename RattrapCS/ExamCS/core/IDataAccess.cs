using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using Gestion.Entities;

namespace Gestion.Core
{
    public interface IDataAccess
    {
        NpgsqlConnection GetConnection();
    }

}