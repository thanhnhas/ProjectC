﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageLibrary
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.ssssadd
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmAdmin());
            //check index value ok ok

        }
    }
}
