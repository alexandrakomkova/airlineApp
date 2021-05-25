using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
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
        public string schemeOfPlane { get; set; }
        public GetPlaceViewModel(UserWindowViewModel parentVM, Flight f, User user)
        {
            this.user = user;
           
            UserSelectedFlight = f;
            
            if (UserSelectedFlight.flightPlane.MaxOfPlaces == 120)
            {
                schemeOfPlane = "/Styles/120.jpg";
            }
            else if (UserSelectedFlight.flightPlane.MaxOfPlaces == 148)
            {
                schemeOfPlane = "/Styles/148.jpg";
            }
            else if (UserSelectedFlight.flightPlane.MaxOfPlaces == 189)
            {
                schemeOfPlane = "/Styles/189.jpg";
            }
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
        private List<string> placesList;

        public List<string> PlacesList 
        {
            get { return placesList; }
            set
            {
                placesList = value;
                NotifyPropertyChanged("PlacesList");
            }
        }
        public ICommand UpdateViewCommand { get; set; }

        private void OnUpdateViewCommandExecuted(object p)
        {

            if (p.ToString() == "GetTicket")
            {
                parentVM.CurrentPage = new ChooseTicketViewModel(parentVM, user, UserSelectedFlight);
            }


            if (p.ToString() == "Passenger" )
            {
                if (ChosenPlace != null) 
                {
                    parentVM.CurrentPage = new EnterUserInfoViewModel(parentVM, UserSelectedFlight, ChosenPlace, user, null, null, null, null);
                }
                else
                {
                    string resultStr = "Пожалуйста, выберите место.";
                    ShowMessageToUser(resultStr);
                }
            }
            
        }

    }
}
