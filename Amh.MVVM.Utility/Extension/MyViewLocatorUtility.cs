using Amh.MVVM.Base.View;
using Amh.MVVM.Base.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Amh.MVVM.Utility.Extension
{
    public class MyViewLocatorUtility
    {
        public static KeyValuePair<object, object> BindViewModelToView<TViewModel, TView>() where TViewModel : ViewModelBase where TView : UserControlBase
        {
            DataTemplate dataTemplate = new DataTemplate
            {
                VisualTree = new FrameworkElementFactory(typeof(TView))
            };
            var dtk = new DataTemplateKey(typeof(TViewModel));
            return new KeyValuePair<object, object>(dtk, dataTemplate);
        }
    }
}
