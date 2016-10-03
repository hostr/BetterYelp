using WeShouldGo.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeShouldGo.Business.Directors
{
    public class YelpDirector
    {
        private YelpSettings _config;

        public YelpDirector(YelpSettings config)
        {
            _config = config;
        }                
    }
}
