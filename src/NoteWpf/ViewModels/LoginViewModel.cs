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
using NoteWpf.Events;

namespace NoteWpf.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _email;
        private string _password;
        private bool _isRemember;
        private bool _isButtonEnable;
        private readonly IFileService _fileService;
        private readonly IAuthorizationService _authorizationService;
        private readonly string _filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NoteAppWpf\\User.json";

        public EventHandler<GetTokensEventArgs> GetTokens { get; set; }

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

        public LoginViewModel(IFileService fileService, IAuthorizationService authorizationService)
        {
            Login = new DelegateCommand(LoginCommand);
            _fileService = fileService;
            _authorizationService = authorizationService;
            _authorizationService.GetTokens += OnGetTokens;
            SetSavedLoginAndPasswordAsync();
        }

        private void OnGetTokens(object? sender, GetTokensEventArgs e)
        {
            Token token = e.Token;
        }

        private void CheckEmpty()
        {
            IsButtonEnable = !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);
            OnPropertyChanged(nameof(IsButtonEnable));
        }

        private void LoginCommand()
        {
            var user = new User() { Email = Email, Password = Password };
            if (IsRemember)
            {
                CreateFileCookies(user);
            }

            Authorize(user);
        }

        private async void SetSavedLoginAndPasswordAsync()
        {
            var user = await _fileService.ReadFileAsync(_filePath);
            Email = user.Email;
            Password = user.Password;
        }

        private async void CreateFileCookies(User user)
        {
            await _fileService.CreateFileAsync(_filePath, user);
        }

        private async void Authorize(User user)
        {
            Token token = await _authorizationService.SendEmailAndPassword(user);

            GetTokens?.Invoke(this, new GetTokensEventArgs(token));
        }
    }
}
