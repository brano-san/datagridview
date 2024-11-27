using datagridview.Tour.Database;

using Serilog;
using Serilog.Extensions.Logging;

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

            var seriLogger = new LoggerConfiguration()
                .WriteTo.Seq("http://localhost:5341/", apiKey: "1b46iVbcK2ULBsAYVs5i")
                .CreateLogger();

            var logger = new SerilogLoggerFactory(seriLogger)
                .CreateLogger("datagridview");

            var tourStorage = new TourStorage();
            var tourManager = new Tour.Manager.TourManager(tourStorage, logger);

            Application.Run(new MainForm(tourManager, logger));
        }
    }
}
