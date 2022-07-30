using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NoteWpf.Models
{
    public class ResponceData
    {
        public HttpStatusCode StatusCode { get; set; }

        public string JsonAnswer { get; set; }
    }
}
