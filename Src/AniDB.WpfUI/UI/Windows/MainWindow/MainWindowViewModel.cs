using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AniDB.WpfUI.UserControls.DatabasesList;
using Autofac;
using GalaSoft.MvvmLight;

namespace AniDB.WpfUI.UI.Windows.MainWindow
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IContainer _container;

        public DatabasesListViewModel DatabasesListViewModel { get; }

        public MainWindowViewModel(IContainer container)
        {
            _container = container;

            DatabasesListViewModel = new DatabasesListViewModel(_container);
            
        }
    }
}
