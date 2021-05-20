using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using airlineApp.Commands;
using airlineApp.Model;
using airlineApp.View;

namespace airlineApp.ViewModel
{
    public class InfoAboutTicketViewModel : DataManageViewModel
    {

        
        private Flight userSelectedFlight;
        private User user;
        private UserWindowViewModel parentVM;
        public string ps, pn, pm;

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

        public InfoAboutTicketViewModel(UserWindowViewModel parentVM, string passSur, string passName, string passMiddle, string passPassport, Flight f, string passSeat, User user)
        {
            this.user = user;
           
            passengerFullName = passSur + " "+ passName + " "+ passMiddle;
           
            passengerPassport = passPassport;
            passengerSeat = passSeat;
            userSelectedFlight = f;
            this.parentVM = parentVM;
            UpdateViewCommand = new Command(OnUpdateViewCommandExecuted);
            ps = passSur;
            pn = passName;
            pm = passMiddle;
        }
        private void OnUpdateViewCommandExecuted(object p)
        {
           
            if (p.ToString() == "Passenger")
            {
                parentVM.CurrentPage = new EnterUserInfoViewModel(parentVM, UserSelectedFlight, passengerSeat, user, passengerPassport, ps, pn, pm);
            }
            else if(p.ToString() == "ViewTicket")
            {
                string resultStr = "";
                
                if (IsAccept == true)
                {
                    resultStr = DataWorker.CreateTicket(PassengerFullName, PassengerPassport, Convert.ToInt32(passengerSeat), userSelectedFlight, user);
                    ShowMessageToUser(resultStr);
                    parentVM.CurrentPage = new UserViewTicketViewModel(parentVM, userSelectedFlight, user);
                }
                else 
                {
                    resultStr = "Пожалуйста, проверьте введенные данные. Если они верны, подтвердите в поле Accept.";
                    ShowMessageToUser(resultStr);
                }
            }

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
        
    }
}
