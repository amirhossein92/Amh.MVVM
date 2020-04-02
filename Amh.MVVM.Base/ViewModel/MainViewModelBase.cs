using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amh.MVVM.Base.ViewModel
{
    public abstract class MainViewModelBase : ViewModelBase
    {
        public MainViewModelBase()
        {
            CurrentUserViewModels = new ObservableCollection<ViewModelBase>();
        }

        private static ObservableCollection<ViewModelBase> _currentUserViewModels;
        public ObservableCollection<ViewModelBase> CurrentUserViewModels
        {
            get => _currentUserViewModels;
            set
            {
                _currentUserViewModels = value;
                OnPropertyChanged();
            }
        }

        private ViewModelBase _currentUserViewModel;
        public ViewModelBase CurrentUserViewModel
        {
            get => _currentUserViewModel;
            set
            {
                _currentUserViewModel = value;
                OnPropertyChanged();
            }
        }

        private ViewModelBase _lastUserViewModel;
        public ViewModelBase LastUserViewModel
        {
            get => _lastUserViewModel;
            set
            {
                _lastUserViewModel = value;
                OnPropertyChanged();
            }
        }
    }
}
