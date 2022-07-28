using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWpf.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public int CategoryId { get; set; }
    }
}
