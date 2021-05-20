using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using airlineApp.Commands;
using airlineApp.Model;

namespace airlineApp.ViewModel
{
    public class EnterUserInfoViewModel : DataManageViewModel
    {
        private UserWindowViewModel parentVM;
        private User user;
        public static Flight UserSelectedFlight;
        private string passengerSurname;
        public string PassengerSurname
        {
            get { return passengerSurname; }
            set
            {
                passengerSurname = value;
                NotifyPropertyChanged("PassengerSurname");
            }
        }

        private string passengerName;
        public string PassengerName
        {
            get { return passengerName; }
            set
            {
                passengerName = value;
                NotifyPropertyChanged("PassengerName");
            }
        }
        private string passengerMiddleName;
        public string PassengerMiddleName
        {
            get { return passengerMiddleName; }
            set
            {
                passengerMiddleName = value;
                NotifyPropertyChanged("PassengerMiddleName");
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

        public EnterUserInfoViewModel(UserWindowViewModel parentVM, Flight f, string place, User user, string pass, string ps, string pn, string pm)
        {
            this.user = user;
           
            UserSelectedFlight = f;
            passengerSeat = place;
            this.parentVM = parentVM;
            this.passengerPassport = pass;
            
            this.passengerName = pn;
            this.passengerMiddleName = pm;
            this.passengerSurname = ps;
            
            UpdateViewCommand = new Command(OnUpdateViewCommandExecuted);
        }
        public bool IsValidPassport(string passport)
        {
            string pattern = "[A-Z]{2}[0-9]{7}$";
            Match isMatch = Regex.Match(passport, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
        public ICommand UpdateViewCommand { get; }
        private void OnUpdateViewCommandExecuted(object p)
        {
            if (p.ToString() == "Place")
            {
                parentVM.CurrentPage = new GetPlaceViewModel(parentVM, UserSelectedFlight, user);
               
            }
            else 
            {
                if (IsValidPassport(passengerPassport) == true)
                {
                    parentVM.CurrentPage = new InfoAboutTicketViewModel(parentVM, passengerSurname, passengerName, passengerMiddleName, passengerPassport, UserSelectedFlight, passengerSeat, user);
                }
                else 
                {
                    string resultStr = "Неправильный формат записи номера пасспорта.\nПример: XX1234567";
                    ShowMessageToUser(resultStr);
                }
            }
        }

    }
}
