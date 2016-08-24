using BetterYelp.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterYelp.Models.UnitOfWork
{
    public interface IUnitOfWork
    {
        ISearchRepository Searches { get; }
        IServiceConnectionsRepository ServiceConnections { get; }
        int Save();
    }
}
