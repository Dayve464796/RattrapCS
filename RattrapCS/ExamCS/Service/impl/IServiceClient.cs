using System;
using Gestion.Entities;
using Gestion.Core;


namespace Gestion.Service
{
    public interface IServiceClient<T> : IService<T>
    {
        T GetByTel(string telephone);
    }
}