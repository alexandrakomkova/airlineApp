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
        private readonly User user;
        public ICommand UpdateViewCommand { get; set; }

        public MainWindowViewModel()
        {
            
            //MessageBox.Show($"{user.Email}");
            UpdateViewCommand = new UpdateViewCommand(this);
        }
        //private void OnUpdateViewCommandExecuted(object p)
        //{
        //    //MessageBox.Show($"{userSelectedFlight.FreePlaces}");
        //    currentList = new ViewAllFlightsPageViewModel(this);
        //}
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
        


    }
}
