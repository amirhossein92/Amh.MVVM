using Amh.MVVM.Base.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amh.MVVM.UiDemo.ViewModel
{
    public class SampleDetailUserControlViewModel : ViewModelBase<Weather>
    {
        public SampleDetailUserControlViewModel()
        {

        }

        public override void LoadCommands()
        {

        }

        public override void LoadData()
        {
            var cities = SampleData.GetCities();
            Cities = new ObservableCollection<Tuple<int, string>>();
            foreach (var item in cities)
                Cities.Add(new Tuple<int, string>(item.Id, item.Name));
        }

        public override string SetTitle()
        {
            return "Detail";
        }

        private ObservableCollection<Tuple<int, string>> _cities;
        public ObservableCollection<Tuple<int, string>> Cities
        {
            get => _cities;
            set
            {
                _cities = value;
                OnPropertyChanged();
            }
        }
    }
}
