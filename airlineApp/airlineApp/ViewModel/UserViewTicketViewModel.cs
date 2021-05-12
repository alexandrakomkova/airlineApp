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

        public UserViewTicketViewModel(UserWindowViewModel parentVM, Flight userSelectedFlight)
        {
            this.parentVM = parentVM;
            this.userSelectedFlight = userSelectedFlight;
        }
    }
}
