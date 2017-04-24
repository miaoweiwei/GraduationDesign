namespace GraduationDesignManagement.Views
{
    partial class SetSchedule
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabBegin = new System.Windows.Forms.TabPage();
            this.dgvBegin = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMiddle = new System.Windows.Forms.TabPage();
            this.dgvMiddle = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabEnd = new System.Windows.Forms.TabPage();
            this.dgvEnd = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddMatter = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cmbOk = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabBegin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBegin)).BeginInit();
            this.tabMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMiddle)).BeginInit();
            this.tabEnd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnd)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1115, 215);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabBegin);
            this.tabControl.Controls.Add(this.tabMiddle);
            this.tabControl.Controls.Add(this.tabEnd);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(969, 209);
            this.tabControl.TabIndex = 131;
            // 
            // tabBegin
            // 
            this.tabBegin.BackColor = System.Drawing.SystemColors.Control;
            this.tabBegin.Controls.Add(this.dgvBegin);
            this.tabBegin.Location = new System.Drawing.Point(4, 22);
            this.tabBegin.Name = "tabBegin";
            this.tabBegin.Padding = new System.Windows.Forms.Padding(3);
            this.tabBegin.Size = new System.Drawing.Size(961, 183);
            this.tabBegin.TabIndex = 0;
            this.tabBegin.Text = "结题";
            // 
            // dgvBegin
            // 
            this.dgvBegin.AllowUserToAddRows = false;
            this.dgvBegin.AllowUserToDeleteRows = false;
            this.dgvBegin.AllowUserToResizeRows = false;
            this.dgvBegin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBegin.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBegin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBegin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvBegin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBegin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.dgvBegin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBegin.Location = new System.Drawing.Point(3, 3);
            this.dgvBegin.Name = "dgvBegin";
            this.dgvBegin.RowHeadersVisible = false;
            this.dgvBegin.RowTemplate.Height = 23;
            this.dgvBegin.Size = new System.Drawing.Size(955, 177);
            this.dgvBegin.TabIndex = 129;
            this.dgvBegin.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTable_CellClick);
            this.dgvBegin.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView_ColumnWidthChanged);
            this.dgvBegin.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView_Scroll);
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "BeginDate";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn10.FillWeight = 20F;
            this.dataGridViewTextBoxColumn10.HeaderText = "开始日期";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "EndDate";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewTextBoxColumn11.FillWeight = 20F;
            this.dataGridViewTextBoxColumn11.HeaderText = "结束日期";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Matter";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTextBoxColumn12.FillWeight = 60F;
            this.dataGridViewTextBoxColumn12.HeaderText = "事项";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tabMiddle
            // 
            this.tabMiddle.BackColor = System.Drawing.SystemColors.Control;
            this.tabMiddle.Controls.Add(this.dgvMiddle);
            this.tabMiddle.Location = new System.Drawing.Point(4, 22);
            this.tabMiddle.Name = "tabMiddle";
            this.tabMiddle.Padding = new System.Windows.Forms.Padding(3);
            this.tabMiddle.Size = new System.Drawing.Size(961, 183);
            this.tabMiddle.TabIndex = 1;
            this.tabMiddle.Text = "中期";
            // 
            // dgvMiddle
            // 
            this.dgvMiddle.AllowUserToAddRows = false;
            this.dgvMiddle.AllowUserToDeleteRows = false;
            this.dgvMiddle.AllowUserToResizeRows = false;
            this.dgvMiddle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMiddle.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvMiddle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMiddle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvMiddle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMiddle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15});
            this.dgvMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMiddle.Location = new System.Drawing.Point(3, 3);
            this.dgvMiddle.Name = "dgvMiddle";
            this.dgvMiddle.RowHeadersVisible = false;
            this.dgvMiddle.RowTemplate.Height = 23;
            this.dgvMiddle.Size = new System.Drawing.Size(955, 177);
            this.dgvMiddle.TabIndex = 130;
            this.dgvMiddle.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTable_CellClick);
            this.dgvMiddle.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView_ColumnWidthChanged);
            this.dgvMiddle.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView_Scroll);
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "BeginDate";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewTextBoxColumn13.FillWeight = 20F;
            this.dataGridViewTextBoxColumn13.HeaderText = "开始日期";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "EndDate";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewTextBoxColumn14.FillWeight = 20F;
            this.dataGridViewTextBoxColumn14.HeaderText = "结束日期";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Matter";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn15.DefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridViewTextBoxColumn15.FillWeight = 60F;
            this.dataGridViewTextBoxColumn15.HeaderText = "事项";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tabEnd
            // 
            this.tabEnd.BackColor = System.Drawing.SystemColors.Control;
            this.tabEnd.Controls.Add(this.dgvEnd);
            this.tabEnd.Location = new System.Drawing.Point(4, 22);
            this.tabEnd.Name = "tabEnd";
            this.tabEnd.Padding = new System.Windows.Forms.Padding(3);
            this.tabEnd.Size = new System.Drawing.Size(961, 183);
            this.tabEnd.TabIndex = 2;
            this.tabEnd.Text = "结题";
            // 
            // dgvEnd
            // 
            this.dgvEnd.AllowUserToAddRows = false;
            this.dgvEnd.AllowUserToDeleteRows = false;
            this.dgvEnd.AllowUserToResizeRows = false;
            this.dgvEnd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEnd.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvEnd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEnd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvEnd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18});
            this.dgvEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEnd.Location = new System.Drawing.Point(3, 3);
            this.dgvEnd.Name = "dgvEnd";
            this.dgvEnd.RowHeadersVisible = false;
            this.dgvEnd.RowTemplate.Height = 23;
            this.dgvEnd.Size = new System.Drawing.Size(955, 177);
            this.dgvEnd.TabIndex = 130;
            this.dgvEnd.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTable_CellClick);
            this.dgvEnd.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView_ColumnWidthChanged);
            this.dgvEnd.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView_Scroll);
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "BeginDate";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn16.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn16.FillWeight = 20F;
            this.dataGridViewTextBoxColumn16.HeaderText = "开始日期";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "EndDate";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn17.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn17.FillWeight = 20F;
            this.dataGridViewTextBoxColumn17.HeaderText = "结束日期";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Matter";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTextBoxColumn18.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn18.FillWeight = 60F;
            this.dataGridViewTextBoxColumn18.HeaderText = "事项";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddMatter);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.cmbOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(978, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(134, 209);
            this.panel1.TabIndex = 132;
            // 
            // btnAddMatter
            // 
            this.btnAddMatter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMatter.Location = new System.Drawing.Point(20, 33);
            this.btnAddMatter.Name = "btnAddMatter";
            this.btnAddMatter.Size = new System.Drawing.Size(95, 23);
            this.btnAddMatter.TabIndex = 133;
            this.btnAddMatter.Text = "添加事项";
            this.btnAddMatter.UseVisualStyleBackColor = true;
            this.btnAddMatter.Click += new System.EventHandler(this.btnDataGridViewRowAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(20, 153);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 23);
            this.btnCancel.TabIndex = 132;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(20, 96);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(77, 23);
            this.btnOk.TabIndex = 131;
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
            this.cmbOk.Location = new System.Drawing.Point(20, 95);
            this.cmbOk.Name = "cmbOk";
            this.cmbOk.Size = new System.Drawing.Size(95, 24);
            this.cmbOk.TabIndex = 130;
            this.cmbOk.SelectionChangeCommitted += new System.EventHandler(this.cmbOk_SelectionChangeCommitted);
            // 
            // SetSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SetSchedule";
            this.Size = new System.Drawing.Size(1115, 215);
            this.Load += new System.EventHandler(this.SetSchedule_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabBegin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBegin)).EndInit();
            this.tabMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMiddle)).EndInit();
            this.tabEnd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnd)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabBegin;
        private System.Windows.Forms.DataGridView dgvBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.TabPage tabMiddle;
        private System.Windows.Forms.DataGridView dgvMiddle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.TabPage tabEnd;
        private System.Windows.Forms.DataGridView dgvEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddMatter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cmbOk;
    }
}
