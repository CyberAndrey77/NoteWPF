using NoteWpf.Models;
using NoteWpf.Services.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWpf.ViewModels
{
    public class NoteViewModel : BaseViewModel
    {
        private ObservableCollection<ShortNote> _notes;
        private readonly INoteService _noteService;
        private Token _token;
        private ShortNote _selectedNote;
        private NoteModel _currentNote;

        public Token Token
        {
            get => _token;
            set 
            {
                _token = value;
                GetAllNotes();
            }
        }
        
        public ShortNote SelectedNote
        {
            get => _selectedNote;
            set
            {
                SetProperty(ref _selectedNote, value);
                GetNote(value.Id);
            }
        }

        public NoteModel CurrentNote
        {
            get => _currentNote;
            set => SetProperty(ref _currentNote, value);
        }

        public ObservableCollection<ShortNote> Notes
        {
            get => _notes;
            set => SetProperty(ref _notes, value);
        }

        public NoteViewModel(INoteService noteService)
        {
            _noteService = noteService;
        }

        private void GetAllNotes()
        {
            if (_token == null)
            {
                throw new ArgumentException("Нет токенов");
            }
            DeserializedData<CollectonShortNotes> deserializedData = _noteService.GetAllNotes(_token.AccessToken);
            CollectonShortNotes notes = deserializedData.Value;
            _notes = new ObservableCollection<ShortNote>(notes.ShortNotes);
        }

        private void GetNote(int id)
        {
            if (_token == null)
            {
                throw new ArgumentException("Нет токенов");
            }

            DeserializedData<Note> note = _noteService.GetNoteById(id, _token.AccessToken);

            CurrentNote = new NoteModel();

            CurrentNote.NoteName = note.Value.Name;
            CurrentNote.NoteText = note.Value.Text;
            CurrentNote.DataCreated = note.Value.DateCreated;
            CurrentNote.DataUpdated = note.Value.DateUpdate;
        }
    }
}
