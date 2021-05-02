using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airlineApp.ViewModel
{
    public class UserWindowViewModel : DataManageViewModel
    {
        
        private DataManageViewModel currentPage = new FindTicketViewModel();
        public DataManageViewModel CurrentPage
        {
            get { return currentPage; }
            set 
            { 
                currentPage = value;
                NotifyPropertyChanged("CurrentPage");
            }
        }
       
    }
}
