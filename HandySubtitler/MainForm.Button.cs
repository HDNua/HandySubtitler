using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



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
        #region FileMenu
        /// <summary>
        /// "새 자막" 버튼을 클릭했습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _FileMenuItem_NewProject_Click(object sender, EventArgs e)
        {
            NewProject();
        }
        /// <summary>
        /// "자막 열기" 버튼을 클릭했습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _FileMenuItem_OpenProject_Click(object sender, EventArgs e)
        {
            OpenProject();
        }
        /// <summary>
        /// "동영상 열기" 버튼을 클릭했습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _FileMenuItem_OpenMovie_Click(object sender, EventArgs e)
        {
            OpenMovie();
        }
        /// <summary>
        /// "SMI 임포트" 버튼을 클릭했습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _FileMenuItem_ImportSmi_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// "저장" 버튼을 클릭했습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _FileMenuItem_Save_Click(object sender, EventArgs e)
        {
            Save();
        }
        /// <summary>
        /// "다른 이름으로 저장" 버튼을 클릭했습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _FileMenuItem_SaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
        }
        /// <summary>
        /// "SMI 추출" 버튼을 클릭했습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _FileMenuItem_ExportSmi_Click(object sender, EventArgs e)
        {
            ExportSmi();
        }
        /// <summary>
        /// "SRT 추출" 버튼을 클릭했습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _FileMenuItem_ExportSrt_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// "끝내기" 버튼을 클릭했습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _FileMenuItem_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion





        #region EditMenu
        /// <summary>
        /// Undo 버튼을 클릭했습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _EditMenuItem_Undo_Click(object sender, EventArgs e)
        {
            Undo();
        }
        /// <summary>
        /// Redo 기능을 실행했습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _EditMenuItem_Redo_Click(object sender, EventArgs e)
        {
            Redo();
        }

        #endregion





        #region PlayMenu
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 정지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WMP_Stop();
        }

        #endregion





        #region ToolMenu
        /// <summary>
        /// "작업 폴더 열기" 버튼을 클릭했습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _ToolMenuItem_OpenDirectory_Click(object sender, EventArgs e)
        {
            OpenWorkingDirectory();
        }

        #endregion





        #region HelpMenu
        /// <summary>
        /// "만든 사람" 버튼을 클릭했습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _HelpMenuItem_Developer_Click(object sender, EventArgs e)
        {
            Handy.GUI.DeveloperDialog.ShowForm();
        }

        #endregion
    }
}
