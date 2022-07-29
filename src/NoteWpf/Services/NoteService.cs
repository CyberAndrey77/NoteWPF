using NoteWpf.Models;
using NoteWpf.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWpf.Services
{
    public class NoteService : INoteService
    {
        private readonly IWebService _webService;
        private readonly IJsonSerializerService _jsonSerializerService;

        public NoteService(IWebService webService, IJsonSerializerService jsonSerializerService)
        {
            _webService = webService;
            _jsonSerializerService = jsonSerializerService;
        }

        public async Task DeleteNoteById(int id, string accessToken)
        {
            string json = _jsonSerializerService.Serialize(id);
            string responce = await _webService.SendPostResponceAsync(json, ControllerTypes.DeleteNote, accessToken);
            if (string.IsNullOrEmpty(responce))
            {
                throw new ArgumentException("Запрос был не удачный");
            }
        }

        public async Task<CollectonShortNotes> GetAllNotes(string accessToken)
        {
            string responce = _webService.SendGetResponceAsync(ControllerTypes.DeleteNote, accessToken);
            if (string.IsNullOrEmpty(responce))
            {
                throw new ArgumentException("Запрос был не удачный");
            }
            return null;
        }

        public Task<Note> GetNoteById(int id, string accessToken)
        {
            throw new NotImplementedException();
        }

        public Task<Note> UpdateNoteById(int id, string accessToken)
        {
            throw new NotImplementedException();
        }
    }
}
