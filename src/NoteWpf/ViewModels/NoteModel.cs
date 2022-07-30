using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWpf.ViewModels
{
    public class NoteModel : BaseViewModel
    {
        private string _noteName;
        private int _noteCategory;
        private string _dataCreated;
        private string _dataUpdated;
        public string NoteName
        {
            get => _noteName;
            set => SetProperty(ref _noteName, value);
        }

        public string NoteText
        {
            get => _noteName;
            set => SetProperty(ref _noteName, value);
        }

        public int NoteCategory
        {
            get => _noteCategory;
            set => SetProperty(ref _noteCategory, value);
        }

        public string DataCreated
        {
            get => _dataCreated;
            set => SetProperty(ref _dataCreated, value);
        }

        public string DataUpdated
        {
            get => _dataUpdated;
            set => SetProperty(ref _dataUpdated, value);
        }
    }
}
