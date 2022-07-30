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

        public void DeleteNoteById(int id, string accessToken)
        {
            //string json = _jsonSerializerService.Serialize(id);
            //string responce = _webService.SendDeleteResponceAsync(json, ControllerTypes.DeleteNote, accessToken);
            //if (string.IsNullOrEmpty(responce))
            //{
            //    throw new ArgumentException("Запрос был не удачный");
            //}
        }

        public DeserializedData<CollectonShortNotes> GetAllNotes(string accessToken)
        {
            ResponceData data = _webService.SendGetResponceAsync(ControllerTypes.GetAllNotes, accessToken);
            var notesData = new DeserializedData<CollectonShortNotes>()
            {
                StatusCode = data.StatusCode
            };

            if (string.IsNullOrEmpty(data.JsonAnswer))
            {
                notesData.Value = new CollectonShortNotes();
                return notesData;
            }
            CollectonShortNotes notes = _jsonSerializerService.Deserialize<CollectonShortNotes>(data.JsonAnswer);
            if (notes == null)
            {
                throw new ArgumentException("Данные не десериализовались");
            }

            notesData.Value = notes;
            return notesData;
        }

        public DeserializedData<Note> GetNoteById(int id, string accessToken)
        {
            ResponceData data = _webService.SendGetResponceAsync(id.ToString(), ControllerTypes.GetNote, accessToken);
            var notesData = new DeserializedData<Note>()
            {
                StatusCode = data.StatusCode
            };
            if (string.IsNullOrEmpty(data.JsonAnswer))
            {
                notesData.Value = new Note();
                return notesData;
            }
            Note note = _jsonSerializerService.Deserialize<Note>(data.JsonAnswer);
            notesData.Value = note ?? throw new ArgumentException("Данные не десериализовались");
            return notesData;
        }

        public Note UpdateNoteById(int id, string accessToken)
        {
            throw new NotImplementedException();
        }
    }
}
