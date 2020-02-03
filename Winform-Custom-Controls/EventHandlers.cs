using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform_Custom_Controls
{
    public class EventHandlers
    {
        /// <summary>
        /// 버튼이벤트 처리로 조회시작
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void BtnClickEventHandler(object sender, EventArgs e);
    }
}
