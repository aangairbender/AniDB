using System;
using System.Collections.ObjectModel;
using AniDB.Application.UseCases.Tables.Queries.GetTablesList;
using Autofac;
using GalaSoft.MvvmLight;
using MediatR;

namespace AniDB.WpfUI.UI.UserControls.TablesList
{
    public class TablesListViewModel : ViewModelBase
    {
        private readonly IContainer _container;
        private readonly IMediator _mediator;
        private readonly Guid _databaseId;

        private ObservableCollection<TableLookupModel> _tables;
        private TableLookupModel _selectedTable;


        public ObservableCollection<TableLookupModel> Tables
        {
            get => _tables;
            set
            {
                if (_tables == value)
                    return;

                _tables = value;
                RaisePropertyChanged();
            }
        }

        public TableLookupModel SelectedTable
        {
            get => _selectedTable;
            set
            {
                if (_selectedTable == value)
                    return;

                _selectedTable = value;
                RaisePropertyChanged();
            }
        }

        public TablesListViewModel(IContainer container, Guid databaseId)
        {
            _container = container;
            _mediator = _container.Resolve<IMediator>();

            _databaseId = databaseId;

            LoadTables();
        }

        public async void LoadTables()
        {
            var tablesList = await _mediator.Send(new GetTablesListQuery{DatabaseId = _databaseId});

            Tables = new ObservableCollection<TableLookupModel>(tablesList.Tables);
            if (SelectedTable == null || !Tables.Contains(SelectedTable))
                SelectedTable = null;
        }
    }
}
