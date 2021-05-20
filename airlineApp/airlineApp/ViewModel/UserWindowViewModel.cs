using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using airlineApp.Commands;
using airlineApp.Model;
using airlineApp.Model.Data;
using airlineApp.View;

namespace airlineApp.ViewModel
{
    public class UserWindowViewModel : DataManageViewModel
    {
        private readonly User user;
        public ICommand UpdateViewCommand;

        public UserWindowViewModel(User user)
        {
            this.user = user;
           
            UpdateViewCommand = new UpdateViewCommand(this);
            currentPage = new ChooseTicketViewModel(this, user, null);
        }
        private DataManageViewModel currentPage;
        public DataManageViewModel CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                NotifyPropertyChanged(nameof(CurrentPage));
                
            }
        }
        public static Way UserFlightDeparture { get; set; }
        public static Way UserFlightArrival { get; set; }
       
       
        public static DateTime SelectedDepartureDate { get; set; }
        
        
        private Command viewUserTicketCommand;
        public Command ViewUserTicketCommand
        {
            get
            {
                return viewUserTicketCommand ?? new Command(
                    obj =>
                    {
                        CurrentPage = new UserViewTicketViewModel(this, null, user);
                        
                    }
                    );
            }
        }
        private Command searchUserTicketCommand;
        public Command SearchUserTicketCommand
        {
            get
            {
                return searchUserTicketCommand ?? new Command(
                    obj =>
                    {
                        CurrentPage = new ChooseTicketViewModel(this, user, null);
                        
                    }
                    );
            }
        }
        
       
       
        private Command changeAccountWndCommand;
        public Command ChangeAccountWndCommand
        {
            get
            {
                return changeAccountWndCommand ?? new Command(
                    obj =>
                    {
                        
                        LoginRegisterWindow loginWindow = new LoginRegisterWindow();
                        loginWindow.Show();
                        (obj as Window).Close();

                    }
                    );
            }
        }


    }
}

