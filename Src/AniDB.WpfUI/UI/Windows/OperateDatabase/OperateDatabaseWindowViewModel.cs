using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AniDB.Application.UseCases.Databases.Commands.CreateDatabase;
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

        public string DatabaseName { get; set; }

        public OperateDatabaseWindowViewModel(IContainer container, Guid databaseId)
        {
            _container = container;
            _mediator = container.Resolve<IMediator>();
            _databaseId = databaseId;
        }
    }
}
