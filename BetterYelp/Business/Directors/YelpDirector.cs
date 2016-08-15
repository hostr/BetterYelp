using BetterYelp.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BetterYelp.Business.Directors
{
    public class YelpDirector
    {
        private YelpConfig _config;

        public YelpDirector(YelpConfig config)
        {
            _config = config;
        }                
    }
}
