using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Core.Data.EntityFramework;

namespace MovieApp.Core.Data.UnitOfWork
{
    public class efUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private IDbContextTransaction _contextTransaction;
        private bool _disposed;
        public efUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool BeginNewTransection()
        {
            var result = true;

            try
            {
                _contextTransaction = _dbContext.Database.BeginTransaction();

            }
            catch (Exception ex)
            {

                result = false;
            }
            return result;
        }

        public bool Commit()
        {
            var result = true;

            var transection = _contextTransaction != null ? _contextTransaction : _dbContext.Database.BeginTransaction();

            try
            {
                using (transection)
                {
                    _dbContext.SaveChanges();
                    transection.Commit();
                }
            }
            catch (Exception)
            {

                transection.Rollback();
                result = false;

            }

            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

            }

            this._disposed = true;

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool RollBackTransection()
        {
            var result = true;
            try
            {
                _contextTransaction.Rollback();
                _contextTransaction = null;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool SaveChanges()
        {
            var result = true;
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        IEntityRepository<T> IUnitOfWork.GetRepository<T>()
        {
            return new efRepositoryBase<T>(_dbContext);
        }
    }
}
