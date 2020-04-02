using Amh.MVVM.Base.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amh.MVVM.Utility
{
    public class MyWindowTabService : IMyWindowService
    {
        private static MainViewModelBase _mainViewModel;
        public MainViewModelBase MainViewModel { get => _mainViewModel; }

        public void SetMainWindowViewModel(MainViewModelBase mainWindowViewModel)
        {
            _mainViewModel = mainWindowViewModel;
        }

        public void ClosePage(ViewModelBase currentViewModel)
        {
            _mainViewModel.CurrentUserViewModels.Remove(currentViewModel);
        }

        public void OpenNewPage<T>(ViewModelBase currentViewModel, T viewModel = null) where T : ViewModelBase
        {
            if (viewModel == null)
                viewModel = Activator.CreateInstance<T>();

            _mainViewModel.CurrentUserViewModels.Add(viewModel);
        }

        public void OpenNewPageWithConstructor<T, Tparameter>(ViewModelBase currentViewModel, Tparameter parameter, T viewModel = null) where T : ViewModelBase<Tparameter>
        {
            if (viewModel == null)
                viewModel = Activator.CreateInstance<T>();

            _mainViewModel.CurrentUserViewModels.Add(viewModel);
        }
    }
}
