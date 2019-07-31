using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ciLayoutDesign
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

            // #1 7-30-2019 td//Application.Run(new FormRudimentary());
            //  #2 7-30-2019 td//Application.Run(new FormBetterFontDraw());

            Application.Run(new FormFontAliasing());

        }
    }
}
