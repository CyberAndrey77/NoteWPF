using NoteWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWpf.ViewModels
{
    public class NoteViewModel : BaseViewModel
    {
        private Token _token;
        public string NoteName { get; set; }

        public string NoteText { get; set; }

        public int NoteCategory { get; set; }

        public string DataCreated { get; set; }

        public string DataUpdated { get; set; }

        public NoteViewModel(Token token)
        {
            _token = token;
        }
    }
}
