using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterYelp.Data
{
    public class SearchRequest
    {
        public string term { get; set; }

        public int limit { get; set; }

        public int offset { get; set; }

        public int sort { get; set; }

        public string category_filter { get; set; }

        public int radius_filter { get; set; }

        public bool deals_filter { get; set; }

        public string location { get; set; }
    }
}
