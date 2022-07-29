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
        Task<CollectonShortNotes> GetAllNotes(string accessToken);

        Task<Note> GetNoteById(int id, string accessToken);

        Task<Note> UpdateNoteById(int id, string accessToken);

        Task DeleteNoteById(int id, string accessToken);
    }
}
