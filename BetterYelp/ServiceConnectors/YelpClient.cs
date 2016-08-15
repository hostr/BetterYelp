using BetterYelp.Business.Directors;
using BetterYelp.Data;
using BetterYelp.Data.Dtos;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetterYelp.ServiceConnectors
{
    public class YelpClient
    {
        private static readonly string AppId = Properties.Settings.Default.AppID;
        private static readonly string AppSecret = Properties.Settings.Default.AppSecret;

        private const double TokenRefreshDurationInMinutes = 30;

        private const string baseUrl = "https://api.yelp.com";

        private const string authEndpoint = "/oauth2/token";
        private const string businessSearchEndpiont = "/v3/businesses/search";

        private YelpConfig config = null;

        public string token { get; set; }
        private DateTime lastRefreshed;

        public YelpClient()
        {
            config = new YelpConfig()
            {
                AppId = AppId,
                AppSecret = AppSecret
            };
        }

        public string GetToken()
        {
            if (String.IsNullOrWhiteSpace(config.AppId) ||
                String.IsNullOrWhiteSpace(config.AppSecret))
            {
                throw new InvalidOperationException("No Oauth info available. Please enter your Yelp app credentials in web.config.");
            }

            if (lastRefreshed < lastRefreshed.AddMinutes(TokenRefreshDurationInMinutes) 
                && !String.IsNullOrWhiteSpace(token))
            {
                return token; 
            }
            else
            {
                AttemptRefreshToken(config);
                return token;
            }                      
        }

        private void AttemptRefreshToken(YelpConfig config)
        {
            var restClient = new RestClient(baseUrl + authEndpoint);

            RestRequest request = new RestRequest()
            {
                Method = Method.POST
            };

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("client_id", config.AppId);
            request.AddParameter("client_secret", config.AppSecret);
            request.AddParameter("grant_type", "client_credentials");

            var response = restClient.Execute(request);
            var responseJson = response.Content;

            // Add error handling if token is null
            token = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson)["access_token"].ToString();
            lastRefreshed = DateTime.Now;
        }

        public BusinessesSearchResponse SearchBusinesses(string term, string location)
        {
            var restClient = new RestClient(baseUrl + businessSearchEndpiont);

            RestRequest request = new RestRequest()
            {
                Method = Method.GET
            };

            request.AddHeader("Authorization", "Bearer " + token);

            request.AddParameter("term", term);
            request.AddParameter("location", location);

            var response = restClient.Execute(request);
            var responseJson = response.Content;

            return JsonConvert.DeserializeObject<BusinessesSearchResponse>(responseJson);
        }
    }
}