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
        #region WMP
        /// <summary>
        /// 플레이어가 재생중인지 확인합니다.
        /// </summary>
        /// <returns>재생중이라면 참입니다.</returns>
        bool WMP_IsPlaying()
        {
            return _WMPObject.playState == WMPLib.WMPPlayState.wmppsPlaying;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="wmpCurrentPosition"></param>
        /// <returns></returns>
        int WMP_GetFrameIndex(double wmpCurrentPosition)
        {
            return int.Parse(_TextBox_StartFrameIndex.Text.ToString())
                + (int)(wmpCurrentPosition * 1000);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wmpCurrentPosition"></param>
        /// <returns></returns>
        string WMP_GetFrameTimeString(double wmpCurrentPosition)
        {
            // TimeSpan 객체를 사용하여 초를 시간 포맷으로 변환합니다.
            TimeSpan timeSpan = TimeSpan.FromSeconds(wmpCurrentPosition);

            // 시간 포맷을 문자열로 변환하여 UI에 표시합니다. 예: "00:03:27"
            return timeSpan.ToString(@"hh\:mm\:ss");
        }


        /// <summary>
        /// 현재 프레임 인덱스를 얻습니다.
        /// </summary>
        /// <returns>현재 프레임 인덱스를 얻습니다.</returns>
        int WMP_GetCurrentFrameIndex()
        {
            return int.Parse(_TextBox_StartFrameIndex.Text.ToString())
                + (int)(WMP_currentPosition * 1000);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string WMP_GetCurrentFrameTimeString()
        {
            // TimeSpan 객체를 사용하여 초를 시간 포맷으로 변환합니다.
            TimeSpan timeSpan = TimeSpan.FromSeconds(WMP_currentPosition);

            // 시간 포맷을 문자열로 변환하여 UI에 표시합니다. 예: "00:03:27"
            return timeSpan.ToString(@"hh\:mm\:ss");
        }

        /// <summary>
        /// 동영상을 재생합니다.
        /// </summary>
        void WMP_Play()
        {
            _WMPObject.Ctlcontrols.play();
        }
        /// <summary>
        /// 플레이어 재생을 일지 정지합니다.
        /// </summary>
        void WMP_Pause()
        {
            _WMPObject.Ctlcontrols.pause();
        }
        /// <summary>
        /// 플레이어 재생을 중지합니다.
        /// </summary>
        void WMP_Stop()
        {
            _WMPObject.Ctlcontrols.stop();
        }
        /// <summary>
        /// 지정된 시간부터 다시 재생합니다.
        /// </summary>
        /// <param name="time">다시 시작할 시간입니다.</param>
        void WMP_ReplayFrom(double time)
        {
            WMP_currentPosition = Common.Clamp(time, 0, double.MaxValue);
        }
        /// <summary>
        /// 지정한 시간 이전 시간부터 다시 재생합니다.
        /// </summary>
        /// <param name="time">되돌릴 시간입니다.</param>
        void WMP_ReplayBefore(double time)
        {
            WMP_currentPosition = Common.Clamp(WMP_currentPosition - time, 0, double.MaxValue);
        }

        #endregion





        #region MyRegion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _WMPObject_KeyDownEvent(object sender, AxWMPLib._WMPOCXEvents_KeyDownEvent e)
        {
            CommonEvent_KeyDown(sender, e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _WMPObject_KeyPressEvent(object sender, AxWMPLib._WMPOCXEvents_KeyPressEvent e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _WMPObject_KeyUpEvent(object sender, AxWMPLib._WMPOCXEvents_KeyUpEvent e)
        {

        }

        #endregion
    }
}
