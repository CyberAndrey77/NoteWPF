using Microsoft.Extensions.DependencyInjection;
using NoteWpf.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWpf.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private object _currentVM;
        public object CurrentVM
        {
            get => _currentVM;
            set => SetProperty(ref _currentVM, value);
        }

        public MainViewModel()
        {
            LoginViewModel loginViewModel = App.Current.ServiceProvider.GetService<LoginViewModel>();
            CurrentVM = loginViewModel;
            loginViewModel.GetTokens += OnGetTokens;
        }

        private void OnGetTokens(object? sender, GetTokensEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
