using System.Linq;
using System.Collections.ObjectModel;
using TestForAtomicus.Model;

namespace TestForAtomicus.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<ColorViewModel> ColorsList { get; set; }

        public MainViewModel(ObservableCollection<Colors> color)
        {
            ColorsList = new ObservableCollection<ColorViewModel>(color.Select(e => new ColorViewModel(e)));
        }

    }
}