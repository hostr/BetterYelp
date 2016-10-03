using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeShouldGo.Data.Dtos
{
    public class Business
    {
        public string id { get; set; }

        public string name { get; set; }

        public string image_url { get; set; }

        public string url { get; set; }

        public string price { get; set; }

        public string phone { get; set; }

        public decimal rating { get; set; }

        public int review_count { get; set; }

        public List<Category> categories { get; set; }

        public Coordinate coordinates { get; set; }

        public Location location { get; set; }
    }
}
