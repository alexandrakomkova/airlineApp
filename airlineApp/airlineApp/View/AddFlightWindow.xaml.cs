
using System.Text.RegularExpressions;
using System.Windows;
using airlineApp.ViewModel;

namespace airlineApp.View
{
    /// <summary>
    /// Логика взаимодействия для AddFlightWindow.xaml
    /// </summary>
    public partial class AddFlightWindow : Window
    {
        public AddFlightWindow()
        {
            InitializeComponent();
            DataContext= new DataManageViewModel();
        }
        private void PreviewTextInputOnlyNumbers(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            
            //Regex regex = new Regex("^([A-Z]{2}[0-9]{7})$");
            //Regex regex = new Regex("^[^a-zA-ZА-Яа-я]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
