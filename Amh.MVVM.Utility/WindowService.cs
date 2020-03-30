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
            viewModel = CreateInstance(viewModel);
            SetCurrentViewModel(currentViewModel, viewModel);
        }

        public static void OpenNewPageWithConstructor<T, Tparameter>(ViewModelBase currentViewModel, Tparameter parameter, T viewModel = null) where T : ViewModelBase<Tparameter>
        {
            viewModel = CreateInstance(viewModel);
            PassParameter(viewModel, parameter);
            SetCurrentViewModel(currentViewModel, viewModel);
        }

        public static void OpenNewDialogPage<T>(ViewModelBase currentViewModel, T viewModel = null) where T : ViewModelBase
        {
            var newWindow = CreateDialogWindow();
            viewModel = CreateInstance(viewModel);
            SetDialogWindowProperties(newWindow, viewModel);
            newWindow.ShowDialog();
        }

        public static void OpenNewPageDialogWithConstructor<T, Tparameter>(ViewModelBase currentViewModel, Tparameter parameter, T viewModel = null) where T : ViewModelBase<Tparameter>
        {
            var newWindow = CreateDialogWindow();
            viewModel = CreateInstance(viewModel);
            PassParameter(viewModel, parameter);
            SetDialogWindowProperties(newWindow, viewModel);
            newWindow.ShowDialog();
        }

        public static void ClosePage(ViewModelBase currentViewModel)
        {
            SetCurrentViewModel<ViewModelBase>(currentViewModel, null);
        }

        public static void CloseDialogPage(ViewModelBase currentViewModel, bool result = false)
        {
            var windows = Application.Current.Windows;
            var window = windows.OfType<MyDialogWindow>().LastOrDefault();
            if (window != null && window.Content.GetType() == currentViewModel.GetType())
                window.Close();
        }

        private static T CreateInstance<T>(T viewModel) where T : ViewModelBase
        {
            if (viewModel == null)
                viewModel = Activator.CreateInstance<T>();
            return viewModel;
        }

        private static void SetCurrentViewModel<T>(ViewModelBase currentViewModel, T viewModel) where T : ViewModelBase
        {
            if (currentViewModel != null)
                _mainViewModel.LastUserViewModel = currentViewModel;
            _mainViewModel.CurrentUserViewModel = viewModel;
        }

        private static void PassParameter<T, Tparameter>(T viewModel, Tparameter parameter) where T : ViewModelBase<Tparameter>
        {
            if (viewModel is ViewModelBase<Tparameter> viewModelConstructor)
                viewModelConstructor.Parameter = parameter;
        }

        private static MyDialogWindow CreateDialogWindow()
        {
            var resources = Application.Current.MainWindow.Resources;
            var newWindow = new MyDialogWindow();
            newWindow.SizeToContent = SizeToContent.WidthAndHeight;
            newWindow.Resources = resources;

            return newWindow;
        }

        private static void SetDialogWindowProperties<T>(MyDialogWindow newWindow, T viewModel) where T : ViewModelBase
        {
            newWindow.Title = viewModel.Title;
            newWindow.Content = viewModel;
        }
    }
}
