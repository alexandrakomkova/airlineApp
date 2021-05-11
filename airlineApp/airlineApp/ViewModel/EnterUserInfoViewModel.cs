using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using airlineApp.Commands;

namespace airlineApp.ViewModel
{
    public class EnterUserInfoViewModel : DataManageViewModel
    {
        public ICommand UpdateViewCommand { get; set; }

        public EnterUserInfoViewModel(UserWindowViewModel parentVM)
        {
            UpdateViewCommand = new UpdateViewCommand(parentVM);
        }
    }
}
