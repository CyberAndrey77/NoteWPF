﻿using Microsoft.Extensions.DependencyInjection;
using NoteWpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NoteWpf.Views
{
    /// <summary>
    /// Логика взаимодействия для NoteView.xaml
    /// </summary>
    public partial class NoteView : UserControl
    {
        public NoteView()
        {
            InitializeComponent();
            DataContext = App.Current.ServiceProvider.GetService<MainNoteViewModel>();
        }
    }
}
