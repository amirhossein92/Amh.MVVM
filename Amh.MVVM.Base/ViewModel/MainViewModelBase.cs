using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amh.MVVM.Base.ViewModel
{
    public abstract class MainViewModelBase : ViewModelBase
    {

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
