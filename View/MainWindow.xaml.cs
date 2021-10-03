using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TestForAtomicus.ViewModel;


namespace TestForAtomicus.View
{
    public partial class MainWindow : Window
    {
        public static MainViewModel ViewModel { get; set; }

        public MainWindow()
        {
            ViewModel = new MainViewModel(ColorViewModel.ListOfColors);

            InitializeComponent();

            ItemsSource.ItemsSource = ColorViewModel.ListOfColors;
        }

        dynamic row;

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ListBox dg = sender as ListBox;
                row = dg.SelectedItems[0] as Model.Colors;
            }
            catch { }

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog dlg = new System.Windows.Forms.ColorDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ColorViewModel.AddColor(Color.FromRgb(dlg.Color.R, dlg.Color.G, dlg.Color.B));
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            ColorViewModel.RemoveUser(row);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog dlg = new System.Windows.Forms.ColorDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ColorViewModel.EditColor(row, Color.FromRgb(dlg.Color.R, dlg.Color.G, dlg.Color.B));
            }

        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            ColorViewModel.ArrayToBinary();
        }
    }


}
