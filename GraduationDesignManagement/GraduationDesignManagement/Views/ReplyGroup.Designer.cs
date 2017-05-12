namespace GraduationDesignManagement.Views
{
    partial class ReplyGroup
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
            this.label1 = new System.Windows.Forms.Label();
            this.lvwElemSource = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSecAllUp = new System.Windows.Forms.Button();
            this.btnSecAllDown = new System.Windows.Forms.Button();
            this.btnSecUp = new System.Windows.Forms.Button();
            this.btnSecDown = new System.Windows.Forms.Button();
            this.lvwElemSelected = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnComplete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chbxAll = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lvwpleaTeacher = new SumscopeAddIn.Views.MyListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(271, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 12);
            this.label1.TabIndex = 111;
            this.label1.Text = "请选择需要显示的内容：";
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
            this.lvwElemSource.Location = new System.Drawing.Point(273, 16);
            this.lvwElemSource.Name = "lvwElemSource";
            this.lvwElemSource.Size = new System.Drawing.Size(186, 172);
            this.lvwElemSource.TabIndex = 108;
            this.lvwElemSource.UseCompatibleStateImageBehavior = false;
            this.lvwElemSource.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "列名";
            this.columnHeader1.Width = 180;
            // 
            // btnSecAllUp
            // 
            this.btnSecAllUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSecAllUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSecAllUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecAllUp.ForeColor = System.Drawing.Color.White;
            this.btnSecAllUp.Location = new System.Drawing.Point(465, 142);
            this.btnSecAllUp.Name = "btnSecAllUp";
            this.btnSecAllUp.Size = new System.Drawing.Size(52, 25);
            this.btnSecAllUp.TabIndex = 107;
            this.btnSecAllUp.Text = "<<";
            this.btnSecAllUp.UseVisualStyleBackColor = false;
            this.btnSecAllUp.Click += new System.EventHandler(this.btnSecAllUp_Click);
            // 
            // btnSecAllDown
            // 
            this.btnSecAllDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSecAllDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSecAllDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecAllDown.ForeColor = System.Drawing.Color.White;
            this.btnSecAllDown.Location = new System.Drawing.Point(465, 66);
            this.btnSecAllDown.Name = "btnSecAllDown";
            this.btnSecAllDown.Size = new System.Drawing.Size(52, 25);
            this.btnSecAllDown.TabIndex = 106;
            this.btnSecAllDown.Text = ">>";
            this.btnSecAllDown.UseVisualStyleBackColor = false;
            this.btnSecAllDown.Click += new System.EventHandler(this.btnSecAllDown_Click);
            // 
            // btnSecUp
            // 
            this.btnSecUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSecUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSecUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecUp.ForeColor = System.Drawing.Color.White;
            this.btnSecUp.Location = new System.Drawing.Point(465, 106);
            this.btnSecUp.Name = "btnSecUp";
            this.btnSecUp.Size = new System.Drawing.Size(52, 25);
            this.btnSecUp.TabIndex = 105;
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
            this.btnSecDown.Location = new System.Drawing.Point(465, 30);
            this.btnSecDown.Name = "btnSecDown";
            this.btnSecDown.Size = new System.Drawing.Size(52, 25);
            this.btnSecDown.TabIndex = 104;
            this.btnSecDown.Text = ">";
            this.btnSecDown.UseVisualStyleBackColor = false;
            this.btnSecDown.Click += new System.EventHandler(this.btnSecDown_Click);
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
            this.lvwElemSelected.Location = new System.Drawing.Point(523, 16);
            this.lvwElemSelected.Name = "lvwElemSelected";
            this.lvwElemSelected.Size = new System.Drawing.Size(186, 172);
            this.lvwElemSelected.TabIndex = 109;
            this.lvwElemSelected.UseCompatibleStateImageBehavior = false;
            this.lvwElemSelected.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "列名";
            this.columnHeader2.Width = 180;
            // 
            // btnComplete
            // 
            this.btnComplete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnComplete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComplete.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnComplete.ForeColor = System.Drawing.Color.White;
            this.btnComplete.Location = new System.Drawing.Point(715, 163);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(58, 25);
            this.btnComplete.TabIndex = 110;
            this.btnComplete.Text = "完成";
            this.btnComplete.UseVisualStyleBackColor = false;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chbxAll);
            this.panel1.Controls.Add(this.lvwpleaTeacher);
            this.panel1.Controls.Add(this.lvwElemSource);
            this.panel1.Controls.Add(this.btnSecAllUp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSecAllDown);
            this.panel1.Controls.Add(this.lvwElemSelected);
            this.panel1.Controls.Add(this.btnSecUp);
            this.panel1.Controls.Add(this.btnComplete);
            this.panel1.Controls.Add(this.btnSecDown);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(819, 200);
            this.panel1.TabIndex = 112;
            // 
            // chbxAll
            // 
            this.chbxAll.BackColor = System.Drawing.Color.Transparent;
            this.chbxAll.Location = new System.Drawing.Point(160, -1);
            this.chbxAll.Name = "chbxAll";
            this.chbxAll.Size = new System.Drawing.Size(56, 17);
            this.chbxAll.TabIndex = 132;
            this.chbxAll.Text = "全选";
            this.chbxAll.UseVisualStyleBackColor = false;
            this.chbxAll.Click += new System.EventHandler(this.chbxAll_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 12);
            this.label2.TabIndex = 111;
            this.label2.Text = "请选择答辩老师：";
            // 
            // lvwpleaTeacher
            // 
            this.lvwpleaTeacher.BackColor = System.Drawing.Color.DarkGray;
            this.lvwpleaTeacher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwpleaTeacher.CheckBoxes = true;
            this.lvwpleaTeacher.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader3});
            this.lvwpleaTeacher.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvwpleaTeacher.ForeColor = System.Drawing.Color.Black;
            this.lvwpleaTeacher.FullRowSelect = true;
            this.lvwpleaTeacher.GridLines = true;
            this.lvwpleaTeacher.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwpleaTeacher.Location = new System.Drawing.Point(6, 16);
            this.lvwpleaTeacher.Name = "lvwpleaTeacher";
            this.lvwpleaTeacher.Size = new System.Drawing.Size(245, 172);
            this.lvwpleaTeacher.TabIndex = 131;
            this.lvwpleaTeacher.UseCompatibleStateImageBehavior = false;
            this.lvwpleaTeacher.View = System.Windows.Forms.View.Details;
            this.lvwpleaTeacher.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwpleaTeacher_ItemChecked);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "教师工号";
            this.columnHeader7.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "教师姓名";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 120;
            // 
            // ReplyGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ReplyGroup";
            this.Size = new System.Drawing.Size(819, 200);
            this.Load += new System.EventHandler(this.ReplyGroup_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvwElemSource;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnSecAllUp;
        private System.Windows.Forms.Button btnSecAllDown;
        private System.Windows.Forms.Button btnSecUp;
        private System.Windows.Forms.Button btnSecDown;
        private System.Windows.Forms.ListView lvwElemSelected;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Panel panel1;
        public SumscopeAddIn.Views.MyListView lvwpleaTeacher;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbxAll;
    }
}
