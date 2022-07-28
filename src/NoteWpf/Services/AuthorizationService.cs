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

        public AuthorizationService(IWebService webService)
        {
            _webService = webService;
        }

        public List<string> GetTokens(User user)
        {
            throw new NotImplementedException();
        }

        public List<string> RefreshTokens(string accessToken)
        {
            throw new NotImplementedException();
        }
    }
}
