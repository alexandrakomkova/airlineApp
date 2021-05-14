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
            currentPage = new ChooseTicketViewModel(this, user, null);
        }
        private DataManageViewModel currentPage; //= new ChooseTicketViewModel();
        public DataManageViewModel CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                NotifyPropertyChanged(nameof(CurrentPage));
                
            }
        }
        public static Way UserFlightDeparture { get; set; }
        public static Way UserFlightArrival { get; set; }
       
        public static DateTime SelectedBackDate { get; set; }
        public static DateTime SelectedDepartureDate { get; set; }
        
        public static Flight UserSelectedBackFlight { get; set; }

        //private bool isBackEnable = false;
        //public bool IsBackEnable
        //{
        //    get { return isBackEnable; }
        //    set
        //    {
        //        isBackEnable = value;
        //        NotifyPropertyChanged(nameof(IsBackEnable));
        //    }
        //}

        //private List<Flight> userListOneWay { get; set; } //= DataWorker.GetAllFlights();
        private List<Flight> userListBackWay { get; set; }//= DataWorker.GetAllFlights();

        //public List<Flight> UserListOneWay
        //{
        //    get { return userListOneWay; }
        //    set
        //    {
        //        userListOneWay = value;
        //        NotifyPropertyChanged("UserListOneWay");

        //    }
        //}
        public List<Flight> UserListBackWay
        {
            get { return userListBackWay; }
            set
            {
                userListBackWay = value;
                NotifyPropertyChanged("UserListBackWay");
            }
        }

        //public static List<Flight> UserSearch(string d, string a, DateTime dt)
        //{

        //    using (ApplicationContext db = new ApplicationContext())
        //    {

        //        var result = db.Flights.Where(f => f.Way.Departure == d
        //        && f.Way.Arrival == a
        //        && f.Way.DepartureTime.Date == dt.Date).ToList();
        //        return result;

        //    }

        //}
        public static List<Flight> UserBackWaySearch(string d, string a, DateTime dt)
        {

            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Flights.Where(f => f.Way.Departure == d
                && f.Way.Arrival == a
                && f.Way.DepartureTime.Date == dt.Date).ToList();
                return result;
            }

        }
        //private Command userSearchCommand;
        //public Command UserSearchCommand
        //{
        //    get
        //    {
        //        return userSearchCommand ?? new Command(
        //            obj =>
        //            {
        //                MessageBox.Show("123");
        //                //UpdateUserFlights();
        //                //if (IsBackEnable == true)
        //                //{
        //                //    UserListBackWay = UserBackWaySearch(FlightWayDepartureString, FlightWayArrivalString, SelectedBackDate);
        //                //    ChooseTicketPage.UserBackFlightsView.ItemsSource = null;
        //                //    ChooseTicketPage.UserBackFlightsView.Items.Clear();
        //                //    ChooseTicketPage.UserBackFlightsView.ItemsSource = UserListBackWay;
        //                //    ChooseTicketPage.UserBackFlightsView.Items.Refresh();
        //                //}

        //            }
        //            );
        //    }
        //}
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
                       // IsBackEnable = true;
                        NotifyPropertyChanged("IsBackEnable");
                    }
                    );
            }
        }
        private Command viewUserTicketCommand;
        public Command ViewUserTicketCommand
        {
            get
            {
                return viewUserTicketCommand ?? new Command(
                    obj =>
                    {
                        CurrentPage = new UserViewTicketViewModel(this, null, user);
                        //MessageBox.Show("gbcz");
                    }
                    );
            }
        }
        private Command searchUserTicketCommand;
        public Command SearchUserTicketCommand
        {
            get
            {
                return searchUserTicketCommand ?? new Command(
                    obj =>
                    {
                        CurrentPage = new ChooseTicketViewModel(this, user, null);
                        //MessageBox.Show("gbcz");
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
        

        
    }
}

