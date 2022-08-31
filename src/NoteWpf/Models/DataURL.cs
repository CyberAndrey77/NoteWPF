using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWpf.Models
{
    public class DataURL
    {
        public Dictionary<ControllerTypes, string> Url { get; private set; } = new Dictionary<ControllerTypes, string>()
        {
            {ControllerTypes.Login, "api/Authorize/login/"},
            {ControllerTypes.RefreshToken, "api/Authorize/refresh/"},
            {ControllerTypes.GetAllNotes, "api/Notes/" },
            {ControllerTypes.GetNote, "api/Notes/" },
            {ControllerTypes.GetAllCategory, "api/Category/" },
        };
    }
}
