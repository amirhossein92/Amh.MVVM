using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Amh.MVVM.UiDemo.Controls.Buttons
{
    public class MyButton : Button
    {
        public MyButton()
        {
            this.MinWidth = 100;
            Margin = new System.Windows.Thickness(5);
        }
    }
}
