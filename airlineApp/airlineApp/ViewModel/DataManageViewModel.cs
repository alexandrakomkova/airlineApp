using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using airlineApp.Model;
using airlineApp.Model.Data;
using airlineApp.View;
using Microsoft.AspNet.Identity;
using Microsoft.Win32;

namespace airlineApp.ViewModel
{
    public class DataManageViewModel : INotifyPropertyChanged
   {

        //get all flight

        
        private List<string> allPlanes = DataWorker.GetAllPlanesString();
        private List<Company> allCompanies = DataWorker.GetAllCompanies();
        private List<string> allCompaniesString = DataWorker.GetAllCompaniesString();
        private List<Way> allWays = DataWorker.GetAllWays();
        private List<Ticket> allTickets = DataWorker.GetAllTickets();
        private List<string> allDeparturesString = DataWorker.GetAllDepartures();
        private List<Flight> allFlights = DataWorker.GetAllFlights();
        
        public List<string> AllDeparturesString
        {
            get { return allDeparturesString; }
            set
            {
                allDeparturesString = value;
                NotifyPropertyChanged("AllDeparturesString");
            }
        }
        public List<Ticket> AllTickets
        {
            get { return allTickets; }
            set
            {
                allTickets = value;
                NotifyPropertyChanged("AllTickets");
            }
        }
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
        public List<string> AllCompaniesString
        {
            get { return allCompaniesString; }
            set
            {
                allCompaniesString = value;
                NotifyPropertyChanged("AllCompaniesString");
            }
        }
       
        public List<string> AllPlanes
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
        
        private string companyLogoPath = @"../../Styles/no_image.png";

        private BitmapImage companyLogo = new BitmapImage();
        public BitmapImage CompanyLogo
        {
            get { return companyLogo; }
            set
            {
                companyLogo = value;
                NotifyPropertyChanged("CompanyLogo");
            }
        }

        private List<string> allArrivalsString;
        public List<string> AllArrivalsString
        {
            get { return allArrivalsString; }
            set
            {
                allArrivalsString = value;
                NotifyPropertyChanged("AllArrivalsString");
            }
        }

        private string flightWayDepartureString;
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
        private string flightWayArrivalString;
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
                
