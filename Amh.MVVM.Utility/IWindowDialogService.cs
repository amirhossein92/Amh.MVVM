using Amh.MVVM.Base.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amh.MVVM.Utility
{
    public interface IWindowDialogService
    {
        void OpenNewDialogPage<T>(ViewModelBase currentViewModel, T viewModel = null) where T : ViewModelBase;
        void OpenNewPageDialogWithConstructor<T, Tparameter>(ViewModelBase currentViewModel, Tparameter parameter, T viewModel = null) where T : ViewModelBase<Tparameter>;
        void CloseDialogPage(ViewModelBase currentViewModel, bool result = false);
    }
}
