using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using airlineApp.Commands;
using airlineApp.Model;
using airlineApp.View;

namespace airlineApp.ViewModel
{
    public class MainWindowViewModel : DataManageViewModel
    {
        public ICommand UpdateViewCommand { get; set; }
       // public ICommand ViewTicketsCommand { get; set; }

        public MainWindowViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            //ViewTicketsCommand = new Command(OnUpdateViewCommandExecuted);
            
        }
        private void OnUpdateViewCommandExecuted(object p)
        {   
           CurrentList = new ViewAllTicketsPageViewModel();
        }
        
        private DataManageViewModel currentList = new ViewAllFlightsPageViewModel();
        public DataManageViewModel CurrentList
        {
            get { return currentList; }
            set
            {
                currentList = value;
                NotifyPropertyChanged("CurrentList");

            }
        }

        public void UpdateCompanies()
        {

            AllCompanies = DataWorker.GetAllCompanies();
            //ViewAllCompaniesPage.AllCompaniesView.ItemsSource = null;
            //ViewAllCompaniesPage.AllCompaniesView.Items.Clear();
            //ViewAllCompaniesPage.AllCompaniesView.ItemsSource = AllCompanies;
            //ViewAllCompaniesPage.AllCompaniesView.Items.Refresh();
        }
        public void UpdateFlights()
        {
            AllFlights = DataWorker.GetAllFlights();
            //ViewAllFlightsPage.AllFlightsView.ItemsSource = null;
            //ViewAllFlightsPage.AllFlightsView.Items.Clear();
            //ViewAllFlightsPage.AllFlightsView.ItemsSource = AllFlights;
            //ViewAllFlightsPage.AllFlightsView.Items.Refresh();

        }
        public void UpdateTickets()
        {

            AllTickets = DataWorker.GetAllTickets();
        }



    }
}
