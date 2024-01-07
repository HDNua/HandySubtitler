namespace HandySubtitler
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this._Label_StartFrameIndex = new System.Windows.Forms.Label();
            this._TextBox_StartFrameIndex = new System.Windows.Forms.TextBox();
            this._Label_WInterval = new System.Windows.Forms.Label();
            this._Label_EInterval = new System.Windows.Forms.Label();
            this._TextBox_Interval_E = new System.Windows.Forms.TextBox();
            this._TextBox_Interval_W = new System.Windows.Forms.TextBox();
            this._Label_FrameIndex = new System.Windows.Forms.Label();
            this._TextBox_FrameIndex = new System.Windows.Forms.TextBox();
            this._Label_QInterval = new System.Windows.Forms.Label();
            this._TextBox_Interval_Q = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._Label_RInterval = new System.Windows.Forms.Label();
            this._TextBox_Interval_T = new System.Windows.Forms.TextBox();
            this._TextBox_Interval_R = new System.Windows.Forms.TextBox();
            this._SubViewer = new System.Windows.Forms.WebBrowser();
            this._Tab_Editor = new System.Windows.Forms.TabControl();
            this._TabPage_Work = new System.Windows.Forms.TabPage();
            this._GridView_Work = new System.Windows.Forms.DataGridView();
            this._GridView_Frame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._GridView_T = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._GridView_Text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._TabPage_Source = new System.Windows.Forms.TabPage();
            this._SubEditor = new System.Windows.Forms.RichTextBox();
            this._MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this._FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._FileMenuItem_NewProject = new System.Windows.Forms.ToolStripMenuItem();
            this._FileMenuItem_OpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this._FileMenuItem_OpenMovie = new System.Windows.Forms.ToolStripMenuItem();
            this._FileMenuItem_ImportSmi = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._FileMenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
            this._FileMenuItem_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this._FileMenuItem_ExportSmi = new System.Windows.Forms.ToolStripMenuItem();
            this._FileMenuIteM_ExportSrt = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._FileMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this._EditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._EditMenuItem_Undo = new System.Windows.Forms.ToolStripMenuItem();
            this._EditMenuItem_Redo = new System.Windows.Forms.ToolStripMenuItem();
            this.재생ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.재생ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.일시정지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.정지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolMenuItem_OpenDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this._HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._HelpMenuItem_Developer = new System.Windows.Forms.ToolStripMenuItem();
            this.단축키ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.행동QToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skqToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skcqToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sksqToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skcsqToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.행동WToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skwToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skcwToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skswToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skcswToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.행동EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skcseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.행동RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skcrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sksrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skcsrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.행동TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sktToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skctToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skcstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.행동AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.행동SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skcsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skssToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skcssToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.행동DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.행동FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.행동GToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._OpenSubtitleDialog = new System.Windows.Forms.OpenFileDialog();
            this._SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this._StatusStrip = new System.Windows.Forms.StatusStrip();
            this._ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._OpenMediaDialog = new System.Windows.Forms.OpenFileDialog();
            this._SaveSmiDialog = new System.Windows.Forms.SaveFileDialog();
            this._WMPObject = new AxWMPLib.AxWindowsMediaPlayer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this._Tab_Editor.SuspendLayout();
            this._TabPage_Work.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._GridView_Work)).BeginInit();
            this._TabPage_Source.SuspendLayout();
            this._MainMenuStrip.SuspendLayout();
            this._StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._WMPObject)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._Tab_Editor);
            this.splitContainer1.Size = new System.Drawing.Size(1693, 711);
            this.splitContainer1.SplitterDistance = 731;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this._WMPObject);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(731, 711);
            this.splitContainer2.SplitterDistance = 373;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this._Label_StartFrameIndex);
            this.splitContainer3.Panel1.Controls.Add(this._TextBox_StartFrameIndex);
            this.splitContainer3.Panel1.Controls.Add(this._Label_WInterval);
            this.splitContainer3.Panel1.Controls.Add(this._Label_EInterval);
            this.splitContainer3.Panel1.Controls.Add(this._TextBox_Interval_E);
            this.splitContainer3.Panel1.Controls.Add(this._TextBox_Interval_W);
            this.splitContainer3.Panel1.Controls.Add(this._Label_FrameIndex);
            this.splitContainer3.Panel1.Controls.Add(this._TextBox_FrameIndex);
            this.splitContainer3.Panel1.Controls.Add(this._Label_QInterval);
            this.splitContainer3.Panel1.Controls.Add(this.textBox1);
            this.splitContainer3.Panel1.Controls.Add(this._TextBox_Interval_Q);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this._Label_RInterval);
            this.splitContainer3.Panel1.Controls.Add(this._TextBox_Interval_T);
            this.splitContainer3.Panel1.Controls.Add(this._TextBox_Interval_R);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this._SubViewer);
            this.splitContainer3.Size = new System.Drawing.Size(731, 334);
            this.splitContainer3.SplitterDistance = 100;
            this.splitContainer3.TabIndex = 2;
            // 
            // _Label_StartFrameIndex
            // 
            this._Label_StartFrameIndex.AutoSize = true;
            this._Label_StartFrameIndex.Location = new System.Drawing.Point(8, 33);
            this._Label_StartFrameIndex.Name = "_Label_StartFrameIndex";
            this._Label_StartFrameIndex.Size = new System.Drawing.Size(69, 12);
            this._Label_StartFrameIndex.TabIndex = 11;
            this._Label_StartFrameIndex.Text = "시작 인덱스";
            // 
            // _TextBox_StartFrameIndex
            // 
            this._TextBox_StartFrameIndex.Location = new System.Drawing.Point(95, 30);
            this._TextBox_StartFrameIndex.Name = "_TextBox_StartFrameIndex";
            this._TextBox_StartFrameIndex.Size = new System.Drawing.Size(141, 21);
            this._TextBox_StartFrameIndex.TabIndex = 10;
            this._TextBox_StartFrameIndex.Text = "0";
            this._TextBox_StartFrameIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._TextBox_StartFrameIndex.KeyDown += new System.Windows.Forms.KeyEventHandler(this._TextBox_StartFrameIndex_KeyDown);
            this._TextBox_StartFrameIndex.Validating += new System.ComponentModel.CancelEventHandler(this._TextBox_StartFrameIndex_Validating);
            // 
            // _Label_WInterval
            // 
            this._Label_WInterval.AutoSize = true;
            this._Label_WInterval.Location = new System.Drawing.Point(315, 9);
            this._Label_WInterval.Name = "_Label_WInterval";
            this._Label_WInterval.Size = new System.Drawing.Size(15, 12);
            this._Label_WInterval.TabIndex = 9;
            this._Label_WInterval.Text = "W";
            // 
            // _Label_EInterval
            // 
            this._Label_EInterval.AutoSize = true;
            this._Label_EInterval.Location = new System.Drawing.Point(382, 9);
            this._Label_EInterval.Name = "_Label_EInterval";
            this._Label_EInterval.Size = new System.Drawing.Size(13, 12);
            this._Label_EInterval.TabIndex = 8;
            this._Label_EInterval.Text = "E";
            // 
            // _TextBox_Interval_E
            // 
            this._TextBox_Interval_E.Location = new System.Drawing.Point(401, 5);
            this._TextBox_Interval_E.Name = "_TextBox_Interval_E";
            this._TextBox_Interval_E.Size = new System.Drawing.Size(40, 21);
            this._TextBox_Interval_E.TabIndex = 7;
            this._TextBox_Interval_E.Text = "0.2";
            this._TextBox_Interval_E.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._TextBox_Interval_E.KeyDown += new System.Windows.Forms.KeyEventHandler(this._TextBox_EInterval_KeyDown);
            this._TextBox_Interval_E.Validating += new System.ComponentModel.CancelEventHandler(this._TextBox_EInterval_Validating);
            // 
            // _TextBox_Interval_W
            // 
            this._TextBox_Interval_W.Location = new System.Drawing.Point(336, 5);
            this._TextBox_Interval_W.Name = "_TextBox_Interval_W";
            this._TextBox_Interval_W.Size = new System.Drawing.Size(40, 21);
            this._TextBox_Interval_W.TabIndex = 6;
            this._TextBox_Interval_W.Text = "0.2";
            this._TextBox_Interval_W.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._TextBox_Interval_W.KeyDown += new System.Windows.Forms.KeyEventHandler(this._TextBox_WInterval_KeyDown);
            this._TextBox_Interval_W.Validating += new System.ComponentModel.CancelEventHandler(this._TextBox_WInterval_Validating);
            // 
            // _Label_FrameIndex
            // 
            this._Label_FrameIndex.AutoSize = true;
            this._Label_FrameIndex.Location = new System.Drawing.Point(8, 8);
            this._Label_FrameIndex.Name = "_Label_FrameIndex";
            this._Label_FrameIndex.Size = new System.Drawing.Size(81, 12);
            this._Label_FrameIndex.TabIndex = 5;
            this._Label_FrameIndex.Text = "프레임 인덱스";
            // 
            // _TextBox_FrameIndex
            // 
            this._TextBox_FrameIndex.Location = new System.Drawing.Point(95, 3);
            this._TextBox_FrameIndex.Name = "_TextBox_FrameIndex";
            this._TextBox_FrameIndex.ReadOnly = true;
            this._TextBox_FrameIndex.Size = new System.Drawing.Size(141, 21);
            this._TextBox_FrameIndex.TabIndex = 4;
            this._TextBox_FrameIndex.Text = "0";
            this._TextBox_FrameIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _Label_QInterval
            // 
            this._Label_QInterval.AutoSize = true;
            this._Label_QInterval.Location = new System.Drawing.Point(249, 9);
            this._Label_QInterval.Name = "_Label_QInterval";
            this._Label_QInterval.Size = new System.Drawing.Size(14, 12);
            this._Label_QInterval.TabIndex = 3;
            this._Label_QInterval.Text = "Q";
            // 
            // _TextBox_Interval_Q
            // 
            this._TextBox_Interval_Q.Location = new System.Drawing.Point(269, 5);
            this._TextBox_Interval_Q.MaxLength = 4;
            this._TextBox_Interval_Q.Name = "_TextBox_Interval_Q";
            this._TextBox_Interval_Q.Size = new System.Drawing.Size(40, 21);
            this._TextBox_Interval_Q.TabIndex = 2;
            this._TextBox_Interval_Q.Text = "0.2";
            this._TextBox_Interval_Q.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._TextBox_Interval_Q.KeyDown += new System.Windows.Forms.KeyEventHandler(this._TextBox_QInterval_KeyDown);
            this._TextBox_Interval_Q.Validating += new System.ComponentModel.CancelEventHandler(this._TextBox_QInterval_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(512, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "T";
            // 
            // _Label_RInterval
            // 
            this._Label_RInterval.AutoSize = true;
            this._Label_RInterval.Location = new System.Drawing.Point(447, 9);
            this._Label_RInterval.Name = "_Label_RInterval";
            this._Label_RInterval.Size = new System.Drawing.Size(13, 12);
            this._Label_RInterval.TabIndex = 1;
            this._Label_RInterval.Text = "R";
            // 
            // _TextBox_Interval_T
            // 
            this._TextBox_Interval_T.Location = new System.Drawing.Point(531, 5);
            this._TextBox_Interval_T.MaxLength = 4;
            this._TextBox_Interval_T.Name = "_TextBox_Interval_T";
            this._TextBox_Interval_T.Size = new System.Drawing.Size(40, 21);
            this._TextBox_Interval_T.TabIndex = 0;
            this._TextBox_Interval_T.Text = "2";
            this._TextBox_Interval_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _TextBox_Interval_R
            // 
            this._TextBox_Interval_R.Location = new System.Drawing.Point(466, 5);
            this._TextBox_Interval_R.MaxLength = 4;
            this._TextBox_Interval_R.Name = "_TextBox_Interval_R";
            this._TextBox_Interval_R.Size = new System.Drawing.Size(40, 21);
            this._TextBox_Interval_R.TabIndex = 0;
            this._TextBox_Interval_R.Text = "2";
            this._TextBox_Interval_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._TextBox_Interval_R.KeyDown += new System.Windows.Forms.KeyEventHandler(this._TextBox_RInterval_KeyDown);
            this._TextBox_Interval_R.Validating += new System.ComponentModel.CancelEventHandler(this._TextBox_RInterval_Validating);
            // 
            // _SubViewer
            // 
            this._SubViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._SubViewer.Location = new System.Drawing.Point(3, 3);
            this._SubViewer.MinimumSize = new System.Drawing.Size(20, 20);
            this._SubViewer.Name = "_SubViewer";
            this._SubViewer.ScrollBarsEnabled = false;
            this._SubViewer.Size = new System.Drawing.Size(725, 222);
            this._SubViewer.TabIndex = 1;
            // 
            // _Tab_Editor
            // 
            this._Tab_Editor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._Tab_Editor.Controls.Add(this._TabPage_Work);
            this._Tab_Editor.Controls.Add(this._TabPage_Source);
            this._Tab_Editor.Location = new System.Drawing.Point(3, 3);
            this._Tab_Editor.Name = "_Tab_Editor";
            this._Tab_Editor.SelectedIndex = 0;
            this._Tab_Editor.Size = new System.Drawing.Size(950, 705);
            this._Tab_Editor.TabIndex = 1;
            // 
            // _TabPage_Work
            // 
            this._TabPage_Work.Controls.Add(this._GridView_Work);
            this._TabPage_Work.Location = new System.Drawing.Point(4, 22);
            this._TabPage_Work.Name = "_TabPage_Work";
            this._TabPage_Work.Padding = new System.Windows.Forms.Padding(3);
            this._TabPage_Work.Size = new System.Drawing.Size(942, 679);
            this._TabPage_Work.TabIndex = 0;
            this._TabPage_Work.Text = "작업";
            this._TabPage_Work.UseVisualStyleBackColor = true;
            // 
            // _GridView_Work
            // 
            this._GridView_Work.AllowUserToAddRows = false;
            this._GridView_Work.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GridView_Work.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._GridView_Work.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._GridView_Work.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._GridView_Frame,
            this._GridView_T,
            this._GridView_Text});
            this._GridView_Work.Location = new System.Drawing.Point(3, 6);
            this._GridView_Work.MultiSelect = false;
            this._GridView_Work.Name = "_GridView_Work";
            this._GridView_Work.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this._GridView_Work.RowTemplate.Height = 23;
            this._GridView_Work.Size = new System.Drawing.Size(934, 667);
            this._GridView_Work.TabIndex = 0;
            this._GridView_Work.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this._GridView_Work_CellEndEdit);
            this._GridView_Work.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this._GridView_Work_CellValidated);
            this._GridView_Work.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this._GridView_Work_CellValidating);
            this._GridView_Work.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this._GridView_Work_UserDeletingRow);
            this._GridView_Work.KeyDown += new System.Windows.Forms.KeyEventHandler(this._GridView_Work_KeyDown);
            // 
            // _GridView_Frame
            // 
            this._GridView_Frame.FillWeight = 35.97122F;
            this._GridView_Frame.HeaderText = "프레임";
            this._GridView_Frame.Name = "_GridView_Frame";
            this._GridView_Frame.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _GridView_T
            // 
            this._GridView_T.HeaderText = "시간";
            this._GridView_T.Name = "_GridView_T";
            this._GridView_T.ReadOnly = true;
            // 
            // _GridView_Text
            // 
            this._GridView_Text.FillWeight = 164.0288F;
            this._GridView_Text.HeaderText = "텍스트";
            this._GridView_Text.Name = "_GridView_Text";
            this._GridView_Text.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _TabPage_Source
            // 
            this._TabPage_Source.Controls.Add(this._SubEditor);
            this._TabPage_Source.Location = new System.Drawing.Point(4, 22);
            this._TabPage_Source.Name = "_TabPage_Source";
            this._TabPage_Source.Padding = new System.Windows.Forms.Padding(3);
            this._TabPage_Source.Size = new System.Drawing.Size(942, 679);
            this._TabPage_Source.TabIndex = 1;
            this._TabPage_Source.Text = "소스";
            this._TabPage_Source.UseVisualStyleBackColor = true;
            // 
            // _SubEditor
            // 
            this._SubEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._SubEditor.BackColor = System.Drawing.SystemColors.Control;
            this._SubEditor.Enabled = false;
            this._SubEditor.Location = new System.Drawing.Point(3, 6);
            this._SubEditor.Name = "_SubEditor";
            this._SubEditor.Size = new System.Drawing.Size(643, 362);
            this._SubEditor.TabIndex = 0;
            this._SubEditor.Text = "";
            this._SubEditor.TextChanged += new System.EventHandler(this._SubEditor_TextChanged);
            this._SubEditor.KeyDown += new System.Windows.Forms.KeyEventHandler(this._SubEditor_KeyDown);
            // 
            // _MainMenuStrip
            // 
            this._MainMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._FileMenu,
            this._EditMenu,
            this.재생ToolStripMenuItem,
            this._ToolMenu,
            this._HelpMenu,
            this.단축키ToolStripMenuItem});
            this._MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this._MainMenuStrip.Name = "_MainMenuStrip";
            this._MainMenuStrip.Size = new System.Drawing.Size(1717, 24);
            this._MainMenuStrip.TabIndex = 3;
            this._MainMenuStrip.Text = "menuStrip1";
            // 
            // _FileMenu
            // 
            this._FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._FileMenuItem_NewProject,
            this._FileMenuItem_OpenProject,
            this._FileMenuItem_OpenMovie,
            this._FileMenuItem_ImportSmi,
            this.toolStripSeparator2,
            this._FileMenuItem_Save,
            this._FileMenuItem_SaveAs,
            this._FileMenuItem_ExportSmi,
            this._FileMenuIteM_ExportSrt,
            this.toolStripSeparator1,
            this._FileMenuItem_Exit});
            this._FileMenu.Name = "_FileMenu";
            this._FileMenu.Size = new System.Drawing.Size(43, 20);
            this._FileMenu.Text = "파일";
            // 
            // _FileMenuItem_NewProject
            // 
            this._FileMenuItem_NewProject.Name = "_FileMenuItem_NewProject";
            this._FileMenuItem_NewProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this._FileMenuItem_NewProject.Size = new System.Drawing.Size(221, 22);
            this._FileMenuItem_NewProject.Text = "새 자막 프로젝트";
            this._FileMenuItem_NewProject.Click += new System.EventHandler(this._FileMenuItem_NewProject_Click);
            // 
            // _FileMenuItem_OpenProject
            // 
            this._FileMenuItem_OpenProject.Name = "_FileMenuItem_OpenProject";
            this._FileMenuItem_OpenProject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this._FileMenuItem_OpenProject.Size = new System.Drawing.Size(221, 22);
            this._FileMenuItem_OpenProject.Text = "자막 프로젝트 열기";
            this._FileMenuItem_OpenProject.Click += new System.EventHandler(this._FileMenuItem_OpenProject_Click);
            // 
            // _FileMenuItem_OpenMovie
            // 
            this._FileMenuItem_OpenMovie.Name = "_FileMenuItem_OpenMovie";
            this._FileMenuItem_OpenMovie.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this._FileMenuItem_OpenMovie.Size = new System.Drawing.Size(221, 22);
            this._FileMenuItem_OpenMovie.Text = "동영상 열기";
            this._FileMenuItem_OpenMovie.Click += new System.EventHandler(this._FileMenuItem_OpenMovie_Click);
            // 
            // _FileMenuItem_ImportSmi
            // 
            this._FileMenuItem_ImportSmi.Enabled = false;
            this._FileMenuItem_ImportSmi.Name = "_FileMenuItem_ImportSmi";
            this._FileMenuItem_ImportSmi.Size = new System.Drawing.Size(221, 22);
            this._FileMenuItem_ImportSmi.Text = "SMI 임포트";
            this._FileMenuItem_ImportSmi.Click += new System.EventHandler(this._FileMenuItem_ImportSmi_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(218, 6);
            // 
            // _FileMenuItem_Save
            // 
            this._FileMenuItem_Save.Name = "_FileMenuItem_Save";
            this._FileMenuItem_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this._FileMenuItem_Save.Size = new System.Drawing.Size(221, 22);
            this._FileMenuItem_Save.Text = "저장";
            this._FileMenuItem_Save.Click += new System.EventHandler(this._FileMenuItem_Save_Click);
            // 
            // _FileMenuItem_SaveAs
            // 
            this._FileMenuItem_SaveAs.Name = "_FileMenuItem_SaveAs";
            this._FileMenuItem_SaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this._FileMenuItem_SaveAs.Size = new System.Drawing.Size(221, 22);
            this._FileMenuItem_SaveAs.Text = "다른 이름으로 저장";
            this._FileMenuItem_SaveAs.Click += new System.EventHandler(this._FileMenuItem_SaveAs_Click);
            // 
            // _FileMenuItem_ExportSmi
            // 
            this._FileMenuItem_ExportSmi.Name = "_FileMenuItem_ExportSmi";
            this._FileMenuItem_ExportSmi.Size = new System.Drawing.Size(221, 22);
            this._FileMenuItem_ExportSmi.Text = "SMI 추출";
            this._FileMenuItem_ExportSmi.Click += new System.EventHandler(this._FileMenuItem_ExportSmi_Click);
            // 
            // _FileMenuIteM_ExportSrt
            // 
            this._FileMenuIteM_ExportSrt.Enabled = false;
            this._FileMenuIteM_ExportSrt.Name = "_FileMenuIteM_ExportSrt";
            this._FileMenuIteM_ExportSrt.Size = new System.Drawing.Size(221, 22);
            this._FileMenuIteM_ExportSrt.Text = "SRT 추출";
            this._FileMenuIteM_ExportSrt.Click += new System.EventHandler(this._FileMenuItem_ExportSrt_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(218, 6);
            // 
            // _FileMenuItem_Exit
            // 
            this._FileMenuItem_Exit.Name = "_FileMenuItem_Exit";
            this._FileMenuItem_Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this._FileMenuItem_Exit.Size = new System.Drawing.Size(221, 22);
            this._FileMenuItem_Exit.Text = "끝내기";
            this._FileMenuItem_Exit.Click += new System.EventHandler(this._FileMenuItem_Exit_Click);
            // 
            // _EditMenu
            // 
            this._EditMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._EditMenuItem_Undo,
            this._EditMenuItem_Redo});
            this._EditMenu.Enabled = false;
            this._EditMenu.Name = "_EditMenu";
            this._EditMenu.Size = new System.Drawing.Size(43, 20);
            this._EditMenu.Text = "편집";
            // 
            // _EditMenuItem_Undo
            // 
            this._EditMenuItem_Undo.Name = "_EditMenuItem_Undo";
            this._EditMenuItem_Undo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this._EditMenuItem_Undo.Size = new System.Drawing.Size(200, 22);
            this._EditMenuItem_Undo.Text = "실행 취소";
            this._EditMenuItem_Undo.Click += new System.EventHandler(this._EditMenuItem_Undo_Click);
            // 
            // _EditMenuItem_Redo
            // 
            this._EditMenuItem_Redo.Name = "_EditMenuItem_Redo";
            this._EditMenuItem_Redo.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this._EditMenuItem_Redo.Size = new System.Drawing.Size(200, 22);
            this._EditMenuItem_Redo.Text = "다시 실행";
            this._EditMenuItem_Redo.Click += new System.EventHandler(this._EditMenuItem_Redo_Click);
            // 
            // 재생ToolStripMenuItem
            // 
            this.재생ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.재생ToolStripMenuItem1,
            this.일시정지ToolStripMenuItem,
            this.정지ToolStripMenuItem});
            this.재생ToolStripMenuItem.Name = "재생ToolStripMenuItem";
            this.재생ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.재생ToolStripMenuItem.Text = "재생";
            // 
            // 재생ToolStripMenuItem1
            // 
            this.재생ToolStripMenuItem1.Name = "재생ToolStripMenuItem1";
            this.재생ToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.재생ToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.재생ToolStripMenuItem1.Text = "재생";
            // 
            // 일시정지ToolStripMenuItem
            // 
            this.일시정지ToolStripMenuItem.Name = "일시정지ToolStripMenuItem";
            this.일시정지ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.일시정지ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.일시정지ToolStripMenuItem.Text = "일시정지";
            // 
            // 정지ToolStripMenuItem
            // 
            this.정지ToolStripMenuItem.Name = "정지ToolStripMenuItem";
            this.정지ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.X)));
            this.정지ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.정지ToolStripMenuItem.Text = "정지";
            this.정지ToolStripMenuItem.Click += new System.EventHandler(this.정지ToolStripMenuItem_Click);
            // 
            // _ToolMenu
            // 
            this._ToolMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ToolMenuItem_OpenDirectory});
            this._ToolMenu.Name = "_ToolMenu";
            this._ToolMenu.Size = new System.Drawing.Size(43, 20);
            this._ToolMenu.Text = "도구";
            // 
            // _ToolMenuItem_OpenDirectory
            // 
            this._ToolMenuItem_OpenDirectory.Name = "_ToolMenuItem_OpenDirectory";
            this._ToolMenuItem_OpenDirectory.Size = new System.Drawing.Size(126, 22);
            this._ToolMenuItem_OpenDirectory.Text = "폴더 열기";
            this._ToolMenuItem_OpenDirectory.Click += new System.EventHandler(this._ToolMenuItem_OpenDirectory_Click);
            // 
            // _HelpMenu
            // 
            this._HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._HelpMenuItem_Developer});
            this._HelpMenu.Name = "_HelpMenu";
            this._HelpMenu.Size = new System.Drawing.Size(55, 20);
            this._HelpMenu.Text = "도움말";
            // 
            // _HelpMenuItem_Developer
            // 
            this._HelpMenuItem_Developer.Name = "_HelpMenuItem_Developer";
            this._HelpMenuItem_Developer.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this._HelpMenuItem_Developer.Size = new System.Drawing.Size(146, 22);
            this._HelpMenuItem_Developer.Text = "만든 사람";
            this._HelpMenuItem_Developer.Click += new System.EventHandler(this._HelpMenuItem_Developer_Click);
            // 
            // 단축키ToolStripMenuItem
            // 
            this.단축키ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.행동QToolStripMenuItem,
            this.행동WToolStripMenuItem,
            this.행동EToolStripMenuItem,
            this.행동RToolStripMenuItem,
            this.행동TToolStripMenuItem,
            this.행동AToolStripMenuItem,
            this.행동SToolStripMenuItem,
            this.행동DToolStripMenuItem,
            this.행동FToolStripMenuItem,
            this.행동GToolStripMenuItem});
            this.단축키ToolStripMenuItem.Name = "단축키ToolStripMenuItem";
            this.단축키ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.단축키ToolStripMenuItem.Text = "단축키";
            // 
            // 행동QToolStripMenuItem
            // 
            this.행동QToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.skqToolStripMenuItem,
            this.skcqToolStripMenuItem,
            this.sksqToolStripMenuItem,
            this.skcsqToolStripMenuItem});
            this.행동QToolStripMenuItem.Name = "행동QToolStripMenuItem";
            this.행동QToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.행동QToolStripMenuItem.Text = "행동Q";
            // 
            // skqToolStripMenuItem
            // 
            this.skqToolStripMenuItem.Name = "skqToolStripMenuItem";
            this.skqToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.skqToolStripMenuItem.Text = "sk_q";
            this.skqToolStripMenuItem.Click += new System.EventHandler(this.skqToolStripMenuItem_Click);
            // 
            // skcqToolStripMenuItem
            // 
            this.skcqToolStripMenuItem.Name = "skcqToolStripMenuItem";
            this.skcqToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.skcqToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.skcqToolStripMenuItem.Text = "sk_cq";
            this.skcqToolStripMenuItem.Click += new System.EventHandler(this.skcqToolStripMenuItem_Click);
            // 
            // sksqToolStripMenuItem
            // 
            this.sksqToolStripMenuItem.Name = "sksqToolStripMenuItem";
            this.sksqToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.sksqToolStripMenuItem.Text = "sk_sq";
            this.sksqToolStripMenuItem.Click += new System.EventHandler(this.sksqToolStripMenuItem_Click);
            // 
            // skcsqToolStripMenuItem
            // 
            this.skcsqToolStripMenuItem.Name = "skcsqToolStripMenuItem";
            this.skcsqToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Q)));
            this.skcsqToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.skcsqToolStripMenuItem.Text = "sk_csq";
            this.skcsqToolStripMenuItem.Click += new System.EventHandler(this.skcsqToolStripMenuItem_Click);
            // 
            // 행동WToolStripMenuItem
            // 
            this.행동WToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.skwToolStripMenuItem,
            this.skcwToolStripMenuItem,
            this.skswToolStripMenuItem,
            this.skcswToolStripMenuItem});
            this.행동WToolStripMenuItem.Name = "행동WToolStripMenuItem";
            this.행동WToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.행동WToolStripMenuItem.Text = "행동W";
            // 
            // skwToolStripMenuItem
            // 
            this.skwToolStripMenuItem.Name = "skwToolStripMenuItem";
            this.skwToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.skwToolStripMenuItem.Text = "sk_w";
            this.skwToolStripMenuItem.Click += new System.EventHandler(this.skwToolStripMenuItem_Click);
            // 
            // skcwToolStripMenuItem
            // 
            this.skcwToolStripMenuItem.Name = "skcwToolStripMenuItem";
            this.skcwToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.skcwToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.skcwToolStripMenuItem.Text = "sk_cw";
            this.skcwToolStripMenuItem.Click += new System.EventHandler(this.skcwToolStripMenuItem_Click);
            // 
            // skswToolStripMenuItem
            // 
            this.skswToolStripMenuItem.Name = "skswToolStripMenuItem";
            this.skswToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.skswToolStripMenuItem.Text = "sk_sw";
            this.skswToolStripMenuItem.Click += new System.EventHandler(this.skswToolStripMenuItem_Click);
            // 
            // skcswToolStripMenuItem
            // 
            this.skcswToolStripMenuItem.Name = "skcswToolStripMenuItem";
            this.skcswToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.W)));
            this.skcswToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.skcswToolStripMenuItem.Text = "sk_csw";
            this.skcswToolStripMenuItem.Click += new System.EventHandler(this.skcswToolStripMenuItem_Click);
            // 
            // 행동EToolStripMenuItem
            // 
            this.행동EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.skeToolStripMenuItem,
            this.skceToolStripMenuItem,
            this.skseToolStripMenuItem,
            this.skcseToolStripMenuItem});
            this.행동EToolStripMenuItem.Name = "행동EToolStripMenuItem";
            this.행동EToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.행동EToolStripMenuItem.Text = "행동E";
            // 
            // skeToolStripMenuItem
            // 
            this.skeToolStripMenuItem.Name = "skeToolStripMenuItem";
            this.skeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.skeToolStripMenuItem.Text = "sk_e";
            this.skeToolStripMenuItem.Click += new System.EventHandler(this.skeToolStripMenuItem_Click);
            // 
            // skceToolStripMenuItem
            // 
            this.skceToolStripMenuItem.Name = "skceToolStripMenuItem";
            this.skceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.skceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.skceToolStripMenuItem.Text = "sk_ce";
            this.skceToolStripMenuItem.Click += new System.EventHandler(this.skceToolStripMenuItem_Click);
            // 
            // skseToolStripMenuItem
            // 
            this.skseToolStripMenuItem.Name = "skseToolStripMenuItem";
            this.skseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.skseToolStripMenuItem.Text = "sk_se";
            this.skseToolStripMenuItem.Click += new System.EventHandler(this.skseToolStripMenuItem_Click);
            // 
            // skcseToolStripMenuItem
            // 
            this.skcseToolStripMenuItem.Name = "skcseToolStripMenuItem";
            this.skcseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.skcseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.skcseToolStripMenuItem.Text = "sk_cse";
            this.skcseToolStripMenuItem.Click += new System.EventHandler(this.skcseToolStripMenuItem_Click);
            // 
            // 행동RToolStripMenuItem
            // 
            this.행동RToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.skrToolStripMenuItem,
            this.skcrToolStripMenuItem,
            this.sksrToolStripMenuItem,
            this.skcsrToolStripMenuItem});
            this.행동RToolStripMenuItem.Name = "행동RToolStripMenuItem";
            this.행동RToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.행동RToolStripMenuItem.Text = "행동R";
            // 
            // skrToolStripMenuItem
            // 
            this.skrToolStripMenuItem.Name = "skrToolStripMenuItem";
            this.skrToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.skrToolStripMenuItem.Text = "sk_r";
            this.skrToolStripMenuItem.Click += new System.EventHandler(this.skrToolStripMenuItem_Click);
            // 
            // skcrToolStripMenuItem
            // 
            this.skcrToolStripMenuItem.Name = "skcrToolStripMenuItem";
            this.skcrToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.skcrToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.skcrToolStripMenuItem.Text = "sk_cr";
            this.skcrToolStripMenuItem.Click += new System.EventHandler(this.skcrToolStripMenuItem_Click);
            // 
            // sksrToolStripMenuItem
            // 
            this.sksrToolStripMenuItem.Name = "sksrToolStripMenuItem";
            this.sksrToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.sksrToolStripMenuItem.Text = "sk_sr";
            this.sksrToolStripMenuItem.Click += new System.EventHandler(this.sksrToolStripMenuItem_Click);
            // 
            // skcsrToolStripMenuItem
            // 
            this.skcsrToolStripMenuItem.Name = "skcsrToolStripMenuItem";
            this.skcsrToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.skcsrToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.skcsrToolStripMenuItem.Text = "sk_csr";
            this.skcsrToolStripMenuItem.Click += new System.EventHandler(this.skcsrToolStripMenuItem_Click);
            // 
            // 행동TToolStripMenuItem
            // 
            this.행동TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sktToolStripMenuItem,
            this.skctToolStripMenuItem,
            this.skstToolStripMenuItem,
            this.skcstToolStripMenuItem});
            this.행동TToolStripMenuItem.Name = "행동TToolStripMenuItem";
            this.행동TToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.행동TToolStripMenuItem.Text = "행동T";
            // 
            // sktToolStripMenuItem
            // 
            this.sktToolStripMenuItem.Name = "sktToolStripMenuItem";
            this.sktToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.sktToolStripMenuItem.Text = "sk_t";
            this.sktToolStripMenuItem.Click += new System.EventHandler(this.sktToolStripMenuItem_Click);
            // 
            // skctToolStripMenuItem
            // 
            this.skctToolStripMenuItem.Name = "skctToolStripMenuItem";
            this.skctToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.skctToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.skctToolStripMenuItem.Text = "sk_ct";
            this.skctToolStripMenuItem.Click += new System.EventHandler(this.skctToolStripMenuItem_Click);
            // 
            // skstToolStripMenuItem
            // 
            this.skstToolStripMenuItem.Name = "skstToolStripMenuItem";
            this.skstToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.skstToolStripMenuItem.Text = "sk_st";
            this.skstToolStripMenuItem.Click += new System.EventHandler(this.skstToolStripMenuItem_Click);
            // 
            // skcstToolStripMenuItem
            // 
            this.skcstToolStripMenuItem.Name = "skcstToolStripMenuItem";
            this.skcstToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.T)));
            this.skcstToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.skcstToolStripMenuItem.Text = "sk_cst";
            this.skcstToolStripMenuItem.Click += new System.EventHandler(this.skcstToolStripMenuItem_Click);
            // 
            // 행동AToolStripMenuItem
            // 
            this.행동AToolStripMenuItem.Name = "행동AToolStripMenuItem";
            this.행동AToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.행동AToolStripMenuItem.Text = "행동A";
            // 
            // 행동SToolStripMenuItem
            // 
            this.행동SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sksToolStripMenuItem,
            this.skcsToolStripMenuItem,
            this.skssToolStripMenuItem,
            this.skcssToolStripMenuItem});
            this.행동SToolStripMenuItem.Name = "행동SToolStripMenuItem";
            this.행동SToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.행동SToolStripMenuItem.Text = "행동S";
            // 
            // sksToolStripMenuItem
            // 
            this.sksToolStripMenuItem.Name = "sksToolStripMenuItem";
            this.sksToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sksToolStripMenuItem.Text = "sk_s";
            // 
            // skcsToolStripMenuItem
            // 
            this.skcsToolStripMenuItem.Name = "skcsToolStripMenuItem";
            this.skcsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.skcsToolStripMenuItem.Text = "sk_cs";
            // 
            // skssToolStripMenuItem
            // 
            this.skssToolStripMenuItem.Name = "skssToolStripMenuItem";
            this.skssToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.skssToolStripMenuItem.Text = "sk_ss";
            // 
            // skcssToolStripMenuItem
            // 
            this.skcssToolStripMenuItem.Name = "skcssToolStripMenuItem";
            this.skcssToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.skcssToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.skcssToolStripMenuItem.Text = "sk_css";
            // 
            // 행동DToolStripMenuItem
            // 
            this.행동DToolStripMenuItem.Name = "행동DToolStripMenuItem";
            this.행동DToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.행동DToolStripMenuItem.Text = "행동D";
            // 
            // 행동FToolStripMenuItem
            // 
            this.행동FToolStripMenuItem.Name = "행동FToolStripMenuItem";
            this.행동FToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.행동FToolStripMenuItem.Text = "행동F";
            // 
            // 행동GToolStripMenuItem
            // 
            this.행동GToolStripMenuItem.Name = "행동GToolStripMenuItem";
            this.행동GToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.행동GToolStripMenuItem.Text = "행동G";
            // 
            // _OpenSubtitleDialog
            // 
            this._OpenSubtitleDialog.Filter = "Handy Subtitler 프로젝트 파일 (*.sub)|*.sub";
            // 
            // _SaveFileDialog
            // 
            this._SaveFileDialog.FileName = "subtitle.sub";
            this._SaveFileDialog.Filter = "Handy Subtitler 프로젝트 파일 (*.sub)|*.sub";
            this._SaveFileDialog.RestoreDirectory = true;
            // 
            // _StatusStrip
            // 
            this._StatusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ToolStripStatusLabel});
            this._StatusStrip.Location = new System.Drawing.Point(0, 741);
            this._StatusStrip.Name = "_StatusStrip";
            this._StatusStrip.Size = new System.Drawing.Size(1717, 22);
            this._StatusStrip.TabIndex = 4;
            this._StatusStrip.Text = "statusStrip1";
            // 
            // _ToolStripStatusLabel
            // 
            this._ToolStripStatusLabel.Name = "_ToolStripStatusLabel";
            this._ToolStripStatusLabel.Size = new System.Drawing.Size(31, 17);
            this._ToolStripStatusLabel.Text = "준비";
            // 
            // _OpenMediaDialog
            // 
            this._OpenMediaDialog.Filter = "MP4 파일(*.mp4)|*.mp4";
            // 
            // _SaveSmiDialog
            // 
            this._SaveSmiDialog.DefaultExt = "SMI 파일 (*.smi)|*.smi";
            this._SaveSmiDialog.FileName = "subtitle.smi";
            // 
            // _WMPObject
            // 
            this._WMPObject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._WMPObject.Enabled = true;
            this._WMPObject.Location = new System.Drawing.Point(3, 3);
            this._WMPObject.Name = "_WMPObject";
            this._WMPObject.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_WMPObject.OcxState")));
            this._WMPObject.Size = new System.Drawing.Size(725, 367);
            this._WMPObject.TabIndex = 0;
            this._WMPObject.PositionChange += new AxWMPLib._WMPOCXEvents_PositionChangeEventHandler(this._WMPObject_PositionChange);
            this._WMPObject.KeyDownEvent += new AxWMPLib._WMPOCXEvents_KeyDownEventHandler(this._WMPObject_KeyDownEvent);
            this._WMPObject.KeyPressEvent += new AxWMPLib._WMPOCXEvents_KeyPressEventHandler(this._WMPObject_KeyPressEvent);
            this._WMPObject.KeyUpEvent += new AxWMPLib._WMPOCXEvents_KeyUpEventHandler(this._WMPObject_KeyUpEvent);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(269, 30);
            this.textBox1.MaxLength = 4;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "3000";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this._TextBox_QInterval_KeyDown);
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this._TextBox_QInterval_Validating);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1717, 763);
            this.Controls.Add(this._StatusStrip);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this._MainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this._MainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Handy Subtitle Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this._Tab_Editor.ResumeLayout(false);
            this._TabPage_Work.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._GridView_Work)).EndInit();
            this._TabPage_Source.ResumeLayout(false);
            this._MainMenuStrip.ResumeLayout(false);
            this._MainMenuStrip.PerformLayout();
            this._StatusStrip.ResumeLayout(false);
            this._StatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._WMPObject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer _WMPObject;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.WebBrowser _SubViewer;
        private System.Windows.Forms.MenuStrip _MainMenuStrip;
        private System.Windows.Forms.OpenFileDialog _OpenSubtitleDialog;
        private System.Windows.Forms.SaveFileDialog _SaveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem _FileMenu;
        private System.Windows.Forms.ToolStripMenuItem _FileMenuItem_NewProject;
        private System.Windows.Forms.ToolStripMenuItem _FileMenuItem_OpenProject;
        private System.Windows.Forms.ToolStripMenuItem _FileMenuItem_OpenMovie;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem _FileMenuItem_Exit;
        private System.Windows.Forms.StatusStrip _StatusStrip;
        private System.Windows.Forms.RichTextBox _SubEditor;
        private System.Windows.Forms.ToolStripMenuItem _EditMenu;
        private System.Windows.Forms.ToolStripMenuItem _EditMenuItem_Undo;
        private System.Windows.Forms.ToolStripMenuItem _EditMenuItem_Redo;
        private System.Windows.Forms.ToolStripMenuItem _HelpMenu;
        private System.Windows.Forms.ToolStripMenuItem _HelpMenuItem_Developer;
        private System.Windows.Forms.OpenFileDialog _OpenMediaDialog;
        private System.Windows.Forms.ToolStripStatusLabel _ToolStripStatusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem _FileMenuItem_Save;
        private System.Windows.Forms.ToolStripMenuItem _FileMenuItem_SaveAs;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabControl _Tab_Editor;
        private System.Windows.Forms.TabPage _TabPage_Work;
        private System.Windows.Forms.DataGridView _GridView_Work;
        private System.Windows.Forms.TabPage _TabPage_Source;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TextBox _TextBox_Interval_R;
        private System.Windows.Forms.Label _Label_RInterval;
        private System.Windows.Forms.Label _Label_QInterval;
        private System.Windows.Forms.TextBox _TextBox_Interval_Q;
        private System.Windows.Forms.TextBox _TextBox_FrameIndex;
        private System.Windows.Forms.Label _Label_FrameIndex;
        private System.Windows.Forms.ToolStripMenuItem _FileMenuItem_ExportSmi;
        private System.Windows.Forms.ToolStripMenuItem _FileMenuIteM_ExportSrt;
        private System.Windows.Forms.ToolStripMenuItem _ToolMenu;
        private System.Windows.Forms.ToolStripMenuItem _ToolMenuItem_OpenDirectory;
        private System.Windows.Forms.ToolStripMenuItem _FileMenuItem_ImportSmi;
        private System.Windows.Forms.SaveFileDialog _SaveSmiDialog;
        private System.Windows.Forms.Label _Label_WInterval;
        private System.Windows.Forms.Label _Label_EInterval;
        private System.Windows.Forms.TextBox _TextBox_Interval_E;
        private System.Windows.Forms.TextBox _TextBox_Interval_W;
        private System.Windows.Forms.Label _Label_StartFrameIndex;
        private System.Windows.Forms.TextBox _TextBox_StartFrameIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn _GridView_Frame;
        private System.Windows.Forms.DataGridViewTextBoxColumn _GridView_T;
        private System.Windows.Forms.DataGridViewTextBoxColumn _GridView_Text;
        private System.Windows.Forms.ToolStripMenuItem 재생ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 정지ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 단축키ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 행동QToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 행동WToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 행동EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 행동RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 행동TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 행동AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 행동SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 행동DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 행동FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 행동GToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skqToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skcqToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sksqToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skcsqToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skwToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skcwToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skswToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skcswToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skcseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skcrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sksrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skcsrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sktToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skctToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skstToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skcstToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skcsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skssToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skcssToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 재생ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 일시정지ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _TextBox_Interval_T;
        private System.Windows.Forms.TextBox textBox1;
    }
}

