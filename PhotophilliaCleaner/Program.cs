using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhetStone.Streams;

namespace PhotophilliaCleaner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
                args = new[] {@"M:\Archive\photophillia\RAW"};
            string rawdir = args[0];
            string[] destinations;
            using (StreamReader r = new StreamReader(Path.Combine(rawdir, "destinations.txt")))
            {
                destinations = r.Loop().ToArray();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Viewer(rawdir, destinations));
        }
    }
}
