using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NoteWpf.Models
{
    public class ShortNote
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("noteName")]
        public string Name { get; set; }
    }
}
