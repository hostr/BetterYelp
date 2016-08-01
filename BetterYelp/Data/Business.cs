using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterYelp.Data
{
    public class Business
    {
        public string id { get; set; }

        public bool is_claimed { get; set; }

        public bool is_closed { get; set; }

        public string name { get; set; }

        public string image_url { get; set; }

        public string url { get; set; }

        public string mobile_url { get; set; }

        public string phone { get; set; }

        public string display_phone { get; set; }

        public int review_count { get; set; }

        public string [][] categories { get; set;}

        public int rating { get; set; }

        public string rating_img_url { get; set; }

        public string rating_img_url_small { get; set; }

        public string rating_img_url_large { get; set; }

        public string snippet_text { get; set; }

        public string snippet_image_url { get; set; }

        public Location location { get; set; }

        public List<Deal> deals { get; set; }

        public string menu_provider { get; set; }

        public int menu_date_updated { get; set; }

        public string reservation_url { get; set; }
    }
}
