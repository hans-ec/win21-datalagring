using _00_EntityFramework_WPF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_EntityFramework_WPF.Models.ViewModels
{
    internal class MainWindowViewModel : ObservableObject
    {       
        public RelayCommand CustomersViewCommand { get; set; }
        public RelayCommand CreateCustomerViewCommand { get; set; }
        public CustomersViewModel CustomersViewModel { get; set; }
        public CreateCustomerViewModel CreateCustomerViewModel { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            CustomersViewModel = new CustomersViewModel();
            CreateCustomerViewModel = new CreateCustomerViewModel();
            CurrentView = CustomersViewModel;

            CustomersViewCommand = new RelayCommand(x => CurrentView = CustomersViewModel);
            CreateCustomerViewCommand = new RelayCommand(x => CurrentView = CreateCustomerViewModel);
        }
    }
}
