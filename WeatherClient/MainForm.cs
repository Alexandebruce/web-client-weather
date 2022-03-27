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

        private async void button1_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "Hello world!";

            var weather = await weatherService.GetWeather(DateTime.Now, "Москва");

            this.richTextBox1.Text = weather.ToString();
        }
    }
}
