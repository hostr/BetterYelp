using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterYelp.Models
{
    public class Business
    {
        public string Id { get; set; }
        public bool IsClaimed { get; set; }
        public bool IsClosed { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public string MobileUrl { get; set; }
        public string Phone { get; set; }
        public string DisplayPhone { get; set; }
        public int ReviewCount { get; set; }
        public List<Category> Categories { get; set; }
        public int Rating { get; set; }

    }
}
