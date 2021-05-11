using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using airlineApp.Commands;

namespace airlineApp.ViewModel
{
    public class GetPlaceViewModel : DataManageViewModel
    {
        public ICommand UpdateViewCommand { get; set; }

        //  private static DataManageViewModel model;
        private List<string> placesList { get; set; }//= MakeSchemaOfPlaces(UserSelectedFlight);

        public List<string> List //= MakeSchemaOfPlaces(UserSelectedFlight);
        {
            get { return placesList; }
            set
            {
                placesList = value;
                NotifyPropertyChanged("PlacesList");
            }
        }
        public GetPlaceViewModel(UserWindowViewModel parentVM, List<string> list)
        {
            UpdateViewCommand = new UpdateViewCommand(parentVM, list);
            List = list;
            NotifyPropertyChanged("List");
            //model = dataManageViewModel;
        }
        //public static DataManageViewModel Model
        //{
        //    get { return model; }
        //    set
        //    {
        //        model = value;
        //       // NotifyPropertyChanged(nameof(Model));
        //    }
        //}
        //public new List<string> PlacesList = Model.PlacesList;
    }
}
