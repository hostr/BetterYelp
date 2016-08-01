using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterYelp.Data
{
    public class SearchResponse
    {
        public int total { get; set; }

        public List<Business> businesses { get; set; }
    }
}
