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

        public string SendDeleteResponceAsync(string json, ControllerTypes controller, string accessToken)
        {
            return SendRequestAsync(json, controller, accessToken, HttpMethod.Delete).Result;
        }

        public string SendGetResponceAsync(string json, ControllerTypes controller)
        {
            return SendGetResponceAsync(json, controller, string.Empty);
        }
        
        public string SendGetResponceAsync(ControllerTypes controller, string accessToken)
        {
            return SendGetResponceAsync(string.Empty, controller, accessToken);
        }

        public string SendGetResponceAsync(string json, ControllerTypes controller, string accessToken)
        {
            return SendRequestAsync(json, controller, accessToken, HttpMethod.Get).Result;
        }

        public async Task<string> SendPostResponceAsync(string json, ControllerTypes controller)
        {
            return await SendPostResponceAsync(json, controller, string.Empty);
        }

        public async Task<string> SendPostResponceAsync(string json, ControllerTypes controller, string accessToken)
        {
            return await SendRequestAsync(json, controller, accessToken, HttpMethod.Post);
        }

        public string SendPutResponceAsync(string json, ControllerTypes controller, string accessToken)
        {
            return SendRequestAsync(json, controller, accessToken, HttpMethod.Put).Result;
        }

        private async Task<string> SendRequestAsync(string json, ControllerTypes controller, string accessToken, HttpMethod method)
        {
            var request = new HttpRequestMessage
            {
                Method = method,
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                RequestUri = new Uri("https://localhost:7127/" + _url.Url[controller])
            };

            if (accessToken != string.Empty)
            {
                request.Headers.Add("Authorization", $"bearer {accessToken}");
            }
            
            var response = await _client.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
