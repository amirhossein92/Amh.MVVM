using Amh.MVVM.Base.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amh.MVVM.UiDemo.ViewModel
{
    public class SampleEditUserControlViewModel : ViewModelBase<Weather>
    {
        public override void LoadCommands()
        {
        }

        public override void LoadData()
        {
        }

        public override string SetTitle()
        {
            return "Edit";
        }
    }
}
