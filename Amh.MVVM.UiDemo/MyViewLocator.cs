using Amh.MVVM.Base.View;
using Amh.MVVM.Base.ViewModel;
using Amh.MVVM.UiDemo.View;
using Amh.MVVM.UiDemo.ViewModel;
using Amh.MVVM.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Amh.MVVM.UiDemo
{
    public static class MyViewLocator
    {
        public static IEnumerable<(object Key, object Value)> GetDataTemplates()
        {
            var results = new List<(object Key, object Value)>();

            results.Add(MyViewLocatorUtility.BindViewModelToView<SampleAddUserControlViewModel, SampleAddUserControlView>());
            results.Add(MyViewLocatorUtility.BindViewModelToView<SampleDetailUserControlViewModel, SampleDetailUserControlView>());
            results.Add(MyViewLocatorUtility.BindViewModelToView<SampleListUserControlViewModel, SampleListUserControlView>());

            return results;
        }
    }
}
