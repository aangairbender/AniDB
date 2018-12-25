using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AniDB.Application.UseCases.Databases.Commands.CreateDatabase;
using AniDB.Application.UseCases.Tables.Commands.CreateTable;
using AniDB.Domain.Entities;
using AniDB.Domain.ValueObjects;
using Autofac;
using FluentValidation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MediatR;

namespace AniDB.WpfUI.UI.Windows.CreateTable
{
    public class CreateTableWindowViewModel : ViewModelBase
    {
        private readonly IContainer _container;
        private readonly IMediator _mediator;

        private readonly Guid _databaseId;

        public string TableName { get; set; }

        public RelayCommand<Window> FinishCommand { get; private set; }
        public RelayCommand AddColumnCommand { get; private set; }

        public ObservableCollection<TableColumnModel> Columns { get; set; }

        public CreateTableWindowViewModel(IContainer container, Guid databaseId)
        {
            _container = container;
            _mediator = container.Resolve<IMediator>();

            _databaseId = databaseId;

            FinishCommand =
                new RelayCommand<Window>(CreateTable);

            AddColumnCommand = new RelayCommand(AddNewColumn);

            Columns = new ObservableCollection<TableColumnModel>();
        }

        private async void CreateTable(Window window)
        {
            try
            {
                await _mediator.Send(new CreateTableCommand
                {
                    Name = TableName,
                    DatabaseId = _databaseId,
                    Columns = Columns.ToDictionary(x=>x.Name, x => TableValue.SupportedTypes.First(kvp => kvp.Value.Equals(x.Type)).Key)
                });
                window.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void AddNewColumn()
        {
            Columns.Add(new TableColumnModel());
        }
    }
}
