using AniDB.WpfUI.UI.Windows.CreateDatabase;
using AniDB.WpfUI.UI.Windows.OperateDatabase;
using AniDB.WpfUI.UserControls.DatabasesList;
using Autofac;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AniDB.WpfUI.UI.Windows.Main
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IContainer _container;

        public DatabasesListViewModel DatabasesListViewModel { get; }

        public RelayCommand CreateNewDatabase { get; private set; }

        public RelayCommand OperateDatabase { get; private set; }

        public MainWindowViewModel(IContainer container)
        {
            _container = container;

            DatabasesListViewModel = new DatabasesListViewModel(_container);
            
            CreateNewDatabase = new RelayCommand(ShowCreateDatabaseWindow);

            OperateDatabase = new RelayCommand(ShowOperateDatabaseWindow, () => DatabasesListViewModel.SelectedDatabase != null);

            DatabasesListViewModel.PropertyChanged += DatabasesListViewModelPropertyChangedHandler;
        }

        private void DatabasesListViewModelPropertyChangedHandler(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(DatabasesListViewModel.SelectedDatabase))
            {
                OperateDatabase.RaiseCanExecuteChanged();
            }
        }

        private void ShowCreateDatabaseWindow()
        {
            var createDatabaseWindow = new CreateDatabaseWindow
            {
                DataContext = new CreateDatabaseWindowViewModel(_container)
            };
            createDatabaseWindow.ShowDialog();
            DatabasesListViewModel.LoadDatabases();
        }

        private void ShowOperateDatabaseWindow()
        {
            var operateDatabaseWindow = new OperateDatabaseWindow
            {
                DataContext =
                    new OperateDatabaseWindowViewModel(_container, DatabasesListViewModel.SelectedDatabase.Id)
            };
            operateDatabaseWindow.Show();
        }
    }
}
