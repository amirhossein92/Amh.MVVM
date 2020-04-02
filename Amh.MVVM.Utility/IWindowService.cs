using Amh.MVVM.Base.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amh.MVVM.Utility
{
    public interface IMyWindowService
    {
        void SetMainWindowViewModel(MainViewModelBase mainWindowViewModel);
        void OpenNewPage<T>(ViewModelBase currentViewModel, T viewModel = null) where T : ViewModelBase;
        void OpenNewPageWithConstructor<T, Tparameter>(ViewModelBase currentViewModel, Tparameter parameter, T viewModel = null) where T : ViewModelBase<Tparameter>;
        void ClosePage(ViewModelBase currentViewModel);

        MainViewModelBase MainViewModel { get; }
    }
}
