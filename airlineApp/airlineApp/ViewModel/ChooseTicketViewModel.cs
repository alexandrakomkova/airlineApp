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

namespace airlineApp.ViewModel
{
    public class ChooseTicketViewModel : DataManageViewModel
    {
        private UserWindowViewModel parentVM;
        private Flight userSelectedFlight;
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

        public ICommand UpdateViewCommand { get; }
        private void OnUpdateViewCommandExecuted(object p)
        {
            //MessageBox.Show($"{userSelectedFlight.FreePlaces}");

            parentVM.CurrentPage = new GetPlaceViewModel(parentVM, userSelectedFlight);
        }

        public ChooseTicketViewModel(UserWindowViewModel parentVM, Flight f)
        {
            this.parentVM = parentVM;
            userSelectedFlight = f;
            if (f != null)
            {
                UserWindowViewModel.UserFlightDeparture = f.flightWay;
                NotifyPropertyChanged("UserFlightDeparture");
            }
            UpdateViewCommand = new Command(OnUpdateViewCommandExecuted);
        }
    }
    
}
