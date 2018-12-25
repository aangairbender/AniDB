using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AniDB.Application.UseCases.Databases.Commands.CreateDatabase;
using AniDB.Application.UseCases.Databases.Queries.GetSerializedDatabase;
using AniDB.Application.UseCases.Tables.Commands.DeleteTable;
using AniDB.WpfUI.UI.UserControls.TableData;
using AniDB.WpfUI.UI.UserControls.TablesList;
using AniDB.WpfUI.UI.UserControls.TableSchema;
using AniDB.WpfUI.UI.Windows.CreateTable;
using Autofac;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MediatR;
using Microsoft.Win32;

namespace AniDB.WpfUI.UI.Windows.OperateDatabase
{
    class OperateDatabaseWindowViewModel : ViewModelBase
    {
        private readonly IContainer _container;
        private readonly IMediator _mediator;

        private readonly Guid _databaseId;

        private TableDataViewModel _tableDataViewModel;
        private TableSchemaViewModel _tableSchemaViewModel;

        public string DatabaseName { get; set; }

        public TablesListViewModel TablesListViewModel { get; }

        public TableDataViewModel TableDataViewModel
        {
            get => _tableDataViewModel;
            set
            {
                if (_tableDataViewModel == value)
                    return;
                _tableDataViewModel = value;
                RaisePropertyChanged();
            }
        }

        public TableSchemaViewModel TableSchemaViewModel
        {
            get => _tableSchemaViewModel;
            set
            {
                if (_tableSchemaViewModel == value)
                    return;
                _tableSchemaViewModel = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand CreateNewTable { get; private set; }

        public RelayCommand DeleteTable { get; private set; }

        public OperateDatabaseWindowViewModel(IContainer container, Guid databaseId, string databaseName)
        {
            _container = container;
            _mediator = container.Resolve<IMediator>();
            _databaseId = databaseId;
            DatabaseName = databaseName;
            TablesListViewModel = new TablesListViewModel(container, databaseId);
            TablesListViewModel.PropertyChanged += TablesListViewModel_PropertyChanged;

            CreateNewTable = new RelayCommand(ShowCreateTableWindow);
            DeleteTable = new RelayCommand(DeleteTableMethod, () => TablesListViewModel.SelectedTable != null);
        }

        private void ShowCreateTableWindow()
        {
            var createDatabaseWindow = new CreateTableWindow
            {
                DataContext = new CreateTableWindowViewModel(_container, _databaseId)
            };
            createDatabaseWindow.ShowDialog();
            TablesListViewModel.LoadTables();
        }

        private async void DeleteTableMethod()
        {
            var id = TablesListViewModel.SelectedTable.Id;
            await _mediator.Send(new DeleteTableCommand{TableId = id});
            TablesListViewModel.LoadTables();
        }

        private void TablesListViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(TablesListViewModel.SelectedTable))
            {
                DeleteTable.RaiseCanExecuteChanged();
                if (TablesListViewModel.SelectedTable != null)
                {
                    TableDataViewModel = new TableDataViewModel(_container, TablesListViewModel.SelectedTable.Id);
                    TableSchemaViewModel = new TableSchemaViewModel(_container, TablesListViewModel.SelectedTable.Id);
                }
                else
                {
                    TableDataViewModel = null;
                    TableSchemaViewModel = null;
                }
            }
        }
    }
}
