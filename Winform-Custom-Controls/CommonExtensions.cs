using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform_Custom_Controls
{
    public static class ColorConverterExtensions
    {
        public static string ToHexString(this Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}";

        public static string ToRgbString(this Color c) => $"RGB({c.R}, {c.G}, {c.B})";
    }
}