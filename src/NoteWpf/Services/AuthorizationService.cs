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

        public EventHandler<GetTokensEventArgs> GetTokens { get; set; }

        public AuthorizationService(IWebService webService, IJsonSerializerService serializerService)
        {
            _webService = webService;
            _jsonSerializerService = serializerService;
        }

        public async Task SendEmailAndPassword(User user)
        {
            string json = _jsonSerializerService.Serialize(user);
            string tokens = await _webService.SendPostResponceAsync(json, ControllerTypes.Login);
            if (string.IsNullOrEmpty(tokens))
            {
                throw new ArgumentException("Запрос был не удачный");
            }

            Token token = _jsonSerializerService.Deserialize<Token>(tokens);
            GetTokens?.Invoke(this, new GetTokensEventArgs(token));
        }

        public List<string> RefreshTokens(string accessToken)
        {
            throw new NotImplementedException();
        }
    }
}
