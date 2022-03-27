using System;
using System.Windows.Forms;
using WeatherClient.Domain.Interfaces;

namespace WeatherClient
{
    public partial class MainForm : Form
    {
        private readonly IWeatherService weatherService;

        public MainForm(IWeatherService weatherService)
        {
            this.weatherService = weatherService;

            InitializeComponent();
        }

        private async void button_Click(object sender, EventArgs e)
        {
            var date = dateTimePicker.Value;
            var city = "Москва";
            var weather = await weatherService.GetWeather(date, city);

            if (weather == null)
            {
                richTextBox.Text = "Нет данных";

                return;
            }

            var text = new System.Text.StringBuilder();
            text.Append(string.Format("Погода в городе {0} на {1} \n", city, date.ToString("dd.MM.yyyy")));
            text.Append(string.Format("{0}, ветер {1} м/с", weather.WeatherDescription, weather.WindSpeed));
            text.Append(string.Format("Осадки {0} мм \n", weather.Precipitation));
            text.Append(string.Format("Температура от {0} до {1} градусов Цельсия \n", weather.TemperatureC.Minimum, weather.TemperatureC.Maximum));
            text.Append(string.Format("Атмосферное давление от {0} до {1} мм рт. ст. \n", weather.PressureAtm.Minimum, weather.PressureAtm.Maximum));
            text.Append(string.Format("Влажность {0}% \n", weather.Humidity));
            text.Append(string.Format("Геомагнитная активность {0} \n", weather.Geomagnetic));

            richTextBox.Text = text.ToString();
        }
    }
}
