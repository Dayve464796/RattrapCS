using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestion.Enums;


namespace Gestion.Core.Factory
{
    public static class AbstractFactory
    {
        public static IRepositoryFactory? CreateFactory(Persistence type)
        {
            return type switch
            {
                Persistence.LIST => new ListRepositoryFactory(),
                Persistence.DATABASE => new DatabaseRepositoryFactory(),
                _ => null
            };
        }
    }
}
