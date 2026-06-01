using System;
using System.Windows.Forms;

namespace Carniceria
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

                       FrmSplash splash = new FrmSplash();
            splash.ShowDialog();

            Application.Run(new Views.FrmLogin());
        }
    }
}