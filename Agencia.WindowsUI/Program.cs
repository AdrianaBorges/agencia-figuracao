using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Agencia.WindowsUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLogin logar = new frmLogin();

            if (logar.ShowDialog() ==  DialogResult.OK)
            {
                Application.Run(new frmPrincipal());

            }
           
        }
    }
}
