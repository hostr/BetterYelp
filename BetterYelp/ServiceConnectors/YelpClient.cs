using BetterYelp.Business.Directors;
using BetterYelp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetterYelp.ServiceConnectors
{
    public class YelpClient
    {
        private AuthDirector _authDirector;
        private RequestDirector _requestDirector;

        private YelpConfig _config;

        public YelpClient(string AppId, string AppSecret)
        {
            _config = new YelpConfig()
            {
                AppId = AppId,
                AppSecret = AppSecret
            };

            _authDirector = new AuthDirector(_config);
            _authDirector.Authenticate();
        }


    }
}