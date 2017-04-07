using System;
using System.Data.Entity;
using BastardFat.ThirdVersion.DatabaseInteraction.Factory.Interface;

namespace BastardFat.ThirdVersion.DatabaseInteraction.Factory.Base
{
    public class DbContextFactoryBase<TDbContext> 
        : IDbContextFactory<TDbContext>, IDisposable
        where TDbContext : DbContext, new()

    {
        public TDbContext GetDbContext()
        {
            if (_disposedValue)
            {
                throw new ObjectDisposedException("ContextFactory");
            }

            return _context ?? (_context = new TDbContext());
        }

        private TDbContext _context;

        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

    }
}