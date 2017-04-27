namespace GraduationDesignManagement.Views
{
    partial class ChooseTearch
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
            this.label4 = new System.Windows.Forms.Label();
            this.mlvSelect = new SumscopeAddIn.Views.MyListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbxDepartment = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnDelect = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBatchImp = new System.Windows.Forms.Button();
            this.labRightNum = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labLeftNum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.mlvUp = new SumscopeAddIn.Views.MyListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAllUp = new System.Windows.Forms.Button();
            this.btnAllDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.mlvDown = new SumscopeAddIn.Views.MyListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labSelect = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.labSelect);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.mlvSelect);
            this.panel1.Controls.Add(this.cbxDepartment);
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.btnDelect);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnBatchImp);
            this.panel1.Controls.Add(this.labRightNum);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.labLeftNum);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.mlvUp);
            this.panel1.Controls.Add(this.btnAllUp);
            this.panel1.Controls.Add(this.btnAllDown);
            this.panel1.Controls.Add(this.btnUp);
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.mlvDown);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1227, 215);
            this.panel1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(913, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(307, 23);
            this.label4.TabIndex = 130;
            this.label4.Text = "已选老师";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mlvSelect
            // 
            this.mlvSelect.BackColor = System.Drawing.Color.Silver;
            this.mlvSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mlvSelect.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.mlvSelect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mlvSelect.ForeColor = System.Drawing.Color.Black;
            this.mlvSelect.FullRowSelect = true;
            this.mlvSelect.GridLines = true;
            this.mlvSelect.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.mlvSelect.Location = new System.Drawing.Point(913, 32);
            this.mlvSelect.Name = "mlvSelect";
            this.mlvSelect.Size = new System.Drawing.Size(307, 126);
            this.mlvSelect.TabIndex = 129;
            this.mlvSelect.UseCompatibleStateImageBehavior = false;
            this.mlvSelect.View = System.Windows.Forms.View.Details;
            this.mlvSelect.VirtualMode = true;
            this.mlvSelect.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.mlvSelect_RetrieveVirtualItem);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "工号";
            this.columnHeader7.Width = 80;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "姓名";
            this.columnHeader8.Width = 80;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "院系";
            this.columnHeader9.Width = 140;
            // 
            // cbxDepartment
            // 
            this.cbxDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(108)))), ((int)(((byte)(75)))));
            this.cbxDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxDepartment.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxDepartment.ForeColor = System.Drawing.Color.White;
            this.cbxDepartment.FormattingEnabled = true;
            this.cbxDepartment.Items.AddRange(new object[] {
            "提交并导出",
            "提交",
            "导出"});
            this.cbxDepartment.Location = new System.Drawing.Point(75, 58);
            this.cbxDepartment.Name = "cbxDepartment";
            this.cbxDepartment.Size = new System.Drawing.Size(131, 24);
            this.cbxDepartment.TabIndex = 128;
            this.cbxDepartment.TextChanged += new System.EventHandler(this.cbxDepartment_TextChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(822, 170);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(77, 23);
            this.btnSubmit.TabIndex = 126;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnDelect
            // 
            this.btnDelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelect.ForeColor = System.Drawing.Color.White;
            this.btnDelect.Location = new System.Drawing.Point(1060, 171);
            this.btnDelect.Name = "btnDelect";
            this.btnDelect.Size = new System.Drawing.Size(77, 23);
            this.btnDelect.TabIndex = 126;
            this.btnDelect.Text = "取消已选";
            this.btnDelect.UseVisualStyleBackColor = false;
            this.btnDelect.Click += new System.EventHandler(this.btnDelect_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(1143, 171);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(77, 23);
            this.btnExport.TabIndex = 126;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(905, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2, 204);
            this.pictureBox1.TabIndex = 124;
            this.pictureBox1.TabStop = false;
            // 
            // btnBatchImp
            // 
            this.btnBatchImp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBatchImp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBatchImp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchImp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBatchImp.ForeColor = System.Drawing.Color.White;
            this.btnBatchImp.Location = new System.Drawing.Point(75, 110);
            this.btnBatchImp.Name = "btnBatchImp";
            this.btnBatchImp.Size = new System.Drawing.Size(131, 28);
            this.btnBatchImp.TabIndex = 53;
            this.btnBatchImp.Text = "批量导入";
            this.btnBatchImp.UseVisualStyleBackColor = false;
            this.btnBatchImp.Click += new System.EventHandler(this.btnBatchImp_Click);
            // 
            // labRightNum
            // 
            this.labRightNum.AutoSize = true;
            this.labRightNum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.labRightNum.ForeColor = System.Drawing.Color.Black;
            this.labRightNum.Location = new System.Drawing.Point(696, 175);
            this.labRightNum.Name = "labRightNum";
            this.labRightNum.Size = new System.Drawing.Size(12, 12);
            this.labRightNum.TabIndex = 52;
            this.labRightNum.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(594, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 12);
            this.label5.TabIndex = 51;
            this.label5.Text = "本次选中人数：";
            // 
            // labLeftNum
            // 
            this.labLeftNum.AutoSize = true;
            this.labLeftNum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.labLeftNum.ForeColor = System.Drawing.Color.Black;
            this.labLeftNum.Location = new System.Drawing.Point(348, 175);
            this.labLeftNum.Name = "labLeftNum";
            this.labLeftNum.Size = new System.Drawing.Size(12, 12);
            this.labLeftNum.TabIndex = 50;
            this.labLeftNum.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(220, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 12);
            this.label1.TabIndex = 49;
            this.label1.Text = "当前筛选出人数：";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 28);
            this.label3.TabIndex = 47;
            this.label3.Text = "院系：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 28);
            this.label2.TabIndex = 47;
            this.label2.Text = "搜索：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(108)))), ((int)(((byte)(75)))));
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(75, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(131, 21);
            this.txtSearch.TabIndex = 48;
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // mlvUp
            // 
            this.mlvUp.BackColor = System.Drawing.Color.Silver;
            this.mlvUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mlvUp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.mlvUp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mlvUp.ForeColor = System.Drawing.Color.Black;
            this.mlvUp.FullRowSelect = true;
            this.mlvUp.GridLines = true;
            this.mlvUp.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.mlvUp.Location = new System.Drawing.Point(222, 3);
            this.mlvUp.Name = "mlvUp";
            this.mlvUp.Size = new System.Drawing.Size(301, 156);
            this.mlvUp.TabIndex = 20;
            this.mlvUp.UseCompatibleStateImageBehavior = false;
            this.mlvUp.View = System.Windows.Forms.View.Details;
            this.mlvUp.VirtualMode = true;
            this.mlvUp.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.mlvUp_RetrieveVirtualItem);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "工号";
            this.columnHeader1.Width = 74;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "姓名";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "院系";
            this.columnHeader3.Width = 138;
            // 
            // btnAllUp
            // 
            this.btnAllUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAllUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAllUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllUp.ForeColor = System.Drawing.Color.White;
            this.btnAllUp.Location = new System.Drawing.Point(533, 133);
            this.btnAllUp.Name = "btnAllUp";
            this.btnAllUp.Size = new System.Drawing.Size(52, 25);
            this.btnAllUp.TabIndex = 19;
            this.btnAllUp.Text = "<<";
            this.btnAllUp.UseVisualStyleBackColor = false;
            this.btnAllUp.Click += new System.EventHandler(this.btnAllUp_Click);
            // 
            // btnAllDown
            // 
            this.btnAllDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAllDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAllDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllDown.ForeColor = System.Drawing.Color.White;
            this.btnAllDown.Location = new System.Drawing.Point(533, 90);
            this.btnAllDown.Name = "btnAllDown";
            this.btnAllDown.Size = new System.Drawing.Size(52, 25);
            this.btnAllDown.TabIndex = 18;
            this.btnAllDown.Text = ">>";
            this.btnAllDown.UseVisualStyleBackColor = false;
            this.btnAllDown.Click += new System.EventHandler(this.btnAllDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.ForeColor = System.Drawing.Color.White;
            this.btnUp.Location = new System.Drawing.Point(533, 47);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(52, 25);
            this.btnUp.TabIndex = 17;
            this.btnUp.Text = "<";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.ForeColor = System.Drawing.Color.White;
            this.btnDown.Location = new System.Drawing.Point(533, 4);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(52, 25);
            this.btnDown.TabIndex = 16;
            this.btnDown.Text = ">";
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // mlvDown
            // 
            this.mlvDown.BackColor = System.Drawing.Color.Silver;
            this.mlvDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mlvDown.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.mlvDown.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mlvDown.ForeColor = System.Drawing.Color.Black;
            this.mlvDown.FullRowSelect = true;
            this.mlvDown.GridLines = true;
            this.mlvDown.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.mlvDown.Location = new System.Drawing.Point(595, 3);
            this.mlvDown.Name = "mlvDown";
            this.mlvDown.Size = new System.Drawing.Size(307, 156);
            this.mlvDown.TabIndex = 15;
            this.mlvDown.UseCompatibleStateImageBehavior = false;
            this.mlvDown.View = System.Windows.Forms.View.Details;
            this.mlvDown.VirtualMode = true;
            this.mlvDown.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.mlvDown_RetrieveVirtualItem);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "工号";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "姓名";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "院系";
            this.columnHeader6.Width = 140;
            // 
            // labSelect
            // 
            this.labSelect.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.labSelect.ForeColor = System.Drawing.Color.Black;
            this.labSelect.Location = new System.Drawing.Point(916, 170);
            this.labSelect.Name = "labSelect";
            this.labSelect.Size = new System.Drawing.Size(138, 23);
            this.labSelect.TabIndex = 131;
            this.labSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChooseTearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ChooseTearch";
            this.Size = new System.Drawing.Size(1227, 215);
            this.Load += new System.EventHandler(this.ChooseTearch_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnBatchImp;
        public System.Windows.Forms.Label labRightNum;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label labLeftNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtSearch;
        public SumscopeAddIn.Views.MyListView mlvUp;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnAllUp;
        private System.Windows.Forms.Button btnAllDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        public SumscopeAddIn.Views.MyListView mlvDown;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ComboBox cbxDepartment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public SumscopeAddIn.Views.MyListView mlvSelect;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button btnDelect;
        private System.Windows.Forms.Button btnSubmit;
        public System.Windows.Forms.Label labSelect;
    }
}
