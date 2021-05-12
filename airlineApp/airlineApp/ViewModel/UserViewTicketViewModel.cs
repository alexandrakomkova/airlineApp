using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using airlineApp.Model;

namespace airlineApp.ViewModel
{
    public class UserViewTicketViewModel : DataManageViewModel
    {
        private UserWindowViewModel parentVM;
        private Flight userSelectedFlight;
        private User user;

        public UserViewTicketViewModel(UserWindowViewModel parentVM, Flight userSelectedFlight, User user)
        {
            this.parentVM = parentVM;
            this.userSelectedFlight = userSelectedFlight;
            this.user = user;
        }
    }
}
