﻿using NoteWpf.Models;
using NoteWpf.Services.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWpf.ViewModels
{
    public class MainNoteViewModel : BaseViewModel
    {
        private ObservableCollection<ShortNote> _notes;
        private readonly INoteService _noteService;
        private readonly ICategoryService _categoryService;
        private Token _token;
        private ShortNote _selectedNote;
        private NoteViewModel _currentNote;
        private ObservableCollection<CategoryViewModel> _categories;
        private CategoryViewModel _selectedCategory;
        private CategoryViewModel _selectedCategoryFilter;
        private ObservableCollection<CategoryViewModel> _categoriesFilter;

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

        public NoteViewModel CurrentNote
        {
            get => _currentNote;
            set => SetProperty(ref _currentNote, value);
        }

        public ObservableCollection<ShortNote> Notes
        {
            get => _notes;
            set => SetProperty(ref _notes, value);
        }

        public CategoryViewModel SelectedCategory 
        {
            get => _selectedCategory;
            set => SetProperty(ref _selectedCategory, value);
        }

        public CategoryViewModel SelectedCategoryFilter
        {
            get => _selectedCategoryFilter;
            set
            {
                SetProperty(ref _selectedCategoryFilter, value);
            }
        }

        public ObservableCollection<CategoryViewModel> Categories
        {
            get => _categories;
            set => SetProperty(ref _categories, value);
        }

        public ObservableCollection<CategoryViewModel> CategiesFilter
        {
            get => _categoriesFilter;
            set => SetProperty(ref _categoriesFilter, value);
        }

        public MainNoteViewModel(INoteService noteService, ICategoryService categoryService)
        {
            _noteService = noteService;
            _categoryService = categoryService;
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
            GetAllCategories();
        }

        private void GetAllCategories()
        {
            if (_token == null)
            {
                throw new ArgumentException("Нет токенов");
            }
            DeserializedData<CategoryCollection> deserializedData = _categoryService.GetAllCategories(_token.AccessToken);
            CategoryCollection categories = deserializedData.Value;
            Categories = new ObservableCollection<CategoryViewModel>();
            CategiesFilter = new ObservableCollection<CategoryViewModel>();
            foreach (var category in categories.Categories)
            {
                Categories.Add(new CategoryViewModel { CategoryId = category.Id, CategoryName = category.CategoryName });
                CategiesFilter.Add(new CategoryViewModel { CategoryId = category.Id, CategoryName = category.CategoryName });
            }
            var categoryFilter = new CategoryViewModel() { CategoryId = 0, CategoryName = "Все" };
            CategiesFilter.Insert(0, categoryFilter);
            SelectedCategoryFilter = categoryFilter;
        }

        private void GetNote(int id)
        {
            if (_token == null)
            {
                throw new ArgumentException("Нет токенов");
            }

            DeserializedData<Note> note = _noteService.GetNoteById(id, _token.AccessToken);

            CurrentNote = new NoteViewModel
            {
                NoteName = note.Value.Name,
                NoteText = note.Value.Text,
                DataCreated = note.Value.DateCreated,
                DataUpdated = note.Value.DateUpdate,
                NoteCategory = note.Value.CategoryId
            };

            SelectedCategory = Categories.FirstOrDefault(x => x.CategoryId == note.Value.CategoryId);
        }
    }
}
