using System.Collections.Generic;

namespace BetterYelp.Data
{
    public class Location
    {
        public string[] address { get; set; }

        public string[] display_address { get; set; }

        public string city { get; set; }

        public string state_code { get; set; }

        public string postal_code { get; set; }

        public string country_code { get; set; }

        public string cross_streets { get; set; }

        public string[] neighborhoods { get; set; }

        public Coordinate coordiante { get; set; }
    }
}