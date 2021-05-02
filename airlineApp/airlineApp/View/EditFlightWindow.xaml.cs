using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using airlineApp.Model;
using airlineApp.ViewModel;

namespace airlineApp.View
{
    /// <summary>
    /// Логика взаимодействия для EditFlightWindow.xaml
    /// </summary>
    public partial class EditFlightWindow : Window
    {
        public EditFlightWindow(Flight flightToEdit)
        {
            InitializeComponent();
            DataContext = new DataManageViewModel();
            DataManageViewModel.SelectedFlight = flightToEdit;
           // DataManageViewModel.FlightCompany = flightToEdit.Company;
            DataManageViewModel.FlightPrice = flightToEdit.Price;
           // DataManageViewModel.FlightWay = flightToEdit.Way;
          //  DataManageViewModel.FlightAllPlaces = flightToEdit.AllPlaces;

        }
        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
