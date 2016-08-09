using BetterYelp.Business.Enums;
using BetterYelp.Data;
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
        private RequestDirector _requestDirector;
        private YelpConfig _config;

        public AuthDirector(YelpConfig config)
        {
            if (String.IsNullOrWhiteSpace(config.AppId) ||
                String.IsNullOrWhiteSpace(config.AppSecret))
            {
                throw new InvalidOperationException("No Oauth info available. Please enter your Yelp app credentials in web.config.");
            }

            _config = config;
        }

        public void Authenticate()
        {
            _requestDirector = new RequestDirector(_config);

            var token = _requestDirector.MakeRequest();
        }


    }
}
