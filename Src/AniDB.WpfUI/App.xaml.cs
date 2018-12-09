using System.Windows;
using AniDB.WpfUI.UI.Windows.MainWindow;

namespace AniDB.WpfUI
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var container = WpfUI.Startup.ConfigureAutofac();

            var mainWindow = new MainWindow();
            mainWindow.DataContext = new MainWindowViewModel(container);
            mainWindow.Show();
        }
    }
}
