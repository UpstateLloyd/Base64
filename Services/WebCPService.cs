using B64.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace B64.Services
{
    class WebCPService
    {
        public string getToken()
        {
            ////Reuse of this value will be necessary among all your calls
            ////Use this method first because none of the other calls can work without your access token


            var client = new RestClient("https://webcp-prod-auth.myparadigmcloud.com/webcp/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", "sales@upstatedoor.com");
            request.AddParameter("system_key", "grLpwt56e775Uyvb");
            request.AddParameter("password", "Solution2020");
            IRestResponse response = client.Execute(request);            
            Dictionary<string, string> dictResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
            string auth_token = "Bearer" + " " + dictResponse["access_token"];
            return auth_token;
        }

        public QuoteHistory getQuoteHistory(string QuoteId, string AuthToken)
        {
            var client = new RestClient("https://upstatedoor.wtsparadigm.com/upstatedoor-prod/api/app/webcp/v1/quotes/" + QuoteId + "/history");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");           
            request.AddHeader("Authorization", AuthToken);
            IRestResponse response = client.Execute(request);
            QuoteHistory deserializedQuoteHistory = JsonConvert.DeserializeObject<QuoteHistory>(response.Content);            
            return deserializedQuoteHistory;
        }

        public HistoryDetail getHistoryDetail(string QuoteId, string HistoryDetailID, string AuthToken)
        {
            var client = new RestClient("https://upstatedoor.wtsparadigm.com/upstatedoor-prod/api/app/webcp/v1/quotes/" + QuoteId + "/history/" + HistoryDetailID);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", AuthToken);
            IRestResponse response = client.Execute(request);
            HistoryDetail deserializedQuoteHistory = JsonConvert.DeserializeObject<HistoryDetail>(response.Content);
            return deserializedQuoteHistory;
        }
    }
}
