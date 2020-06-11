using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Porto.Api.Database.Contexts;

namespace Porto.Api.Database.Data
{
    public interface IUnitOfWork
    {
        int SaveChanges();

        IDbContextTransaction BeginTransaction();
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ProtoDbContext _context;

        public UnitOfWork(ProtoDbContext context)
        {
            _context = context;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
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
                _context.Dispose();
            }

            _disposed = true;
        }
    }
}
