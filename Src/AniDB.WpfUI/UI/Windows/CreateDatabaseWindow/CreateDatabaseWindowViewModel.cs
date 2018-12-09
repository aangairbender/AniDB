using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AniDB.Application.UseCases.Databases.Commands.CreateDatabase;
using Autofac;
using FluentValidation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MediatR;

namespace AniDB.WpfUI.UI.Windows.CreateDatabaseWindow
{
    public class CreateDatabaseWindowViewModel : ViewModelBase
    {
        private readonly IContainer _container;
        private readonly IMediator _mediator;

        public string DatabaseName { get; set; }

        public RelayCommand<Window> CreateDatabaseCommand { get; private set; }

        public CreateDatabaseWindowViewModel(IContainer container)
        {
            _container = container;
            _mediator = container.Resolve<IMediator>();

            CreateDatabaseCommand =
                new RelayCommand<Window>(CreateDatabase);
        }

        private async void CreateDatabase(Window window)
        {
            try
            {
                await _mediator.Send(new CreateDatabaseCommand {Name = DatabaseName});
                window.Close();
            }
            catch (ValidationException validationException)
            {
                MessageBox.Show(validationException.Message);
            }
            catch (DatabaseWithSameNameExistsException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
