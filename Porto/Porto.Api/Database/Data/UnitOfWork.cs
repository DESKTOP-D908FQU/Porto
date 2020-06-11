using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Porto.Api.Database.Contexts;

namespace Porto.Api.Database.Data
{
    public interface IUnitOfWork : IUnitOfWork<ProtoDbContext>
    {
    }

    public class UnitOfWork : UnitOfWork<ProtoDbContext>, IUnitOfWork, IDisposable
    {
        public UnitOfWork(ProtoDbContext dbContext) 
            : base(dbContext)
        {
        }
    }

    public interface IUnitOfWork<TContext> : IDisposable
        where TContext : DbContext
    {
        int Commit();

        Task<int> CommitAsync();

        IDbContextTransaction BeginTransaction();
    }

    public class UnitOfWork<TContext> : IUnitOfWork<TContext>
        where TContext : DbContext
    {
        public UnitOfWork(TContext context)
        {
            DbContext = context;
        }

        public TContext DbContext { get; }

        public virtual int Commit()
        {
            return DbContext.SaveChanges();
        }

        public virtual Task<int> CommitAsync()
        {
            return DbContext.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return DbContext.Database.BeginTransaction();
        }

        private bool _disposed = false;

        ~UnitOfWork() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                DbContext?.Dispose();
            }

            _disposed = true;
        }
    }
}
