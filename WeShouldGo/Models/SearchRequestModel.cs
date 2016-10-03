using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeShouldGo.Models
{
    /// <summary>
    /// Used to search the Yelp API, for more info see web docs
    /// https://www.yelp.com/developers/documentation/v2/search_api
    /// </summary>
    public class SearchRequestModel
    {
        public string Term { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Sort { get; set; }
        public string CategoryFilter { get; set; }
        public int RadiusFilter { get; set; }
        public bool DealsFilter { get; set; }

        /// <summary>
        /// Specifies combination of "address, neighborhood, city, state, or zip, optional country"
        /// to be used when searching for businesses
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Option latitude, longitude parameter can also be specified as a hint
        /// to the geocoder to disambiguate the location text
        /// </summary>
        public CLL Cll { get; set; }

    }

    public class CLL
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
