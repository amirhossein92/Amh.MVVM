using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Amh.MVVM.Base.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase()
        {
            Title = SetTitle();
            LoadCommands();
        }

        public abstract string SetTitle();
        public abstract void LoadCommands();
        public abstract void LoadData();

        private string _title;
        public string Title
        {
            get => _title; set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public abstract class ViewModelBase<T> : ViewModelBase
    {
        private T _parameter;
        public T Parameter
        {
            get => _parameter; set
            {
                _parameter = value;
                OnPropertyChanged();
            }
        }
    }
}
