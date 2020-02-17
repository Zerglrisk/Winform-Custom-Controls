using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Winform_Custom_Controls.Core.Data
{
    public class WindowGraphics
    {
        public static Color GetNearestColor(Color color, IntPtr hdc)
        {
            return ColorTranslator.FromWin32(WinAPI.GetNearestColor(new HandleRef((object)null, hdc), ColorTranslator.ToWin32(color)));
        }
    }
}