                var result = db.Ways.Where(w => w.Departure == d).Select(w => w.Arrival).Distinct().ToList();
                return result;
            }
        }
        
        private static List<Way> AvailableDateTime(string d, string a)
        {

            using (ApplicationContext db = new ApplicationContext())
            {

                var result = db.Ways.Where(w => w.Departure == d && w.Arrival == a).Distinct().ToList();
                return result;
            }
        }

        private Way flightWay;
        public Way FlightWay
        {
            get { return flightWay; }
            set
            {
                flightWay = value;
                NotifyPropertyChanged("FlightWay");
            }
        }


        public static string FlightCompany { get; set; }
       
        public static string FlightPlane { get; set; }
        public static string FlightPrice { get; set; }
        

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
            window.ShowDialog();
        }
        private void OpenAddFlightWndMethod() 
        {
            AddFlightWindow addFlightWindow = new AddFlightWindow();
            SetWindowPosition(addFlightWindow);
        }
        private void OpenEditFlightWndMethod(Flight flight)
        {
            FlightCompany = flight.flightCompany.Name;
            
            FlightWayDepartureString = flight.flightWay.Departure.ToString();
            FlightWayArrivalString = flight.flightWay.Arrival.ToString();
            FlightWay = flight.flightWay;
            FlightPlane = flight.flightPlane.Name;
            FlightPrice = flight.Price.ToString();


            EditFlightWindow editFlightWindow = new EditFlightWindow(this);
            SetWindowPosition(editFlightWindow);
            
           
        }
        private void OpenEditCompanyWndMethod(Company selectedCompany)
        {
            EditCompanyWindow editCompanyWindow = new EditCompanyWindow();
            SelectedCompany = selectedCompany;
            CompanyName = selectedCompany.Name;
            CompanyLogo = new BitmapImage(new Uri(selectedCompany.Logo, UriKind.RelativeOrAbsolute));
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
                   CompanyLogo = new BitmapImage(new Uri(ofd.FileName, UriKind.Absolute));
                   companyLogoPath = ofd.FileName;
                }
                catch
                {
                    string resultStr = "Не удалось загрузить картинку.";
                    ShowMessageToUser(resultStr);
                }
            }
        }
       
       
        private User user;
       
        private void OpenUserWndMethod(User user)
        {
            
            var UserWindowViewModel = new UserWindowViewModel(user);
            var userWindow = new UserWindow { DataContext = UserWindowViewModel};
            userWindow.Show();
            
        }

        private void CloseWndMethod(object obj)
        {
            Window win = obj as Window;
            win.Close();
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
                        //Application.Current.MainWindow.Close();
                        
                        LoginRegisterWindow loginWindow = new LoginRegisterWindow();
                        loginWindow.Show();
                       (obj as Window).Close();

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
                        LoginRegisterWindow loginWindow = new LoginRegisterWindow();
                        loginWindow.Show();
                        (obj as Window).Close();
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
                        RegisterWindow registerWindow = new RegisterWindow();
                        registerWindow.Show();
                        (obj as Window).Close();
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
                            resultStr = "Пожалуйста, введите название авиакомпании.";
                            ShowMessageToUser(resultStr);
                        }
                        else
                        {

                            resultStr = DataWorker.CreateCompany(CompanyName, companyLogoPath);
                           
                            UpdateAllDataView();
                            CurrentList = new ViewAllCompaniesPageViewModel();
                            UpdateCompaniesList(AllCompanies);
                            ShowMessageToUser(resultStr);
                            SetNullValuesToProperties();


                            window.Close();

                        }
                      
                    }
                    );
            }
        }
        private DataManageViewModel currentList;
        public DataManageViewModel CurrentList
        {
            get { return currentList; }
            set
            {
                currentList = value;
                NotifyPropertyChanged("CurrentList");

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
                        if (FlightCompany != null &&
                           FlightWayDepartureString != null &&
                           FlightWayArrivalString != null &&
                           FlightWay != null &&
                           FlightPlane != null &&
                           FlightPrice != null && Convert.ToInt32(FlightPrice) != 0
                           )
                        {
                            using (ApplicationContext db = new ApplicationContext())
                            {
                                resultStr = DataWorker.CreateFlight(FlightWay, FlightCompany.ToString(), FlightPlane, Convert.ToInt32(FlightPrice));
                                 
                                UpdateAllDataView();
                                CurrentList = new ViewAllFlightsPageViewModel();
                                UpdateFlightsList(AllFlights);
                                SetNullValuesToProperties();
                                ShowMessageToUser(resultStr);

                            }
                            window.Close();
                        }
                        else 
                        {
                            string str = "Пожалуйста, заполните все поля формы.";
                            ShowMessageToUser(str);
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
            NotifyPropertyChanged(nameof(AllFlights));
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
            NotifyPropertyChanged(nameof(AllCompanies));
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
        private Command deleteFlight;
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

        private Command deleteCompany;
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
        private Command editFlight;
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

        private Command editCompany;
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
        private Command editFlightCommand;
        public Command EditFlightCommand
        {
            get
            {

                return editFlightCommand ?? new Command(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "";
                    
                    if (FlightCompany != null &&
                            FlightWayDepartureString != null &&
                            FlightWayArrivalString != null &&
                            FlightWay != null &&
                            FlightPlane !=null &&
                            FlightPrice != null && Convert.ToInt32(FlightPrice) != 0
                            )
                    {
                        using (ApplicationContext db = new ApplicationContext()) 
                        {
                            var plane = db.Planes.FirstOrDefault(p => p.Name == FlightPlane);
                           
                            int diff = plane.MaxOfPlaces - (SelectedFlight.flightPlane.MaxOfPlaces - SelectedFlight.FreePlaces);
                            if (diff > 0)
                            {

                                resultStr = DataWorker.EditFlight(SelectedFlight, FlightWay, FlightCompany, FlightPlane, Convert.ToInt32(FlightPrice));

                                UpdateAllDataView();
                                UpdateFlightsList(AllFlights);

                                SetNullValuesToProperties();
                                ShowMessageToUser(resultStr);

                                 window.Close(); 

                            }
                            else
                            {
                                resultStr = "Количество забронированных билетов превышает места в новом самолете. Выберите самолет побольше.";
                                ShowMessageToUser(resultStr);
                            } 
                        }
                            
                    }
                    else
                    {
                        resultStr = "Пожалуйста, заполните все поля.";
                        ShowMessageToUser(resultStr);
                    }

                }
                    );
            }
        }

        private Command editCompanyCommand;
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
                      
                        resultStr = DataWorker.EditCompany(SelectedCompany, CompanyName, companyLogoPath);
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
        private Command login;
        private Command register;
        private Command forgotPassword;
        public Command LoginCommand
        {
            get
            {
                return login ?? new Command(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "";
                    if (LoginEmail == null || LoginEmail.Replace(" ", "").Length == 0
                    || LoginPassword == null || LoginPassword.Replace(" ", "").Length == 0)
                    {
                        resultStr = "Пожалуйста, введите email и пароль для входа.";
                        ShowMessageToUser(resultStr);
                    }
                    else
                    {
                        User authUser = null;
                        IPasswordHasher passwordHashed = new PasswordHasher();

                        using (ApplicationContext db = new ApplicationContext())
                        {
                            authUser = DataWorker.GetUserByEmail(LoginEmail);
                            if (authUser != null)
                            {
                                
                                PasswordVerificationResult verificationResult = passwordHashed.VerifyHashedPassword(authUser.Password, LoginPassword);
                                if (verificationResult == PasswordVerificationResult.Success)
                                {
                                    if (IsAdmin(authUser) == true)
                                    {
                                        Window main = new MainWindow();
                                        main.Show();
                                        window.Close();
                                    }
                                    else
                                    {
                                        OpenUserWndMethod(authUser);
                                        window.Close();
                                    }
                                }
                                else
                                {
                                    resultStr = "Неверный пароль.";
                                    ShowMessageToUser(resultStr);
                                }
                            }
                            else
                            {
                                resultStr = "Неверный email.";
                                ShowMessageToUser(resultStr);
                            }
                        }
                    }
                }
                    );
            }
        }
        public bool IsValidEmail(string email)
        {

            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
        public bool IsEmailUsed(string email)
        {
            User authUser = null;
            authUser = DataWorker.GetUserByEmail(email);
            bool isUsed = false;
            if (authUser != null) 
            {
               isUsed = true;
            }
            return isUsed;
        }
        public Command RegisterCommand
        {
            get
            {
                return register ?? new Command(obj =>
                {

                    string resultStr = "";
                    Window window = obj as Window;
                    try
                    {
                        if (EmailText == null || EmailText.Replace(" ", "").Length == 0
                        || PasswordText == null || PasswordText.Replace(" ", "").Length == 0
                        || ConfirmPasswordText == null)
                        {
                            resultStr = "Пожалуйста, заполните поля для регистрации.";
                            ShowMessageToUser(resultStr);
                        }
                        else if (PasswordText.Length < 6)
                        {
                            resultStr = "Пароль должен быть не меньше 6 символов.";
                            
                            ShowMessageToUser(resultStr);
                        }
                        else
                        if (PasswordText != ConfirmPasswordText)
                        {
                            resultStr = "Пароли не совпадают.";
                            ShowMessageToUser(resultStr);
                        }
                        else
                        {
                            if (IsEmailUsed(EmailText) == false)
                            {
                                if (IsValidEmail(EmailText) == true)
                                {


                                    resultStr = DataWorker.CreateUser(EmailText, PasswordText);
                                    ShowMessageToUser(resultStr);
                                    User authUser = null;
                                    authUser = DataWorker.GetUserByEmail(EmailText);
                                    OpenUserWndMethod(authUser);
                                    window.Close();
                                    SetNullValuesToProperties();

                                }
                                else
                                {
                                    resultStr = "Неверный формат email.";
                                    ShowMessageToUser(resultStr);

                                }
                            }
                            else 
                            {
                                resultStr = "Пользователь с таким email уже зарегистрирован.";
                                ShowMessageToUser(resultStr);
                            }
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
                if (user.IsAdmin.ToString() == isAdmin) 
                {
                    i = true;
                }
                return i;
            }
        }
        public Command ForgotPasswordCommand
        {
            get
            {
                return forgotPassword ?? new Command(obj =>
                {
                    string resultStr = "";
                    if (LoginEmail != null)
                    {
                        using (ApplicationContext db = new ApplicationContext())
                        { 
                            User authUser = null;
                            authUser = DataWorker.GetUserByEmail(LoginEmail);
                            if (authUser != null)
                            {
                                const int timeout = 1000;
                                const string host = "google.com";

                                if (CanPingGoogle() == true)
                                {
                                    resultStr = "Письмо отправлено на email под которым вы зарегистрированы. Проверьте также категорию Спам.";
                                    SendEmailAsync(LoginEmail).GetAwaiter();
                                    ShowMessageToUser(resultStr);
                                    authUser = DataWorker.GetUserByEmail(LoginEmail);
                                   
                                    DataWorker.EditUser(LoginEmail, newPassword);
                                }
                                else
                                {
                                    resultStr = "К сожалению, вы не подключены к сети Интернет, чтобы получить дальнейшую инстуркцию по почте.";
                                    ShowMessageToUser(resultStr);
                                }

                            }
                            else
                            {
                            resultStr = "Пользователь с таким Email отсутствует. Необходимо зарегистрироваться.";
                            ShowMessageToUser(resultStr);
                            }

                        }
                    }
                    else 
                    {
                        resultStr = "Пожалуйста, заполните поле Email, чтобы мы могли отправить вам дальнейшие указания.";
                        ShowMessageToUser(resultStr);
                    }
                }
                    );
            }
        }
        public static string newPassword;
        private static async Task SendEmailAsync(string str)
        {
            newPassword = Random(7);
            
            
            MailAddress from = new MailAddress("airlineapp377@gmail.com", "AirlineApp");
            MailAddress to = new MailAddress(str); 
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Никому не сообщайте информацию из письма!";
            m.Body = $"Здравствуйте! Ваш новый пароль: {newPassword}";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("airlineapp377@gmail.com", "CnEiHvZR2Q");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }
        public static string Random(int length)
        {
            try
            {
                
                char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz".ToCharArray();

                Random rand = new Random();
                newPassword = null;
                for (int i = 1; i <= length; i++)
                {
                    int letter_num = rand.Next(0, letters.Length - 1);
                    newPassword += letters[letter_num];
                }
                return newPassword;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private static bool CanPingGoogle()
        {
            const int timeout = 1000;
            const string host = "google.com";

            var ping = new Ping();
            var buffer = new byte[32];
            var pingOptions = new PingOptions();

            try
            {
                var reply = ping.Send(host, timeout, buffer, pingOptions);
                return (reply != null && reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

       
        
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
            NotifyPropertyChanged(nameof(FlightCompany));
            FlightPrice = null;
            FlightPlane = null;
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
