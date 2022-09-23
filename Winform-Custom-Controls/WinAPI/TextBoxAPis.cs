using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform_Custom_Controls.WinAPI
{
    internal class TextBoxAPis
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool HideCaret(IntPtr hWnd);

        /// <summary>
        /// 폼가장자리 둥글게 둥글게
        /// 0,0,width.height, 35,35
        /// </summary>
        /// <param name="nLeftRect"></param>
        /// <param name="nTopRect"></param>
        /// <param name="nRightRect"></param>
        /// <param name="nBottomRect"></param>
        /// <param name="nWidthEllipse"></param>
        /// <param name="nHeightEllipse"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int message, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        /// <summary>
        /// Calls the default window procedure to provide default processing for any window messages that an application does not process.
        /// This function ensures that every message is processed. DefWindowProc is called with the same parameters received by the window procedure.
        /// Minimum supported client : Windows 2000 Professional [desktop apps only]
        /// Minimum supported server : Windows 2000 Server[desktop apps only]
        /// Target Platform : Windows
        /// Header : winuser.h(include Windows.h)
        /// Library : User32.lib
        /// DLL : User32.dll
        /// </summary>
        /// <param name="hwnd">A handle to the window procedure that received the message.</param>
        /// <param name="uMsg">The message.</param>
        /// <param name="wParam">Additional message information. The content of this parameter depends on the value of the Msg parameter.</param>
        /// <param name="lParam">Additional message information. The content of this parameter depends on the value of the Msg parameter.</param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern IntPtr DefWindowProcA(IntPtr hwnd, int uMsg, IntPtr wParam, IntPtr lParam);

        [System.Runtime.InteropServices.DllImport("gdi32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int GetNearestColor(System.Runtime.InteropServices.HandleRef hDC, int color);

        [System.Runtime.InteropServices.DllImport("gdi32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int SetTextColor(System.Runtime.InteropServices.HandleRef hDC, int crColor);

        [System.Runtime.InteropServices.DllImport("gdi32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int GetTextAlign(System.Runtime.InteropServices.HandleRef hdc);

        [System.Runtime.InteropServices.DllImport("gdi32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int GetTextColor(System.Runtime.InteropServices.HandleRef hDC);

        [System.Runtime.InteropServices.DllImport("gdi32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int SetBkColor(System.Runtime.InteropServices.HandleRef hDC, int clr);
    }
}
