using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Text;
using System.Linq;

/// <summary>
/// 
/// </summary>
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

            //_GridView_Work.Rows.Insert(newRowIndex, WMP_GetCurrentFrameIndex(), EMPTY_LINE);
            GridView_InsertRow(
                rowIndex: newRowIndex,
                currentPosition: WMP_currentPosition,
                s: EMPTY_LINE
                );

            //
            _GridView_Work.CurrentCell = _GridView_Work.Rows[newRowIndex].Cells[0];
            GridView_Sort();
        }

        /// <summary>
        /// 
        /// </summary>
        double WMP_currentPosition
        {
            get
            {
                return _WMPObject.Ctlcontrols.currentPosition;
            }
            set
            {
                _WMPObject.Ctlcontrols.currentPosition = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="frameIndex"></param>
        /// <returns></returns>
        public int FindRowByFrameIndex(DataGridView dataGridView, int frameIndex)
        {
            // 이전 값 초기화 (첫 번째 행 이전을 가정)
            int previousValue = int.MinValue;

            //
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                // 첫 번째 열의 값이 null이면 건너뛴다.
                if (dataGridView.Rows[i].Cells[0].Value == null)
                    continue;

                // 현재 행의 첫 번째 셀의 값을 정수로 변환한다.
                int currentValue = Convert.ToInt32(dataGridView.Rows[i].Cells[0].Value);

                // 현재 값이 찾고자 하는 frameIndex와 같다면 해당 인덱스를 반환한다.
                if (currentValue == frameIndex)
                {
                    return i;
                }

                // frameIndex가 현재 값과 이전 값 사이에 있다면 이전 행의 인덱스를 반환한다.
                if (frameIndex > previousValue && frameIndex < currentValue)
                {
                    return i - 1;
                }

                // 다음 루프를 위해 현재 값을 이전 값으로 설정한다.
                previousValue = currentValue;
            }

            // 마지막 행을 검사한다: frameIndex가 마지막 값보다 크다면 마지막 행의 인덱스를 반환한다.
            if (frameIndex > previousValue)
            {
                return dataGridView.RowCount - 1;
            }

            // 찾고자 하는 값이 범위 내에 없다면 -1을 반환한다.
            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        public static List<int> GetColumnItemsAsInt(DataGridView dataGridView, int columnIndex)
        {
            // 첫 번째 열의 모든 셀 값을 정수 리스트로 변환합니다.
            // 여기서는 첫 번째 셀의 값이 null이 아니고 정수로 변환 가능하다고 가정합니다.
            var rowsList = dataGridView.Rows
                                       .Cast<DataGridViewRow>() // DataGridViewRow 컬렉션으로 캐스팅
                                       .Where(row => row.Cells[columnIndex].Value != null) // null이 아닌 셀만 필터링
                                       .Select(row => Convert.ToInt32(row.Cells[columnIndex].Value)) // 셀 값을 정수로 변환
                                       .ToList(); // 결과를 List<int>로 변환

            return rowsList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        public static List<string> GetColumnItemsAsString(DataGridView dataGridView, int columnIndex)
        {
            // 첫 번째 열의 모든 셀 값을 정수 리스트로 변환합니다.
            // 여기서는 첫 번째 셀의 값이 null이 아니고 정수로 변환 가능하다고 가정합니다.
            var rowsList = dataGridView.Rows
                                       .Cast<DataGridViewRow>() // DataGridViewRow 컬렉션으로 캐스팅
                                       .Where(row => row.Cells[columnIndex].Value != null) // null이 아닌 셀만 필터링
                                       .Select(row => row.Cells[columnIndex].Value.ToString()) // 셀 값을 문자열로 변환
                                       .ToList(); // 결과를 List<string>로 변환

            return rowsList;
        }

        /// <summary>
        /// 빈 줄을 추가합니다.
        /// </summary>
        void AddEmptyLine2()
        {
            double wmpCurrentPosition = WMP_currentPosition;

            // 새 행을 추가합니다.
            int newFrameIndex = WMP_GetFrameIndex(wmpCurrentPosition);
            int newRowIndex = _GridView_Work.RowCount;

            //
            DataGridViewCell cell;
            if (false)
            {
                cell = _GridView_Work.CurrentCell;
                if (cell != null)
                {
                    newRowIndex = _GridView_Work.CurrentCell.RowIndex + 1;
                }
            }
            else
            {
                newRowIndex = FindRowByFrameIndex(_GridView_Work, newFrameIndex);
            }

            //_GridView_Work.Rows.Insert(newRowIndex, WMP_GetCurrentFrameIndex(), EMPTY_LINE);
            var prevRow = _GridView_Work.Rows[newRowIndex];
            var prevRowData = GetSubLineRowData(prevRow);
            var nextRow = _GridView_Work.Rows[newRowIndex + 1];
            var nextRowData = GetSubLineRowData(nextRow);

            //
            if (nextRowData.FrameIndex == int.MaxValue)
            {
                // 새 줄을 넣습니다.
                GridView_InsertRow(
                    rowIndex: newRowIndex,
                    currentPosition: wmpCurrentPosition,
                    s: "텍스트 입력"
                    );

                // 3초 후에 새 줄을 넣습니다.
                GridView_InsertRow(
                    rowIndex: newRowIndex + 1,
                    currentPosition: wmpCurrentPosition + 3,
                    s: EMPTY_LINE
                    );
            }
            //
            else if (nextRowData.FrameIndex - prevRowData.FrameIndex == 3000)
            {
                var listFrameIndex = GetColumnItemsAsInt(_GridView_Work, CellIndex.FrameIndex);
                int ri;
                DataGridViewRow prevRow0 = null;
                SubLineData prevRowData0 = null;
                DataGridViewRow nextRow0 = null;
                SubLineData nextRowData0 = null;
                for (ri = newRowIndex; ri < listFrameIndex.Count; ++ri)
                {
                    prevRow0 = _GridView_Work.Rows[ri];
                    prevRowData0 = GetSubLineRowData(prevRow0);
                    nextRow0 = _GridView_Work.Rows[ri + 1];
                    nextRowData0 = GetSubLineRowData(nextRow0);

                    //
                    if (nextRowData0.FrameIndex - prevRowData0.FrameIndex > 3000)
                    {
                        break;
                    }
                }

                // 새 줄을 넣습니다.
                GridView_InsertRow(
                    rowIndex: ri,
                    currentPosition: prevRowData0.FrameIndex / 1000.0 + 3,
                    s: EMPTY_LINE
                    );
            }
            //
            else if (newFrameIndex - nextRowData.FrameIndex > 3000)
            {
                // 새 줄을 넣습니다.
                GridView_InsertRow(
                    rowIndex: newRowIndex,
                    currentPosition: wmpCurrentPosition,
                    s: "텍스트 입력"
                    );

                // 3초 후에 새 줄을 넣습니다.
                GridView_InsertRow(
                    rowIndex: newRowIndex + 1,
                    currentPosition: wmpCurrentPosition + 3,
                    s: EMPTY_LINE
                    );
            }

            //
            _GridView_Work.CurrentCell = _GridView_Work.Rows[newRowIndex].Cells[0];
            GridView_Sort();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        static SubLineData GetSubLineRowData(DataGridViewRow row)
        {
            SubLineData ret = new SubLineData();
            ret.FrameIndex = int.Parse(row.Cells[CellIndex.FrameIndex].Value.ToString());
            ret.SubtitleText = row.Cells[CellIndex.Text].Value.ToString();
            return ret;
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
            int rel = (int)(WMP_currentPosition * 1000);
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


        #endregion





        #region 이벤트 핸들러를 구현합니다.
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
