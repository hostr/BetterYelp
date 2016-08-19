using System.Collections.Generic;

namespace BetterYelp.Models
{
    public interface ISearchRepository
    {
        void AddSearch(Search search);
        IEnumerable<Search> GetAllSearches();
    }
}