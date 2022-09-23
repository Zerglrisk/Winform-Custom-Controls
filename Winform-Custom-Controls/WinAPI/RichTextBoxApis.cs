using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Interop.Richedit;

namespace Winform_Custom_Controls.WinAPI
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="https://csharp.hotexamples.com/examples/System.Windows.Forms/PARAFORMAT2/-/php-paraformat2-class-examples.html"/>
    /// <see cref="https://github.com/BrentKnowles/YourOtherMind/blob/master/Layout/RichText/RichTextExtended.cs"/>
    /// <see cref="https://github.com/CodeFork/RichTextBoxEx/blob/master/RichTextBoxEx/RichTextBoxEx.cs"/>
    /// <see cref="http://www.kydsoft.com/winui/kr/devdoc/live/pdui/richedit_0tf6.htm"/>
    /// <see cref="https://microsoft.github.io/windows-docs-rs/doc/windows/Win32/UI/Controls/RichEdit/constant.PFM_LINESPACING.html"/>
    /// <see cref="https://titanwolf.org/Network/Articles/Article?AID=2cffdfdf-7191-4469-ace5-aef194e4a32c"/>
    /// <see cref="https://docs.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-paraformat2"/>
    /// <see cref="http://cleartopartlycloudy.blogspot.com/2013/01/shading-style-in-richtextbox-50.html"/>
    internal class RichTextBoxApis
    {
        [System.Runtime.InteropServices.DllImport("user32", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern IntPtr SendMessage(System.Runtime.InteropServices.HandleRef hWnd, int msg, int wParam, ref PARAFORMAT2 lParam);

        [System.Runtime.InteropServices.DllImport("USER32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wp, IntPtr lp);

        public static void SetLineFormat(System.Windows.Forms.RichTextBox rtb, byte rule, int space)
        {
            PARAFORMAT2 pf2 = new PARAFORMAT2();
            pf2.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(pf2);
            pf2.dwMask = (uint)PFM.LINESPACING;
            pf2.dyLineSpacing = space;
            pf2.bLineSpacingRule = rule;
            rtb.SelectAll();
            SendMessage(new System.Runtime.InteropServices.HandleRef(rtb, rtb.Handle),
                         (int)EM.SETPARAFORMAT,
                         (int)SCF.SELECTION,
                         ref pf2
                       );

            rtb.Select(0, 0);
        }

        public static float GetLineSpacing(System.Windows.Forms.RichTextBox rtb)
        {
            PARAFORMAT2 pf2 = new PARAFORMAT2();
            pf2.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(pf2); ;
            pf2.dwMask = (uint)PFM.LINESPACING;

            IntPtr lParam = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(pf2.cbSize);
            System.Runtime.InteropServices.Marshal.StructureToPtr(pf2, lParam, true);
            SendMessage(rtb.Handle, (uint)EM.GETPARAFORMAT, IntPtr.Zero, lParam);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(lParam);
            return pf2.dyLineSpacing / 100f;

        }
        public static void SetLineSpacing(IntPtr hRichEditHandle, float lineSpacing)
        {
            PARAFORMAT2 fmt = new PARAFORMAT2();
            fmt.cbSize = Marshal.SizeOf(fmt);
            fmt.bLineSpacingRule = 4;
            fmt.dyLineSpacing = (int)(lineSpacing * 100);
            fmt.dwMask = (uint)PFM.LINESPACING; //PFM_LINESPACING;

            IntPtr lParam = Marshal.AllocCoTaskMem(fmt.cbSize);
            Marshal.StructureToPtr(fmt, lParam, true);
            //NativeMethods.User32.SendMessage(hRichEditHandle, EM_SETPARAFORMAT, IntPtr.Zero, lParam); //
            SendMessage(hRichEditHandle, (uint)EM.SETPARAFORMAT, IntPtr.Zero, lParam);
            Marshal.FreeCoTaskMem(lParam);
        }

        public static void SetParagraphSpacing(System.Windows.Forms.RichTextBox rtb, byte rule, int AdditionalSpacing)
        {
            PARAFORMAT2 paraform = new PARAFORMAT2();
            paraform.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(paraform);

            int textHeight;
            int singleLineSpacing = 20;
            //Calc Text Height
            //using (Graphics g = rtb.CreateGraphics())
            //{
            //    textHeight = TextRenderer.MeasureText(g, "가", rtb.Font, rtb.ClientSize, TextFormatFlags.Left
            //                            | TextFormatFlags.Top
            //                            | TextFormatFlags.NoPrefix
            //                            | TextFormatFlags.TextBoxControl).Height;
            //}
            // NOTE: You need both of these!
            paraform.bLineSpacingRule = rule;
            paraform.dyLineSpacing = singleLineSpacing + AdditionalSpacing;

            paraform.wReserved = 0;
            paraform.dwMask = (uint)PFM.LINESPACING;

            IntPtr res = IntPtr.Zero;

            IntPtr wparam = IntPtr.Zero;

            //Get the pointer to the FORMATRANGE structure in memory
            IntPtr lparam = IntPtr.Zero;
            rtb.SelectAll();
            lparam = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(System.Runtime.InteropServices.Marshal.SizeOf(paraform));
            System.Runtime.InteropServices.Marshal.StructureToPtr(paraform, lparam, false);

            //Send the rendered data for printing 
            res = SendMessage(rtb.Handle, (int)EM.SETPARAFORMAT, wparam, lparam);

            //Free the block of memory allocated
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(lparam);

            rtb.Select(0, 0);
        }
        public void SetLineSpacing(System.Windows.Forms.RichTextBox rtb, int space)
        {
            PARAFORMAT2 pf2 = new PARAFORMAT2();
            pf2.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(space);
            // [NEED FIX]
        }
    }
}
