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
    public class LayoutUtils
    {
        public static readonly Size MaxSize = new Size(int.MaxValue, int.MaxValue);
        public static readonly Size InvalidSize = new Size(int.MinValue, int.MinValue);
        public static readonly Rectangle MaxRectangle = new Rectangle(0, 0, int.MaxValue, int.MaxValue);

        public static Rectangle InflateRect(Rectangle rect, Padding padding)
        {
            rect.X -= padding.Left;
            rect.Y -= padding.Top;
            rect.Width += padding.Horizontal;
            rect.Height += padding.Vertical;
            return rect;
        }

        public static Rectangle DeflateRect(Rectangle rect, Padding padding)
        {
            rect.X += padding.Left;
            rect.Y += padding.Top;
            rect.Width -= padding.Horizontal;
            rect.Height -= padding.Vertical;
            return rect;
        }

        #region MeasureTextCache

        public sealed class MeasureTextCache
        {
            private Size unconstrainedPreferredSize = LayoutUtils.InvalidSize;
            private int nextCacheEntry = -1;
            private const int MaxCacheSize = 6;
            private LayoutUtils.MeasureTextCache.PreferredSizeCache[] sizeCacheList;

            public void InvalidateCache()
            {
                this.unconstrainedPreferredSize = LayoutUtils.InvalidSize;
                this.sizeCacheList = (LayoutUtils.MeasureTextCache.PreferredSizeCache[])null;
            }

            public Size GetTextSize(
              string text,
              Font font,
              Size proposedConstraints,
              TextFormatFlags flags)
            {
                if (!this.TextRequiresWordBreak(text, font, proposedConstraints, flags))
                    return this.unconstrainedPreferredSize;
                if (this.sizeCacheList == null)
                    this.sizeCacheList = new LayoutUtils.MeasureTextCache.PreferredSizeCache[6];
                foreach (LayoutUtils.MeasureTextCache.PreferredSizeCache sizeCache in this.sizeCacheList)
                {
                    if (sizeCache.ConstrainingSize == proposedConstraints || sizeCache.ConstrainingSize.Width == proposedConstraints.Width && sizeCache.PreferredSize.Height <= proposedConstraints.Height)
                        return sizeCache.PreferredSize;
                }
                Size preferredSize = TextRenderer.MeasureText(text, font, proposedConstraints, flags);
                this.nextCacheEntry = (this.nextCacheEntry + 1) % 6;
                this.sizeCacheList[this.nextCacheEntry] = new LayoutUtils.MeasureTextCache.PreferredSizeCache(proposedConstraints, preferredSize);
                return preferredSize;
            }

            private Size GetUnconstrainedSize(string text, Font font, TextFormatFlags flags)
            {
                if (this.unconstrainedPreferredSize == LayoutUtils.InvalidSize)
                {
                    flags &= ~TextFormatFlags.WordBreak;
                    this.unconstrainedPreferredSize = TextRenderer.MeasureText(text, font, LayoutUtils.MaxSize, flags);
                }
                return this.unconstrainedPreferredSize;
            }

            public bool TextRequiresWordBreak(string text, Font font, Size size, TextFormatFlags flags)
            {
                return this.GetUnconstrainedSize(text, font, flags).Width > size.Width;
            }

            private struct PreferredSizeCache
            {
                public readonly Size ConstrainingSize;
                public readonly Size PreferredSize;

                public PreferredSizeCache(Size constrainingSize, Size preferredSize)
                {
                    this.ConstrainingSize = constrainingSize;
                    this.PreferredSize = preferredSize;
                }
            }
        }

        #endregion
    }
   
}
