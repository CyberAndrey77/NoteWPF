using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NoteWpf.Models
{
    public class CollectonNotes
    {
        [JsonPropertyName("$values")]
        public List<Note> Notes { get; set; } = new List<Note>();
    }
}
