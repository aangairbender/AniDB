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

namespace AniDB.WpfUI.UI.UserControls.TableData
{
    public class TableDataViewModel : ViewModelBase
    {
        private readonly IContainer _container;
        private readonly IMediator _mediator;
        private readonly Guid _tableId;

        private DataTable _data;

        public DataTable Data
        {
            get => _data;
            set
            {
                if (_data == value)
                    return;
                _data = value;
                RaisePropertyChanged();
            }
        }

        public TableDataViewModel(IContainer container, Guid tableId)
        {
            _container = container;
            _mediator = container.Resolve<IMediator>();

            _tableId = tableId;
            
            LoadTableData();
        }

        private async void LoadTableData()
        {
            var tableSchema = await _mediator.Send(new GetTableSchemaQuery { TableId = _tableId });
            var tableData = await _mediator.Send(new GetTableDataQuery { TableId = _tableId });
            var data = new DataTable();
            foreach (var schemaColumn in tableSchema.Schema.Columns)
            {
                data.Columns.Add(schemaColumn.Name);
            }

            foreach (var tableRow in tableData.Data)
            {
                data.Rows.Add(tableRow.Values.Select(x => (object)x.ToString()).ToArray());
            }

            Data = data;
        }
    }
}
