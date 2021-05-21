using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using airlineApp.Commands;
using airlineApp.Model;
using airlineApp.View;

namespace airlineApp.ViewModel
{
    public class MainWindowViewModel : DataManageViewModel
    {
        public ICommand UpdateViewCommand { get; set; }

        public MainWindowViewModel()
        {
            App.LanguageChanged += LanguageChanged;
            CultureInfo currLang = App.Language;
            UpdateViewCommand = new UpdateViewCommand(this);
            
           
        }
        private void LanguageChanged(Object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;
        }


        private DataManageViewModel currentList = new ViewAllFlightsPageViewModel();
        public DataManageViewModel CurrentList
        {
            get { return currentList; }
            set
            {
                currentList = value;
                NotifyPropertyChanged("CurrentList");

            }
        }

        public void UpdateCompanies()
        {
            AllCompanies = DataWorker.GetAllCompanies();
            NotifyPropertyChanged(nameof(AllCompanies));
        }
        public void UpdateFlights()
        {
            AllFlights = DataWorker.GetAllFlights();
            NotifyPropertyChanged(nameof(AllFlights));

        }
        public void UpdateTickets()
        {

            AllTickets = DataWorker.GetAllTickets();
            NotifyPropertyChanged(nameof(AllTickets));
        }
        private int selectedLanguage;
        public int SelectedLanguage 
        { 
           get 
           {
                return selectedLanguage;
           }
           set 
           {
                selectedLanguage = value;
                if (selectedLanguage == 0)
                {
                    CultureInfo lang = new CultureInfo("ru-RU");
                    App.Language = lang;


                }
                if (selectedLanguage == 1)
                {
                    CultureInfo lang = new CultureInfo("en-US");
                    App.Language = lang;


                }
                NotifyPropertyChanged(nameof(SelectedLanguage));
           } 
        }
        

    }
}
