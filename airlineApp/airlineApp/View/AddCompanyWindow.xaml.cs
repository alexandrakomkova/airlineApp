
using System.Text.RegularExpressions;
using System.Windows;
using airlineApp.ViewModel;

namespace airlineApp.View
{
    /// <summary>
    /// Логика взаимодействия для AddCompanyWindow.xaml
    /// </summary>
    public partial class AddCompanyWindow : Window
    {
        public AddCompanyWindow()
        {
            InitializeComponent();
            DataContext = new DataManageViewModel();
        }
        private void PreviewTextInputOnlyLetters(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");
           // Regex regex = new Regex("/^([- A-Za-zа-яА-ЯёЁ0-9_@]+)$/");
            
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
