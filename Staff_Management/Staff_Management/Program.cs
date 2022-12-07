using Staff_Management.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_Management
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new Frmlogin());
=======
            new Splash_Screen().Show();
            Application.Run();
>>>>>>> e8de72574e9f67f05914697571c1d94294d1af77
            
        }
    }
}
