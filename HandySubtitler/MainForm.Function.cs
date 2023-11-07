using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
        /// Q 버튼에 대한 루틴입니다.
        /// </summary>
        /// <param name="shift">쉬프트 키가 눌려있는지를 표현합니다.</param>
        void RoutineCQ(bool shift)
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
        void RoutineCW(bool shift)
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
        void RoutineCE(bool shift)
        {
            if (shift)
            {
                WMP_Pause();
                _TextBox_EInterval.Focus();
            }
            else
            {
                WMP_ReplayBefore(double.Parse(_TextBox_EInterval.Text));
                AddEmptyLine2();
            }
        }
        /// <summary>
        /// R 버튼에 대한 루틴입니다.
        /// </summary>
        /// <param name="shift">쉬프트 키가 눌려있는지를 표현합니다.</param>
        void RoutineCR(bool shift)
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
        void RoutineCT(bool shift)
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
        /// 
        /// </summary>
        /// <param name="shift"></param>
        void RoutineX(bool shift)
        {
            if (WMP_IsPlaying())
            {
                WMP_Pause();
            }
            else
            {
                WMP_Play();
            }
            WMP_Stop();
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

                //
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
                int frameIndex = int.Parse(row.Cells[CellIndex.FrameIndex].Value.ToString());
                string subText = row.Cells[CellIndex.Text].Value.ToString();
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
    }
}
