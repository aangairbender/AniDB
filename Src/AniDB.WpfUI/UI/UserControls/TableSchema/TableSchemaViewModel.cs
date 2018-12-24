using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AniDB.Application.UseCases.Tables.Queries.GetTableData;
using AniDB.Application.UseCases.Tables.Queries.GetTableSchema;
using AniDB.Domain.Entities;
using Autofac;
using GalaSoft.MvvmLight;
using MediatR;

namespace AniDB.WpfUI.UI.UserControls.TableSchema
{
    public class TableSchemaViewModel : ViewModelBase
    {
        private readonly IContainer _container;
        private readonly IMediator _mediator;
        private readonly Guid _tableId;

        private ObservableCollection<TableColumn> _columns;

        public ObservableCollection<TableColumn> Columns
        {
            get => _columns;
            set
            {
                if (_columns == value)
                    return;
                _columns = value;
                RaisePropertyChanged();
            }
        }

        public TableSchemaViewModel(IContainer container, Guid tableId)
        {
            _container = container;
            _mediator = container.Resolve<IMediator>();

            _tableId = tableId;

            LoadTableSchema();
        }

        private async void LoadTableSchema()
        {
            var tableSchema = await _mediator.Send(new GetTableSchemaQuery { TableId = _tableId });
            Columns = new ObservableCollection<TableColumn>(tableSchema.Schema.Columns);
        }
    }
}
