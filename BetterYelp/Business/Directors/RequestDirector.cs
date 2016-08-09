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
    public class RequestDirector
    {
        private YelpConfig _config;

        private const string BASE_URL = "https://api.yelp.com";

        private const string AUTH_URL = "/oauth2/token";

        public RequestDirector(YelpConfig config)
        {
            _config = config;
        }        

        public string MakeRequest()
        {
            var restClient = new RestClient(BASE_URL + AUTH_URL);

            RestRequest request = new RestRequest()
            {
                Method = Method.POST
            };

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("client_id", _config.AppId);
            request.AddParameter("client_secret", _config.AppSecret);
            request.AddParameter("grant_type", "client_credentials");

            var response = restClient.Execute(request);
            var responseJson = response.Content;
            var token = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson)["access_token"].ToString();

            return token.Length > 0 ? token : null;
        }
    }
}
