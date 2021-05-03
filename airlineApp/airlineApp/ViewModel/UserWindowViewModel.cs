using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using airlineApp.Model;
using airlineApp.Model.Data;
using airlineApp.View;

namespace airlineApp.ViewModel
{
    public class UserWindowViewModel : DataManageViewModel
    {
        public static Way UserFlightDeparture { get; set; }
        public static Way UserFlightArrival { get; set; }
        public DateTime ThisDate { get; set; }
        public static DateTime SelectedArrivalDate { get; set; }
        public static DateTime SelectedDepartureDate { get; set; }
        private List<Flight> userListOneWay = DataWorker.GetAllFlights();

        public List<Flight> UserListOneWay
        {
            get { return userListOneWay; }
            set
            {
                userListOneWay = value;
               NotifyPropertyChanged("UserListOneWay");
            }
        }
        //public List<Flight> UserListOneWay { get; set; }

        private DataManageViewModel currentPage = new ChooseTicketViewModel();
        public DataManageViewModel CurrentPage
        {
            get { return currentPage; }
            set 
            { 
                currentPage = value;
                NotifyPropertyChanged("CurrentPage");
                ThisDate = DateTime.Now;
            }
        }
        public static List<Flight> UserSearch(Way d, Way a, DateTime dt, DateTime da)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                //var result = db.Flights.Where(f=> f.Way.Departure == d && f.Way.Arrival == a && f.Way.ArrivalTime==da && f.Way.DepartureTime==dt).ToList();
                var result = db.Flights.Where(f => f.Way.Departure == d.Departure && f.Way.Arrival == a.Arrival && f.Way.ArrivalTime.Date == da.Date && f.Way.DepartureTime.Date == dt.Date).ToList();
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
        {
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
