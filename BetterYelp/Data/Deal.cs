using System.Collections.Generic;

namespace BetterYelp.Data
{
    public class Deal
    {
        public string id { get; set; }

        public string title { get; set; }

        public string url { get; set; }

        public string image_url { get; set; }

        public string currency_code { get; set; }

        public double time_start { get; set; }

        public double time_end { get; set; }

        public bool is_popular { get; set; }

        public string what_you_get { get; set; }

        public string important_restrictions { get; set; }

        public string additional_restrictions { get; set; }

        public List<DealOptions> options { get; set; }
    }
}