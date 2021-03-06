﻿using Amh.MVVM.Base.ViewModel;
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
        void OpenNewPage<TViewModel>(ViewModelBase currentViewModel, TViewModel viewModel = null) where TViewModel : ViewModelBase;
        void OpenNewPageWithConstructor<TViewModel, Tparameter>(ViewModelBase currentViewModel, Tparameter parameter, TViewModel viewModel = null) where TViewModel : ViewModelBase<Tparameter>;
        void ClosePage(ViewModelBase currentViewModel);

        MainViewModelBase MainViewModel { get; }
    }
}
