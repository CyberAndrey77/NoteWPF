using NoteWpf.Models;
using NoteWpf.ViewModels.Commands;
using NoteWpf.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteWpf.Services;
using System.Text.Json;

namespace NoteWpf.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _email;
        private string _password;
        private bool _isRemember;
        private bool _isButtonEnable;
        private IFileService _fileService;
        private string _filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NoteAppWpf\\User.json";

        public string Email 
        {
            get => _email;
            set
            {
                SetProperty(ref _email, value);
                CheckEmpty();
            }
        }
        public string Password 
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value);
                CheckEmpty();
            }
        }

        public bool IsRemember
        {
            get => _isRemember;
            set => SetProperty(ref _isRemember, value);
        }

        public bool IsButtonEnable
        {
            get => _isButtonEnable;
            set => SetProperty(ref _isButtonEnable, value);
        }

        public DelegateCommand Login { get; set; }

        public LoginViewModel(IFileService fileService)
        {
            Login = new DelegateCommand(LoginCommand);
            _fileService = fileService;
            //Task.Run(() =>
            //{
            //    var user = _fileService.ReadFileAsync(_filePath);
            //    Email = user.Result.Email;
            //    Password = user.Result.Password;
            //});
            SetSavedLoginAndPasswordAsync();
        }

        private void CheckEmpty()
        {
            IsButtonEnable = !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);
            OnPropertyChanged(nameof(IsButtonEnable));
        }

        private void LoginCommand()
        {
            if (IsRemember)
            {
                _fileService.CreateFileAsync(_filePath, new User() { Email = Email, Password = Password });
            }
            string b;
            var task = Task.Run(() =>
            {
                WebService service = new WebService();
                var json = JsonSerializer.Serialize(new User { Email = Email, Password = Password });
                var a = service.Login(json, "https://localhost:7127/api/Authorize/login");
                b = a.Result;
            });
            task.Wait();
        }

        private async void SetSavedLoginAndPasswordAsync()
        {
            var user = await _fileService.ReadFileAsync(_filePath);
            Email = user.Email;
            Password = user.Password;
        }
    }
}
