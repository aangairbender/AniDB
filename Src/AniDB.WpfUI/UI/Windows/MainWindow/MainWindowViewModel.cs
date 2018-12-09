using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AniDB.WpfUI.UI.Windows.CreateDatabaseWindow;
using AniDB.WpfUI.UserControls.DatabasesList;
using Autofac;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AniDB.WpfUI.UI.Windows.MainWindow
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IContainer _container;

        public DatabasesListViewModel DatabasesListViewModel { get; }

        public RelayCommand CreateNewDatabase { get; private set; }

        public MainWindowViewModel(IContainer container)
        {
            _container = container;

            DatabasesListViewModel = new DatabasesListViewModel(_container);
            
            CreateNewDatabase = new RelayCommand(ShowCreateDatabaseWindow);
        }

        private void ShowCreateDatabaseWindow()
        {
            var createDatabaseWindow = new CreateDatabaseWindow.CreateDatabaseWindow();
            createDatabaseWindow.DataContext = new CreateDatabaseWindowViewModel(_container);
            createDatabaseWindow.ShowDialog();
            DatabasesListViewModel.LoadDatabases();
        }
    }
}
