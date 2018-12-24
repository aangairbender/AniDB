using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AniDB.Application.UseCases.Databases.Commands.CreateDatabase;
using AniDB.WpfUI.UI.UserControls.TableData;
using AniDB.WpfUI.UI.UserControls.TablesList;
using AniDB.WpfUI.UI.UserControls.TableSchema;
using Autofac;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MediatR;

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

        public OperateDatabaseWindowViewModel(IContainer container, Guid databaseId, string databaseName)
        {
            _container = container;
            _mediator = container.Resolve<IMediator>();
            _databaseId = databaseId;
            DatabaseName = databaseName;
            TablesListViewModel = new TablesListViewModel(container, databaseId);
            TablesListViewModel.PropertyChanged += TablesListViewModel_PropertyChanged;
        }

        private void TablesListViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(TablesListViewModel.SelectedTable))
            {
                TableDataViewModel = new TableDataViewModel(_container, TablesListViewModel.SelectedTable.Id);
                TableSchemaViewModel = new TableSchemaViewModel(_container, TablesListViewModel.SelectedTable.Id);
            }
        }
    }
}
