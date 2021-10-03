using System.Windows;
using TestForAtomicus.ViewModel;
using TestForAtomicus.View;

namespace TestForAtomicus
{
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            ColorViewModel.ColorInit();

            var window = new MainWindow();
            window.Show();
        }
    }
}
