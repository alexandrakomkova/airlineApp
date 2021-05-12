using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using airlineApp.Model;
using airlineApp.ViewModel;

namespace airlineApp.View
{
    /// <summary>
    /// Логика взаимодействия для ViewAllFlightsPage.xaml
    /// </summary>
    public partial class ViewAllFlightsPage : UserControl
    {
        public static ListView AllFlightsView;

        public ViewAllFlightsPage()
        {
            InitializeComponent();
            AllFlightsView = ViewAllFlights;
            DataContext = new MainWindowViewModel();

        }
        //public static ListView AllFlightsView;
        //private User user;

        //public ViewAllFlightsPage(User user)
        //{
        //    this.user = user;
        //    InitializeComponent();
        //    AllFlightsView = ViewAllFlights;
        //    DataContext = new MainWindowViewModel(user);

        //}
    }
}
