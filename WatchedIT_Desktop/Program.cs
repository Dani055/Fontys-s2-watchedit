using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraries.data_access;
using ClassLibraries.interfaces;
using ClassLibraries.services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WatchedIT_Desktop.forms;

namespace WatchedIT_Desktop
{
    static class Program
    {
        public static IServiceProvider ServiceProvider { get; } = CreateServices();

        private static IServiceProvider CreateServices()
        {
            return new HostBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<IDBSettings, DBSettings>();
                services.AddSingleton<IDataAccessEpisode, DataAccessEpisode>();
                services.AddSingleton<IDataAccessMovie, DataAccessMovie>();
                services.AddScoped<IMovieService, MovieService>();
                services.AddScoped<IEpisodeService, EpisodeService>();

            }).Build()
            .Services;
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}
