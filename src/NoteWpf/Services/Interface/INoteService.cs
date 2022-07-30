using NoteWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWpf.Services.Interface
{
    public interface INoteService
    {
        DeserializedData<CollectonShortNotes> GetAllNotes(string accessToken);

        DeserializedData<Note> GetNoteById(int id, string accessToken);

        Note UpdateNoteById(int id, string accessToken);

        void DeleteNoteById(int id, string accessToken);
    }
}
