using ScreenSaver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperSaver
{
    internal class ScreenSaverTestConfiguration : IScreenSaverConfiguration
    {
        public string ScreenSaverName
        {
            get
            {
                return "SuperSaver";
            }
        }

        public Control CreateScreenSaverControl(Screen screen)
        {
            Control display = new Display();
            return display.Controls[0];
        }

        public Control CreatePreviewControl()
        {
            Control display = new Display();
            return display.Controls[0];
        }

        public ConfigurationControl CreateConfigurationControl()
        {
            return null;
        }
    }
}