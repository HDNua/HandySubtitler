using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Text;

namespace HandySubtitler
{
    /// <summary>
    /// 자막 편집기 폼입니다.
    /// </summary>
    public partial class MainForm : Form
    {
        #region 상수를 정의합니다.
        /// <summary>
        /// 
        /// </summary>
        const string INITIAL_FILENAME = "";
        /// <summary>
        /// 
        /// </summary>
        const string EMPTY_LINE = "&nbsp;";


        #endregion



        #region 생성자를 정의합니다.
        /// <summary>
        /// 자막 편집기 폼입니다.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();


            // 그리드 뷰를 초기화합니다.
            GridView_Init();
            _SubViewer.DocumentText = "";

            // 타이머를 초기화합니다.
            _timer = new Timer();
            _timer.Interval = 10;
            _timer.Tick += TimerTick_Update;
            _timer.Start();

            // 포커스를 이동합니다.
            /// _GridView_Work.Focus();
        }


        #endregion









        #region 필드 및 프로퍼티를 정의합니다.
        /// <summary>
        /// 저장되었다면 참입니다.
        /// </summary>
        bool _saved = true;
        /// <summary>
        /// 저장되지 않았다면 거짓입니다.
        /// </summary>
        bool Saved
        {
            get { return _saved; }
            set
            {
                _saved = value;
                if (_saved)
                {
                    this.Text = _projectName;
                }
                else
                {
                    this.Text = _projectName + " *";
                }
            }
        }


        /// <summary>
        /// 작업중인 자막 프로젝트 파일의 이름입니다.
        /// </summary>
        string _projectName = INITIAL_FILENAME;
        /// <summary>
        /// 추출할 자막 파일의 이름입니다.
        /// </summary>
        string _subName;


        /// <summary>
        /// 업데이트 관리자입니다.
        /// </summary>
        Timer _timer;


        /// <summary>
        /// 
        /// </summary>
        int _updateFrameIndexDelta = 20;
        /// <summary>
        /// 
        /// </summary>
        double _defaultQ = 0.2;
        /// <summary>
        /// 
        /// </summary>
        double _defaultW = 0.2;
        /// <summary>
        /// 
        /// </summary>
        double _defaultE = 0.1;
        /// <summary>
        /// 
        /// </summary>
        double _defaultR = 2;


        #endregion










        #region 메서드를 정의합니다.
        /// <summary>
        /// 상태 표시줄에 로그를 남깁니다. string.Format()과 사용법이 같습니다.
        /// </summary>
        /// <param name="format">합성 형식 문자열입니다.</param>
        /// <param name="args">형식을 지정할 개체입니다.</param>
        void Log(string format, params object[] args)
        {
            _ToolStripStatusLabel.Text = string.Format(format, args);
        }




        /// <summary>
        /// 플레이어가 재생중인지 확인합니다.
        /// </summary>
        /// <returns>재생중이라면 참입니다.</returns>
        bool WMP_IsPlaying()
        {
            return _WMPObject.playState == WMPLib.WMPPlayState.wmppsPlaying;
        }

        /// <summary>
        /// 현재 프레임 인덱스를 얻습니다.
        /// </summary>
        /// <returns>현재 프레임 인덱스를 얻습니다.</returns>
        int WMP_GetCurrentFrameIndex()
        {
            return int.Parse(_TextBox_StartFrameIndex.Text.ToString()) + (int)(_WMPObject.Ctlcontrols.currentPosition * 1000);
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
            _WMPObject.Ctlcontrols.currentPosition = Clamp(time, 0, double.MaxValue);
        }
        /// <summary>
        /// 지정한 시간 이전 시간부터 다시 재생합니다.
        /// </summary>
        /// <param name="time">되돌릴 시간입니다.</param>
        void WMP_ReplayBefore(double time)
        {
            _WMPObject.Ctlcontrols.currentPosition = Clamp(_WMPObject.Ctlcontrols.currentPosition - time, 0, double.MaxValue);
        }




