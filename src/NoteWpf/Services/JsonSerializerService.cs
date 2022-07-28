using NoteWpf.Services.Interface;
using System.Text.Json;

namespace NoteWpf.Services
{
    public class JsonSerializerService : IJsonSerializerService
    {
        public T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }

        public string Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize(obj);
        }
    }
}
