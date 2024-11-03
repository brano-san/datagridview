using System;
using System.Windows.Forms;
using datagridview.Tour.Storage;

namespace datagridview.src
{
    static internal class Program
    {
        /// <summary>
        /// ������� ����� ����� ��� ����������.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var tourStorage = new TourStorage();
            var tourManager = new TourManager.TourManager(tourStorage);

            Application.Run(new MainForm(tourManager));
        }
    }
}
