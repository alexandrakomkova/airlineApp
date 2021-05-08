using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using airlineApp.Commands;
using airlineApp.Model;
using airlineApp.Model.Data;
using airlineApp.View;

namespace airlineApp.ViewModel
{
    public class UserWindowViewModel : DataManageViewModel
    {
        public ICommand UpdateViewCommand { get; set; }

        public UserWindowViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            currentPage = new ChooseTicketViewModel(this);
        }
        public static Way UserFlightDeparture { get; set; }
        public static Way UserFlightArrival { get; set; }
        public DateTime ThisDate { get; set; } = DateTime.Now;
        public static DateTime SelectedBackDate { get; set; } 
        public static DateTime SelectedDepartureDate { get; set; }
        public static Flight UserSelectedFlight { get; set; }
        public static Flight UserSelectedBackFlight { get; set; }

        private DataManageViewModel currentPage; //= new ChooseTicketViewModel();
        public DataManageViewModel CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                NotifyPropertyChanged(nameof(CurrentPage));
                ThisDate = DateTime.Now;
            }
        }
       // public static bool IsBackEnable { get; set; } = false;
        private bool isBackEnable = false; //= new ChooseTicketViewModel();
        public bool IsBackEnable
        {
            get { return isBackEnable; }
            set
            {
                isBackEnable = value;
                NotifyPropertyChanged(nameof(IsBackEnable));
                if (IsBackEnable == true && SelectedBackDate != ThisDate)
                {
                    UserListBackWay = UserBackWaySearch(UserFlightDeparture, UserFlightArrival, SelectedBackDate);
                    ChooseTicketPage.UserBackFlightsView.ItemsSource = null;
                    ChooseTicketPage.UserBackFlightsView.Items.Clear();
                    ChooseTicketPage.UserBackFlightsView.ItemsSource = UserListBackWay;
                    ChooseTicketPage.UserBackFlightsView.Items.Refresh();
                }
                //вызвать тут поиск билета обратно + обновление списка для обратных рейсов
            }
        }

        private List<Flight> userListOneWay { get; set; }//= DataWorker.GetAllFlights();
        private List<Flight> userListBackWay { get; set; }//= DataWorker.GetAllFlights();

        public List<Flight> UserListOneWay
        {
            get { return userListOneWay; }
            set
            {
                userListOneWay = value;
                NotifyPropertyChanged("UserListOneWay");
            }
        }
        public List<Flight> UserListBackWay
        {
            get { return userListBackWay; }
            set
            {
                userListBackWay = value;
                NotifyPropertyChanged("UserListBackWay");
            }
        }

        public static List<Flight> UserSearch(Way d, Way a, DateTime dt)
        {
           
            using (ApplicationContext db = new ApplicationContext())
            {
               
                var result = db.Flights.Where(f=> f.Way.Departure == d.Departure 
                && f.Way.Arrival == a.Arrival 
                && f.Way.DepartureTime.Date == dt.Date).ToList();
                return result;
                
            }
            
        }
        public static List<Flight> UserBackWaySearch(Way d, Way a, DateTime dt)
        {
            //MessageBox.Show($"{a.Arrival} - {d.Departure}");
            using (ApplicationContext db = new ApplicationContext())
            {
                //придумать когда вытаскивать дату из back date для сравнения
                var result = db.Flights.Where(f => f.Way.Departure == d.Arrival
                && f.Way.Arrival == a.Departure
                /*&& f.Way.DepartureTime.Date == dt.Date*/).ToList();
                return result;
            }

        }
        private Command userSearchCommand;
        public Command UserSearchCommand
        {
            get
            {
                return userSearchCommand ?? new Command(
                    obj =>
                    {
                        UpdateUserFlights();
                        if (IsBackEnable == true && SelectedBackDate != ThisDate)
                        {
                            UserListBackWay = UserBackWaySearch(UserFlightDeparture, UserFlightArrival, SelectedBackDate);
                            ChooseTicketPage.UserBackFlightsView.ItemsSource = null;
                            ChooseTicketPage.UserBackFlightsView.Items.Clear();
                            ChooseTicketPage.UserBackFlightsView.ItemsSource = UserListBackWay;
                            ChooseTicketPage.UserBackFlightsView.Items.Refresh();
                        }
                    }
                    );
            }
        }
        private Command switchDapartureArrivalCommand;
        public Command SwitchDapartureArrivalCommand
        {
            get
            {
                return switchDapartureArrivalCommand ?? new Command(
                    obj =>
                    {
                        //Way middleD = UserFlightDeparture;
                        //Way middleA = UserFlightArrival;
                        //UserFlightDeparture = middleA;
                        //UserFlightArrival = middleD;
                        Way middle = UserFlightDeparture;
                        UserFlightDeparture = null;
                        UserFlightDeparture = UserFlightArrival;
                        UserFlightArrival = null;
                        UserFlightArrival = middle;

                        NotifyPropertyChanged("UserFlightDeparture");
                        NotifyPropertyChanged("UserFlightArrival");
                        ShowMessageToUser($"{UserFlightDeparture.Departure} - {UserFlightArrival.Arrival}");

                    }
                    );
            }
        }
        private Command needBackTicketCommand;
        public Command NeedBackTicketCommand
        {
            get
            {
                return needBackTicketCommand ?? new Command(
                    obj =>
                    {
                        IsBackEnable = true;
                        NotifyPropertyChanged("IsBackEnable");
                    }
                    );
            }
        }
        private void ShowMessageToUser(string text)
        {
            Message message = new Message(text);
            SetWindowPosition(message);
        }
        private List<int> MakeSchemaOfPlaces()
        {
            List<int> places = new List<int>();
            using (ApplicationContext db = new ApplicationContext()) 
            {
                var result = db.Planes.Where(p=> p.Id == UserSelectedFlight.PlaneId).FirstOrDefault();
                for (int i =0; i<result.MaxOfPlaces;i++) 
                {
                    places.Add(i);
                }
            }
            return places;
        }

        public List<int> PlacesList
        {
            get => MakeSchemaOfPlaces();
        }

  

        private void SetWindowPosition(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        private void UpdateUserFlights()
        { //возможно надо будет в другой вьюмодел
            UserListOneWay = UserSearch(UserFlightDeparture, UserFlightArrival, SelectedDepartureDate);
            ChooseTicketPage.UserFlightsView.ItemsSource = null;
            ChooseTicketPage.UserFlightsView.Items.Clear();
            ChooseTicketPage.UserFlightsView.ItemsSource = UserListOneWay;
            ChooseTicketPage.UserFlightsView.Items.Refresh();
            
            //это грязно
            //придумать что-нибудь
        }
    }
}
