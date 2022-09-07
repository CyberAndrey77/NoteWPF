using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NoteWpf.Models
{
    public class Note : ICloneable
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("noteName")]
        public string Name { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("createdDate")]
        public string DateCreated { get; set; }

        [JsonPropertyName("updatedDate")]
        public string DateUpdate { get; set; }

        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
