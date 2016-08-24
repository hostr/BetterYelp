using BetterYelp.Models.Entities;
using BetterYelp.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterYelp.Models.Repositories
{
    public interface ISearchRepository : IRepository<Search>
    {
        IEnumerable<Search> GetUserSearches(ApplicationUser user);
    }
}
