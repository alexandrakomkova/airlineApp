using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using airlineApp.Model;
using airlineApp.View;

namespace airlineApp.ViewModel
{
   public class DataManageViewModel : INotifyPropertyChanged
   {
        //get all flight
        //private ObservableCollection<Flight> allFlights = DataWorker.GetAllFlights();
        private List<Flight> allFlights = DataWorker.GetAllFlights();
        private List<Company> allCompanies = DataWorker.GetAllCompanies();
        private List<Way> allWays = DataWorker.GetAllWays();
        public List<Flight> AllFlights
        {
            get { return allFlights; }
            set
            {
                allFlights = value;
                NotifyPropertyChanged("AllFlights");
            }
        }
        //public ObservableCollection<Flight> AllFlights 
        //{
        //    get { return allFlights; }
        //    set 
        //    {
        //        allFlights = value;
        //        NotifyPropertyChanged("AllFlights");
        //    }
        //}
        public List<Company> AllCompanies
        {
            get { return allCompanies; }
            set
            {
                allCompanies = value;
                NotifyPropertyChanged("AllCompanies");
            }
        }
        public List<Way> AllWays
        {
            get { return allWays; }
            set
            {
                allWays = value;
                NotifyPropertyChanged("AllWays");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName) 
        {
            if (PropertyChanged != null) 
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //methods for open/close windows
        #region methods for open windows
        private void SetWindowPosition(Window window) 
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        private void OpenAddFlightWndMethod() 
        {
            AddFlightWindow addFlightWindow = new AddFlightWindow();
            SetWindowPosition(addFlightWindow);
        }
        private void OpenAddCompanyWndMethod()
        {
            AddCompanyWindow addCompanyWindow = new AddCompanyWindow();
            SetWindowPosition(addCompanyWindow);
        }
        private void LoadCompanyLogoWndMethod()
        {
           
        }
        private void CloseWndMethod()
        {
            App.Current.Windows.OfType<Message>().First().Close();
        }
        #endregion

        //commands to open/close windows
        #region commands to open windows
        private Command openAddFlightWndCommand;
        private Command openAddCompanyWndCommand;
        private Command loadCompanyLogoWndCommand;
        private Command closeWndCommand;
        public Command OpenAddFlightWndCommand 
        {
            get 
            {
                return openAddFlightWndCommand ?? new Command(
                    obj =>
                    {
                        OpenAddFlightWndMethod();
                    }
                    );
            }
        }
        public Command OpenAddCompanyWndCommand
        {
            get
            {
                return openAddCompanyWndCommand ?? new Command(
                    obj =>
                    {
                        OpenAddCompanyWndMethod();
                    }
                    );
            }
        }
        public Command LoadCompanyLogoWndCommand
        {
            get
            {
                return loadCompanyLogoWndCommand ?? new Command(
                    obj =>
                    {
                        LoadCompanyLogoWndMethod();
                    }
                    );
            }
        }
        public Command CloseWndCommand
        {
            get
            {
                return closeWndCommand ?? new Command(
                    obj =>
                    { 
                        CloseWndMethod();
                    }
                    );
            }
        }

        #endregion

        //commands to add 
        #region commands to add 
        private Command addCompanyWndCommand;
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public Command AddCompanyWndCommand
        {
            get
            {
                return addCompanyWndCommand ?? new Command(
                    obj =>
                    {
                        Window window = obj as Window;
                        string resultStr = "";
                        if (CompanyName == null || CompanyName.Replace(" ", "").Length == 0)
                        {
                            SetRedBlockControll(window, "CompanyNameTextBox");
                        }
                        else
                        {
                            resultStr = DataWorker.CreateCompany(CompanyName, CompanyLogo);
                            UpdateAllDataView();
                            ShowMessageToUser(resultStr);
                            SetNullValuesToProperties();
                            window.Close();
                        }
                      
                    }
                    );
            }
        }
        private Command addFlightWndCommand;
        public Way FlightWay { get; set; }
        public Company FlightCompany { get; set; }
        public int FlightPrice { get; set; }
        public int FlightAllPlaces { get; set; }
        public Command AddFlightWndCommand
        {
            get
            {
                return addFlightWndCommand ?? new Command(
                    obj =>
                    {
                        Window window = obj as Window;
                        string resultStr = "";
                        if (FlightWay == null)
                        {
                            string str = "Пожалуйста, выберите маршрут для данного рейса.";
                            ShowMessageToUser(str);
                        }
                        if (FlightCompany == null)
                        {
                            string str = "Пожалуйста, выберите авиакомпанию для данного рейса.";
                            ShowMessageToUser(str);
                        }
                        if (FlightPrice == 0)
                        {
                            string str = "Пожалуйста, укажите макисмальное количество мест на борту саамолета для данного рейса.";
                            ShowMessageToUser(str);
                            SetRedBlockControll(window, "PriceTextBox");
                        }
                        if (FlightAllPlaces == 0)
                        {
                            string str = "Пожалуйста, укажите макисмальное количество мест на борту саамолета для данного рейса.";
                            ShowMessageToUser(str);
                            SetRedBlockControll(window, "AllPlacesTextBox");
                        }
                        else
                        {
                            resultStr = DataWorker.CreateFlight(FlightWay, FlightCompany, FlightPrice, FlightAllPlaces);
                            UpdateAllDataView();

                            ShowMessageToUser(resultStr);
                            SetNullValuesToProperties();
                            //window.Close();
                        }
                    }
                    );
            }
        }


        #endregion

        //updates
        #region update views and commands
        private Command updateAllFlightsCommand;
        private void UpdateAllDataView()
        {
            UpdateCompanies();
            UpdateFlights();
        }
        private void UpdateCompanies()
        {
            AllCompanies = DataWorker.GetAllCompanies();
        }
        public Command UpdateAllFlightsCommand
        {
            get
            {
                return updateAllFlightsCommand ?? new Command(
                    obj =>
                    {
                        UpdateAllDataView();
                    }
                    );
            }
        }

        private void UpdateFlights()
        {
            AllFlights = DataWorker.GetAllFlights();
            MainWindow.AllFlightsView.ItemsSource = null;
            MainWindow.AllFlightsView.Items.Clear();
            MainWindow.AllFlightsView.ItemsSource = AllFlights;
            MainWindow.AllFlightsView.Items.Refresh();
            //это грязно
            //придумать что-нибудь
        }
        #endregion

        //delete data
        #region commands to delete data

        private Command deleteFlight { get; set; }
        public Command DeleteFlight 
        {
            get 
            {
                return deleteFlight ?? new Command(obj=>
                {
                    string resultStr = "Пожалуйста, выберите объект для удаления.";
                    if (SelectedTabItem.Name == "UsersTab" && SelectedUser != null)
                    {
                        resultStr = DataWorker.DeleteUser(SelectedUser);
                        UpdateAllDataView();
                    }
                }
                    );
            }
        }
        #endregion

        //edit data
        #region edit data
        #endregion
        private void SetRedBlockControll(Window wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }
        private void ShowMessageToUser(string text)
        {
            Message message = new Message(text);
            SetWindowPosition(message);
        }
        private void SetNullValuesToProperties()
        {
            CompanyName = null;
            CompanyLogo = null;
            FlightWay = null;
            FlightCompany = null;
            FlightPrice = 0;
            FlightAllPlaces = 0;
        }
    }
}
