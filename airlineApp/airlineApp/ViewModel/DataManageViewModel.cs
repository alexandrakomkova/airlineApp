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
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace airlineApp.ViewModel
{
   public class DataManageViewModel : INotifyPropertyChanged
   {
        
        //get all flight
        
        private List<Plane> allPlanes = DataWorker.GetAllPlanes();
        private List<Company> allCompanies = DataWorker.GetAllCompanies();
        private List<Way> allWays = DataWorker.GetAllWays();
        private List<string> allDeparturesString = DataWorker.GetAllDepartures();
        //private List<List<Way>> allWaysGr = DataWorker.GetAllWaysGr();
        public List<string> AllDeparturesString
        {
            get { return allDeparturesString; }
            set
            {
                allDeparturesString = value;
                NotifyPropertyChanged("AllDeparturesString");
            }
        }
        private List<Flight> allFlights = DataWorker.GetAllFlights();
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
        public List<Plane> AllPlanes
        {
            get { return allPlanes; }
            set
            {
                allPlanes = value;
                NotifyPropertyChanged("AllPlanes");
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
        private List<Way> allWaysDateTime;
        public List<Way> AllWaysDateTime
        {
            get { return allWaysDateTime; }
            set
            {
                allWaysDateTime = value;
                NotifyPropertyChanged("AllWaysDateTime");
            }
        }


        public static Flight SelectedFlight { get; set; }
        public static Company SelectedCompany { get; set; }
        public static string CompanyName { get; set; }
        public static string CompanyLogo { get; set; }
        private List<string> allArrivalsString { get; set; }
        public List<string> AllArrivalsString
        {
            get { return allArrivalsString; }
            set
            {
                allArrivalsString = value;
                NotifyPropertyChanged("AllArrivalsString");
            }
        }
        private string flightWayDepartureString { get; set; }
        public string FlightWayDepartureString
        {
            get { return flightWayDepartureString; }
            set
            {
                flightWayDepartureString = value;
                NotifyPropertyChanged("FlightWayDepartureString");
                AllArrivalsString = StringArrivals(FlightWayDepartureString);
                NotifyPropertyChanged("AllArrivalsString");
                
            }
        }
        private string flightWayArrivalString { get; set; }
        public string FlightWayArrivalString
        {
            get { return flightWayArrivalString; }
            set
            {
                flightWayArrivalString = value;
                NotifyPropertyChanged("FlightWayArrivalString");
                AllWaysDateTime = AvailableDateTime(FlightWayDepartureString, FlightWayArrivalString);
                NotifyPropertyChanged("AllWaysDateTime");

            }
        }
        private static List<string> StringArrivals(string d)
        {
            
            using (ApplicationContext db = new ApplicationContext())
            {
                //var result = db.Ways.Select(w => w.Departure).Distinct().ToList();
                var result = db.Ways.Where(w => w.Departure == d).Select(w => w.Arrival).Distinct().ToList();
                return result;
            }
        }
        private static List<Way> AvailableDateTime(string d, string a)
        {

            using (ApplicationContext db = new ApplicationContext())
            {
                //var result = db.Ways.Select(w => w.Departure).Distinct().ToList();
               // Way way = db.Ways.FirstOrDefault(p => p.Departure == d && p.Arrival ==);
                //        return way;
                var result = db.Ways.Where(w => w.Departure == d && w.Arrival == a).Distinct().ToList();
                return result;
            }
        }
        private Way flightWay { get; set; } //= OnlyAvailableArrivals(FlightWay); //поле то самое
        public Way FlightWay
        {
            get { return flightWay; }
            set
            {
                flightWay = value;
                NotifyPropertyChanged("FlightWay");
            }
        }
        //public static Way FlightWayArrival { get; set; }
        // public static Way FlightWay { get; set; }
        public static Company FlightCompany { get; set; }
        public static Plane FlightPlane { get; set; }
        public static decimal FlightPrice { get; set; }
        public static int FlightAllPlaces { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String propertyName) 
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
        private void OpenEditCompanyWndMethod(Company selectedCompany)
        {
            EditCompanyWindow editCompanyWindow = new EditCompanyWindow(selectedCompany);
            SetWindowPosition(editCompanyWindow);
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
                    
                }
                catch
                {
                    string resultStr = "Не удалось загрузить картинку.";
                    ShowMessageToUser(resultStr);
                }
            }
        }
        private void OpenLoginWndMethod()
        {
            LoginRegisterWindow loginWindow = new LoginRegisterWindow();
            SetWindowPosition(loginWindow);
        }
        private void OpenRegisterWndMethod()
        {
            RegisterWindow registerWindow = new RegisterWindow();
            SetWindowPosition(registerWindow);
        }
        private User user;
        //private void OpenMainWndMethod(User user)
        //{
        //    this.user = user;
        //    MainWindow mainWindow = new MainWindow(user);
        //    SetWindowPosition(mainWindow);
        //}
        private void OpenMainWndMethod()
        {
            MainWindow mainWindow = new MainWindow();
            SetWindowPosition(mainWindow);
        }
        //private void OpenUserWndMethod(User user)
        //{
        //    this.user = user;
        //    UserWindow userWindow = new UserWindow(user);
        //    SetWindowPosition(userWindow);
        //}
        private void OpenUserWndMethod(User user)
        {
            //MessageBox.Show($"{user.Email}"); //тут тоже классно я проверила всё показывает правильно
            var UserWindowViewModel = new UserWindowViewModel(user);
            var userWindow = new UserWindow { DataContext = UserWindowViewModel};
            userWindow.Show();
            //SetWindowPosition(userWindow);
        }

        private void CloseWndMethod(object obj)
        {
            Window win = obj as Window;
            win.Hide();
        }
        #endregion


        //commands to open/close windows
        #region commands to open windows
        private Command openAddFlightWndCommand;
        private Command openAddCompanyWndCommand;
        private Command openEditFlightWndCommand;
        private Command loadCompanyLogoWndCommand;
        private Command openLoginWndCommand;
        private Command openRegisterWndCommand;
        private Command shutDownCommand;
        private Command changeAccountWndCommand;

        private Command closeWndCommand;

        public Command ShutDownCommand
        {
            get
            {
                return shutDownCommand ?? new Command(
                    obj =>
                    {
                        App.Current.Shutdown();
                    }
                    );
            }
        }
        public Command ChangeAccountWndCommand
        {
            get
            {
                return changeAccountWndCommand ?? new Command(
                    obj =>
                    {
                        App.Current.MainWindow.Hide();
                        OpenLoginWndMethod();
                    }
                    );
            }
        }
        public Command OpenLoginWndCommand
        {
            get
            {
                return openLoginWndCommand ?? new Command(
                    obj =>
                    {
                        OpenLoginWndMethod();
                    }
                    );
            }
        }
        public Command OpenRegisterWndCommand
        {
            get
            {
                return openRegisterWndCommand ?? new Command(
                    obj =>
                    {
                       
                        OpenRegisterWndMethod();
                    }
                    );
            }
        }
       

        
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
                        CloseWndMethod
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
                            UpdateCompaniesList(AllCompanies);
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
                        if (FlightWayDepartureString == null)
                        {
                            string str = "Пожалуйста, выберите пункт отправления для данного рейса.";
                            ShowMessageToUser(str);
                        }
                        if (FlightWayArrivalString == null)
                        {
                            string str = "Пожалуйста, выберите пункт прибытия  для данного рейса.";
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
                        if (FlightPlane == null)
                        {
                            string str = "Пожалуйста, выберите авиакомпанию для данного рейса.";
                            ShowMessageToUser(str);
                        }
                        else
                        {
                            
                            resultStr = DataWorker.CreateFlight(FlightWay, FlightCompany, FlightPlane, FlightPrice, FlightPlane.MaxOfPlaces);
                            UpdateAllDataView();
                            UpdateFlightsList(AllFlights);
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
        //private Command updateAllCompaniesCommand;
        private void UpdateAllDataView()
        {
            UpdateCompanies();
            UpdateFlights();
           
        }

 

        private void UpdateFlights()
        {
            AllFlights = DataWorker.GetAllFlights();
            //UpdateFlightsList(AllFlights);
            //это грязно
            //придумать что-нибудь
        }
        
        private void UpdateFlightsList(List<Flight> list)
        {
            ViewAllFlightsPage.AllFlightsView.ItemsSource = null;
            ViewAllFlightsPage.AllFlightsView.Items.Clear();
            ViewAllFlightsPage.AllFlightsView.ItemsSource = list;
            ViewAllFlightsPage.AllFlightsView.Items.Refresh();
        }
        private void UpdateCompanies()
        {

            AllCompanies = DataWorker.GetAllCompanies();
            //вынести ручное обновление в отдельный метод
            //так же сделать и у апдейтфлайс
           
        }
        private void UpdateCompaniesList(List<Company> list)
        {
            ViewAllCompaniesPage.AllCompaniesView.ItemsSource = null;
            ViewAllCompaniesPage.AllCompaniesView.Items.Clear();
            ViewAllCompaniesPage.AllCompaniesView.ItemsSource = list;
            ViewAllCompaniesPage.AllCompaniesView.Items.Refresh();
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
                        UpdateFlightsList(AllFlights);
                        
                    }
                    SetNullValuesToProperties();
                    ShowMessageToUser(resultStr);
                }
                    );
            }
        }

        private Command deleteCompany { get; set; }
        public Command DeleteCompanyCommand
        {
            get
            {
                return deleteCompany ?? new Command(obj =>
                {
                    string resultStr = "Пожалуйста, выберите объект для удаления.";

                    if (SelectedCompany != null)
                    {
                        resultStr = DataWorker.DeleteCompany(SelectedCompany);
                        UpdateAllDataView();
                        UpdateCompaniesList(AllCompanies);
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

        private Command editCompany { get; set; }
        public Command EditCompanyWndCommand
        {
            get
            {
                return editCompany ?? new Command(obj =>
                {
                    if (SelectedCompany != null)
                    {
                        OpenEditCompanyWndMethod(SelectedCompany);
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
                                resultStr = DataWorker.EditFlight(SelectedFlight, FlightWay, FlightCompany, FlightPlane, FlightPrice, FlightPlane.MaxOfPlaces);

                                UpdateAllDataView();
                                UpdateFlightsList(AllFlights);
                               
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

        private Command editCompanyCommand { get; set; }
        public Command EditCompany
        {
            get
            {
                return editCompanyCommand ?? new Command(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Пожалуйста, выберите компанию для редактирования.";
                    
                    if (SelectedCompany != null)
                    {
                        resultStr = DataWorker.EditCompany(SelectedCompany, CompanyName, CompanyLogo);

                        UpdateAllDataView();
                        UpdateCompaniesList(AllCompanies);
                        SetNullValuesToProperties();
                        ShowMessageToUser(resultStr);
                        window.Close();
                    }
                    else ShowMessageToUser(resultStr);
                }
                    );
            }
        }
        #endregion




        #region login and register command
        public string EmailText { get; set; }
        public string PasswordText { get; set; }
        public string ConfirmPasswordText { get; set; }
        public string LoginEmail { get; set; }
        public string LoginPassword { get; set; }
        private Command login { get; set; }
        private Command register { get; set; }
        public Command LoginCommand
        {
            get
            {
                return login ?? new Command(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "";
                    if (LoginEmail == null || LoginEmail.Replace(" ", "").Length == 0 
                    || LoginPassword==null || LoginPassword.Replace(" ", "").Length == 0) 
                    {
                        resultStr = "Пожалуйста, введите email и пароль для входа.";
                        ShowMessageToUser(resultStr);
                    }
                    User authUser = null;
                    IPasswordHasher passwordHashed = new PasswordHasher();
                    
                    using (ApplicationContext db = new ApplicationContext()) 
                    {
                        authUser = DataWorker.GetUserByEmail(LoginEmail);
                        PasswordVerificationResult verificationResult = passwordHashed.VerifyHashedPassword(authUser.Password, LoginPassword);
                        if (authUser == null || verificationResult ==PasswordVerificationResult.Failed)
                        {
                            resultStr = "Неверный email или пароль.";
                            ShowMessageToUser(resultStr);
                        }
                        else 
                        {

                            if (IsAdmin(authUser) == true)
                            {
                                //OpenMainWndMethod(authUser);
                                OpenMainWndMethod();
                                //(window as Window).Hide(); 

                            }
                            else 
                            {
                                if (authUser != null)
                                {
                                    OpenUserWndMethod(authUser); //тут всё классно всё передается
                                }
                                else 
                                {
                                    MessageBox.Show("authUser is null");
                                }

                                //(window as Window).Hide();
                            }
                        }
                    }
                }
                    );
            }
        }
       
        public Command RegisterCommand
        {
            get
            {
                return register ?? new Command(obj =>
                {

                    string resultStr = "";
                   
                    try
                    {
                        //if (EmailText == null || PasswordText == null || ConfirmPasswordText == null)
                        //{
                        //    resultStr = "Пожалуйста, заполните поля для регистрации.";
                        //    ShowMessageToUser(resultStr);
                        //}
                        if (EmailText == null || EmailText.Replace(" ", "").Length == 0)
                        {
                            //SetRedBlockControll(window, "EmailBox");
                            resultStr = "Пожалуйста, введите email для регистрации.";
                            ShowMessageToUser(resultStr);
                        }
                        if (PasswordText == null || PasswordText.Replace(" ", "").Length == 0 || PasswordText.Length < 6)
                        {
                            resultStr = "Пароль должен быть не меньше 6 символов.";
                            // SetRedBlockControll(window, "PasswordBox");
                            ShowMessageToUser(resultStr);
                        }
                        if (PasswordText != ConfirmPasswordText)
                        {
                            resultStr = "Пароли не совпадают.";
                            //SetRedBlockControll(window, "PasswordBox");
                            //SetRedBlockControll(window, "ConfirmPasswordBox");
                            ShowMessageToUser(resultStr);
                        }
                        else
                        {

                            resultStr = DataWorker.CreateUser(EmailText, PasswordText);
                            ShowMessageToUser(resultStr);
                            OpenLoginWndMethod();
                            SetNullValuesToProperties();
                        }
                    }
                    catch
                    {
                        resultStr = "Пожалуйста, заполните поля для регистрации.";
                        ShowMessageToUser(resultStr);
                    }
                }
                );
            }
        }
        private bool IsAdmin(User user) 
        {
            using (ApplicationContext db = new ApplicationContext()) 
            {
                string isAdmin = "admin";
                bool i = false;
                //MessageBox.Show();
                //user = db.Users.Where(u=> u.IsAdmin.ToLower() == isAdmin).FirstOrDefault();
                //if (user != null) 
                //{
                //    i = true;
                //}
                if (user.IsAdmin.ToString() == isAdmin) 
                {
                    i = true;
                }
                return i;
            }
        }

        #endregion

        private void SetRedBlockControll(Window wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }
        private static List<Way> OnlyAvailableArrivals(Way d)
        {
            MessageBox.Show($"{d.Arrival}");
            using (ApplicationContext db = new ApplicationContext()) 
            {
                var result = db.Ways.Where(w=> w.Departure == d.Departure).ToList();
                return result;
            }
        }
        protected void ShowMessageToUser(string text)
        {
            Message message = new Message(text);
            SetWindowPosition(message);
        }
        private void SetNullValuesToProperties()
        {
            CompanyName = null;
            CompanyLogo = null;
            FlightWay = null;
            FlightWayDepartureString = null;
            FlightWayArrivalString = null;
            FlightCompany = null;
            FlightPrice = 0;
            FlightPlane = null;
        }
        private void SetNullValuesToUserProperties()
        {

            EmailText = null;
            PasswordText = null;
            LoginPassword = null;
            LoginEmail = null;
            ConfirmPasswordText = null;
        }

        #region search bar and sorting
        private string searchText;
    
        public string SearchText
        {
            get { return searchText; }
            set
            {
                
                searchText = value;
                NotifyPropertyChanged("SearchText");

                using (ApplicationContext db = new ApplicationContext())
                {
                    ViewAllFlightsPage.AllFlightsView.ItemsSource = null;
                    ViewAllFlightsPage.AllFlightsView.Items.Clear();
                    var result = db.Flights.Select(f => f).Where(f => f.Company.Name.Contains(value) || f.Way.Departure.Contains(value) || f.Way.Arrival.Contains(value)).ToList();
                    if (result != null)
                    {
                        ViewAllFlightsPage.AllFlightsView.ItemsSource = result;
                    }

                    ViewAllFlightsPage.AllFlightsView.Items.Refresh();

                   
                }


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
                           
                            var sortByCompany = db.Flights.OrderBy(f => f.Company.Name);

                            AllFlights = sortByCompany.ToList();
                            NotifyPropertyChanged("AllFlights");
                            UpdateFlightsList(AllFlights);

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
                            UpdateFlightsList(AllFlights);
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
                            UpdateFlightsList(AllFlights);
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
                            UpdateFlightsList(AllFlights);
                        }
                    }
                    );
            }
        }
        #endregion    
   }
}
