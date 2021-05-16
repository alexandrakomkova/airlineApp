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

namespace airlineApp.ViewModel
{
    public class GetPlaceViewModel : DataManageViewModel
    {
        private UserWindowViewModel parentVM;
        private User user;
        public static Flight UserSelectedFlight;


        public GetPlaceViewModel(UserWindowViewModel parentVM, Flight f, User user)
        {
            this.user = user;
            //MessageBox.Show($"{user.Email}");
            UserSelectedFlight = f;
            List<string> places = new List<string>();
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Flights.Where(p => p.Id == f.Id).FirstOrDefault();
                var except = db.Tickets.Where(t => t.FlightId == f.Id).Select(t => t.Seat).ToList();
                for (int i = 1; i < result.FreePlaces + 1; i++)
                {
                    places.Add(i.ToString());
                }
                for (int j = 0; j < except.Count; j++)
                {
                    places.Remove(except[j].ToString());
                }
            }
            PlacesList = places;
            NotifyPropertyChanged("PlacesList");


            this.parentVM = parentVM;
            UpdateViewCommand = new Command(OnUpdateViewCommandExecuted);
        }
        public static string ChosenPlace { get; set; }
        private List<string> placesList { get; set; }

        public List<string> PlacesList 
        {
            get { return placesList; }
            set
            {
                placesList = value;
                NotifyPropertyChanged("PlacesList");
            }
        }
        public ICommand UpdateViewCommand { get; }
        public ICommand UpdateBackViewCommand { get; }
        private void OnUpdateViewCommandExecuted(object p)
        {
            parentVM.CurrentPage = new EnterUserInfoViewModel(parentVM, UserSelectedFlight, ChosenPlace, user, null, null, null, null);
            if (p.ToString() == "GetTicket") 
            {
                parentVM.CurrentPage = new ChooseTicketViewModel(parentVM, user, UserSelectedFlight);
            }
        }

    }
}
