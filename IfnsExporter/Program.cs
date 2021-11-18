using System;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Cso.IfnsExporter.Views;
using TmAvt.ExceptionHandling;

namespace Cso.IfnsExporter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += Application_ThreadException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // локализация приложения
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru-RU");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru");

            // настройка логгирования ошибок
            UnhandledExceptionManager.ScreenshotImageFormat = ImageFormat.Jpeg;
            UnhandledExceptionManager.AddHandler();

            Application.Run(new MainView());
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            UnhandledExceptionManager.HandleException(e.Exception, false, true);
            MessageBox.Show(e.Exception.Message);
        }
    }
}
