using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_Custom_Controls
{
    public class EventTemplates
    {
        /// <summary>
        /// Enable Right Click Selecta
        /// </summary>
        /// <see cref="https://stackoverflow.com/a/47897850"/>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DataGridView_CellMouseDown_Handle_Right_Button(object sender,
            DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var dgv = sender as DataGridView;
            dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
            dgv.Rows[e.RowIndex].Selected = true;
            dgv.Focus();
        }

        /// <summary>
        /// 텍스트 수정 불가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBox_Disable_KeyPress(object Sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        public static void TextBox_Disable_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                case Keys.Back:
                    e.Handled = true;
                    break;
            }
        }

        /// <summary>
        /// 텍스트 박스 숫자만
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBox_NumberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// 클릭 시, 커서 없애기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBox_HideCursor_Click(object sender, EventArgs e)
        {
            WinAPI.HideCaret(((System.Windows.Forms.TextBox)sender).Handle);
        }
        /// <summary>
        /// 클릭 시, 커서 없애기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBox_Got_Focus(object sender, EventArgs e)
        {
            WinAPI.HideCaret(((System.Windows.Forms.TextBox)sender).Handle);
        }

        /// <summary>
        /// 이를 사용하면 사용한 컨트롤의 MouseUp, Click이 작동하지 않음.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DragMoveWindowMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WinAPI.ReleaseCapture();
                Control panel;
                for (panel = (sender as Control); panel.Parent != null; panel = panel.Parent) ;
                //SendMessage((sender as Panel).Parent.Handle, WM_NCBUTTONDOWN, HT_CAPTION, 0);
                WinAPI.SendMessage(panel.Handle, (int) WindowsMessages.WM_NCLBUTTONDOWN, (int) CursorPositions.HTCAPTION, 0);
            }
        }

        /// <summary>
        /// 드래그 무브 이벤트, 주로 이 것을 사용
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DragMoveWindowMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WinAPI.ReleaseCapture();
                Control panel;
                for (panel = (sender as Control); panel.Parent != null; panel = panel.Parent) ;
                //SendMessage((sender as Panel).Parent.Handle, WM_NCBUTTONDOWN, HT_CAPTION, 0);
                WinAPI.SendMessage(panel.Handle, (int)WindowsMessages.WM_NCLBUTTONDOWN, (int)CursorPositions.HTCAPTION, 0);
            }
        }
    }
}
