using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Krypton.Toolkit;
using System.Threading.Tasks;

namespace Whackerlink_CPS.Properties
{
    internal class Theme
    {
        public KryptonManager kryptonManager;

        public void krypton2007White()
        {
            KryptonManager kryptonManager = new KryptonManager();
            kryptonManager.GlobalPaletteMode = PaletteMode.Office2007White;
            Properties.Settings.Default.Themes = "Light";

        }
        public void krypton2007Blue()
        {

            KryptonManager kryptonManager = new KryptonManager();
            kryptonManager.GlobalPaletteMode = PaletteMode.Office2007Blue;
            Properties.Settings.Default.Themes = "Blue";

        }
        public void krypton2007Dark()
        {

            KryptonManager kryptonManager = new KryptonManager();
            kryptonManager.GlobalPaletteMode = PaletteMode.Office2007DarkGray;
            Properties.Settings.Default.Themes = "Dark";

        }
        public void krypton2007Sparkle()
        {

            KryptonManager kryptonManager = new KryptonManager();
            kryptonManager.GlobalPaletteMode = PaletteMode.SparklePurple;
            Properties.Settings.Default.Themes = "Sparkle";

        }
        public void krypton2007SilverDark()
        {

            KryptonManager kryptonManager = new KryptonManager();
            kryptonManager.GlobalPaletteMode = PaletteMode.Office2007SilverDarkMode;
            Properties.Settings.Default.Themes = "SilverDark";

        }

        public void krypton2007SilverLight()
        {

            KryptonManager kryptonManager = new KryptonManager();
            kryptonManager.GlobalPaletteMode = PaletteMode.Office2007SilverLightMode;
            Properties.Settings.Default.Themes = "SilverLight";

        }


    }
}

