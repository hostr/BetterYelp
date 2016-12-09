using WeShouldGo.Business.Directors;
using WeShouldGo.Data;
using WeShouldGo.Data.Dtos;
using WeShouldGo.Models.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeShouldGo.Models;

namespace WeShouldGo.ServiceConnectors
{
    public class YelpClient
    {
        private readonly SearchContext _context;
        private readonly YelpSettings _settings;

        private const double TokenTimeToLiveInMinutes = 30;

        private const string BaseUrl = "https://api.yelp.com";

        private const string AuthEndpoint = "/oauth2/token";
        private const string BusinessSearchEndpoint = "/v3/businesses/search";

        public YelpClient(SearchContext context)
        {
            _context = context;
            _settings = new YelpSettings
            {
                AppId = ConfigurationManager.AppSettings["YelpAppId"],
                AppSecret = ConfigurationManager.AppSettings["YelpAppSecret"]
            };
        }

        public string GetToken()
        {
            var yelpEntity = _context.ServiceConnections.FirstOrDefault(m => m.ServiceName == "Yelp");

            // If no yelp connection exists in the db, then seed one here
            if (yelpEntity == null)
            {
                _context.ServiceConnections.Add(new ServiceConnections
                {
                    LastUpdated = DateTime.Now,
                    ServiceName = "Yelp",
                    Token = RefreshToken()
                });

                _context.SaveChanges();
            }

            var elapsedTime = new TimeSpan(DateTime.Now.Ticks - yelpEntity.LastUpdated.Ticks);
            double deltaInMinutes = Math.Abs(elapsedTime.TotalMinutes);

            if (deltaInMinutes < TokenTimeToLiveInMinutes
                && !string.IsNullOrWhiteSpace(yelpEntity.Token))
            {
                return yelpEntity.Token;
            }
            else
            {
                yelpEntity.Token = RefreshToken();
                yelpEntity.LastUpdated = DateTime.Now;

                return yelpEntity.Token;
            }
        }

        private string RefreshToken()
        {
            var restClient = new RestClient(BaseUrl + AuthEndpoint);

            RestRequest request = new RestRequest()
            {
                Method = Method.POST
            };

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("client_id", _settings.AppId);
            request.AddParameter("client_secret", _settings.AppSecret);
            request.AddParameter("grant_type", "client_credentials");

            var response = restClient.Execute(request);
            var responseJson = response.Content;

            var token = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson)["access_token"].ToString();

            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("No Yelp token received");
            }

            return token;
        }

        public BusinessesSearchResponse SearchBusinesses(string term, string location)
        {
            var restClient = new RestClient(BaseUrl + BusinessSearchEndpoint);

            RestRequest request = new RestRequest()
            {
                Method = Method.GET
            };

            request.AddHeader("Authorization", "Bearer " + GetToken());

            request.AddParameter("term", term);
            request.AddParameter("location", location);

            var response = restClient.Execute(request);
            var responseJson = response.Content;

            var results = JsonConvert.DeserializeObject<BusinessesSearchResponse>(responseJson);

            return results;
        }
    }
}