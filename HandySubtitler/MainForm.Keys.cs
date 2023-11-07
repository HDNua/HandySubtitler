using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// 
/// </summary>
namespace HandySubtitler
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainForm
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="control"></param>
        /// <param name="shift"></param>
        /// <param name="key"></param>
        void CommonEvent_KeyDown(object sender, bool control, bool shift, Keys key)
        {
            /*
            if (control)
            {
                switch (key)
                {
                    case Keys.Q: RoutineQ(shift); break;
                    case Keys.W: RoutineW(shift); break;
                    case Keys.E: RoutineE(shift); break;
                    case Keys.R: RoutineR(shift); break;
                    case Keys.T: RoutineT(shift); break;
                    case Keys.X: RoutineX(shift); break;
                }
            }
            */
        }

        /// <summary>
        /// 키 입력 이벤트가 발생했습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        void CommonEvent_KeyDown(object sender, KeyEventArgs e)
        {
            bool btnControl = e.Control;
            bool btnShift = e.Shift;
            CommonEvent_KeyDown(sender, control: btnControl, shift: btnShift, key: (Keys)e.KeyCode);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CommonEvent_KeyDown(object sender, AxWMPLib._WMPOCXEvents_KeyDownEvent e)
        {
            bool btnControl = (e.nShiftState & 0b10) != 0;
            bool btnShift = (e.nShiftState & 0b01) != 0;
            CommonEvent_KeyDown(sender, control: btnControl, shift: btnShift, key: (Keys)e.nKeyCode);
        }
    }
}
