using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using airlineApp.Model;
using airlineApp.Model.Data;
using airlineApp.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace airlineApp.ViewModel
{
   public class DataManageViewModel : INotifyPropertyChanged
   {
        //get all flight
        //private ObservableCollection<Flight> allFlights = DataWorker.GetAllFlights();
        private List<Flight> allFlights = DataWorker.GetAllFlights();
        private List<Company> allCompanies = DataWorker.GetAllCompanies();
        private List<Way> allWays = DataWorker.GetAllWays();
        public ICollectionView FlightView { get; set; }
        public List<Flight> AllFlights
        {
            get { return allFlights; }
            set
            {
                allFlights = value;
                NotifyPropertyChanged("AllFlights");
            }
        }
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
        public ListView SelectedList { get; set; }
        public static Flight SelectedFlight { get; set; }
        public static string CompanyName { get; set; }
        public static string CompanyLogo { get; set; }
        public static Way FlightWay { get; set; }
        public static Company FlightCompany { get; set; }
        public static decimal FlightPrice { get; set; }
        public static int FlightAllPlaces { get; set; }

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
        private void OpenEditFlightWndMethod(Flight flight)
        {
            EditFlightWindow editFlightWindow = new EditFlightWindow(flight);
            SetWindowPosition(editFlightWindow);
        }
        private void OpenAddCompanyWndMethod()
        {
            AddCompanyWindow addCompanyWindow = new AddCompanyWindow();
            SetWindowPosition(addCompanyWindow);
        }
        private void LoadCompanyLogoWndMethod()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Фотографии|*.jpg;*.png;*.jpeg| All Files (*.*)|*.*";
            if (ofd.ShowDialog() == true)
            {
                try
                {
                    
                    CompanyLogo = ofd.FileName;
                    //System.Windows.Forms.MessageBox.Show(airline.imagePath);
                }
                catch
                {
                    string resultStr = "Не удалось загрузить картинку.";
                    ShowMessageToUser(resultStr);
                }
            }
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
        private Command openEditFlightWndCommand;
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
        public Command OpenEditFlightWndCommand
        {
            get
            {
                return openEditFlightWndCommand ?? new Command(
                    obj =>
                    {
                        if (SelectedFlight != null)
                        {
                            OpenEditFlightWndMethod(SelectedFlight);
                        }
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
                           // window.Close();
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
        public Command DeleteFlightCommand
        {
            get 
            {
                return deleteFlight ?? new Command(obj=>
                {
                    string resultStr = "Пожалуйста, выберите объект для удаления.";
                    
                    if (SelectedFlight!=null)
                    {
                        resultStr = DataWorker.DeleteFlight(SelectedFlight);
                        UpdateAllDataView();
                    }
                    SetNullValuesToProperties();
                    ShowMessageToUser(resultStr);
                }
                    );
            }
        }
        #endregion

        //edit data
        #region edit data
        private Command editFlight { get; set; }
        public Command EditFlightWndCommand
        {
            get
            {
                return editFlight ?? new Command(obj =>
                {
                    if (SelectedFlight != null)
                    {
                        OpenEditFlightWndMethod(SelectedFlight);
                    }
                   
                }
                    );
            }
        }
        #endregion

        #region edit command
        private Command editFlightCommand { get; set; }
        public Command EditFlight
        {
            get
            {
                return editFlightCommand ?? new Command(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Пожалуйста, выберите рейс для редактирования.";
                    string noCompanyStr = "Не выбрана новая компания дл авиарейса.";
                    string noWayStr = "Не выбран новый маршрут для авиарейса.";
                    if (SelectedFlight != null)
                    {
                        if (FlightCompany != null)
                        {
                            if (FlightWay != null)
                            {
                                resultStr = DataWorker.EditFlight(SelectedFlight, FlightWay, FlightCompany, FlightPrice, FlightAllPlaces);

                                UpdateAllDataView();
                                SetNullValuesToProperties();
                                ShowMessageToUser(resultStr);
                                window.Close();
                            }
                            else ShowMessageToUser(noWayStr);
                        }
                        else ShowMessageToUser(noCompanyStr);
                    }
                    else ShowMessageToUser(resultStr);
                }
                    );
            }
        }
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


        #region search bar and sorting
        private string searchText { get; set; }
        public static ObservableCollection<Flight> FlightCollection { get; set; }
        //private List<DataManageViewModel> GetFlightsVM()
        //{

        //    using (ApplicationContext db = new ApplicationContext())
        //    {
        //        var result = new List<DataManageViewModel>();
        //       result = new ObservableCollection<RentObject>(dbContext.RentObjects.ToList());

        //        return result;
        //    }
        //}
        public ObservableCollection<Flight> FlightsCollection { get; set; }
        public ICollectionView List { get; set; }
        //public FlightListViewModel()//modified to public
        //{
        //    using (ApplicationContext db = new ApplicationContext())
        //    {
        //        FlightCollection = new ObservableCollection<Flight>(db.Flights.ToList());
        //    }
        //    //List = CollectionViewSource.GetDefaultView(AllFlights);
        //    this._view = new ListCollectionView(this.employeeList);
        //}

        public string SearchText
        {
            get { return searchText; }
            set
            {
                //ShowMessageToUser("n");
                searchText = value;
                NotifyPropertyChanged("SearchText");
                
                   // List = CollectionViewSource.GetDefaultView(FlightCollection);

                //string pattern = $"{value}";
                // Regex regex = new Regex(pattern);
                // var findFlight = from i in AllFlights
                //                  where regex.IsMatch(i.Company.Name)
                //                  select i;
                // //AllFlights = findFlight.ToList();
                // MainWindow.AllFlightsView.Items.Clear();
                // MainWindow.AllFlightsView.ItemsSource = findFlight.ToList();
                //// NotifyPropertyChanged("AllFlights");
                // //MainWindow.AllFlightsView.ItemsSource = AllFlights;


                //List.Filter = (obj) =>
                //{
                //    if (obj is Flight f)
                //    {
                //        return f.Company.Name.ToLower().Contains(SearchText.ToLower());
                //    }

                //return false;
                //if (String.IsNullOrEmpty(value))
                //    List.Filter = null;
                //else
                //    List.Filter = new Predicate<object>(o => ((Flight)o).Company.Name == value);
                //List.Refresh();
            }
               



            
        }

        private Command sortByCompanyCommand;
        public Command SortByCompanyCommand
        {
            get
            {
                return sortByCompanyCommand ?? new Command(
                    obj =>
                    {

                        using (ApplicationContext db = new ApplicationContext())
                        {
                           //  UpdateAllDataView();
                            var sortByCompany = db.Flights.OrderBy(f => f.Company.Name);

                            AllFlights = sortByCompany.ToList();
                            NotifyPropertyChanged("AllFlights");
                        }
                    }
                    );
            }
        }
        private Command sortByPriceCommand;
        public Command SortByPriceCommand
        {
            get
            {
                return sortByPriceCommand ?? new Command(
                    obj =>
                    {

                        using (ApplicationContext db = new ApplicationContext())
                        {
                            
                            var sortByPrice = db.Flights.OrderBy(f => f.Price);

                            AllFlights = sortByPrice.ToList();
                            NotifyPropertyChanged("AllFlights");
                        }
                    }
                    );
            }
        }

        private Command sortByArrivalCommand;
        public Command SortByArrivalCommand
        {
            get
            {
                return sortByArrivalCommand ?? new Command(
                    obj =>
                    {

                        using (ApplicationContext db = new ApplicationContext())
                        {

                            var sortByArrival = db.Flights.OrderBy(f => f.Way.Arrival);

                            AllFlights = sortByArrival.ToList();
                            NotifyPropertyChanged("AllFlights");
                        }
                    }
                    );
            }
        }
        private Command sortByDepartureCommand;
        public Command SortByDepartureCommand
        {
            get
            {
                return sortByDepartureCommand ?? new Command(
                    obj =>
                    {

                        using (ApplicationContext db = new ApplicationContext())
                        {

                            var sortByDeparture = db.Flights.OrderBy(f => f.Way.Departure);

                            AllFlights = sortByDeparture.ToList();
                            NotifyPropertyChanged("AllFlights");
                        }
                    }
                    );
            }
        }
        private Command searchCommand;
        public Command SearchCommand
        {
            get
            {
                return searchCommand ?? new Command(
                    obj =>
                    {

                        using (ApplicationContext db = new ApplicationContext())
                        {
                            //  UpdateAllDataView();
                            //var findFlight = db.Flights.Include("Company").Where(p => p.Company.Name.Any(p => p.Contains(SearchText)));

                            //string pattern = $"{SearchText}";
                            //Regex regex = new Regex(pattern);
                            //var findFlight = (from i in db.Flights
                            //                  where regex.IsMatch(i.Company.Name)
                            //                  select i).ToList() ;
                            //ShowMessageToUser($"{findFlight.ToList()}");

                            // var findFlight = db.Flights.Where(p => p.Company.Name.Contains(SearchText));
                            var findFlight = db.
                            AllFlights = findFlight.ToList();
                            //AllFlights = findFlight;
                            NotifyPropertyChanged("AllFlights");

                            //MainWindow.AllFlightsView.Items.Clear();
                            //MainWindow.AllFlightsView.ItemsSource = users.ToList();
                        }
                    }
                    );
            }
        }

        #endregion
    }
}