        /// <summary>
        /// 줄을 추가하고 화면을 정지합니다.
        /// </summary>
        void AddLine()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 빈 줄을 추가합니다.
        /// </summary>
        void AddEmptyLine()
        {
            // 새 행을 추가합니다.
            int newRowIndex = _GridView_Work.RowCount;
            DataGridViewCell cell = _GridView_Work.CurrentCell;
            if (cell != null)
            {
                newRowIndex = _GridView_Work.CurrentCell.RowIndex + 1;
            }
            _GridView_Work.Rows.Insert(newRowIndex, WMP_GetCurrentFrameIndex(), EMPTY_LINE);
            _GridView_Work.CurrentCell = _GridView_Work.Rows[newRowIndex].Cells[0];
            GridView_Sort();
        }


        /// <summary>
        /// 그리드 뷰를 초기화합니다.
        /// </summary>
        void GridView_Init()
        {
            _GridView_Work.Rows.Clear();
            _GridView_Work.Rows.Add(-1, EMPTY_LINE);
            _GridView_Work.Rows.Add(int.MaxValue, EMPTY_LINE);
            _GridView_Work.Rows[0].ReadOnly = true;
            _GridView_Work.Rows[1].ReadOnly = true;
        }
        /// <summary>
        /// 현재 행을 제거합니다. 제거할 수 없는 행이면 무시합니다.
        /// </summary>
        void GridView_DeleteRow()
        {
            _GridView_Work.Rows.Remove(_GridView_Work.CurrentRow);
        }
        /// <summary>
                 /// 그리드 뷰의 셀을 가져옵니다.
                 /// </summary>
                 /// <param name="rowIndex">가져올 셀의 행 인덱스입니다.</param>
                 /// <param name="columnIndex">가져올 셀의 열 인덱스입니다.</param>
                 /// <returns>그리드 뷰[행, 열]의 셀을 가져옵니다.</returns>
        DataGridViewCell GridView_GetCell(int rowIndex, int columnIndex)
        {
            return _GridView_Work.Rows[rowIndex].Cells[columnIndex];
        }
        /// <summary>
        /// 그리드 뷰의 셀의 값을 설정합니다.
        /// </summary>
        /// <param name="value">셀의 새 값입니다.</param>
        /// <param name="rowIndex">셀의 행 인덱스입니다.</param>
        /// <param name="columnIndex">셀의 열 인덱스입니다.</param>
        void GridView_SetCellValue(int value, int rowIndex, int columnIndex)
        {
            _GridView_Work.Rows[rowIndex].Cells[columnIndex].Value = value;
        }
        /// <summary>
        /// 그리드 뷰를 정렬합니다.
        /// </summary>
        void GridView_Sort()
        {
            _GridView_Work.Sort(_GridView_Work.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
        }
        /// <summary>
        /// 행 인덱스에 대한 프레임 인덱스를 가져옵니다.
        /// </summary>
        /// <param name="i">프레임 인덱스를 획득할 행 인덱스입니다.</param>
        /// <returns>인덱스에 대한 프레임 인덱스를 가져옵니다.</returns>
        int GetFrameIndexByRowIndex(int i)
        {
            DataGridViewRow row = _GridView_Work.Rows[i];
            DataGridViewCell cell = row.Cells[0];
            return int.Parse(cell.Value.ToString());
        }
        /// <summary>
        /// 시간에 맞는 자막 텍스트를 가져옵니다.
        /// </summary>
        /// <param name="index">자막 텍스트의 프레임 인덱스입니다.</param>
        /// <returns>프레임 인덱스에 대한 자막 텍스트를 반환합니다.</returns>
        string GetSubtitleTextByFrameIndex(int index)
        {
            int i, len;
            int prevIndex, nextIndex;

            for (i = 1, len = _GridView_Work.RowCount; i < len; ++i)
            {
                prevIndex = GetFrameIndexByRowIndex(i - 1);
                nextIndex = GetFrameIndexByRowIndex(i);
                if (prevIndex < index && index < nextIndex)
                {
                    break;
                }
            }
            if (i < len)
            {
                return _GridView_Work.Rows[i - 1].Cells[1].Value.ToString();
            }
            return string.Format(EMPTY_LINE);
        }
        /// <summary>
        /// 데이터 그리드 뷰로부터 자막 데이터 리스트를 생성하여 반환합니다.
        /// </summary>
        /// <returns>데이터 그리드 뷰로부터 자막 데이터 리스트를 생성하여 반환합니다.</returns>
        List<SubLineData> GridView_CreateSubtitleDataList()
        {
            List<SubLineData> ret = new List<SubLineData>();
            foreach (DataGridViewRow row in _GridView_Work.Rows)
            {
                SubLineData subtitleData = new SubLineData();
                subtitleData.FrameIndex = int.Parse(row.Cells[0].Value.ToString());
                subtitleData.SubtitleText = row.Cells[1].Value.ToString();
                ret.Add(subtitleData);
            }
            return ret;
        }
        /// <summary>
        /// 데이터 그리드 뷰를 자막 데이터 리스트로 업데이트합니다.
        /// </summary>
        /// <param name="subtitleDataList">자막 데이터 리스트입니다.</param>
        void GridView_OpenSubtitleDataList(List<SubLineData> subtitleDataList)
        {
            _GridView_Work.Rows.Clear();
            foreach (SubLineData data in subtitleDataList)
            {
                _GridView_Work.Rows.Add(data.FrameIndex, data.SubtitleText);
            }
            _GridView_Work.Rows[0].ReadOnly = true;
            _GridView_Work.Rows[_GridView_Work.RowCount - 1].ReadOnly = true;
        }
        /// <summary>
        /// 서로 셀 값이 같은지 확인합니다.
        /// </summary>
        /// <param name="v1">왼쪽 값입니다.</param>
        /// <param name="v2">오른쪽 값입니다.</param>
        /// <returns>서로 같으면 참, 다르면 거짓을 반환합니다.</returns>
        private bool GridView_IsSameCellValue(object v1, object v2)
        {
            if (v1 == null && v2 == null)
            {
                return true;
            }
            else if (v1 == null)
            {
                return v2.ToString() == "";
            }
            else if (v2 == null)
            {
                return v1.ToString() == "";
            }
            return v1.ToString() == v2.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="delta"></param>
        private void GridView_UpdateCurrentCellFrameIndexDelta(int delta)
        {
            DataGridViewCell cell = GridView_GetCell(_GridView_Work.CurrentCell.RowIndex, 0);
            int value = Clamp((int)cell.Value + delta, 0, int.MaxValue);
            GridView_SetCellValue(value, cell.RowIndex, 0);
        }


        /// <summary>
        /// 인덱스가 지정된 범위 내[v1, v2]에 있는지 확인합니다.
        /// </summary>
        /// <param name="index">범위를 확인할 인덱스입니다.</param>
        /// <param name="v1">범위의 최솟값입니다.</param>
        /// <param name="v2">범위의 최댓값입니다.</param>
        /// <returns>인덱스가 지정된 범위 내[v1, v2]에 있다면 참입니다.</returns>
        bool IsIndexInRange(int index, int v1, int v2)
        {
            return (v1 <= index && index <= v2);
        }
        /// <summary>
        /// 범위 내에서 값을 반환합니다.
        /// </summary>
        /// <typeparam name="T">비교 가능한(IComparable) 형식입니다.</typeparam>
        /// <param name="value">사용할 값입니다.</param>
        /// <param name="minValue">최솟값입니다.</param>
        /// <param name="maxValue">최댓값입니다.</param>
        /// <returns>최솟값보다 작으면 최솟값, 최댓값보다 크면 최댓값, 그 외의 경우 원래 값을 반환합니다.</returns>
        private T Clamp<T>(T value, T minValue, T maxValue) where T : IComparable<T>
        {
            if (value.CompareTo(minValue) < 0) return minValue;
            if (value.CompareTo(maxValue) > 0) return maxValue;
            return value;
        }


        /// <summary>
        /// 저장 확인 다이얼로그를 생성합니다.
        /// </summary>
        /// <returns>확인 버튼이 눌렸다면 참입니다.</returns>
        bool OpenSaveConfirmDialog()
        {
            Handy.GUI.ConfirmDialog dialog = new Handy.GUI.ConfirmDialog("파일이 저장되지 않았습니다! 저장 없이 진행합니까?");
            return (dialog.ShowDialog() == DialogResult.OK);
        }


        #endregion










        #region 버튼 이벤트 핸들러를 정의합니다.
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


        /// <summary>
        /// "작업 폴더 열기" 버튼을 클릭했습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _ToolMenuItem_OpenDirectory_Click(object sender, EventArgs e)
        {
            OpenWorkingDirectory();
        }
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










        #region 이벤트 핸들러를 정의합니다.
        /// <summary>
        /// 병렬로 처리되는 루틴입니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void TimerTick_Update(object sender, EventArgs e)
        {
            if (WMP_IsPlaying() == false)
            {
                return;
            }

            // 프레임 인덱스를 업데이트합니다.
            int frameIndex = WMP_GetCurrentFrameIndex();
            _TextBox_FrameIndex.Text = frameIndex.ToString();

            // 프레임 인덱스에 대한 텍스트를 가져온 후 뷰어를 업데이트합니다.
            string text = GetSubtitleTextByFrameIndex(frameIndex);
            _SubViewer.Document.OpenNew(true);
            _SubViewer.Document.Write(text);
        }
        /// <summary>
        /// 키 입력 이벤트가 발생했습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void CommonEvent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                bool shift = e.Shift;
                switch (e.KeyCode)
                {
                    case Keys.Q: RoutineQ(shift); break;
                    case Keys.W: RoutineW(shift); break;
                    case Keys.E: RoutineE(shift); break;
                    case Keys.R: RoutineR(shift); break;
                    case Keys.T: RoutineT(shift); break;
                }
            }
        }


