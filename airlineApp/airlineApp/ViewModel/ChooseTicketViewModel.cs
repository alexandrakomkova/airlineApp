using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using airlineApp.Commands;
using airlineApp.CustomControls;
using airlineApp.Model;
using airlineApp.Model.Data;
using airlineApp.View;

namespace airlineApp.ViewModel
{
    public class ChooseTicketViewModel : DataManageViewModel
    {
        
        private Flight userSelectedFlight;
        private User user;
        private UserWindowViewModel parentVM;
      
        public Flight UserSelectedFlight
        {
            get { return userSelectedFlight; }
            set
            {
                userSelectedFlight = value;
                NotifyPropertyChanged("UserSelectedFlight");
            }
        }

        
        private List<Flight> userListOneWay { get; set; } //= DataWorker.GetAllFlights();
        public List<Flight> UserListOneWay
        {
            get { return userListOneWay; }
            set
            {
                userListOneWay = value;
                NotifyPropertyChanged("UserListOneWay");

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
                    }
                    );
            }
        }
        public static DateTime SelectedDepartureDate { get; set; } = DateTime.Now; 
        public static List<Flight> UserSearch(string d, string a, DateTime dt)
        {

            using (ApplicationContext db = new ApplicationContext())
            {

                var result = db.Flights.Where(f => f.Way.Departure == d
                && f.Way.Arrival == a
                && f.Way.DepartureTime.Date == dt.Date).ToList();
                return result;

            }

        }
        private void UpdateUserFlights()
        { //возможно надо будет в другой вьюмодел
            UserListOneWay = UserSearch(FlightWayDepartureString, FlightWayArrivalString, SelectedDepartureDate);
            if (UserListOneWay != null)
            {
                ChooseTicketPage.UserFlightsView.ItemsSource = null;
                ChooseTicketPage.UserFlightsView.Items.Clear();
                ChooseTicketPage.UserFlightsView.ItemsSource = UserListOneWay;
                ChooseTicketPage.UserFlightsView.Items.Refresh();
            }
            else 
            {
                //string resultStr = "К сожалению авиарейсов на эту дату нет.";
                //ShowMessageToUser(resultStr);
            }
            

            //это грязно
            //придумать что-нибудь
        }
        public ICommand UpdateViewCommand { get; }
        private void OnUpdateViewCommandExecuted(object p)
        {
            //MessageBox.Show($"{userSelectedFlight.FreePlaces}");
            if (userSelectedFlight != null)
            {
                parentVM.CurrentPage = new GetPlaceViewModel(parentVM, userSelectedFlight, user);
            }
            else 
            {
                string resultStr = "Пожалуйста, выберите инетресующий вас авиарейс.";
                ShowMessageToUser(resultStr);
            }
        }
        public ChooseTicketViewModel(UserWindowViewModel parentVM, User user, Flight f)
        {
           
            this.parentVM = parentVM;
            this.user = user;
            
            userSelectedFlight = f;
            if (userSelectedFlight != null)
            {
                FlightWayDepartureString = userSelectedFlight.flightWay.Departure;
                FlightWayArrivalString = userSelectedFlight.flightWay.Arrival;
            }
           
            UpdateViewCommand = new Command(OnUpdateViewCommandExecuted);
        }
        private Command switchDapartureArrivalCommand;
        public Command SwitchDapartureArrivalCommand
        {
            get
            {
                return switchDapartureArrivalCommand ?? new Command(
                    obj =>
                    {
                        string str = FlightWayDepartureString;
                        FlightWayDepartureString = FlightWayArrivalString;
                        FlightWayArrivalString = str;
                    }
                    );
            }
        }

    }
    
}
