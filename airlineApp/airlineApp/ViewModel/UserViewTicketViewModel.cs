using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using airlineApp.Model;
using airlineApp.View;

namespace airlineApp.ViewModel
{
    public class UserViewTicketViewModel : DataManageViewModel
    {
        private UserWindowViewModel parentVM;
        private Flight userSelectedFlight;
        private User user;
        private static List<Ticket> allUserTickets { get; set; }
        public List<Ticket> AllUserTickets
        {
            get { return allUserTickets; }
            set
            {
                allUserTickets = value;
                NotifyPropertyChanged("AllUserTickets");
            }
        }

        public UserViewTicketViewModel(UserWindowViewModel parentVM, Flight userSelectedFlight, User user)
        {
            this.parentVM = parentVM;
            this.userSelectedFlight = userSelectedFlight;
            this.user = user;
            allUserTickets = DataWorker.GetAllUserTickets(user);
            NotifyPropertyChanged("AllUserTickets");

            
        }

       

    }
}
