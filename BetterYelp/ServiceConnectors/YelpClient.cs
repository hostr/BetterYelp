using WeShouldGo.Business.Directors;
using WeShouldGo.Data;
using WeShouldGo.Data.Dtos;
using WeShouldGo.Models.Entities;
using WeShouldGo.Models.UnitOfWork;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeShouldGo.ServiceConnectors
{
    public class YelpClient
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IApiRequest _api;
        private YelpSettings _settings;

        private const double TokenRefreshDurationInMinutes = 30;

        private const string baseUrl = "https://api.yelp.com";

        private const string authEndpoint = "/oauth2/token";
        private const string businessSearchEndpiont = "/v3/businesses/search";

        private string token;
        private DateTime lastRefreshed;

        public YelpClient(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitializeSettings();
        }

        private void InitializeSettings()
        {
            _settings = new YelpSettings();

            _settings.AppId = Properties.Settings.Default.AppID;
            _settings.AppSecret = Properties.Settings.Default.AppSecret;
        }

        public string GetToken()
        {
            if (String.IsNullOrEmpty(_settings.AppId))
            {
                throw new ArgumentException("Yelp App Id");
            }

            if (String.IsNullOrEmpty(_settings.AppSecret))
            {
                throw new ArgumentException("Yelp App Secret");
            }

            var entity = _unitOfWork.ServiceConnections.Find(m => m.ServiceName == "Yelp").FirstOrDefault();

            var elapsedTime = new TimeSpan(DateTime.Now.Ticks - entity.LastUpdated.Ticks);
            double deltaInMinutes = Math.Abs(elapsedTime.TotalMinutes);

            if (deltaInMinutes < TokenRefreshDurationInMinutes 
                && !String.IsNullOrWhiteSpace(entity.Token))
            {
                return entity.Token; 
            }
            else
            {
                entity.Token = AttemptRefreshToken();
                entity.LastUpdated = DateTime.Now;
                return entity.Token;
            }                      
        }

        private string AttemptRefreshToken()
        {
            var restClient = new RestClient(baseUrl + authEndpoint);

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
            
            if (token == null || string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("yelp token");
            }

            return token;
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

            return null;
        }
    }
}