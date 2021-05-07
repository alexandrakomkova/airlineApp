using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using airlineApp.Commands;

namespace airlineApp.ViewModel
{
    public class ChooseTicketViewModel : DataManageViewModel
    {
        public ICommand UpdateViewCommand { get; set; }

        public ChooseTicketViewModel(UserWindowViewModel parentVM)
        {
            UpdateViewCommand = new UpdateViewCommand(parentVM);
        }
    }
}
