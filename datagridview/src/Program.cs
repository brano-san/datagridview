using datagridview.Tour.Storage;
using Microsoft.Extensions.Logging;

namespace datagridview.src
{
    static internal class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var tourManagerLogger = LoggerFactory.Create(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Debug);
                builder.AddConsole();
            }).CreateLogger(nameof(TourManager));

            var mainFormLogger = LoggerFactory.Create(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Debug);
                builder.AddConsole();
            }).CreateLogger(nameof(MainForm));

            var tourStorage = new TourStorage();
            var tourManager = new TourManager.TourManager(tourStorage, tourManagerLogger);

            Application.Run(new MainForm(tourManager, mainFormLogger));
        }
    }
}
