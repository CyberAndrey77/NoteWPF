using NoteWpf.Events;
using NoteWpf.Models;
using NoteWpf.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWpf.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IWebService _webService;
        private readonly IJsonSerializerService _jsonSerializerService;


        public AuthorizationService(IWebService webService, IJsonSerializerService serializerService)
        {
            _webService = webService;
            _jsonSerializerService = serializerService;
        }

        public DeserializedData<Token> SendEmailAndPassword(User user)
        {
            string json = _jsonSerializerService.Serialize(user);
            ResponceData data = _webService.SendPostResponceAsync(json, ControllerTypes.Login);
            var tokenData = new DeserializedData<Token>
            {
                StatusCode = data.StatusCode
            };

            if (string.IsNullOrEmpty(data.JsonAnswer))
            {
                tokenData.Value = new Token();
                return tokenData;
            }

            Token token = _jsonSerializerService.Deserialize<Token>(data.JsonAnswer);
            tokenData.Value = token;
            return tokenData;
        }

        public List<string> RefreshTokens(string accessToken)
        {
            throw new NotImplementedException();
        }
    }
}
