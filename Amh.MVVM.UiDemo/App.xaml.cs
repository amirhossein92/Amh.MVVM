using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Amh.MVVM.UiDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var resources = MyViewLocator.DataTemplates;
            foreach (var resource in resources)
                this.Resources.Add(resource.Key, resource.Value);
        }
    }
}
