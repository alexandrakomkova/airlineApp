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
    /// Логика взаимодействия для EditCompanyWindow.xaml
    /// </summary>
    public partial class EditCompanyWindow : Window
    {
        public EditCompanyWindow(Company companyToEdit)
        {
            InitializeComponent();
            DataContext = new DataManageViewModel();
            //DataManageViewModel.SelectedCompany = companyToEdit;
            //DataManageViewModel.CompanyName = companyToEdit.Name;
            //DataManageViewModel.CompanyLogo = companyToEdit.Logo;
          
        }
        private void PreviewTextInputOnlyLetters(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");
            // Regex regex = new Regex("/^([- A-Za-zа-яА-ЯёЁ0-9_@]+)$/");

            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
