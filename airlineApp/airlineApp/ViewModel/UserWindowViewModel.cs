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
        private readonly User user;
        public ICommand UpdateViewCommand { get; set; }

        public UserWindowViewModel(User user)
        {
            this.user = user;
           // MessageBox.Show($"{user.Email}");//выводит месседж показывает данные а потом пишет что юзер нул
            UpdateViewCommand = new UpdateViewCommand(this);
            currentPage = new ChooseTicketViewModel(this);
        }
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
        public static Way UserFlightDeparture { get; set; }
        public static Way UserFlightArrival { get; set; }
        public DateTime ThisDate { get; set; } = DateTime.Now;
        public static DateTime SelectedBackDate { get; set; }
        public static DateTime SelectedDepartureDate { get; set; }
        //private Flight userSelectedFlight{ get; set; }
        //public Flight UserSelectedFlight
        //{
        //    get { return userSelectedFlight; }
        //    set
        //    {
        //        userSelectedFlight = value;
        //        NotifyPropertyChanged("UserSelectedFlight");
        //        PlacesList = MakeSchemaOfPlaces(UserSelectedFlight);
        //        NotifyPropertyChanged("PlacesList");
        //    }
        //}
        //public static Flight UserSelectedFlight { get; set; }
        public static Flight UserSelectedBackFlight { get; set; }




        private bool isBackEnable = false;
        public bool IsBackEnable
        {
            get { return isBackEnable; }
            set
            {
                isBackEnable = value;
                NotifyPropertyChanged(nameof(IsBackEnable));
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

                var result = db.Flights.Where(f => f.Way.Departure == d.Departure
                && f.Way.Arrival == a.Arrival
                && f.Way.DepartureTime.Date == dt.Date).ToList();
                return result;

            }

        }
        public static List<Flight> UserBackWaySearch(Way d, Way a, DateTime dt)
        {

            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Flights.Where(f => f.Way.Departure == d.Arrival
                && f.Way.Arrival == a.Departure
                && f.Way.DepartureTime.Date == dt.Date).ToList();
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
                        if (IsBackEnable == true)
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

