using NoteWpf.Events;
using NoteWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWpf.Services.Interface
{
    public interface IAuthorizationService
    {
        EventHandler<GetTokensEventArgs> GetTokens { get; set; }
        Task<Token> SendEmailAndPassword(User user);
        List<string> RefreshTokens(string accessToken);
    }
}
