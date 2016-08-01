using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterYelp.Models
{
    /// <summary>
    /// Results from the Yelp API search. 
    /// Use with the SearchRequestModel
    /// </summary>
    public class SearchResultsModel
    {
        public List<Business> Businesses;
    }
}
