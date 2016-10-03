using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterYelp.Models.Repositories;
using System.Data.Entity;

namespace BetterYelp.Models.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _context;
        
        public ISearchRepository Searches { get; private set; }
        public IServiceConnectionsRepository ServiceConnections { get; private set; }

        public UnitOfWork(DbContext context, 
            ISearchRepository searchRepository, 
            IServiceConnectionsRepository serviceConnectionsRepository)
        {
            _context = context;
            Searches = searchRepository;
            ServiceConnections = serviceConnectionsRepository;
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
