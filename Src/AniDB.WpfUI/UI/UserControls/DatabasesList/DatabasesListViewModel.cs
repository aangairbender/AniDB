using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AniDB.Application.UseCases.Databases.Commands.CreateDatabase;
using AniDB.Application.UseCases.Databases.Queries.GetDatabasesList;
using Autofac;
using Autofac.Core;
using GalaSoft.MvvmLight;
using MediatR;

namespace AniDB.WpfUI.UserControls.DatabasesList
{
    public class DatabasesListViewModel : ViewModelBase
    {
        private readonly IContainer _container;
        private readonly IMediator _mediator;


        private ObservableCollection<DatabaseLookupModel> _databases;
        private DatabaseLookupModel _selectedDatabase;

        public ObservableCollection<DatabaseLookupModel> Databases
        {
            get => _databases;
            set
            {
                if (_databases == value)
                    return;
                
                _databases = value;
                RaisePropertyChanged();
            }
        }

        public DatabaseLookupModel SelectedDatabase
        {
            get => _selectedDatabase;
            set
            {
                if (_selectedDatabase == value)
                    return;

                _selectedDatabase = value;
                RaisePropertyChanged();
            }
        }

        public DatabasesListViewModel(IContainer container)
        {
            _container = container;
            _mediator = _container.Resolve<IMediator>();
            
            LoadDatabases();
        }

        public async void LoadDatabases()
        {
            var databasesList = await _mediator.Send(new GetDatabasesListQuery());

            Databases = new ObservableCollection<DatabaseLookupModel>(databasesList.Databases);
            if (SelectedDatabase == null || !Databases.Contains(SelectedDatabase))
                SelectedDatabase = null;
        }
    }
}
