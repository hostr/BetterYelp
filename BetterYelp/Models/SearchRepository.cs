using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterYelp.Models
{
    public class SearchRepository : ISearchRepository
    {
        private SearchContext _context;

        public SearchRepository(SearchContext context)
        {
            _context = context;
        }

        public IEnumerable<Search> GetAllSearches()
        {
            return _context.Search.ToList();
        }

        public void AddSearch(Search search)
        {

        }
    }
}
