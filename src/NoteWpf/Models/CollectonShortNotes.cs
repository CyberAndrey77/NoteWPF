using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NoteWpf.Models
{
    public class CollectonShortNotes
    {
        [JsonPropertyName("$values")]
        public List<ShortNote> ShortNotes { get; set; } = new List<ShortNote>();
    }
}
