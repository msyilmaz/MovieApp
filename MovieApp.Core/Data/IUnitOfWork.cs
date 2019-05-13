using MovieApp.Core.Data.Entitiy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IEntityRepository<T> GetRepository<T>() where T : class, IEntity, new();
        bool BeginNewTransection();
        bool RollBackTransection();
        bool SaveChanges();
        bool Commit();
    }
}
