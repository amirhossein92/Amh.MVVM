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
        private static ObservableCollection<ViewModelBase> _currentUserViewModels = new ObservableCollection<ViewModelBase>();
        public ObservableCollection<ViewModelBase> CurrentUserViewModels
        {
            get => _currentUserViewModels;
            set
            {
                _currentUserViewModels = value;
                OnPropertyChanged();
            }
        }

        public static int _currentUserViewModelIndex;
        public int CurrentUserViewModelIndex
        {
            get => _currentUserViewModelIndex;
            set
            {
                _currentUserViewModelIndex = value;
                OnPropertyChanged();
            }
        }
    }
}
