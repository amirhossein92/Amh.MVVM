using Amh.MVVM.Base.View;
using Amh.MVVM.Base.ViewModel;
using Amh.MVVM.UiDemo.View;
using Amh.MVVM.UiDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Amh.MVVM.UiDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var resources = MyViewLocator.GetDataTemplates();
            foreach (var resource in resources)
                this.Resources.Add(resource.Key, resource.Value);
            InitializeComponent();
        }
    }
}
