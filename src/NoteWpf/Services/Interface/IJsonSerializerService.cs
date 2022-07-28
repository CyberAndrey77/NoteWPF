using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWpf.Services.Interface
{
    public interface IJsonSerializerService
    {
        string Serialize<T>(T obj);
        T Deserialize<T>(string json);
    }
}
