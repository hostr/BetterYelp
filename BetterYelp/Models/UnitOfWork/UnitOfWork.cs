using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterYelp.Models.Repositories;

namespace BetterYelp.Models.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SearchContext _context;

        public ISearchRepository Searches { get; private set; }
        public IServiceConnectionsRepository ServiceConnections { get; private set; }

        public UnitOfWork(SearchContext context)
        {
            _context = context;
            Searches = new SearchRepository(context);
            ServiceConnections = new ServiceConnectionsRepository(context);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
