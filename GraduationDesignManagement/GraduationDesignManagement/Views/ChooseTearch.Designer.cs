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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cmbOk = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBatchImp = new System.Windows.Forms.Button();
            this.lblChooseNum = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labUpNum = new System.Windows.Forms.Label();
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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.cmbOk);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnBatchImp);
            this.panel1.Controls.Add(this.lblChooseNum);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.labUpNum);
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
            this.panel1.Size = new System.Drawing.Size(980, 215);
            this.panel1.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(108)))), ((int)(((byte)(75)))));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(108)))), ((int)(((byte)(75)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "提交并导出",
            "提交",
            "导出"});
            this.comboBox1.Location = new System.Drawing.Point(111, 58);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(131, 24);
            this.comboBox1.TabIndex = 128;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(889, 170);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 127;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(784, 170);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(77, 23);
            this.btnOk.TabIndex = 126;
            this.btnOk.Text = "提交并导出";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cmbOk
            // 
            this.cmbOk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbOk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbOk.FormattingEnabled = true;
            this.cmbOk.Items.AddRange(new object[] {
            "提交并导出",
            "提交",
            "导出"});
            this.cmbOk.Location = new System.Drawing.Point(784, 170);
            this.cmbOk.Name = "cmbOk";
            this.cmbOk.Size = new System.Drawing.Size(95, 24);
            this.cmbOk.TabIndex = 125;
            this.cmbOk.SelectionChangeCommitted += new System.EventHandler(this.cmbOk_SelectionChangeCommitted);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(280, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2, 185);
            this.pictureBox1.TabIndex = 124;
            this.pictureBox1.TabStop = false;
            // 
            // btnBatchImp
            // 
            this.btnBatchImp.BackColor = System.Drawing.Color.Black;
            this.btnBatchImp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBatchImp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatchImp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBatchImp.ForeColor = System.Drawing.Color.Orange;
            this.btnBatchImp.Location = new System.Drawing.Point(111, 110);
            this.btnBatchImp.Name = "btnBatchImp";
            this.btnBatchImp.Size = new System.Drawing.Size(131, 28);
            this.btnBatchImp.TabIndex = 53;
            this.btnBatchImp.Text = "批量导入";
            this.btnBatchImp.UseVisualStyleBackColor = false;
            // 
            // lblChooseNum
            // 
            this.lblChooseNum.AutoSize = true;
            this.lblChooseNum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.lblChooseNum.ForeColor = System.Drawing.Color.Black;
            this.lblChooseNum.Location = new System.Drawing.Point(748, 177);
            this.lblChooseNum.Name = "lblChooseNum";
            this.lblChooseNum.Size = new System.Drawing.Size(12, 12);
            this.lblChooseNum.TabIndex = 52;
            this.lblChooseNum.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(656, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 51;
            this.label5.Text = "已选中人数：";
            // 
            // labUpNum
            // 
            this.labUpNum.AutoSize = true;
            this.labUpNum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.labUpNum.ForeColor = System.Drawing.Color.Black;
            this.labUpNum.Location = new System.Drawing.Point(422, 177);
            this.labUpNum.Name = "labUpNum";
            this.labUpNum.Size = new System.Drawing.Size(12, 12);
            this.labUpNum.TabIndex = 50;
            this.labUpNum.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(294, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 12);
            this.label1.TabIndex = 49;
            this.label1.Text = "当前筛选出人数：";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(31, 58);
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
            this.label2.Location = new System.Drawing.Point(31, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 28);
            this.label2.TabIndex = 47;
            this.label2.Text = "搜索：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(108)))), ((int)(((byte)(75)))));
            this.txtSearch.Location = new System.Drawing.Point(111, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(131, 21);
            this.txtSearch.TabIndex = 48;
            // 
            // mlvUp
            // 
            this.mlvUp.BackColor = System.Drawing.Color.DarkGray;
            this.mlvUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mlvUp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.mlvUp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mlvUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(198)))), ((int)(((byte)(110)))));
            this.mlvUp.FullRowSelect = true;
            this.mlvUp.GridLines = true;
            this.mlvUp.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.mlvUp.Location = new System.Drawing.Point(292, 3);
            this.mlvUp.Name = "mlvUp";
            this.mlvUp.Size = new System.Drawing.Size(293, 156);
            this.mlvUp.TabIndex = 20;
            this.mlvUp.UseCompatibleStateImageBehavior = false;
            this.mlvUp.View = System.Windows.Forms.View.Details;
            this.mlvUp.VirtualMode = true;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "工号";
            this.columnHeader1.Width = 74;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "院系";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 106;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "姓名";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 102;
            // 
            // btnAllUp
            // 
            this.btnAllUp.BackColor = System.Drawing.SystemColors.Control;
            this.btnAllUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAllUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllUp.ForeColor = System.Drawing.Color.Black;
            this.btnAllUp.Location = new System.Drawing.Point(595, 133);
            this.btnAllUp.Name = "btnAllUp";
            this.btnAllUp.Size = new System.Drawing.Size(52, 25);
            this.btnAllUp.TabIndex = 19;
            this.btnAllUp.Text = "<<";
            this.btnAllUp.UseVisualStyleBackColor = false;
            // 
            // btnAllDown
            // 
            this.btnAllDown.BackColor = System.Drawing.SystemColors.Control;
            this.btnAllDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAllDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllDown.ForeColor = System.Drawing.Color.Black;
            this.btnAllDown.Location = new System.Drawing.Point(595, 90);
            this.btnAllDown.Name = "btnAllDown";
            this.btnAllDown.Size = new System.Drawing.Size(52, 25);
            this.btnAllDown.TabIndex = 18;
            this.btnAllDown.Text = ">>";
            this.btnAllDown.UseVisualStyleBackColor = false;
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.SystemColors.Control;
            this.btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.ForeColor = System.Drawing.Color.Black;
            this.btnUp.Location = new System.Drawing.Point(595, 47);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(52, 25);
            this.btnUp.TabIndex = 17;
            this.btnUp.Text = "<";
            this.btnUp.UseVisualStyleBackColor = false;
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.SystemColors.Control;
            this.btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.ForeColor = System.Drawing.Color.Black;
            this.btnDown.Location = new System.Drawing.Point(595, 4);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(52, 25);
            this.btnDown.TabIndex = 16;
            this.btnDown.Text = ">";
            this.btnDown.UseVisualStyleBackColor = false;
            // 
            // mlvDown
            // 
            this.mlvDown.BackColor = System.Drawing.Color.DarkGray;
            this.mlvDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mlvDown.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.mlvDown.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mlvDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(198)))), ((int)(((byte)(110)))));
            this.mlvDown.FullRowSelect = true;
            this.mlvDown.GridLines = true;
            this.mlvDown.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.mlvDown.Location = new System.Drawing.Point(657, 3);
            this.mlvDown.Name = "mlvDown";
            this.mlvDown.Size = new System.Drawing.Size(307, 156);
            this.mlvDown.TabIndex = 15;
            this.mlvDown.UseCompatibleStateImageBehavior = false;
            this.mlvDown.View = System.Windows.Forms.View.Details;
            this.mlvDown.VirtualMode = true;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "工号";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "院系";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "姓名";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 121;
            // 
            // ChooseTearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ChooseTearch";
            this.Size = new System.Drawing.Size(980, 215);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnBatchImp;
        public System.Windows.Forms.Label lblChooseNum;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label labUpNum;
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
        private System.Windows.Forms.ComboBox cmbOk;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
    }
}
