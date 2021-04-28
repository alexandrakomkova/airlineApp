
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
    }
}
