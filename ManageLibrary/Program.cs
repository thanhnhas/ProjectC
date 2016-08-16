using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageLibrary
{
    static class Program
    {
        private static void SplashScreen()
        {
            Application.Run(new frmLoadForm());
        }
        private static void SecondLogin()
        {
            Application.Run(new frmLogin());
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread t = new Thread(new ThreadStart(SplashScreen));
            t.Start();
            Thread.Sleep(3500);
            //hàm này có tác dụng hủy
            t.Abort();
            t = new Thread(new ThreadStart(SecondLogin));
            t.Start();
          

        }
    }
}
