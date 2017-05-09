namespace GraduationDesignManagement.Views
{
    partial class ReplyTeacher
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReplyTeacher));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle57 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle58 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle59 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle60 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle61 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle62 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle63 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExport = new System.Windows.Forms.Button();
            this.rdBtnMiddle = new System.Windows.Forms.RadioButton();
            this.rdBtnEnd = new System.Windows.Forms.RadioButton();
            this.rdBtnBegin = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txbComment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbScore = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txbDownLoad = new System.Windows.Forms.TextBox();
            this.rdgvFile = new GraduationDesignManagement.Views.RowMergeView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new GraduationDesignManagement.Views.DataGridViewDisableButtonColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdgvProject = new GraduationDesignManagement.Views.RowMergeView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rdgvFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgvProject)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(1207, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(121, 23);
            this.btnExport.TabIndex = 177;
            this.btnExport.Text = "导出所有学生成绩";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // rdBtnMiddle
            // 
            this.rdBtnMiddle.AutoSize = true;
            this.rdBtnMiddle.Location = new System.Drawing.Point(1070, 6);
            this.rdBtnMiddle.Name = "rdBtnMiddle";
            this.rdBtnMiddle.Size = new System.Drawing.Size(47, 16);
            this.rdBtnMiddle.TabIndex = 174;
            this.rdBtnMiddle.Text = "中期";
            this.rdBtnMiddle.UseVisualStyleBackColor = true;
            this.rdBtnMiddle.CheckedChanged += new System.EventHandler(this.rdBtn_CheckedChanged);
            // 
            // rdBtnEnd
            // 
            this.rdBtnEnd.AutoSize = true;
            this.rdBtnEnd.Location = new System.Drawing.Point(1133, 6);
            this.rdBtnEnd.Name = "rdBtnEnd";
            this.rdBtnEnd.Size = new System.Drawing.Size(47, 16);
            this.rdBtnEnd.TabIndex = 175;
            this.rdBtnEnd.Text = "结题";
            this.rdBtnEnd.UseVisualStyleBackColor = true;
            this.rdBtnEnd.CheckedChanged += new System.EventHandler(this.rdBtn_CheckedChanged);
            // 
            // rdBtnBegin
            // 
            this.rdBtnBegin.AutoSize = true;
            this.rdBtnBegin.Checked = true;
            this.rdBtnBegin.Location = new System.Drawing.Point(1007, 6);
            this.rdBtnBegin.Name = "rdBtnBegin";
            this.rdBtnBegin.Size = new System.Drawing.Size(47, 16);
            this.rdBtnBegin.TabIndex = 176;
            this.rdBtnBegin.TabStop = true;
            this.rdBtnBegin.Text = "开题";
            this.rdBtnBegin.UseVisualStyleBackColor = true;
            this.rdBtnBegin.CheckedChanged += new System.EventHandler(this.rdBtn_CheckedChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(1251, 180);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(77, 23);
            this.btnSubmit.TabIndex = 183;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txbComment
            // 
            this.txbComment.Location = new System.Drawing.Point(1007, 56);
            this.txbComment.Multiline = true;
            this.txbComment.Name = "txbComment";
            this.txbComment.ReadOnly = true;
            this.txbComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbComment.Size = new System.Drawing.Size(321, 118);
            this.txbComment.TabIndex = 181;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(937, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 179;
            this.label2.Text = "评语：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbScore
            // 
            this.txbScore.Location = new System.Drawing.Point(1007, 28);
            this.txbScore.Name = "txbScore";
            this.txbScore.ReadOnly = true;
            this.txbScore.Size = new System.Drawing.Size(321, 21);
            this.txbScore.TabIndex = 182;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(937, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 180;
            this.label3.Text = "成绩：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(537, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 23);
            this.label1.TabIndex = 186;
            this.label1.Text = "下载路径";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(786, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 23);
            this.button1.TabIndex = 185;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txbDownLoad
            // 
            this.txbDownLoad.Location = new System.Drawing.Point(609, 2);
            this.txbDownLoad.Name = "txbDownLoad";
            this.txbDownLoad.ReadOnly = true;
            this.txbDownLoad.Size = new System.Drawing.Size(171, 21);
            this.txbDownLoad.TabIndex = 184;
            // 
            // rdgvFile
            // 
            this.rdgvFile.AllowUserToAddRows = false;
            this.rdgvFile.AllowUserToDeleteRows = false;
            this.rdgvFile.AllowUserToResizeRows = false;
            this.rdgvFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.rdgvFile.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle55.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle55.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle55.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle55.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle55.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle55.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rdgvFile.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle55;
            this.rdgvFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rdgvFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column2,
            this.Column3});
            this.rdgvFile.Location = new System.Drawing.Point(537, 28);
            this.rdgvFile.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.rdgvFile.MergeColumnHeaderFontColor = System.Drawing.Color.Black;
            this.rdgvFile.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("rdgvFile.MergeColumnNames")));
            this.rdgvFile.Name = "rdgvFile";
            this.rdgvFile.RowHeadersVisible = false;
            this.rdgvFile.RowTemplate.Height = 23;
            this.rdgvFile.Size = new System.Drawing.Size(389, 179);
            this.rdgvFile.TabIndex = 178;
            this.rdgvFile.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rdgvFile_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "FileName";
            dataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle56.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle56.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle56.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle56.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle56;
            this.Column1.HeaderText = "文件名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "UpLoadTime";
            dataGridViewCellStyle57.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle57.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle57.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle57.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle57.SelectionForeColor = System.Drawing.Color.Black;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle57;
            this.Column4.HeaderText = "上传时间";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "DownLoad";
            dataGridViewCellStyle58.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle58.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle58.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle58.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle58.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle58.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle58;
            this.Column2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column2.HeaderText = "下载";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "FileCode";
            this.Column3.HeaderText = "FileCode";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Visible = false;
            // 
            // rdgvProject
            // 
            this.rdgvProject.AllowUserToAddRows = false;
            this.rdgvProject.AllowUserToDeleteRows = false;
            this.rdgvProject.AllowUserToResizeRows = false;
            this.rdgvProject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.rdgvProject.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle59.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle59.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle59.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle59.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle59.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle59.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rdgvProject.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle59;
            this.rdgvProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rdgvProject.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.rdgvProject.Location = new System.Drawing.Point(3, 3);
            this.rdgvProject.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.rdgvProject.MergeColumnHeaderFontColor = System.Drawing.Color.Black;
            this.rdgvProject.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("rdgvProject.MergeColumnNames")));
            this.rdgvProject.Name = "rdgvProject";
            this.rdgvProject.RowHeadersVisible = false;
            this.rdgvProject.RowTemplate.Height = 23;
            this.rdgvProject.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.rdgvProject.Size = new System.Drawing.Size(528, 204);
            this.rdgvProject.TabIndex = 154;
            this.rdgvProject.CurrentCellChanged += new System.EventHandler(this.rdgvProject_CurrentCellChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "StudentId";
            dataGridViewCellStyle60.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle60.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle60;
            this.dataGridViewTextBoxColumn1.HeaderText = "学号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "StudentName";
            dataGridViewCellStyle61.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle61.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle61;
            this.dataGridViewTextBoxColumn2.HeaderText = "姓名";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "StudentClass";
            dataGridViewCellStyle62.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle62.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle62;
            this.dataGridViewTextBoxColumn3.HeaderText = "班级";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ProjectName";
            dataGridViewCellStyle63.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle63.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle63;
            this.dataGridViewTextBoxColumn4.HeaderText = "项目";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(851, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 185;
            this.button2.Text = "打开文件夹";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ReplyTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txbDownLoad);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txbComment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbScore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rdgvFile);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.rdBtnMiddle);
            this.Controls.Add(this.rdBtnEnd);
            this.Controls.Add(this.rdBtnBegin);
            this.Controls.Add(this.rdgvProject);
            this.Name = "ReplyTeacher";
            this.Size = new System.Drawing.Size(1337, 210);
            this.Load += new System.EventHandler(this.ReplyTeacher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rdgvFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgvProject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RowMergeView rdgvProject;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.RadioButton rdBtnMiddle;
        private System.Windows.Forms.RadioButton rdBtnEnd;
        private System.Windows.Forms.RadioButton rdBtnBegin;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txbComment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbScore;
        private System.Windows.Forms.Label label3;
        private RowMergeView rdgvFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private DataGridViewDisableButtonColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txbDownLoad;
        private System.Windows.Forms.Button button2;
    }
}
