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
        #region 상수 및 공용 형식을 정의합니다.

        #endregion



        #region 초기화 함수를 정의합니다.
        /// <summary>
        /// 그리드 뷰를 초기화합니다.
        /// </summary>
        void GridView_Init()
        {
            _GridView_Work.Rows.Clear();

            GridView_AddRow(-1, EMPTY_LINE);
            GridView_AddRow(int.MaxValue, EMPTY_LINE);

            _GridView_Work.Rows[0].ReadOnly = true;
            _GridView_Work.Rows[1].ReadOnly = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameIndex"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        int GridView_AddRow(int frameIndex, string s)
        {
            string timeString = "00:00:00";
            if (frameIndex == int.MaxValue)
            {
                timeString = "00:00:00";
            }
            else
            {
                timeString = WMP_GetFrameTimeString(WMP_currentPosition);
            }
            _GridView_Work.Rows.Add(frameIndex, timeString, s);
            return frameIndex;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="currentPosition"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        int GridView_InsertRow(int rowIndex, double currentPosition, string s)
        {
            int frameIndex = WMP_GetFrameIndex(currentPosition);
            string frameTime = WMP_GetFrameTimeString(currentPosition);
            _GridView_Work.Rows.Insert(rowIndex, frameIndex, frameTime, s);

            //
            return frameIndex;
        }


        #endregion





        #region 속성을 정의합니다.
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

        #endregion





        #region 기타 기본 함수를 정의합니다.
        /// <summary>
        /// 현재 행을 제거합니다. 제거할 수 없는 행이면 무시합니다.
        /// </summary>
        void GridView_DeleteRow()
        {
            _GridView_Work.Rows.Remove(_GridView_Work.CurrentRow);
        }
        /// <summary>
        /// 그리드 뷰를 정렬합니다.
        /// </summary>
        void GridView_Sort()
        {
            _GridView_Work.Sort(_GridView_Work.Columns[CellIndex.FrameIndex], System.ComponentModel.ListSortDirection.Ascending);
        }
        /// <summary>
        /// 
        /// </summary>
        void GridView_UpdateTimeString()
        {
            foreach (DataGridViewRow row in _GridView_Work.Rows)
            {
                var data = GetSubLineRowData(row);
                if (data.FrameIndex == -1 || data.FrameIndex == int.MaxValue)
                {
                    continue;
                }
                row.SetValues(data.FrameIndex, WMP_GetFrameTimeString(data.FrameIndex / 1000.0), data.SubtitleText);
            }
        }


        /// <summary>
        /// 서로 셀 값이 같은지 확인합니다.
        /// </summary>
        /// <param name="v1">왼쪽 값입니다.</param>
        /// <param name="v2">오른쪽 값입니다.</param>
        /// <returns>서로 같으면 참, 다르면 거짓을 반환합니다.</returns>
        static bool GridView_IsSameCellValue(object v1, object v2)
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

        #endregion





        #region GridView 함수를 정의합니다.

        /// <summary>
        /// 행 인덱스에 대한 프레임 인덱스를 가져옵니다.
        /// </summary>
        /// <param name="i">프레임 인덱스를 획득할 행 인덱스입니다.</param>
        /// <returns>인덱스에 대한 프레임 인덱스를 가져옵니다.</returns>
        int GetFrameIndexByRowIndex(int i)
        {
            DataGridViewRow row = _GridView_Work.Rows[i];
            DataGridViewCell cell = row.Cells[CellIndex.FrameIndex];
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
                return _GridView_Work.Rows[i - 1].Cells[CellIndex.Text].Value.ToString();
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
                subtitleData.FrameIndex = int.Parse(row.Cells[CellIndex.FrameIndex].Value.ToString());
                subtitleData.SubtitleText = row.Cells[CellIndex.Text].Value.ToString();
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
                int frameIndex = data.FrameIndex;
                double framePosition = frameIndex / 1000.0;
                string timeString = WMP_GetFrameTimeString(framePosition);

                //
                _GridView_Work.Rows.Add(frameIndex, timeString, data.SubtitleText);
            }
            _GridView_Work.Rows[0].ReadOnly = true;
            _GridView_Work.Rows[_GridView_Work.RowCount - 1].ReadOnly = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="delta"></param>
        private void GridView_UpdateCurrentCellFrameIndexDelta(int delta)
        {
            DataGridViewCell cell = GridView_GetCell(_GridView_Work.CurrentCell.RowIndex, CellIndex.FrameIndex);
            int value = Common.Clamp((int)cell.Value + delta, 0, int.MaxValue);
            GridView_SetCellValue(value, cell.RowIndex, CellIndex.FrameIndex);
        }

        #endregion





        #region 이벤트 핸들러를 정의합니다.
        /// <summary>
        /// 작업 그리드 뷰에서 키가 눌렸습니다.
        /// </summary>
        /// <param name="sender">이벤트가 발생한 객체입니다.</param>
        /// <param name="e">이벤트 정보를 담은 객체입니다.</param>
        private void _GridView_Work_KeyDown(object sender, KeyEventArgs e)
        {
            CommonEvent_KeyDown(sender, e);

            // 수정할 수 없는 행이면 무시합니다.
            if (Common.IsIndexInRange(_GridView_Work.CurrentRow.Index, 1, _GridView_Work.RowCount - 2))
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
                GridView_UpdateTimeString();
            }));
        }

        #endregion
    }
}
