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
using airlineApp.ViewModel;

namespace airlineApp.View
{
    /// <summary>
    /// Логика взаимодействия для LoginRegisterWindow.xaml
    /// </summary>
    public partial class LoginRegisterWindow : Window
    {
        public LoginRegisterWindow()
        {
            InitializeComponent();
            DataContext = new DataManageViewModel();
        }
        private void PreviewTextInputEmail(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            // Regex regex = new Regex("/^([- A-Za-zа-яА-ЯёЁ0-9_@]+)$/");

            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
