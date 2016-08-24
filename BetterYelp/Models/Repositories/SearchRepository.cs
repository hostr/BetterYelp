using BetterYelp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BetterYelp.Models.Repositories
{
    public class SearchRepository : Repository<Search>, ISearchRepository
    {
        public SearchContext SearchContext {
            get
            {
                return Context as SearchContext;
            }
        }

        public SearchRepository(SearchContext context) 
            : base(context)
        {
        }

        public IEnumerable<Search> GetUserSearches(ApplicationUser user)
        {
            return SearchContext.Search.OrderByDescending(m => m.Id).ToList();
        }
    }
}
