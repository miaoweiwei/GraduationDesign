namespace GraduationDesignManagement.Views
{
    partial class MyProject
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
            this.txbIntroduce = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbTeacherName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbProjectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbIntroduce
            // 
            this.txbIntroduce.Location = new System.Drawing.Point(103, 59);
            this.txbIntroduce.Multiline = true;
            this.txbIntroduce.Name = "txbIntroduce";
            this.txbIntroduce.ReadOnly = true;
            this.txbIntroduce.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbIntroduce.Size = new System.Drawing.Size(321, 128);
            this.txbIntroduce.TabIndex = 146;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 23);
            this.label2.TabIndex = 143;
            this.label2.Text = "项目说明：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbTeacherName
            // 
            this.txbTeacherName.Location = new System.Drawing.Point(103, 32);
            this.txbTeacherName.Name = "txbTeacherName";
            this.txbTeacherName.ReadOnly = true;
            this.txbTeacherName.Size = new System.Drawing.Size(321, 21);
            this.txbTeacherName.TabIndex = 147;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 23);
            this.label3.TabIndex = 144;
            this.label3.Text = "指导老师：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbProjectName
            // 
            this.txbProjectName.Location = new System.Drawing.Point(103, 5);
            this.txbProjectName.Name = "txbProjectName";
            this.txbProjectName.ReadOnly = true;
            this.txbProjectName.Size = new System.Drawing.Size(321, 21);
            this.txbProjectName.TabIndex = 148;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 23);
            this.label1.TabIndex = 145;
            this.label1.Text = "项目名称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChange.ForeColor = System.Drawing.Color.White;
            this.btnChange.Location = new System.Drawing.Point(448, 3);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(95, 23);
            this.btnChange.TabIndex = 149;
            this.btnChange.Text = "更改项目";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // MyProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.txbIntroduce);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbTeacherName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbProjectName);
            this.Controls.Add(this.label1);
            this.Name = "MyProject";
            this.Size = new System.Drawing.Size(602, 200);
            this.Load += new System.EventHandler(this.MyProject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbIntroduce;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbTeacherName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbProjectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChange;
    }
}
