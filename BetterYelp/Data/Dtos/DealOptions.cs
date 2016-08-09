using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterYelp.Data.Dtos
{
    public class DealOptions
    {
        public string title { get; set; }

        public string purchase_url { get; set; }

        public double price { get; set; }

        public string formatted_price { get; set; }

        public double original_price { get; set; }

        public string formatted_original_price { get; set; }

        public bool is_quantity_limited { get; set; }

        public int remaining_count { get; set; }
    }
}
