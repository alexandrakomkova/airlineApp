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
using System.Windows.Navigation;
using System.Windows.Shapes;
using airlineApp.ViewModel;

namespace airlineApp.View
{
    /// <summary>
    /// Логика взаимодействия для EnterUserInfo.xaml
    /// </summary>
    public partial class EnterUserInfo : UserControl
    {
        public EnterUserInfo()
        {
            InitializeComponent();
           
        }
        private void PreviewTextInputOnlyLetters(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            
            Regex regex = new Regex("^[^a-zA-ZА-Яа-я]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void PreviewTextInputPassport(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[A-Z]{2}[0-9]{7}$");

            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
