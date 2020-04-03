using Amh.MVVM.Base.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amh.MVVM.Utility;
using Amh.MVVM.Base.Command;
using System.Windows.Interop;
using Amh.MVVM.UiDemo.Model;

namespace Amh.MVVM.UiDemo.ViewModel
{
    public class SampleListUserControlViewModel : ViewModelBase
    {
        private MyWindowTabService _myWindowTabService = new MyWindowTabService();
        private IWindowDialogService _windowDialogService = new WindowDialogService();

        public SampleListUserControlViewModel()
        {
            MessagingService<AlertModel>.Subscribe(OnMsgSent);
        }

        private void OnMsgSent(AlertModel obj)
        {
            var a = 2;
        }

        public override void LoadCommands()
        {
            AddCommand = new RelayCommand(OnAdd);
            ShowCommand = new RelayCommand(OnShow);
            DetailCommand = new RelayCommand<Weather>(OnDetail);
        }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand ShowCommand { get; set; }
        public RelayCommand<Weather> DetailCommand { get; set; }
        public RelayCommand DetailsCommand { get; set; }

        private void OnAdd()
        {
            // New Dialog Page
            var weather = new Weather();
            //WindowService.OpenNewPageDialogWithConstructor<SampleAddUserControlViewModel, Weather>(this, weather);
            _windowDialogService.OpenNewPageDialogWithConstructor<SampleAddUserControlViewModel, Weather>(this, weather);
        }

        private void OnShow()
        {
            Weathers = SampleData.GetWeathers(Count).ToObservable();
        }

        private void OnDetail(Weather weather)
        {
            // Open New Page and have back button
            //WindowService.OpenNewPage<SampleDetailUserControlViewModel>();
            //WindowService.OpenNewPageWithConstructor<SampleDetailUserControlViewModel, Weather>(this, weather);
            _myWindowTabService.OpenNewPageWithConstructor<SampleDetailUserControlViewModel, Weather>(this, weather);
        }

        public override async void LoadData()
        {
            if (Weathers == null)
            {
                await Task.Delay(2500);
                OnShow();
            }
        }

        public override string SetTitle()
        {
            return "List";
        }

        private ObservableCollection<Weather> _weathers;
        public ObservableCollection<Weather> Weathers
        {
            get => _weathers; set
            {
                _weathers = value;
                OnPropertyChanged();
            }
        }

        private int _count = 10;
        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged();
            }
        }
    }

    public static class SampleData
    {
        private static List<Weather> _currentWeather;

        public static List<Weather> GetWeathers(int count)
        {
            var result = new List<Weather>();
            var random = new Random();

            for (int i = 1; i <= count; i++)
            {
                var faker = new Bogus.Faker();
                var address = faker.Address;

                var city = new City { Id = i, Name = address.City(), Country = address.Country() };
                result.Add(new Weather
                {
                    Id = i,
                    City = city,
                    CityId = city.Id,
                    Pressure = random.Next(100, 1000),
                    Temperature = random.Next(-20, 35)
                });
            }

            _currentWeather = new List<Weather>();
            _currentWeather.AddRange(result);
            return result;
        }

        public static List<City> GetCities()
        {
            var result = new List<City>();

            if (_currentWeather != null)
                result.AddRange(_currentWeather.Select(item => item.City).Distinct().ToList());

            return result;
        }
    }

    public class Weather
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public double Temperature { get; set; }
        public double Pressure { get; set; }

        public City City { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
