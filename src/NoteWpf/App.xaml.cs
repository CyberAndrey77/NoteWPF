﻿using Microsoft.Extensions.DependencyInjection;
using NoteWpf.Models;
using NoteWpf.Services;
using NoteWpf.Services.Interface;
using NoteWpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NoteWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; set; }

        public new static App Current => (App)Application.Current;
        protected override void OnStartup(StartupEventArgs e)
        {
            ServiceProvider = CreateServiceProvider();
            base.OnStartup(e);
        }

        private static IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IJsonSerializerService, JsonSerializerService>();
            services.AddSingleton<IWebService, WebService>();
            services.AddSingleton<IAuthorizationService, AuthorizationService>();
            services.AddSingleton<INoteService, NoteService>();
            services.AddSingleton<ICategoryService, CategoryService>();


            services.AddSingleton<MainViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<MainNoteViewModel>();
            return services.BuildServiceProvider();
        }
    }
}
