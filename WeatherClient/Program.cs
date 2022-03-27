using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using WeatherClient.Domain.Interfaces;
using System.Net.Http;
using WeatherClient.Domain;

namespace WeatherClient
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddHttpClient();
            services.AddTransient<Dao.Interfaces.IHttpClient>(provider => new Dao.HttpClient(provider.GetService<IHttpClientFactory>()));
            services.AddTransient<IWeatherService>(provider => new WeatherService(provider.GetService<Dao.Interfaces.IHttpClient>()));
            services.AddSingleton<MainForm>();
        }
    }
}
