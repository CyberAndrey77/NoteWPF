using NoteWpf.Models;
using NoteWpf.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NoteWpf.Services
{
    public class WebService : IWebService
    {
        private readonly HttpClient _client;
        private readonly DataURL _url;

        public WebService()
        {
            _client = new HttpClient();
            _url = new DataURL();
        }

        public ResponceData SendDeleteResponceAsync(string json, ControllerTypes controller, string accessToken)
        {
            return SendRequestAsync(json, controller, accessToken, HttpMethod.Delete);
        }

        public ResponceData SendGetResponceAsync(string id, ControllerTypes controller)
        {
            return SendGetResponceAsync(id, controller, string.Empty);
        }
        
        public ResponceData SendGetResponceAsync(ControllerTypes controller, string accessToken)
        {
            return SendGetResponceAsync(string.Empty, controller, accessToken);
        }

        public ResponceData SendGetResponceAsync(string id, ControllerTypes controller, string accessToken)
        {
            return SendRequestAsync(id, controller, accessToken, HttpMethod.Get);
        }

        public ResponceData SendPostResponceAsync(string json, ControllerTypes controller)
        {
            return SendPostResponceAsync(json, controller, string.Empty);
        }

        public ResponceData SendPostResponceAsync(string json, ControllerTypes controller, string accessToken)
        {
            return SendRequestAsync(json, controller, accessToken, HttpMethod.Post);
        }

        public ResponceData SendPutResponceAsync(string json, ControllerTypes controller, string accessToken)
        {
            return SendRequestAsync(json, controller, accessToken, HttpMethod.Put);
        }

        private ResponceData SendRequestAsync(string data, ControllerTypes controller, string accessToken, HttpMethod method)
        {
            var request = new HttpRequestMessage
            {
                Method = method,
            };

            if (method == HttpMethod.Post || method == HttpMethod.Put)
            {
                request.Content = new StringContent(data, Encoding.UTF8, "application/json");
                request.RequestUri = new Uri("https://localhost:7127/" + _url.Url[controller]);
            }
            else
            {
                request.RequestUri = new Uri("https://localhost:7127/" + _url.Url[controller] + data);
            }

            if (accessToken != string.Empty)
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", accessToken);
            }

            HttpResponseMessage response = _client.SendAsync(request).Result;
            
            var responceData = new ResponceData();
            responceData.StatusCode = response.StatusCode;
            responceData.JsonAnswer = response.Content.ReadAsStringAsync().Result;
            return responceData;
        }
    }
}
