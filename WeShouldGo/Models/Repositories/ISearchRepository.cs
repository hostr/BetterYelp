using WeShouldGo.Models.Entities;
using WeShouldGo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeShouldGo.Models.Repositories
{
    public interface ISearchRepository : IRepository<Search>
    {
        IEnumerable<Search> GetUserSearches(ApplicationUser user);
    }
}
