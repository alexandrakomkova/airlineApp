﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using airlineApp.Model;
using airlineApp.ViewModel;

namespace airlineApp.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainWindowViewModel viewModel;
        private UserWindowViewModel userViewModel;
        private DataManageViewModel model;
        private List<string> list;
        private Flight f;
        private User user;
        private string str;


        public UpdateViewCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public UpdateViewCommand(UserWindowViewModel userViewModel, DataManageViewModel model)
        {
            this.userViewModel = userViewModel;
            this.model = model;
        }
        public UpdateViewCommand(UserWindowViewModel userViewModel)
        {
            this.userViewModel = userViewModel;
            
        }
        public UpdateViewCommand(UserWindowViewModel userViewModel, List<string> list)
        {
            this.userViewModel = userViewModel;
            this.list = list;

        }
        public UpdateViewCommand(UserWindowViewModel userViewModel, Flight f)
        {
            this.userViewModel = userViewModel;
            this.f = f;

        }
        public UpdateViewCommand(UserWindowViewModel userViewModel, string str)
        {
            this.userViewModel = userViewModel;
            this.str = str;

        }
        public UpdateViewCommand(UserWindowViewModel userViewModel, User user)
        {
            this.userViewModel = userViewModel;
            this.user = user;

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
            else if (parameter.ToString() == "GetTicket")
            {
                userViewModel.CurrentPage = new ChooseTicketViewModel(userViewModel);
            }
            else if (parameter.ToString() == "Place")
            {
                userViewModel.CurrentPage = new GetPlaceViewModel(userViewModel, f);
            }
            else if (parameter.ToString() == "Passenger")
            {
                
                userViewModel.CurrentPage = new EnterUserInfoViewModel(userViewModel, f, str);
            }
            else if (parameter.ToString() == "BookATicket")
            {
                userViewModel.CurrentPage = new InfoAboutTicketViewModel(userViewModel, str, str, str, str, f, str);
            }
            else if (parameter.ToString() == "BookATicket" && userViewModel.IsBackEnable==true)
            {
                userViewModel.CurrentPage = new InfoAboutReturnTicketsViewModel(userViewModel);
            }
        }
    }
}
