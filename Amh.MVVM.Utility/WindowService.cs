using Amh.MVVM.Base.ViewModel;
using Amh.MVVM.Base.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Amh.MVVM.Utility
{
    public static class WindowService
    {
        private static MainViewModelBase _mainViewModel;

        public static void SetMainWindowViewModel(MainViewModelBase mainWindowViewModel)
        {
            _mainViewModel = mainWindowViewModel;
        }

        public static void OpenNewPage<T>(ViewModelBase currentViewModel, T viewModel = null) where T : ViewModelBase
        {
            if (viewModel == null)
                viewModel = Activator.CreateInstance<T>();
            if (currentViewModel != null)
                _mainViewModel.LastUserViewModel = currentViewModel;
            _mainViewModel.CurrentUserViewModel = viewModel;
        }

        public static void OpenNewPageWithConstructor<T, Tparameter>(ViewModelBase currentViewModel, Tparameter parameter) where T : ViewModelBase<Tparameter>
        {
            var viewModel = Activator.CreateInstance<T>();
            if (viewModel is ViewModelBase<Tparameter> viewModelConstructor)
                viewModelConstructor.Parameter = parameter;

            if (currentViewModel != null)
                _mainViewModel.LastUserViewModel = currentViewModel;
            _mainViewModel.CurrentUserViewModel = viewModel;
        }

        public static void OpenNewDialogPage<T>(ViewModelBase currentViewModel, T viewModel = null) where T : ViewModelBase
        {
            var resources = Application.Current.MainWindow.Resources;
            var newWindow = new MyDialogWindow();
            newWindow.SizeToContent = SizeToContent.WidthAndHeight;
            newWindow.Resources = resources;
            if (viewModel == null)
                viewModel = Activator.CreateInstance<T>();
            newWindow.Title = viewModel.Title;
            newWindow.Content = viewModel;
            newWindow.ShowDialog();
        }

        public static void OpenNewPageDialogWithConstructor<T, Tparameter>(ViewModelBase currentViewModel, Tparameter parameter) where T : ViewModelBase<Tparameter>
        {
            var resources = Application.Current.MainWindow.Resources;
            var newWindow = new MyDialogWindow();
            newWindow.Resources = resources;
            newWindow.SizeToContent = SizeToContent.WidthAndHeight;
            var viewModel = Activator.CreateInstance<T>();

            if (viewModel is ViewModelBase<Tparameter> viewModelConstructor)
                viewModelConstructor.Parameter = parameter;
            newWindow.Title = viewModel.Title;
            newWindow.Content = viewModel;
            newWindow.ShowDialog();
        }

        public static void ClosePage(ViewModelBase currentViewModel)
        {
            if (currentViewModel != null)
                _mainViewModel.LastUserViewModel = currentViewModel;
            _mainViewModel.CurrentUserViewModel = null;
        }

        public static void CloseDialogPage(ViewModelBase currentViewModel, bool result = false)
        {
            var windows = Application.Current.Windows;
            var window = windows.OfType<MyDialogWindow>().LastOrDefault();
            if (window != null && window.Content.GetType() == currentViewModel.GetType())
                window.Close();
        }
    }
}
