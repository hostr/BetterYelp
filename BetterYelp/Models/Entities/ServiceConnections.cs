using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterYelp.Models.Entities
{
    public class ServiceConnections : EntityBase
    {
        public string ServiceName { get; set; }
        public string Token { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
