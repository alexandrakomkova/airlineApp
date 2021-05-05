using System.Windows;
using System.Windows.Controls;
using airlineApp.ViewModel;

namespace airlineApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public static ListView AllFlightsView;
        //public static ListView AllCompaniesView;

        public MainWindow()
        {
            InitializeComponent();
            
            //AllFlightsView = ViewAllFlights;
            DataContext = new MainWindowViewModel();
        }
    }
}
