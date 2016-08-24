using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterYelp.Models.Entities
{
    public class Search
    {
        public int Id { get; set; }
        public string Term { get; set; }
        public string Location { get; set; }
    }
}
