﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using airlineApp.Commands;
using airlineApp.Model;

namespace airlineApp.ViewModel
{
    public class EnterUserInfoViewModel : DataManageViewModel
    {
        private UserWindowViewModel parentVM;
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

        private string passengerName { get; set; }
        public string PassengerName
        {
            get { return passengerName; }
            set
            {
                passengerName = value;
                NotifyPropertyChanged("PassengerName");
            }
        }
        private string passengerMiddleName { get; set; }
        public string PassengerMiddleName
        {
            get { return passengerMiddleName; }
            set
            {
                passengerMiddleName = value;
                NotifyPropertyChanged("PassengerMiddleName");
            }
        }
        private string passengerPassport { get; set; }
        public string PassengerPassport
        {
            get { return passengerPassport; }
            set
            {
                passengerPassport = value;
                NotifyPropertyChanged("PassengerPassport");
            }
        }
        private string passengerSeat { get; set; }
        public string PassengerSeat
        {
            get { return passengerSeat; }
            set
            {
                passengerSeat = value;
                NotifyPropertyChanged("PassengerSeat");
            }
        }

        public EnterUserInfoViewModel(UserWindowViewModel parentVM, Flight f, string place)
        {
            UserSelectedFlight = f;
            passengerSeat = place;
            this.parentVM = parentVM;
            UpdateViewCommand = new Command(OnUpdateViewCommandExecuted);
        }
        public ICommand UpdateViewCommand { get; }
        private void OnUpdateViewCommandExecuted(object p)
        {
           
            parentVM.CurrentPage = new InfoAboutTicketViewModel(parentVM, passengerSurname, passengerName, passengerMiddleName, passengerPassport, UserSelectedFlight, passengerSeat);
        }

    }
}
