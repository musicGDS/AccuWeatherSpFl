using AccuWeatherSpFl.Models;
using RestSharp;
using SpecFlowProject1;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccuWeatherSpFl.Actions
{
    class ApiActions
    {
        string BaseUrl = ConfigurationReader.GetValue("url");
        string key = ConfigurationReader.GetValue("key");
        readonly IRestClient _client;

        string _accountSid;

        public ApiActions()
        {
            _client = new RestClient(BaseUrl);
            //_client.Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator("key", key);
        }

        public List<T> Execute<T>(RestRequest request) where T : new()
        {
           // request.AddParameter("AccountSid", _accountSid, ParameterType.UrlSegment); // used on every request
            var response = _client.Execute<List<T>>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var twilioException = new Exception(message, response.ErrorException);
                throw twilioException;
            }
            return response.Data;
        }

        public List<CityModel> GetCities(string countryCode)
        {
            var request = new RestRequest("locations/v1/adminareas/{countryCode}");
            //request.RootElement = "Call";
            request.AddParameter("countryCode", countryCode, ParameterType.UrlSegment);
            request.AddParameter("apikey", key);
            //request.AddParameter("key", key, ParameterType.UrlSegment);

            return Execute<CityModel>(request);
        }
    }
}
