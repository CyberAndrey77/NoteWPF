using NoteWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWpf.Events
{
    public class GetTokensEventArgs : EventArgs
    {
        public Token Token { get; set; }

        public GetTokensEventArgs(Token token)
        {
            Token = token;
        }
    }
}
