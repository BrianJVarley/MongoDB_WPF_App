﻿using MongoDBApp.Services;
using MongoDBApp.ViewModels;
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

namespace MongoDBApp.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {

        private LoginViewModel ViewModel { get; set; }
        private IAuthenticationService _authService;

        public LoginView()
        {
            InitializeComponent();
            ViewModel = new LoginViewModel(_authService);
            this.DataContext = ViewModel;
            
        }

    
    }
}
