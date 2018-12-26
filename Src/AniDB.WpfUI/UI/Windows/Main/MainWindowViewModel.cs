using System.IO;
using AniDB.Application.UseCases.Databases.Commands.LoadSerializedDatabase;
using AniDB.Application.UseCases.Databases.Queries.GetSerializedDatabase;
using AniDB.WpfUI.UI.Windows.CreateDatabase;
using AniDB.WpfUI.UI.Windows.OperateDatabase;
using AniDB.WpfUI.UserControls.DatabasesList;
using Autofac;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MediatR;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace AniDB.WpfUI.UI.Windows.Main
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IContainer _container;
        private readonly IMediator _mediator;

        public DatabasesListViewModel DatabasesListViewModel { get; }

        public RelayCommand CreateNewDatabase { get; private set; }

        public RelayCommand OperateDatabase { get; private set; }

        public RelayCommand SaveDatabase { get; private set; }

        public RelayCommand LoadDatabase { get; private set; }

        public MainWindowViewModel(IContainer container)
        {
            _container = container;
            _mediator = _container.Resolve<IMediator>();

            DatabasesListViewModel = new DatabasesListViewModel(_container);
            
            CreateNewDatabase = new RelayCommand(ShowCreateDatabaseWindow);

            OperateDatabase = new RelayCommand(ShowOperateDatabaseWindow, () => DatabasesListViewModel.SelectedDatabase != null);
            SaveDatabase = new RelayCommand(SaveDatabaseMethod, () => DatabasesListViewModel.SelectedDatabase != null);
            LoadDatabase = new RelayCommand(LoadDatabaseMethod);

            DatabasesListViewModel.PropertyChanged += DatabasesListViewModelPropertyChangedHandler;
        }

        private async void SaveDatabaseMethod()
        {
            var id = DatabasesListViewModel.SelectedDatabase.Id;
            var serializedDatabase = await _mediator.Send(new GetSerializedDatabaseQuery { DatabaseId = id });

            var saveFileDialog = new SaveFileDialog();

            bool? result = saveFileDialog.ShowDialog();

            if (result == true)
            {
                string filename = saveFileDialog.FileName;
                File.WriteAllText(filename, serializedDatabase);
            }
        }

        private async void LoadDatabaseMethod()
        {
            var loadFileDialog = new OpenFileDialog();

            bool? result = loadFileDialog.ShowDialog();

            if (result == true)
            {
                string filename = loadFileDialog.FileName;
                string content = File.ReadAllText(filename);
                await _mediator.Send(new LoadSerializedDatabaseCommand {Content = content});
                DatabasesListViewModel.LoadDatabases();
            }
        }

        private void DatabasesListViewModelPropertyChangedHandler(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(DatabasesListViewModel.SelectedDatabase))
            {
                OperateDatabase.RaiseCanExecuteChanged();
                SaveDatabase.RaiseCanExecuteChanged();
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
                    new OperateDatabaseWindowViewModel(_container,
                        DatabasesListViewModel.SelectedDatabase.Id,
                        DatabasesListViewModel.SelectedDatabase.Name)
            };
            operateDatabaseWindow.Show();
        }
    }
}
