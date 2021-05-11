using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using airlineApp.Commands;
using airlineApp.Model;

namespace airlineApp.ViewModel
{
    public class InfoAboutTicketViewModel : DataManageViewModel
    {

        //public static Flight UserSelectedFlight;
        private Flight userSelectedFlight;
        public Flight UserSelectedFlight
        {
            get { return userSelectedFlight; }
            set
            {
                userSelectedFlight = value;
                NotifyPropertyChanged("UserSelectedFlight");
            }
        }
        public ICommand UpdateViewCommand { get; set; }

        public InfoAboutTicketViewModel(UserWindowViewModel parentVM, string passSur, string passName, string passMiddle, string passPassport, Flight f, string passSeat)
        {
            passengerFullName = passSur + " "+ passName + " "+ passMiddle;
            //NotifyPropertyChanged("PassengerFullName");
            passengerPassport = passPassport;
            passengerSeat = passSeat;
            userSelectedFlight = f;
            
        }

        private string passengerFullName;
        public string PassengerFullName
        {
            get { return passengerFullName; }
            set
            {
                passengerFullName = value;
                NotifyPropertyChanged("PassengerFullName");
            }
        }
        
        private string passengerPassport;
        public string PassengerPassport
        {
            get { return passengerPassport; }
            set
            {
                passengerPassport = value;
                NotifyPropertyChanged("PassengerPassport");
            }
        }
        private string passengerSeat;
        public string PassengerSeat
        {
            get { return passengerSeat; }
            set
            {
                passengerSeat = value;
                NotifyPropertyChanged("PassengerSeat");
            }
        }
        private bool isAccept = false;
        public bool IsAccept
        {
            get { return isAccept; }
            set
            {
                isAccept = value;
                NotifyPropertyChanged(nameof(IsAccept));
            }
        }
        private Command isAcceptCommand;
        public Command IsAcceptCommand
        {
            get
            {
                return isAcceptCommand ?? new Command(
                    obj =>
                    {
                        isAccept = true;
                        NotifyPropertyChanged("IsAccept");
                    }
                    );
            }
        }
        private Command bookTicketCommand;
        public Command BookTicketCommand
        {
            get
            {
                return bookTicketCommand ?? new Command(
                    obj =>
                    {
                        
                    }
                    );
            }
        }
    }
}
