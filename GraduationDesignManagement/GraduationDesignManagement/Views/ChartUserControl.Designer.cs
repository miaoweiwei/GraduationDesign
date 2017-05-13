namespace GraduationDesignManagement.Views
{
    partial class ChartUserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartUserControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvwElemSource = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSecAllUp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSecAllDown = new System.Windows.Forms.Button();
            this.lvwElemSelected = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSecUp = new System.Windows.Forms.Button();
            this.btnSecDown = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.rdgvScore = new GraduationDesignManagement.Views.RowMergeView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdgvScore)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvwElemSource);
            this.panel1.Controls.Add(this.btnSecAllUp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSecAllDown);
            this.panel1.Controls.Add(this.lvwElemSelected);
            this.panel1.Controls.Add(this.btnSecUp);
            this.panel1.Controls.Add(this.btnSecDown);
            this.panel1.Controls.Add(this.btnPrevious);
            this.panel1.Controls.Add(this.btnComplete);
            this.panel1.Controls.Add(this.rdgvScore);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1130, 200);
            this.panel1.TabIndex = 1;
            // 
            // lvwElemSource
            // 
            this.lvwElemSource.BackColor = System.Drawing.Color.DarkGray;
            this.lvwElemSource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvwElemSource.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvwElemSource.ForeColor = System.Drawing.Color.Black;
            this.lvwElemSource.FullRowSelect = true;
            this.lvwElemSource.GridLines = true;
            this.lvwElemSource.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwElemSource.Location = new System.Drawing.Point(437, 18);
            this.lvwElemSource.Name = "lvwElemSource";
            this.lvwElemSource.Size = new System.Drawing.Size(107, 172);
            this.lvwElemSource.TabIndex = 122;
            this.lvwElemSource.UseCompatibleStateImageBehavior = false;
            this.lvwElemSource.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "列名";
            this.columnHeader1.Width = 100;
            // 
            // btnSecAllUp
            // 
            this.btnSecAllUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSecAllUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSecAllUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecAllUp.ForeColor = System.Drawing.Color.White;
            this.btnSecAllUp.Location = new System.Drawing.Point(550, 147);
            this.btnSecAllUp.Name = "btnSecAllUp";
            this.btnSecAllUp.Size = new System.Drawing.Size(52, 25);
            this.btnSecAllUp.TabIndex = 121;
            this.btnSecAllUp.Text = "<<";
            this.btnSecAllUp.UseVisualStyleBackColor = false;
            this.btnSecAllUp.Click += new System.EventHandler(this.btnSecAllUp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(435, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 12);
            this.label1.TabIndex = 124;
            this.label1.Text = "请选择需要显示的成绩类型：";
            // 
            // btnSecAllDown
            // 
            this.btnSecAllDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSecAllDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSecAllDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecAllDown.ForeColor = System.Drawing.Color.White;
            this.btnSecAllDown.Location = new System.Drawing.Point(550, 71);
            this.btnSecAllDown.Name = "btnSecAllDown";
            this.btnSecAllDown.Size = new System.Drawing.Size(52, 25);
            this.btnSecAllDown.TabIndex = 120;
            this.btnSecAllDown.Text = ">>";
            this.btnSecAllDown.UseVisualStyleBackColor = false;
            this.btnSecAllDown.Click += new System.EventHandler(this.btnSecAllDown_Click);
            // 
            // lvwElemSelected
            // 
            this.lvwElemSelected.BackColor = System.Drawing.Color.DarkGray;
            this.lvwElemSelected.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvwElemSelected.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvwElemSelected.ForeColor = System.Drawing.Color.Black;
            this.lvwElemSelected.FullRowSelect = true;
            this.lvwElemSelected.GridLines = true;
            this.lvwElemSelected.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwElemSelected.Location = new System.Drawing.Point(608, 18);
            this.lvwElemSelected.Name = "lvwElemSelected";
            this.lvwElemSelected.Size = new System.Drawing.Size(107, 172);
            this.lvwElemSelected.TabIndex = 123;
            this.lvwElemSelected.UseCompatibleStateImageBehavior = false;
            this.lvwElemSelected.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "列名";
            this.columnHeader2.Width = 100;
            // 
            // btnSecUp
            // 
            this.btnSecUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSecUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSecUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecUp.ForeColor = System.Drawing.Color.White;
            this.btnSecUp.Location = new System.Drawing.Point(550, 111);
            this.btnSecUp.Name = "btnSecUp";
            this.btnSecUp.Size = new System.Drawing.Size(52, 25);
            this.btnSecUp.TabIndex = 119;
            this.btnSecUp.Text = "<";
            this.btnSecUp.UseVisualStyleBackColor = false;
            this.btnSecUp.Click += new System.EventHandler(this.btnSecUp_Click);
            // 
            // btnSecDown
            // 
            this.btnSecDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSecDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSecDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecDown.ForeColor = System.Drawing.Color.White;
            this.btnSecDown.Location = new System.Drawing.Point(550, 35);
            this.btnSecDown.Name = "btnSecDown";
            this.btnSecDown.Size = new System.Drawing.Size(52, 25);
            this.btnSecDown.TabIndex = 118;
            this.btnSecDown.Text = ">";
            this.btnSecDown.UseVisualStyleBackColor = false;
            this.btnSecDown.Click += new System.EventHandler(this.btnSecDown_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(721, 165);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(58, 25);
            this.btnPrevious.TabIndex = 117;
            this.btnPrevious.Text = "上一页";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnComplete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComplete.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnComplete.ForeColor = System.Drawing.Color.White;
            this.btnComplete.Location = new System.Drawing.Point(796, 165);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(58, 25);
            this.btnComplete.TabIndex = 117;
            this.btnComplete.Text = "完成";
            this.btnComplete.UseVisualStyleBackColor = false;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // rdgvScore
            // 
            this.rdgvScore.AllowUserToAddRows = false;
            this.rdgvScore.AllowUserToDeleteRows = false;
            this.rdgvScore.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rdgvScore.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.rdgvScore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.rdgvScore.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rdgvScore.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.rdgvScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rdgvScore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.rdgvScore.Location = new System.Drawing.Point(3, 3);
            this.rdgvScore.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.rdgvScore.MergeColumnHeaderFontColor = System.Drawing.Color.Black;
            this.rdgvScore.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("rdgvScore.MergeColumnNames")));
            this.rdgvScore.Name = "rdgvScore";
            this.rdgvScore.RowHeadersVisible = false;
            this.rdgvScore.RowTemplate.Height = 23;
            this.rdgvScore.Size = new System.Drawing.Size(420, 187);
            this.rdgvScore.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "StudentId";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "学号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "StudentName";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column2.HeaderText = "姓名";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "BeginScore";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column3.HeaderText = "开题成绩";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "MiddleScore";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column4.HeaderText = "中期成绩";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "EndScore";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column5.HeaderText = "结题成绩";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "SumScore";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column6.HeaderText = "总成绩";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // ChartUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ChartUserControl";
            this.Size = new System.Drawing.Size(1130, 200);
            this.Load += new System.EventHandler(this.ChartUserControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdgvScore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public RowMergeView rdgvScore;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.ListView lvwElemSource;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnSecAllUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSecAllDown;
        private System.Windows.Forms.ListView lvwElemSelected;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnSecUp;
        private System.Windows.Forms.Button btnSecDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}