        /// <summary>
        /// Q 간격 텍스트 박스에서 키가 눌렸습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _TextBox_QInterval_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                _GridView_Work.Focus();
            }
        }
        /// <summary>
        /// W 간격 텍스트 박스에서 키가 눌렸습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _TextBox_WInterval_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                _GridView_Work.Focus();
            }
        }
        /// <summary>
        /// E 간격 텍스트 박스에서 키가 눌렸습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _TextBox_EInterval_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                _GridView_Work.Focus();
            }
        }
        /// <summary>
        /// R 간격 텍스트 박스에서 키가 눌렸습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _TextBox_RInterval_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                _GridView_Work.Focus();
            }
        }
        /// <summary>
        /// Q 간격 텍스트박스의 유효성 검사를 진행합니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _TextBox_QInterval_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                double.Parse(_TextBox_QInterval.Text);
            }
            catch (Exception)
            {
                /// e.Cancel = true;
                _TextBox_QInterval.Text = _defaultQ.ToString();
                Log("잘못된 Q 간격 값입니다.");
            }
        }
        /// <summary>
        /// W 간격 텍스트박스의 유효성 검사를 진행합니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _TextBox_WInterval_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                double.Parse(_TextBox_WInterval.Text);
            }
            catch (Exception)
            {
                /// e.Cancel = true;
                _TextBox_WInterval.Text = _defaultW.ToString();
                Log("잘못된 W 간격 값입니다.");
            }
        }
        /// <summary>
        /// E 간격 텍스트박스의 유효성 검사를 진행합니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _TextBox_EInterval_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                double.Parse(_TextBox_EInterval.Text);
            }
            catch (Exception)
            {
                /// e.Cancel = true;
                _TextBox_EInterval.Text = _defaultE.ToString();
                Log("잘못된 E 간격 값입니다.");
            }
        }
        /// <summary>
        /// R 간격 텍스트박스의 유효성 검사를 진행합니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _TextBox_RInterval_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                double.Parse(_TextBox_RInterval.Text);
            }
            catch (Exception)
            {
                /// e.Cancel = true;
                _TextBox_RInterval.Text = _defaultR.ToString();
                Log("잘못된 R 간격 값입니다.");
            }
        }


        /// <summary>
        /// 시작 프레임 인덱스 텍스트 박스의 유효성을 검사합니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _TextBox_StartFrameIndex_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                int.Parse(_TextBox_StartFrameIndex.Text);
            }
            catch (Exception)
            {
                _TextBox_StartFrameIndex.Text = "0";
                Log("잘못된 시작 프레임 인덱스");
            }
        }
        /// <summary>
        /// 시작 프레임 인덱스 텍스트 박스에서 키가 눌렸습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _TextBox_StartFrameIndex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                _GridView_Work.Focus();
            }
        }


        /// <summary>
        /// MainForm에서 KeyDown이 발생했습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            CommonEvent_KeyDown(sender, e);
        }
        /// <summary>
        /// MainForm을 닫으려고 했습니다. 폼이 닫히기 전에 발생합니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm_OnClose(sender, e);
        }


        /// <summary>
        /// 플레이어의 position이 사용자에 의해 변경되었습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _WMPObject_PositionChange(object sender, AxWMPLib._WMPOCXEvents_PositionChangeEvent e)
        {
            int rel = (int)(_WMPObject.Ctlcontrols.currentPosition * 1000);
            int abs = int.Parse(_TextBox_StartFrameIndex.Text) + rel;
            Log("Relative: {0} / Absolute: {1}", rel, abs);
        }


        /// <summary>
        /// SubEditor에서 텍스트가 변경되었습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _SubEditor_TextChanged(object sender, EventArgs e)
        {
            Saved = false;
        }
        /// <summary>
        /// SubEditor에서 키가 눌렸습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _SubEditor_KeyDown(object sender, KeyEventArgs e)
        {
            CommonEvent_KeyDown(sender, e);
        }


        /// <summary>
        /// 작업 그리드 뷰에서 키가 눌렸습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _GridView_Work_KeyDown(object sender, KeyEventArgs e)
        {
            CommonEvent_KeyDown(sender, e);


            // 수정할 수 없는 행이면 무시합니다.
            if (IsIndexInRange(_GridView_Work.CurrentRow.Index, 1, _GridView_Work.RowCount - 2))
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        GridView_DeleteRow();
                        break;

                    case Keys.PageUp:
                        GridView_UpdateCurrentCellFrameIndexDelta(-_updateFrameIndexDelta);
                        break;

                    case Keys.PageDown:
                        GridView_UpdateCurrentCellFrameIndexDelta(_updateFrameIndexDelta);
                        break;
                }
            }
        }


        /// <summary>
        /// 사용자가 행을 삭제하려고 했습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _GridView_Work_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // 삭제할 수 없는 행에 대해 요청을 취소합니다.
            if (e.Row.Index == 0 || e.Row.Index == _GridView_Work.RowCount - 1)
            {
                e.Cancel = true;
            }
            Saved = false;
        }
        /// <summary>
        /// 셀 타당성 검사를 진행합니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _GridView_Work_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // 값이 변하지 않은 경우 그냥 종료합니다.
            DataGridViewCell cell = GridView_GetCell(e.RowIndex, e.ColumnIndex);
            if (GridView_IsSameCellValue(cell.Value, e.FormattedValue))
            {
                return;
            }


            // 행 인덱스가 0인 경우, 즉 시간 축에 대해서만 유효성 검사를 진행합니다.
            if (e.ColumnIndex == 0)
            {
                try
                {
                    // 사실상 integer 파싱이 실패하면, 유효하지 않은 것으로 간주되고 값 변경은 취소됩니다.
                    GridView_SetCellValue(int.Parse(e.FormattedValue.ToString()), e.RowIndex, e.ColumnIndex);
                }
                catch (Exception)
                {
                    e.Cancel = true;
                }
            }
            Saved = false;
        }


        /// <summary>
        /// 셀 타당성 검사가 끝났습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _GridView_Work_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            // 문자열로 입력되었을 가능성이 있는 셀에 대해 정수로 캐스팅합니다.
            if (e.ColumnIndex == 0)
            {
                GridView_SetCellValue(int.Parse(GridView_GetCell(e.RowIndex, e.ColumnIndex).Value.ToString()), e.RowIndex, e.ColumnIndex);
            }
        }
        /// <summary>
        /// 셀 편집이 종료되었습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _GridView_Work_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // 셀 편집 종료 즉시 열 정렬을 진행합니다.
            // http://stackoverflow.com/questions/26522927/how-to-evade-reentrant-call-to-setcurrentcelladdresscore
            this.BeginInvoke(new MethodInvoker(() =>
            {
                GridView_Sort();
            }));
        }


        #endregion










        #region 이벤트 핸들러를 구현합니다.
        /// <summary>
        /// Q 버튼에 대한 루틴입니다.
        /// </summary>
        /// <param name="shift">쉬프트 키가 눌려있는지를 표현합니다.</param>
        void RoutineQ(bool shift)
        {
            if (shift)
            {
                WMP_Pause();
                _TextBox_QInterval.Focus();
            }
            else
            {
                WMP_Pause();
                WMP_ReplayBefore(double.Parse(_TextBox_QInterval.Text));
                AddEmptyLine();
            }
        }
        /// <summary>
        /// W 버튼에 대한 루틴입니다.
        /// </summary>
        /// <param name="shift">쉬프트 키가 눌려있는지를 표현합니다.</param>
        void RoutineW(bool shift)
        {
            if (shift)
            {
                WMP_Pause();
                _TextBox_WInterval.Focus();
            }
            else
            {
                WMP_ReplayBefore(double.Parse(_TextBox_WInterval.Text));
                AddEmptyLine();
            }
        }
        /// <summary>
        /// E 버튼에 대한 루틴입니다.
        /// </summary>
        /// <param name="shift">쉬프트 키가 눌려있는지를 표현합니다.</param>
        void RoutineE(bool shift)
        {
            if (shift)
            {
                WMP_Pause();
                _TextBox_EInterval.Focus();
            }
            else
            {
                WMP_ReplayBefore(double.Parse(_TextBox_EInterval.Text));
                AddEmptyLine();
            }
        }
        /// <summary>
        /// R 버튼에 대한 루틴입니다.
        /// </summary>
        /// <param name="shift">쉬프트 키가 눌려있는지를 표현합니다.</param>
        void RoutineR(bool shift)
        {
            if (shift)
            {
                WMP_Pause();
                _TextBox_RInterval.Focus();
            }
            else
            {
                WMP_Play();
                WMP_ReplayBefore(double.Parse(_TextBox_RInterval.Text));
            }
        }
        /// <summary>
        /// T 버튼에 대한 루틴입니다.
        /// </summary>
        /// <param name="shift">쉬프트 키가 눌려있는지를 표현합니다.</param>
        void RoutineT(bool shift)
        {
            if (WMP_IsPlaying())
            {
                WMP_Pause();
            }
            else
            {
                WMP_Play();
            }
        }


        /// <summary>
        /// 새 프로젝트를 생성합니다.
        /// </summary>
        void NewProject()
        {
            // 저장이 되지 않았다면
            if (Saved == false)
            {
                // 저장 확인 다이얼로그가 취소되었다면
                // 사용자가 저장 없이 계속 진행하지 않겠다고 했다면
                if (OpenSaveConfirmDialog() == false)
                {
                    // 새 프로젝트 생성을 중단합니다.
                    return;
                }
            }


            // 그리드 뷰를 초기화합니다.
            GridView_Init();
            Saved = true;
        }
        /// <summary>
        /// 자막 프로젝트 파일(*.sub)을 엽니다.
        /// </summary>
        void OpenProject()
        {
            if (Saved == false)
            {
                // 저장 확인 다이얼로그가 취소되었다면
                // 사용자가 저장 없이 계속 진행하지 않겠다고 했다면
                if (OpenSaveConfirmDialog() == false)
                {
                    // 새 프로젝트 생성을 중단합니다.
                    return;
                }
            }


            // 자막 파일 열기에 성공한 경우의 처리입니다.
            if (_OpenSubtitleDialog.ShowDialog() == DialogResult.OK)
            {
                _projectName = _OpenSubtitleDialog.FileName;
                Stream fin = new FileStream(_projectName, FileMode.Open);
                BinaryFormatter deserializer = new BinaryFormatter();
                List<SubLineData> datalist =
                    (List<SubLineData>)deserializer.Deserialize(fin);
                fin.Close();

                GridView_OpenSubtitleDataList(datalist);


                // 타이틀을 업데이트합니다.
                Saved = true;
            }
        }
        /// <summary>
        /// 동영상을 엽니다.
        /// </summary>
        void OpenMovie()
        {
            if (_OpenMediaDialog.ShowDialog() == DialogResult.OK)
            {
                _WMPObject.URL = _OpenMediaDialog.FileName;
                WMP_Stop();
            }
        }
        /// <summary>
        /// 자막 프로젝트(*.sub)를 저장합니다.
        /// </summary>
        void Save()
        {
            if (_projectName == INITIAL_FILENAME)
            {
                SaveAs();
            }
            else if (Saved == false)
            {
                List<SubLineData> datalist = GridView_CreateSubtitleDataList();

                // 파일로 자막을 저장합니다.
                Stream fout = new FileStream(_projectName, FileMode.Create);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(fout, datalist);
                fout.Close();

                // 필드 및 속성을 업데이트합니다.
                Saved = true;
            }
        }
        /// <summary>
        /// 다른 이름으로 프로젝트를 저장합니다.
        /// </summary>
        void SaveAs()
        {
            if (_SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _projectName = _SaveFileDialog.FileName;
                Save();
            }
        }
        /// <summary>
        /// SMI 파일을 추출합니다.
        /// </summary>
        void ExportSmi()
        {
            if (true) // (_subName == "")
            {
                if (_SaveSmiDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                _subName = _SaveSmiDialog.FileName;
            }


            // SMI 파일을 출력합니다.
            StringWriter sw = new StringWriter();
            foreach (DataGridViewRow row in _GridView_Work.Rows)
            {
                int frameIndex = int.Parse(row.Cells[0].Value.ToString());
                string subText = row.Cells[1].Value.ToString();
                sw.WriteLine("<SYNC START={0}><P Class=KRCC>", frameIndex);
                sw.WriteLine(subText);
            }
            sw.Close();

            // 출력한 텍스트를 파일에 기록합니다.
            StreamWriter fout = new StreamWriter(new FileStream(_subName, FileMode.Create), Encoding.Default);
            fout.Write(sw.ToString());
            fout.Close();

            // 로그를 출력합니다.
            Log("SMI 추출 완료");
        }
        /// <summary>
        /// SRT 파일을 추출합니다.
        /// </summary>
        void ExportSrt()
        {
            Log("SRT 추출 완료 (사실 아무것도 하지 않음)");
        }


        /// <summary>
        /// 최근의 실행을 취소합니다.
        /// </summary>
        void Undo()
        {
            Log("Undo activated");
        }
        /// <summary>
        /// 최근이 취소한 행동을 다시 실행합니다.
        /// </summary>
        void Redo()
        {
            Log("Redo activated");
        }


        /// <summary>
        /// 작업 폴더를 엽니다.
        /// </summary>
        void OpenWorkingDirectory()
        {
            Process.Start("explorer.exe", Environment.CurrentDirectory);
        }


        /// <summary>
        /// MainForm을 닫으려고 했습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        void MainForm_OnClose(object sender, FormClosingEventArgs e)
        {
            if (Saved)
            {

            }
            else
            {
                // 저장 확인 다이얼로그에서 취소를 눌렀다면
                if (OpenSaveConfirmDialog() == false)
                {
                    // 종료를 취소합니다.
                    e.Cancel = true;
                }
            }
        }


        #endregion










        #region 구형 정의를 보관합니다.


        #endregion
    }
}
