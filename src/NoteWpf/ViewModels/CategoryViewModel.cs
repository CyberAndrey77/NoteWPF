using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWpf.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        private int _categoryId;
        private string _categoryName;

        public int CategoryId 
        {
            get => _categoryId;
            set => SetProperty(ref _categoryId, value);
        }
        public string CategoryName 
        {
            get => _categoryName;
            set => SetProperty(ref _categoryName, value);
        }
    }
}
