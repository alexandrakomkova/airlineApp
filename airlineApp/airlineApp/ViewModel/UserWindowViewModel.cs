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
        public static DateTime SelectedArrivalDate { get; set; } 
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

        public static List<Flight> UserSearch(Way d, Way a, DateTime dt, DateTime da)
        {
           
            using (ApplicationContext db = new ApplicationContext())
            {
               
                var result = db.Flights.Where(f=> f.Way.Departure == d.Departure 
                && f.Way.Arrival == a.Arrival 
                && f.Way.ArrivalTime.Date == da.Date
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
                        
                        //if (UserListOneWay.Count == 0)
                        //{
                        //    ShowMessageToUser("К сожалению таких маршрутов нет..");
                        //}
                        //else
                        //{
                        //    ShowMessageToUser(UserFlightDeparture.Departure);
                        //}
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
            UserListOneWay = UserSearch(UserFlightDeparture, UserFlightArrival, SelectedDepartureDate, SelectedArrivalDate);
            ChooseTicketPage.UserFlightsView.ItemsSource = null;
            ChooseTicketPage.UserFlightsView.Items.Clear();
            ChooseTicketPage.UserFlightsView.ItemsSource = UserListOneWay;
            ChooseTicketPage.UserFlightsView.Items.Refresh();
            //это грязно
            //придумать что-нибудь
        }
    }
}
