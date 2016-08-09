using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterYelp.Data.Dtos
{
    public class BusinessesSearchRequest
    {
        public string term { get; set; }

        public string location { get; set; }

        public decimal latitude { get; set; }

        public decimal longitude { get; set; }

        public int radius { get; set; }

        public string categories { get; set; }

        public string locale { get; set; }

        public int limit { get; set; }

        public int offset { get; set; }

        public string sort_by { get; set; }

        public string pricing_filter { get; set; }

        public bool open_now_filter { get; set; }
    }
}
