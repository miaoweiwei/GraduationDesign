namespace GraduationDesignManagement.Views
{
    partial class FrmVersion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labCurrentVer = new System.Windows.Forms.Label();
            this.btnCheckUpDate = new System.Windows.Forms.Button();
            this.pgbDownload = new System.Windows.Forms.ProgressBar();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labDownloadprg = new System.Windows.Forms.Label();
            this.labDownprg = new System.Windows.Forms.Label();
            this.labnewVer = new System.Windows.Forms.Label();
            this.labNewVerson = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(75, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "毕业设计管理";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "当前  版本：";
            // 
            // labCurrentVer
            // 
            this.labCurrentVer.AutoSize = true;
            this.labCurrentVer.Location = new System.Drawing.Point(155, 97);
            this.labCurrentVer.Name = "labCurrentVer";
            this.labCurrentVer.Size = new System.Drawing.Size(53, 12);
            this.labCurrentVer.TabIndex = 2;
            this.labCurrentVer.Text = "当前版本";
            // 
            // btnCheckUpDate
            // 
            this.btnCheckUpDate.Location = new System.Drawing.Point(112, 149);
            this.btnCheckUpDate.Name = "btnCheckUpDate";
            this.btnCheckUpDate.Size = new System.Drawing.Size(61, 23);
            this.btnCheckUpDate.TabIndex = 3;
            this.btnCheckUpDate.Text = "检查更新";
            this.btnCheckUpDate.UseVisualStyleBackColor = true;
            this.btnCheckUpDate.Click += new System.EventHandler(this.btnCheckUpDate_Click);
            // 
            // pgbDownload
            // 
            this.pgbDownload.Location = new System.Drawing.Point(12, 212);
            this.pgbDownload.Name = "pgbDownload";
            this.pgbDownload.Size = new System.Drawing.Size(258, 23);
            this.pgbDownload.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbDownload.TabIndex = 4;
            this.pgbDownload.Visible = false;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(38, 149);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(68, 23);
            this.btnDownload.TabIndex = 5;
            this.btnDownload.Text = "下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Visible = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(179, 149);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labDownloadprg
            // 
            this.labDownloadprg.AutoSize = true;
            this.labDownloadprg.Location = new System.Drawing.Point(152, 186);
            this.labDownloadprg.Name = "labDownloadprg";
            this.labDownloadprg.Size = new System.Drawing.Size(0, 12);
            this.labDownloadprg.TabIndex = 7;
            this.labDownloadprg.Visible = false;
            // 
            // labDownprg
            // 
            this.labDownprg.AutoSize = true;
            this.labDownprg.Location = new System.Drawing.Point(78, 186);
            this.labDownprg.Name = "labDownprg";
            this.labDownprg.Size = new System.Drawing.Size(65, 12);
            this.labDownprg.TabIndex = 8;
            this.labDownprg.Text = "下载进度：";
            this.labDownprg.Visible = false;
            // 
            // labnewVer
            // 
            this.labnewVer.AutoSize = true;
            this.labnewVer.Location = new System.Drawing.Point(78, 123);
            this.labnewVer.Name = "labnewVer";
            this.labnewVer.Size = new System.Drawing.Size(77, 12);
            this.labnewVer.TabIndex = 1;
            this.labnewVer.Text = "可更新版本：";
            this.labnewVer.Visible = false;
            // 
            // labNewVerson
            // 
            this.labNewVerson.AutoSize = true;
            this.labNewVerson.Location = new System.Drawing.Point(155, 123);
            this.labNewVerson.Name = "labNewVerson";
            this.labNewVerson.Size = new System.Drawing.Size(41, 12);
            this.labNewVerson.TabIndex = 2;
            this.labNewVerson.Text = "新版本";
            this.labNewVerson.Visible = false;
            // 
            // FrmVerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 262);
            this.ControlBox = false;
            this.Controls.Add(this.labDownprg);
            this.Controls.Add(this.labDownloadprg);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.pgbDownload);
            this.Controls.Add(this.btnCheckUpDate);
            this.Controls.Add(this.labNewVerson);
            this.Controls.Add(this.labCurrentVer);
            this.Controls.Add(this.labnewVer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关于毕设管理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labCurrentVer;
        private System.Windows.Forms.Button btnCheckUpDate;
        private System.Windows.Forms.ProgressBar pgbDownload;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labDownloadprg;
        private System.Windows.Forms.Label labDownprg;
        private System.Windows.Forms.Label labnewVer;
        private System.Windows.Forms.Label labNewVerson;
    }
}