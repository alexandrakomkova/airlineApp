﻿using System.Windows;
using System.Windows.Controls;
using airlineApp.Model;
using airlineApp.ViewModel;

namespace airlineApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
        //private User user; 
        //public MainWindow(User user)
        //{
        //    this.user = user;
        //    InitializeComponent();
        //    DataContext = new MainWindowViewModel(user);
        //}
    }
}
