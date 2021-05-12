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
               // MessageBox.Show($"{userSelectedFlight.FreePlaces}");
            }
        }

        
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
                        //if (IsBackEnable == true)
                        //{
                        //    UserListBackWay = UserBackWaySearch(FlightWayDepartureString, FlightWayArrivalString, SelectedBackDate);
                        //    ChooseTicketPage.UserBackFlightsView.ItemsSource = null;
                        //    ChooseTicketPage.UserBackFlightsView.Items.Clear();
                        //    ChooseTicketPage.UserBackFlightsView.ItemsSource = UserListBackWay;
                        //    ChooseTicketPage.UserBackFlightsView.Items.Refresh();
                        //}

                    }
                    );
            }
        }
        public static DateTime SelectedDepartureDate { get; set; }
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
                MessageBox.Show("list is null");
            }

            //это грязно
            //придумать что-нибудь
        }
        public ICommand UpdateViewCommand { get; }
        private void OnUpdateViewCommandExecuted(object p)
        {
            //MessageBox.Show($"{userSelectedFlight.FreePlaces}");

            parentVM.CurrentPage = new GetPlaceViewModel(parentVM, userSelectedFlight, user);
        }
        public ChooseTicketViewModel(UserWindowViewModel parentVM, User user, Flight f)
        {
           
            this.parentVM = parentVM;
            this.user = user;
            //MessageBox.Show($"{this.user.Email}");
            userSelectedFlight = f;
            
            UpdateViewCommand = new Command(OnUpdateViewCommandExecuted);
        }

        
    }
    
}
