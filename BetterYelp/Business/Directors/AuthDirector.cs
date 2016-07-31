using BetterYelp.Business.Enums;
using BetterYelp.Security;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterYelp.Business.Directors
{
    public class AuthDirector
    {
        private ConfigType _type;

        private string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string Token { get; set; }
        public string TokenSecret { get; set; }

        public AuthDirector(ConfigType type)
        {
            this._type = type;
        }


    }
}
