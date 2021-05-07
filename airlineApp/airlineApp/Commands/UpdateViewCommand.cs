﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using airlineApp.ViewModel;

namespace airlineApp.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainWindowViewModel viewModel;
        private UserWindowViewModel userViewModel;

        public UpdateViewCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public UpdateViewCommand(UserWindowViewModel userViewModel)
        {
            this.userViewModel = userViewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Flight")
            {
                viewModel.UpdateFlights();
                viewModel.CurrentList = new ViewAllFlightsPageViewModel();
               
            }
            else if (parameter.ToString() == "Company")
            {
                viewModel.UpdateCompanies();
                viewModel.CurrentList = new ViewAllCompaniesPageViewModel();
                
            }
            else if (parameter.ToString() == "Place")
            {
                //new GetPlaceViewModel()
                userViewModel.CurrentPage = new GetPlaceViewModel();
                MessageBox.Show("test");

            }
        }
    }
}