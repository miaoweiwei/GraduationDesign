namespace GraduationDesignManagement.Views
{
    partial class AddProjectFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txbProjectName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbIntroduce = new System.Windows.Forms.TextBox();
            this.btnModifyOk = new System.Windows.Forms.Button();
            this.rtnModify = new System.Windows.Forms.RadioButton();
            this.rbtnAdd = new System.Windows.Forms.RadioButton();
            this.rbtnView = new System.Windows.Forms.RadioButton();
            this.dgvProject = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOk = new System.Windows.Forms.Button();
            this.cmbOk = new System.Windows.Forms.ComboBox();
            this.btnDelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProject)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(251, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "项目名称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbProjectName
            // 
            this.txbProjectName.Location = new System.Drawing.Point(341, 45);
            this.txbProjectName.Name = "txbProjectName";
            this.txbProjectName.ReadOnly = true;
            this.txbProjectName.Size = new System.Drawing.Size(321, 21);
            this.txbProjectName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(251, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "项目说明：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbIntroduce
            // 
            this.txbIntroduce.Location = new System.Drawing.Point(341, 69);
            this.txbIntroduce.Multiline = true;
            this.txbIntroduce.Name = "txbIntroduce";
            this.txbIntroduce.ReadOnly = true;
            this.txbIntroduce.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbIntroduce.Size = new System.Drawing.Size(321, 116);
            this.txbIntroduce.TabIndex = 2;
            // 
            // btnModifyOk
            // 
            this.btnModifyOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnModifyOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifyOk.ForeColor = System.Drawing.Color.White;
            this.btnModifyOk.Location = new System.Drawing.Point(466, 7);
            this.btnModifyOk.Name = "btnModifyOk";
            this.btnModifyOk.Size = new System.Drawing.Size(77, 23);
            this.btnModifyOk.TabIndex = 134;
            this.btnModifyOk.Text = "确定修改";
            this.btnModifyOk.UseVisualStyleBackColor = false;
            this.btnModifyOk.Click += new System.EventHandler(this.btnModifyOk_Click);
            // 
            // rtnModify
            // 
            this.rtnModify.AutoSize = true;
            this.rtnModify.Location = new System.Drawing.Point(324, 10);
            this.rtnModify.Name = "rtnModify";
            this.rtnModify.Size = new System.Drawing.Size(47, 16);
            this.rtnModify.TabIndex = 135;
            this.rtnModify.Text = "修改";
            this.rtnModify.UseVisualStyleBackColor = true;
            this.rtnModify.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbtnAdd
            // 
            this.rbtnAdd.AutoSize = true;
            this.rbtnAdd.Location = new System.Drawing.Point(387, 10);
            this.rbtnAdd.Name = "rbtnAdd";
            this.rbtnAdd.Size = new System.Drawing.Size(47, 16);
            this.rbtnAdd.TabIndex = 135;
            this.rbtnAdd.Text = "添加";
            this.rbtnAdd.UseVisualStyleBackColor = true;
            this.rbtnAdd.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbtnView
            // 
            this.rbtnView.AutoSize = true;
            this.rbtnView.Checked = true;
            this.rbtnView.Location = new System.Drawing.Point(254, 10);
            this.rbtnView.Name = "rbtnView";
            this.rbtnView.Size = new System.Drawing.Size(47, 16);
            this.rbtnView.TabIndex = 135;
            this.rbtnView.TabStop = true;
            this.rbtnView.Text = "查看";
            this.rbtnView.UseVisualStyleBackColor = true;
            this.rbtnView.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // dgvProject
            // 
            this.dgvProject.AllowUserToAddRows = false;
            this.dgvProject.AllowUserToDeleteRows = false;
            this.dgvProject.AllowUserToResizeColumns = false;
            this.dgvProject.AllowUserToResizeRows = false;
            this.dgvProject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProject.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProject.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProject.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvProject.Location = new System.Drawing.Point(3, 3);
            this.dgvProject.MultiSelect = false;
            this.dgvProject.Name = "dgvProject";
            this.dgvProject.RowHeadersVisible = false;
            this.dgvProject.RowTemplate.Height = 23;
            this.dgvProject.Size = new System.Drawing.Size(240, 182);
            this.dgvProject.TabIndex = 136;
            this.dgvProject.CurrentCellChanged += new System.EventHandler(this.dgvProject_CurrentCellChanged);
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "我的项目";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ProjectCode";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(567, 7);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(77, 23);
            this.btnOk.TabIndex = 138;
            this.btnOk.Text = "提交并导出";
            this.btnOk.UseVisualStyleBackColor = false;
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
            this.cmbOk.Location = new System.Drawing.Point(567, 7);
            this.cmbOk.Name = "cmbOk";
            this.cmbOk.Size = new System.Drawing.Size(95, 24);
            this.cmbOk.TabIndex = 137;
            this.cmbOk.SelectionChangeCommitted += new System.EventHandler(this.cmbOk_SelectionChangeCommitted);
            // 
            // btnDelect
            // 
            this.btnDelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelect.ForeColor = System.Drawing.Color.White;
            this.btnDelect.Location = new System.Drawing.Point(254, 134);
            this.btnDelect.Name = "btnDelect";
            this.btnDelect.Size = new System.Drawing.Size(77, 23);
            this.btnDelect.TabIndex = 134;
            this.btnDelect.Text = "删除";
            this.btnDelect.UseVisualStyleBackColor = false;
            this.btnDelect.Click += new System.EventHandler(this.btnDelect_Click);
            // 
            // AddProjectFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbOk);
            this.Controls.Add(this.dgvProject);
            this.Controls.Add(this.rbtnAdd);
            this.Controls.Add(this.rbtnView);
            this.Controls.Add(this.rtnModify);
            this.Controls.Add(this.btnDelect);
            this.Controls.Add(this.btnModifyOk);
            this.Controls.Add(this.txbIntroduce);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbProjectName);
            this.Controls.Add(this.label1);
            this.Name = "AddProjectFrm";
            this.Size = new System.Drawing.Size(695, 200);
            this.Load += new System.EventHandler(this.AddProjectFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbProjectName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbIntroduce;
        private System.Windows.Forms.Button btnModifyOk;
        private System.Windows.Forms.RadioButton rtnModify;
        private System.Windows.Forms.RadioButton rbtnAdd;
        private System.Windows.Forms.RadioButton rbtnView;
        private System.Windows.Forms.DataGridView dgvProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cmbOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnDelect;
    }
}
