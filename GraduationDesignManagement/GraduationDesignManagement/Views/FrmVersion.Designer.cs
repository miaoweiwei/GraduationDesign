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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(474, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "毕业设计管理系统";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "当前  版本：";
            // 
            // labCurrentVer
            // 
            this.labCurrentVer.AutoSize = true;
            this.labCurrentVer.Location = new System.Drawing.Point(375, 116);
            this.labCurrentVer.Name = "labCurrentVer";
            this.labCurrentVer.Size = new System.Drawing.Size(53, 12);
            this.labCurrentVer.TabIndex = 2;
            this.labCurrentVer.Text = "当前版本";
            // 
            // btnCheckUpDate
            // 
            this.btnCheckUpDate.Location = new System.Drawing.Point(332, 168);
            this.btnCheckUpDate.Name = "btnCheckUpDate";
            this.btnCheckUpDate.Size = new System.Drawing.Size(61, 23);
            this.btnCheckUpDate.TabIndex = 3;
            this.btnCheckUpDate.Text = "检查更新";
            this.btnCheckUpDate.UseVisualStyleBackColor = true;
            this.btnCheckUpDate.Click += new System.EventHandler(this.btnCheckUpDate_Click);
            // 
            // pgbDownload
            // 
            this.pgbDownload.Location = new System.Drawing.Point(230, 219);
            this.pgbDownload.Name = "pgbDownload";
            this.pgbDownload.Size = new System.Drawing.Size(258, 23);
            this.pgbDownload.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbDownload.TabIndex = 4;
            this.pgbDownload.Visible = false;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(258, 168);
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
            this.btnCancel.Location = new System.Drawing.Point(399, 168);
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
            this.labDownloadprg.Location = new System.Drawing.Point(372, 200);
            this.labDownloadprg.Name = "labDownloadprg";
            this.labDownloadprg.Size = new System.Drawing.Size(0, 12);
            this.labDownloadprg.TabIndex = 7;
            this.labDownloadprg.Visible = false;
            // 
            // labDownprg
            // 
            this.labDownprg.AutoSize = true;
            this.labDownprg.Location = new System.Drawing.Point(298, 200);
            this.labDownprg.Name = "labDownprg";
            this.labDownprg.Size = new System.Drawing.Size(65, 12);
            this.labDownprg.TabIndex = 8;
            this.labDownprg.Text = "下载进度：";
            this.labDownprg.Visible = false;
            // 
            // labnewVer
            // 
            this.labnewVer.AutoSize = true;
            this.labnewVer.Location = new System.Drawing.Point(298, 142);
            this.labnewVer.Name = "labnewVer";
            this.labnewVer.Size = new System.Drawing.Size(77, 12);
            this.labnewVer.TabIndex = 1;
            this.labnewVer.Text = "可更新版本：";
            this.labnewVer.Visible = false;
            // 
            // labNewVerson
            // 
            this.labNewVerson.AutoSize = true;
            this.labNewVerson.Location = new System.Drawing.Point(375, 142);
            this.labNewVerson.Name = "labNewVerson";
            this.labNewVerson.Size = new System.Drawing.Size(41, 12);
            this.labNewVerson.TabIndex = 2;
            this.labNewVerson.Text = "新版本";
            this.labNewVerson.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(12, 348);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(476, 23);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "毕业设计管理系统";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(11, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 185);
            this.label3.TabIndex = 10;
            this.label3.Text = "    本系统主要是面向于毕业班的老师和同学，减少教师和同学的不必要的劳动和重复性工作，方便对毕业生毕业设计的管理，也方便学生更快捷的了解毕业设计的要求和相关文档" +
    "的下载，教师只须将毕业生管理的重点放在审核上，而不是繁琐的流程，进而提高教师工作效率。 ";
            // 
            // FrmVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 380);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabel1);
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
            this.Name = "FrmVersion";
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
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
    }
}