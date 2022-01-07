using _03_EntityFramework_WPF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_EntityFramework_WPF.Models.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        private object _currentView;

        public MainViewModel()
        {
            UserViewModel = new UserViewModel();
            NewUserViewModel = new NewUserViewModel();
            CurrentView = UserViewModel;

            UserViewCommand = new RelayCommand(x => CurrentView = UserViewModel);
            NewUserViewCommand = new RelayCommand(x => CurrentView = NewUserViewModel);
        }

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand UserViewCommand { get; set; }
        public UserViewModel UserViewModel { get; set; }

        public RelayCommand NewUserViewCommand { get; set; }
        public NewUserViewModel NewUserViewModel { get; set; }


    }
}
