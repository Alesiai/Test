using System.Windows.Media;
using TestForAtomicus.DataActions;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.ComponentModel;
using TestForAtomicus.Model;

namespace TestForAtomicus.ViewModel
{
    public class ColorViewModel : ViewModelBase
    {
        public Model.Colors Colors
        {
            get; set;
        }

        public ColorViewModel(Model.Colors color)
        {
            this.Colors = color;
        }

        public Color ColorName
        {
            get { return Colors.ColorName; }
            set
            {
                Colors.ColorName = value;
                OnPropertyChanged("UserName");
            }
        }

        static ICollectionView collectionView;
        public static ICollectionView CV
        {
            get => collectionView;
            set
            {
                collectionView = value;

            }
        }

        public static ObservableCollection<Model.Colors> ListOfColors = new ObservableCollection<Model.Colors>();
        public static void ColorInit()
        {
            ListOfColors = TakeData.TakeColorsFromBinary();
            CV = CollectionViewSource.GetDefaultView(ListOfColors);
        }

        public static void AddColor(Color color)
        {
            Model.Colors NewColor = new Model.Colors();
            NewColor.ColorName = color;
            ListOfColors.Add(NewColor);

            ArrayToBinary();
        }

        public static void RemoveUser(Model.Colors RemoveColor)
        {
            ListOfColors.Remove(RemoveColor);

            ArrayToBinary();
        }

        public static void EditColor(Model.Colors EditUser, Color color)
        {
            EditUser.ColorName = color;

            ArrayToBinary();
        }

        public static void ArrayToBinary()
        {
            TakeData.SendColorsToBinary(ListOfColors);
        }
    }
}
