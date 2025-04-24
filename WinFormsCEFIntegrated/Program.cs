using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsCEFIntegrated
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            int refreshInterval = 10000; // default 20 seconds

            // Check if there's a command-line argument for interval
            if (args.Length > 0 && int.TryParse(args[0], out int parsedInterval))
            {
                refreshInterval = parsedInterval;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(refreshInterval));
        }
    }
}
