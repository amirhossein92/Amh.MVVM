using Amh.MVVM.Base.View;
using Amh.MVVM.Base.ViewModel;
using Amh.MVVM.UiDemo.View;
using Amh.MVVM.UiDemo.ViewModel;
using Amh.MVVM.Utility;
using Amh.MVVM.Utility.Extension;
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
        private static IEnumerable<KeyValuePair<object, object>> GetDataTemplates()
        {
            var results = new List<KeyValuePair<object, object>>();

            results.Add(MyViewLocatorUtility.BindViewModelToView<SampleAddUserControlViewModel, SampleAddUserControlView>());
            results.Add(MyViewLocatorUtility.BindViewModelToView<SampleDetailUserControlViewModel, SampleDetailUserControlView>());
            results.Add(MyViewLocatorUtility.BindViewModelToView<SampleListUserControlViewModel, SampleListUserControlView>());
            //results.Add(MyViewLocatorUtility.BindViewModelToView<SampleTabUserControlViewModel, SampleTabUserControlView>());

            return results;
        }

        private static IEnumerable<KeyValuePair<object, object>> _dataTemplates;
        public static IEnumerable<KeyValuePair<object, object>> DataTemplates
        {
            get
            {
                if (_dataTemplates == null)
                    _dataTemplates = GetDataTemplates();

                return _dataTemplates;
            }
        }
    }
}
