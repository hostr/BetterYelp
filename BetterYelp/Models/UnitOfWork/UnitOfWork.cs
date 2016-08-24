using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterYelp.Models.Repositories;

namespace BetterYelp.Models.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SearchContext _context;

        public ISearchRepository Searches { get; }
        public IServiceConnectionsRepository ServiceConnections { get; }

        public UnitOfWork( )
        {
            _context = new SearchContext();
            Searches = new SearchRepository(_context);
            ServiceConnections = new ServiceConnectionsRepository(_context);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
