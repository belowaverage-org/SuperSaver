using System;
using ScreenSaver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperSaver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            ScreenSaver.ScreenSaver ScreenSaver = new ScreenSaver.ScreenSaver(new ScreenSaverTestConfiguration());
            ScreenSaver.Run(args);
        }
    }
}
