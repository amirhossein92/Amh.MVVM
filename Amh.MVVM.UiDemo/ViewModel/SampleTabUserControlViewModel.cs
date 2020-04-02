using Amh.MVVM.Base.Command;
using Amh.MVVM.Base.ViewModel;
using Amh.MVVM.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amh.MVVM.UiDemo.ViewModel
{
    public class SampleTabUserControlViewModel : MainViewModelBase
    {
        private MyWindowTabService _windowService = new MyWindowTabService();

        public SampleTabUserControlViewModel()
        {
            CurrentUserViewModels = new ObservableCollection<ViewModelBase>();
            CurrentUserViewModels.Add(new SampleListUserControlViewModel());
            CurrentUserViewModels.Add(new SampleAddUserControlViewModel());

            CloseTabCommand = new RelayCommand<ViewModelBase>(OnCloseTab);
            OpenNewTabCommand = new RelayCommand(OnOpenNewTab);
            OpenAnotherTabCommand = new RelayCommand(OnOpenAnotherTab);
        }

        private void OnOpenNewTab()
        {
            _windowService.OpenNewPage<SampleListUserControlViewModel>(null);
        }

        private void OnOpenAnotherTab()
        {
            _windowService.OpenNewPage<SampleDetailUserControlViewModel>(null);
        }

        private void OnCloseTab(ViewModelBase viewModel)
        {
            this.CurrentUserViewModels.Remove(viewModel);
        }

        public RelayCommand<ViewModelBase> CloseTabCommand { get; set; }
        public RelayCommand OpenNewTabCommand { get; set; }
        public RelayCommand OpenAnotherTabCommand { get; set; }

        public override void LoadCommands()
        {
        }

        public override void LoadData()
        {
        }

        public override string SetTitle()
        {
            return "Tabsss";
        }
    }
}
