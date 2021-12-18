using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poth_Dekho
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

            //Application.Run(new tourpackage());
            //Application.Run(new Choose_package(1));
            //Application.Run(new booked_trip(1));
            //Application.Run(new admin_booked_packages("admin1"));
            //Application.Run(new admin_dashboard("admin1"));
            //Application.Run(new admin_add_traveller("admin1"));
            //Application.Run(new traveller_create_account());
            //Application.Run(new admin_add_guide("admin1"));
            //Application.Run(new Admin_Reg());
            //Application.Run(new admin_view_profile("aqib1"));
            Application.Run(new admin_login());

        }
    }
}
