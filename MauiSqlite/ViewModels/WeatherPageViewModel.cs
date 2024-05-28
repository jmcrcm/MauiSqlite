using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiSqlite.ViewModels
{
    internal class WeatherPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private bool _btnRefreshEnabled = true;
        private bool _actIsBusyIsRunning = false;
        private string _txtPostalCode = string.Empty;
        private string _lblWindTxt = string.Empty;
        private string _lblHumidityTxt = string.Empty;
        private string _lblPrecipitationTxt = string.Empty;
        private string _lblTemperatureTxt = string.Empty;
        private ImageSource _imgConditionSource = string.Empty;

        public Command ButtonPressed { get; set; }

        public WeatherPageViewModel()
        {
            ButtonPressed = new(OnButtonClicked);
        }

        private async void OnButtonClicked()
        {
            BtnRefreshEnabled = false;
            ActIsBusyIsRunning = true;

            Models.WeatherData weatherData = await Services.WeatherServer.GetWeather(TxtPostalCode);

            LblWindTxt = weatherData.Wind.ToString();
            LblHumidityTxt = weatherData.Humidity.ToString();
            LblPrecipitationTxt = weatherData.Precipitation.ToString();
            LblTemperatureTxt = weatherData.Temperature.ToString();

            ImgConditionSource = weatherData.Condition switch
            { 
                Models.WeatherType.Sunny => ImageSource.FromFile("sunny.png"),
                Models.WeatherType.Cloudy => ImageSource.FromFile("cloud.png"),
                _ => ImageSource.FromFile("question.png")
            };

            BtnRefreshEnabled = true;
            ActIsBusyIsRunning = false;
            
        }

        public bool BtnRefreshEnabled
        {
            get => _btnRefreshEnabled;
            set
            {
                if (_btnRefreshEnabled != value)
                {
                    _btnRefreshEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool ActIsBusyIsRunning
        {
            get => _actIsBusyIsRunning;
            set
            {
                if (_actIsBusyIsRunning != value)
                {
                    _actIsBusyIsRunning = value;
                    OnPropertyChanged();
                }
            }
        }

        public string TxtPostalCode
        {
            get => _txtPostalCode;
            set
            {
                if (_txtPostalCode != value)
                {
                    _txtPostalCode = value;
                    OnPropertyChanged();
                }
            }
        }

        public string LblWindTxt
        {
            get => _lblWindTxt;
            set
            {
                if (_lblWindTxt != value)
                {
                    _lblWindTxt = value;
                    OnPropertyChanged();
                }
            }
        }

        public string LblHumidityTxt
        {
            get => _lblHumidityTxt;
            set
            {
                if (value != _lblHumidityTxt)
                {
                    _lblHumidityTxt = value;
                    OnPropertyChanged();
                }

            }
        }

        public string LblPrecipitationTxt
        {
            get => _lblPrecipitationTxt;
            set
            {
                if (_lblPrecipitationTxt != value)
                {
                    _lblPrecipitationTxt = value;
                    OnPropertyChanged();
                }
            }
        }

        public string LblTemperatureTxt
        {
            get => _lblTemperatureTxt;
            set
            {
                if (_lblTemperatureTxt != value)
                {
                    _lblTemperatureTxt = value;
                    OnPropertyChanged();
                }
            }
        }

        public ImageSource ImgConditionSource
        {
            get => _imgConditionSource;
            set
            {
                if (_imgConditionSource != value)
                {
                    _imgConditionSource = value;
                    OnPropertyChanged();
                }
            }
        }

        public void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
