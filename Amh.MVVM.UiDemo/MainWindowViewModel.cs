using Amh.MVVM.Base.Command;
using Amh.MVVM.Base.ViewModel;
using Amh.MVVM.UiDemo.Model;
using Amh.MVVM.UiDemo.ViewModel;
using Amh.MVVM.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amh.MVVM.UiDemo
{
    public class MainWindowViewModel : MainViewModelBase
    {
        private MyWindowTabService _tabWindowService = new MyWindowTabService();

        public MainWindowViewModel()
        {
            _tabWindowService.SetMainWindowViewModel(this);
            _tabWindowService.OpenNewPage<SampleListUserControlViewModel>(null);
            //WindowService.SetMainWindowViewModel(this);
            MessagingService<AlertModel>.Subscribe(OnMsgSent);

            OpenNewTabCommand = new RelayCommand(OnOpenNewTab);
            OpenAnotherTabCommand = new RelayCommand(OnOpenAnotherTab);
        }

        public RelayCommand OpenNewTabCommand { get; set; }
        public RelayCommand OpenAnotherTabCommand { get; set; }

        private void OnOpenNewTab()
        {
            _tabWindowService.OpenNewPage<SampleListUserControlViewModel>(null);
        }

        private void OnOpenAnotherTab()
        {
            _tabWindowService.OpenNewPage<SampleDetailUserControlViewModel>(null);
        }

        private void OnMsgSent(AlertModel msg)
        {
            AlertMessage = msg.Message;
            IsAlert = true;
        }

        public override void LoadCommands()
        {
            BackCommand = new RelayCommand(OnBack);
        }

        public RelayCommand BackCommand { get; set; }

        private void OnBack()
        {
            //WindowService.OpenNewPage<SampleListUserControlViewModel>();
            //WindowService.OpenNewPage(CurrentUserViewModel, LastUserViewModel);
        }

        public override void LoadData()
        {
        }

        public override string SetTitle()
        {
            return "Main Window";
        }

        private string _alertMessage;
        public string AlertMessage
        {
            get => _alertMessage;
            set
            {
                _alertMessage = value;
                OnPropertyChanged();
            }
        }

        private bool _isAlert;
        public bool IsAlert
        {
            get => _isAlert;
            set
            {
                _isAlert = value;
                OnPropertyChanged();
            }
        }
    }
}
