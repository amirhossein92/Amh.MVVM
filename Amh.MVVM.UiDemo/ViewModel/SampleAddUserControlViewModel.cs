using Amh.MVVM.Base.Command;
using Amh.MVVM.Base.ViewModel;
using Amh.MVVM.UiDemo.Model;
using Amh.MVVM.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amh.MVVM.UiDemo.ViewModel
{
    public class SampleAddUserControlViewModel : ViewModelBase<Weather>
    {
        public SampleAddUserControlViewModel()
        {
            Title = "Add Weather";

            SaveCommand = new RelayCommand(OnSave);
            CloseCommand = new RelayCommand(OnClose);
        }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }

        private void OnSave()
        {
            WindowService.CloseDialogPage(this);
            MessagingService<AlertModel>.Sent(new AlertModel { Message = "Saved" });
        }

        private void OnClose()
        {
            WindowService.CloseDialogPage(this);
        }

        public override void LoadData()
        {
            var cities = SampleData.GetCities();
            Cities = new ObservableCollection<Tuple<int, string>>();
            foreach (var item in cities)
                Cities.Add(new Tuple<int, string>(item.Id, item.Name));
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
