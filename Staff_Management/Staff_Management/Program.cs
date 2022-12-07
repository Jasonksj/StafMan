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
            new Organigramme().Show();
=======
            new FrmSignup().Show();
>>>>>>> 85a5fe97f48242e7c6ace49a2feb3db5e7325aac
            Application.Run();
        }
    }
}
