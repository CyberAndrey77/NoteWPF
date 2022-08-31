using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NoteWpf.Models
{
    public class CategoryCollection
    {
        [JsonPropertyName("$values")]
        public List<Category> Categories { get; set; }
    }
}
