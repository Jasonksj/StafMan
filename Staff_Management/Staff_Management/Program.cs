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
            Application.Run(new MainForm());
=======
            new Splash_Screen().Show();
            Application.Run();
>>>>>>> 98da8cce8a568a2faa4f7834bd7b4ec18ec2c42f
            
        }
    }
}
