using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace BOOKSTORE
{
    static class Program1
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (SplashScreen S = new SplashScreen())
            {
                S.Show();
                Application.DoEvents();
                System.Threading.Thread.Sleep(3000);
                S.Close();
            }

            Application.Run(new Login());
        }
    }
}
