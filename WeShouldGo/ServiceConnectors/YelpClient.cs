using WeShouldGo.Business.Directors;
using WeShouldGo.Data;
using WeShouldGo.Data.Dtos;
using WeShouldGo.Models.Entities;
using WeShouldGo.Models.UnitOfWork;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WeShouldGo.ServiceConnectors
{
    public class YelpClient
    {
        private readonly IUnitOfWork _unitOfWork;
        private YelpSettings _settings;

        private const double TokenTimeToLiveInMinutes = 30;

        private const string BaseUrl = "https://api.yelp.com";

        private const string AuthEndpoint = "/oauth2/token";
        private const string BusinessSearchEndpoint = "/v3/businesses/search";

        public YelpClient(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitializeSettings();
        }

        private void InitializeSettings()
        {
            _settings = new YelpSettings
            {
                AppId = ConfigurationManager.AppSettings["YelpAppId"],
                AppSecret = ConfigurationManager.AppSettings["YelpAppSecret"]
            };

            GetToken();
        }

        public string GetToken()
        {
            if (string.IsNullOrEmpty(_settings.AppId)) { throw new ArgumentException(nameof(_settings.AppId)); }
            if (string.IsNullOrEmpty(_settings.AppSecret)) { throw new ArgumentException(nameof(_settings.AppId)); }

            var yelpEntity = _unitOfWork.ServiceConnections.Find(m => m.ServiceName == "Yelp").FirstOrDefault();
            if (yelpEntity == null) throw new ArgumentNullException(nameof(yelpEntity));

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

            if (token == null || string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("yelp token");
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

            request.AddHeader("Authorization", "Bearer " + token);

            request.AddParameter("term", term);
            request.AddParameter("location", location);

            return null;
        }
    }
}