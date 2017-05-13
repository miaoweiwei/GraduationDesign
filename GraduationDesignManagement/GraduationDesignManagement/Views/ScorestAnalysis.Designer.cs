namespace GraduationDesignManagement.Views
{
    partial class ScorestAnalysis
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.chbxAll = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.btnComplete = new System.Windows.Forms.Button();
            this.lvwElemSource = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSecAllUp = new System.Windows.Forms.Button();
            this.btnSecAllDown = new System.Windows.Forms.Button();
            this.lvwElemSelected = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSecUp = new System.Windows.Forms.Button();
            this.btnSecDown = new System.Windows.Forms.Button();
            this.labRightNum = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labLeftNum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lvwpleaTeacher = new SumscopeAddIn.Views.MyListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labRightNum);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.labLeftNum);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chbxAll);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lvwpleaTeacher);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbxType);
            this.panel1.Controls.Add(this.btnComplete);
            this.panel1.Controls.Add(this.lvwElemSource);
            this.panel1.Controls.Add(this.btnSecAllUp);
            this.panel1.Controls.Add(this.btnSecAllDown);
            this.panel1.Controls.Add(this.lvwElemSelected);
            this.panel1.Controls.Add(this.btnSecUp);
            this.panel1.Controls.Add(this.btnSecDown);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1130, 220);
            this.panel1.TabIndex = 0;
            // 
            // chbxAll
            // 
            this.chbxAll.BackColor = System.Drawing.Color.Transparent;
            this.chbxAll.Location = new System.Drawing.Point(301, 0);
            this.chbxAll.Name = "chbxAll";
            this.chbxAll.Size = new System.Drawing.Size(56, 17);
            this.chbxAll.TabIndex = 134;
            this.chbxAll.Text = "全选";
            this.chbxAll.UseVisualStyleBackColor = false;
            this.chbxAll.Click += new System.EventHandler(this.chbxAll_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(552, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2, 196);
            this.pictureBox1.TabIndex = 133;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(35, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 28);
            this.label3.TabIndex = 130;
            this.label3.Text = "分类：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxType
            // 
            this.cbxType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(108)))), ((int)(((byte)(75)))));
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxType.ForeColor = System.Drawing.Color.White;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Items.AddRange(new object[] {
            "提交并导出",
            "提交",
            "导出"});
            this.cbxType.Location = new System.Drawing.Point(95, 66);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(153, 24);
            this.cbxType.TabIndex = 129;
            this.cbxType.TextChanged += new System.EventHandler(this.cbxType_TextChanged);
            // 
            // btnComplete
            // 
            this.btnComplete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnComplete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComplete.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnComplete.ForeColor = System.Drawing.Color.White;
            this.btnComplete.Location = new System.Drawing.Point(1057, 170);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(58, 25);
            this.btnComplete.TabIndex = 116;
            this.btnComplete.Text = "完成";
            this.btnComplete.UseVisualStyleBackColor = false;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // lvwElemSource
            // 
            this.lvwElemSource.BackColor = System.Drawing.Color.DarkGray;
            this.lvwElemSource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.lvwElemSource.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvwElemSource.ForeColor = System.Drawing.Color.Black;
            this.lvwElemSource.FullRowSelect = true;
            this.lvwElemSource.GridLines = true;
            this.lvwElemSource.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwElemSource.Location = new System.Drawing.Point(560, 23);
            this.lvwElemSource.Name = "lvwElemSource";
            this.lvwElemSource.Size = new System.Drawing.Size(209, 172);
            this.lvwElemSource.TabIndex = 114;
            this.lvwElemSource.UseCompatibleStateImageBehavior = false;
            this.lvwElemSource.View = System.Windows.Forms.View.Details;
            this.lvwElemSource.VirtualMode = true;
            this.lvwElemSource.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwElemSource_RetrieveVirtualItem);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "学号";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "姓名";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 100;
            // 
            // btnSecAllUp
            // 
            this.btnSecAllUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSecAllUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSecAllUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecAllUp.ForeColor = System.Drawing.Color.White;
            this.btnSecAllUp.Location = new System.Drawing.Point(775, 152);
            this.btnSecAllUp.Name = "btnSecAllUp";
            this.btnSecAllUp.Size = new System.Drawing.Size(52, 25);
            this.btnSecAllUp.TabIndex = 113;
            this.btnSecAllUp.Text = "<<";
            this.btnSecAllUp.UseVisualStyleBackColor = false;
            this.btnSecAllUp.Click += new System.EventHandler(this.btnAllUp_Click);
            // 
            // btnSecAllDown
            // 
            this.btnSecAllDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSecAllDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSecAllDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecAllDown.ForeColor = System.Drawing.Color.White;
            this.btnSecAllDown.Location = new System.Drawing.Point(775, 76);
            this.btnSecAllDown.Name = "btnSecAllDown";
            this.btnSecAllDown.Size = new System.Drawing.Size(52, 25);
            this.btnSecAllDown.TabIndex = 112;
            this.btnSecAllDown.Text = ">>";
            this.btnSecAllDown.UseVisualStyleBackColor = false;
            this.btnSecAllDown.Click += new System.EventHandler(this.btnAllDown_Click);
            // 
            // lvwElemSelected
            // 
            this.lvwElemSelected.BackColor = System.Drawing.Color.DarkGray;
            this.lvwElemSelected.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4});
            this.lvwElemSelected.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvwElemSelected.ForeColor = System.Drawing.Color.Black;
            this.lvwElemSelected.FullRowSelect = true;
            this.lvwElemSelected.GridLines = true;
            this.lvwElemSelected.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwElemSelected.Location = new System.Drawing.Point(833, 23);
            this.lvwElemSelected.Name = "lvwElemSelected";
            this.lvwElemSelected.Size = new System.Drawing.Size(209, 172);
            this.lvwElemSelected.TabIndex = 115;
            this.lvwElemSelected.UseCompatibleStateImageBehavior = false;
            this.lvwElemSelected.View = System.Windows.Forms.View.Details;
            this.lvwElemSelected.VirtualMode = true;
            this.lvwElemSelected.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwElemSelected_RetrieveVirtualItem);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "学号";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "姓名";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 100;
            // 
            // btnSecUp
            // 
            this.btnSecUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSecUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSecUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecUp.ForeColor = System.Drawing.Color.White;
            this.btnSecUp.Location = new System.Drawing.Point(775, 116);
            this.btnSecUp.Name = "btnSecUp";
            this.btnSecUp.Size = new System.Drawing.Size(52, 25);
            this.btnSecUp.TabIndex = 111;
            this.btnSecUp.Text = "<";
            this.btnSecUp.UseVisualStyleBackColor = false;
            this.btnSecUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnSecDown
            // 
            this.btnSecDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSecDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSecDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecDown.ForeColor = System.Drawing.Color.White;
            this.btnSecDown.Location = new System.Drawing.Point(775, 40);
            this.btnSecDown.Name = "btnSecDown";
            this.btnSecDown.Size = new System.Drawing.Size(52, 25);
            this.btnSecDown.TabIndex = 110;
            this.btnSecDown.Text = ">";
            this.btnSecDown.UseVisualStyleBackColor = false;
            this.btnSecDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // labRightNum
            // 
            this.labRightNum.AutoSize = true;
            this.labRightNum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.labRightNum.ForeColor = System.Drawing.Color.Black;
            this.labRightNum.Location = new System.Drawing.Point(920, 198);
            this.labRightNum.Name = "labRightNum";
            this.labRightNum.Size = new System.Drawing.Size(12, 12);
            this.labRightNum.TabIndex = 138;
            this.labRightNum.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(831, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 137;
            this.label5.Text = "已选中人数：";
            // 
            // labLeftNum
            // 
            this.labLeftNum.AutoSize = true;
            this.labLeftNum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.labLeftNum.ForeColor = System.Drawing.Color.Black;
            this.labLeftNum.Location = new System.Drawing.Point(673, 198);
            this.labLeftNum.Name = "labLeftNum";
            this.labLeftNum.Size = new System.Drawing.Size(12, 12);
            this.labLeftNum.TabIndex = 136;
            this.labLeftNum.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(558, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 12);
            this.label1.TabIndex = 135;
            this.label1.Text = "当前筛选出人数：";
            // 
            // lvwpleaTeacher
            // 
            this.lvwpleaTeacher.BackColor = System.Drawing.Color.DarkGray;
            this.lvwpleaTeacher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwpleaTeacher.CheckBoxes = true;
            this.lvwpleaTeacher.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader5});
            this.lvwpleaTeacher.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvwpleaTeacher.ForeColor = System.Drawing.Color.Black;
            this.lvwpleaTeacher.FullRowSelect = true;
            this.lvwpleaTeacher.GridLines = true;
            this.lvwpleaTeacher.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwpleaTeacher.Location = new System.Drawing.Point(301, 23);
            this.lvwpleaTeacher.Name = "lvwpleaTeacher";
            this.lvwpleaTeacher.Size = new System.Drawing.Size(245, 172);
            this.lvwpleaTeacher.TabIndex = 132;
            this.lvwpleaTeacher.UseCompatibleStateImageBehavior = false;
            this.lvwpleaTeacher.View = System.Windows.Forms.View.Details;
            this.lvwpleaTeacher.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwpleaTeacher_ItemChecked);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "教师工号";
            this.columnHeader7.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "教师姓名";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 120;
            // 
            // ScorestAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ScorestAnalysis";
            this.Size = new System.Drawing.Size(1130, 220);
            this.Load += new System.EventHandler(this.ScorestAnalysis_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvwElemSource;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnSecAllUp;
        private System.Windows.Forms.Button btnSecAllDown;
        private System.Windows.Forms.ListView lvwElemSelected;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnSecUp;
        private System.Windows.Forms.Button btnSecDown;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.Label label3;
        public SumscopeAddIn.Views.MyListView lvwpleaTeacher;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chbxAll;
        public System.Windows.Forms.Label labRightNum;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label labLeftNum;
        private System.Windows.Forms.Label label1;
    }
}
