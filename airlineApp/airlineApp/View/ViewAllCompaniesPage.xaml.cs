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
    /// Логика взаимодействия для ViewAllCompaniesPage.xaml
    /// </summary>
    public partial class ViewAllCompaniesPage : UserControl
    {
        public static ListView AllCompaniesView;
        public ViewAllCompaniesPage()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            AllCompaniesView = ViewAllCompanies;
        }
        //public static ListView AllCompaniesView;
        //private User user;

        //public ViewAllCompaniesPage()
        //{
        //    InitializeComponent();
        //    DataContext = new MainWindowViewModel(user);
        //    AllCompaniesView = ViewAllCompanies;
        //}
    }
}
