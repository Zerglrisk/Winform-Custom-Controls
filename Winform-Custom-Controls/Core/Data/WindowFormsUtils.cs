using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_Custom_Controls.Core.Data
{
    public class WindowFormsUtils
    {
        public static readonly ContentAlignment AnyRightAlign = ContentAlignment.TopRight | ContentAlignment.MiddleRight | ContentAlignment.BottomRight;
        public static readonly ContentAlignment AnyLeftAlign = ContentAlignment.TopLeft | ContentAlignment.MiddleLeft | ContentAlignment.BottomLeft;
        public static readonly ContentAlignment AnyTopAlign = ContentAlignment.TopLeft | ContentAlignment.TopCenter | ContentAlignment.TopRight;
        public static readonly ContentAlignment AnyBottomAlign = ContentAlignment.BottomLeft | ContentAlignment.BottomCenter | ContentAlignment.BottomRight;
        public static readonly ContentAlignment AnyMiddleAlign = ContentAlignment.MiddleLeft | ContentAlignment.MiddleCenter | ContentAlignment.MiddleRight;
        public static readonly ContentAlignment AnyCenterAlign = ContentAlignment.TopCenter | ContentAlignment.MiddleCenter | ContentAlignment.BottomCenter;

        #region Controls
        /// <summary>
        ///   오른쪽에서 왼쪽으로 쓰는 텍스트를 지원하려면 지정된 <see cref="T:System.Drawing.ContentAlignment" />를 적절한 <see cref="T:System.Drawing.ContentAlignment" />로 변환합니다.
        /// </summary>
        /// <param name="align">
        ///   <see cref="T:System.Drawing.ContentAlignment" /> 값 중 하나입니다.
        /// </param>
        /// <returns>
        ///   <see cref="T:System.Drawing.ContentAlignment" /> 값 중 하나입니다.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static ContentAlignment RtlTranslateContent(ContentAlignment align, RightToLeft rightToLeft)
        {
            if (RightToLeft.Yes == rightToLeft)
            {
                if ((align & AnyTopAlign) != (ContentAlignment)0)
                {
                    if (align == ContentAlignment.TopLeft)
                        return ContentAlignment.TopRight;
                    if (align == ContentAlignment.TopRight)
                        return ContentAlignment.TopLeft;
                }
                if ((align & AnyMiddleAlign) != (ContentAlignment)0)
                {
                    if (align == ContentAlignment.MiddleLeft)
                        return ContentAlignment.MiddleRight;
                    if (align == ContentAlignment.MiddleRight)
                        return ContentAlignment.MiddleLeft;
                }
                if ((align & AnyBottomAlign) != (ContentAlignment)0)
                {
                    if (align == ContentAlignment.BottomLeft)
                        return ContentAlignment.BottomRight;
                    if (align == ContentAlignment.BottomRight)
                        return ContentAlignment.BottomLeft;
                }
            }
            return align;
        }
        #endregion

        #region ControlPaints

        private static readonly System.Drawing.ContentAlignment anyRight = System.Drawing.ContentAlignment.TopRight | System.Drawing.ContentAlignment.MiddleRight | System.Drawing.ContentAlignment.BottomRight;
        private static readonly System.Drawing.ContentAlignment anyBottom = System.Drawing.ContentAlignment.BottomLeft | System.Drawing.ContentAlignment.BottomCenter | System.Drawing.ContentAlignment.BottomRight;
        private static readonly System.Drawing.ContentAlignment anyCenter = System.Drawing.ContentAlignment.TopCenter | System.Drawing.ContentAlignment.MiddleCenter | System.Drawing.ContentAlignment.BottomCenter;
        private static readonly System.Drawing.ContentAlignment anyMiddle = System.Drawing.ContentAlignment.MiddleLeft | System.Drawing.ContentAlignment.MiddleCenter | System.Drawing.ContentAlignment.MiddleRight;

        internal static TextFormatFlags CreateTextFormatFlags(
            Control ctl,
            System.Drawing.ContentAlignment textAlign,
            bool showEllipsis,
            bool useMnemonic,
            bool showKeyboardCues)
        {
            textAlign = RtlTranslateContent(textAlign, ctl.RightToLeft);
            TextFormatFlags textFormatFlags = WindowFormsUtils.TextFormatFlagsForAlignmentGDI(textAlign) | TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak;
            if (showEllipsis)
                textFormatFlags |= TextFormatFlags.EndEllipsis;
            if (ctl.RightToLeft == RightToLeft.Yes)
                textFormatFlags |= TextFormatFlags.RightToLeft;
            if (!useMnemonic)
                textFormatFlags |= TextFormatFlags.NoPrefix;
            else if (!showKeyboardCues)
                textFormatFlags |= TextFormatFlags.HidePrefix;
            return textFormatFlags;
        }

        internal static TextFormatFlags TextFormatFlagsForAlignmentGDI(
            System.Drawing.ContentAlignment align)
        {
            return TextFormatFlags.Default | WindowFormsUtils.TranslateAlignmentForGDI(align) | WindowFormsUtils.TranslateLineAlignmentForGDI(align);
        }

        internal static StringAlignment TranslateAlignment(System.Drawing.ContentAlignment align)
        {
            return (align & WindowFormsUtils.anyRight) == (System.Drawing.ContentAlignment)0 ? ((align & WindowFormsUtils.anyCenter) == (System.Drawing.ContentAlignment)0 ? StringAlignment.Near : StringAlignment.Center) : StringAlignment.Far;
        }

        internal static TextFormatFlags TranslateAlignmentForGDI(System.Drawing.ContentAlignment align)
        {
            return (align & WindowFormsUtils.anyBottom) == (System.Drawing.ContentAlignment)0 ? ((align & WindowFormsUtils.anyMiddle) == (System.Drawing.ContentAlignment)0 ? TextFormatFlags.Default : TextFormatFlags.VerticalCenter) : TextFormatFlags.Bottom;
        }

        internal static StringAlignment TranslateLineAlignment(System.Drawing.ContentAlignment align)
        {
            return (align & WindowFormsUtils.anyBottom) == (System.Drawing.ContentAlignment)0 ? ((align & WindowFormsUtils.anyMiddle) == (System.Drawing.ContentAlignment)0 ? StringAlignment.Near : StringAlignment.Center) : StringAlignment.Far;
        }

        internal static TextFormatFlags TranslateLineAlignmentForGDI(
            System.Drawing.ContentAlignment align)
        {
            return (align & WindowFormsUtils.anyRight) == (System.Drawing.ContentAlignment)0 ? ((align & WindowFormsUtils.anyCenter) == (System.Drawing.ContentAlignment)0 ? TextFormatFlags.Default : TextFormatFlags.HorizontalCenter) : TextFormatFlags.Right;
        }

        #endregion
    }
}
