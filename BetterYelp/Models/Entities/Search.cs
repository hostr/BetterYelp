using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterYelp.Models.Entities
{
    public class Search : EntityBase
    {
        public string Term { get; set; }
        public string Location { get; set; }
    }
}
