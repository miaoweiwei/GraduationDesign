namespace GraduationDesignManagement.Game.GluttonousSnake
{
    partial class SnakeControl
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnBegin = new System.Windows.Forms.Button();
            this.hSbDifLevel = new System.Windows.Forms.HScrollBar();
            this.grbDif = new System.Windows.Forms.GroupBox();
            this.grbTheme = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTheme = new System.Windows.Forms.Button();
            this.btnFruitColor = new System.Windows.Forms.Button();
            this.btnSkinColor = new System.Windows.Forms.Button();
            this.grbSet = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudCellWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudActivScopeCol = new System.Windows.Forms.NumericUpDown();
            this.nudActivScopeRow = new System.Windows.Forms.NumericUpDown();
            this.grbScorest = new System.Windows.Forms.GroupBox();
            this.labScore = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grbDif.SuspendLayout();
            this.grbTheme.SuspendLayout();
            this.grbSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCellWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudActivScopeCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudActivScopeRow)).BeginInit();
            this.grbScorest.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDown);
            this.groupBox1.Controls.Add(this.btnRight);
            this.groupBox1.Controls.Add(this.btnLeft);
            this.groupBox1.Controls.Add(this.btnUp);
            this.groupBox1.Controls.Add(this.btnInit);
            this.groupBox1.Controls.Add(this.btnPause);
            this.groupBox1.Controls.Add(this.btnBegin);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 220);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "控制";
            // 
            // btnDown
            // 
            this.btnDown.Enabled = false;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Location = new System.Drawing.Point(89, 179);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(59, 35);
            this.btnDown.TabIndex = 7;
            this.btnDown.Text = "下";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnRight
            // 
            this.btnRight.Enabled = false;
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRight.Location = new System.Drawing.Point(131, 135);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(59, 35);
            this.btnRight.TabIndex = 6;
            this.btnRight.Text = "右";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Enabled = false;
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeft.Location = new System.Drawing.Point(54, 138);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(59, 35);
            this.btnLeft.TabIndex = 5;
            this.btnLeft.Text = "左";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnUp
            // 
            this.btnUp.Enabled = false;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Location = new System.Drawing.Point(89, 94);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(59, 35);
            this.btnUp.TabIndex = 4;
            this.btnUp.Text = "上";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnInit
            // 
            this.btnInit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInit.Location = new System.Drawing.Point(6, 20);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(232, 23);
            this.btnInit.TabIndex = 0;
            this.btnInit.Text = "界面初始化";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Location = new System.Drawing.Point(131, 65);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(107, 23);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "暂停";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnBegin
            // 
            this.btnBegin.Enabled = false;
            this.btnBegin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBegin.Location = new System.Drawing.Point(6, 65);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(107, 23);
            this.btnBegin.TabIndex = 1;
            this.btnBegin.Text = "开始";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // hSbDifLevel
            // 
            this.hSbDifLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hSbDifLevel.Enabled = false;
            this.hSbDifLevel.Location = new System.Drawing.Point(3, 17);
            this.hSbDifLevel.Maximum = 450;
            this.hSbDifLevel.Name = "hSbDifLevel";
            this.hSbDifLevel.Size = new System.Drawing.Size(238, 21);
            this.hSbDifLevel.TabIndex = 1;
            this.hSbDifLevel.ValueChanged += new System.EventHandler(this.hSbDifLevel_ValueChanged);
            // 
            // grbDif
            // 
            this.grbDif.Controls.Add(this.hSbDifLevel);
            this.grbDif.Location = new System.Drawing.Point(3, 333);
            this.grbDif.Name = "grbDif";
            this.grbDif.Size = new System.Drawing.Size(244, 41);
            this.grbDif.TabIndex = 2;
            this.grbDif.TabStop = false;
            this.grbDif.Text = "难度";
            // 
            // grbTheme
            // 
            this.grbTheme.Controls.Add(this.button1);
            this.grbTheme.Controls.Add(this.btnTheme);
            this.grbTheme.Controls.Add(this.btnFruitColor);
            this.grbTheme.Controls.Add(this.btnSkinColor);
            this.grbTheme.Enabled = false;
            this.grbTheme.Location = new System.Drawing.Point(3, 380);
            this.grbTheme.Name = "grbTheme";
            this.grbTheme.Size = new System.Drawing.Size(244, 100);
            this.grbTheme.TabIndex = 3;
            this.grbTheme.TabStop = false;
            this.grbTheme.Text = "主题";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(20, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "默认主题";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTheme
            // 
            this.btnTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTheme.Location = new System.Drawing.Point(20, 58);
            this.btnTheme.Name = "btnTheme";
            this.btnTheme.Size = new System.Drawing.Size(66, 23);
            this.btnTheme.TabIndex = 2;
            this.btnTheme.Text = "主题跟随";
            this.btnTheme.UseVisualStyleBackColor = true;
            this.btnTheme.Click += new System.EventHandler(this.btnTheme_Click);
            // 
            // btnFruitColor
            // 
            this.btnFruitColor.BackColor = System.Drawing.Color.Blue;
            this.btnFruitColor.Enabled = false;
            this.btnFruitColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFruitColor.Location = new System.Drawing.Point(163, 58);
            this.btnFruitColor.Name = "btnFruitColor";
            this.btnFruitColor.Size = new System.Drawing.Size(66, 23);
            this.btnFruitColor.TabIndex = 1;
            this.btnFruitColor.Text = "果实颜色";
            this.btnFruitColor.UseVisualStyleBackColor = false;
            this.btnFruitColor.Click += new System.EventHandler(this.btnFruitColor_Click);
            // 
            // btnSkinColor
            // 
            this.btnSkinColor.BackColor = System.Drawing.Color.Red;
            this.btnSkinColor.Enabled = false;
            this.btnSkinColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSkinColor.Location = new System.Drawing.Point(163, 20);
            this.btnSkinColor.Name = "btnSkinColor";
            this.btnSkinColor.Size = new System.Drawing.Size(66, 23);
            this.btnSkinColor.TabIndex = 0;
            this.btnSkinColor.Text = "皮肤颜色";
            this.btnSkinColor.UseVisualStyleBackColor = false;
            this.btnSkinColor.Click += new System.EventHandler(this.btnSkinColor_Click);
            // 
            // grbSet
            // 
            this.grbSet.Controls.Add(this.label3);
            this.grbSet.Controls.Add(this.label2);
            this.grbSet.Controls.Add(this.nudCellWidth);
            this.grbSet.Controls.Add(this.label1);
            this.grbSet.Controls.Add(this.nudActivScopeCol);
            this.grbSet.Controls.Add(this.nudActivScopeRow);
            this.grbSet.Enabled = false;
            this.grbSet.Location = new System.Drawing.Point(3, 229);
            this.grbSet.Name = "grbSet";
            this.grbSet.Size = new System.Drawing.Size(244, 98);
            this.grbSet.TabIndex = 4;
            this.grbSet.TabStop = false;
            this.grbSet.Text = "设置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "小 方 块 的 宽";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "活动范围的列数";
            // 
            // nudCellWidth
            // 
            this.nudCellWidth.Location = new System.Drawing.Point(163, 74);
            this.nudCellWidth.Name = "nudCellWidth";
            this.nudCellWidth.Size = new System.Drawing.Size(74, 21);
            this.nudCellWidth.TabIndex = 0;
            this.nudCellWidth.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.nudCellWidth.ValueChanged += new System.EventHandler(this.nudCellWidth_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "活动范围的行数";
            // 
            // nudActivScopeCol
            // 
            this.nudActivScopeCol.Location = new System.Drawing.Point(163, 47);
            this.nudActivScopeCol.Name = "nudActivScopeCol";
            this.nudActivScopeCol.Size = new System.Drawing.Size(74, 21);
            this.nudActivScopeCol.TabIndex = 0;
            this.nudActivScopeCol.Value = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.nudActivScopeCol.ValueChanged += new System.EventHandler(this.nudActivScopeCol_ValueChanged);
            // 
            // nudActivScopeRow
            // 
            this.nudActivScopeRow.Location = new System.Drawing.Point(163, 20);
            this.nudActivScopeRow.Name = "nudActivScopeRow";
            this.nudActivScopeRow.Size = new System.Drawing.Size(74, 21);
            this.nudActivScopeRow.TabIndex = 0;
            this.nudActivScopeRow.Value = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.nudActivScopeRow.ValueChanged += new System.EventHandler(this.nudActivScopeRow_ValueChanged);
            // 
            // grbScorest
            // 
            this.grbScorest.Controls.Add(this.labScore);
            this.grbScorest.Location = new System.Drawing.Point(1, 486);
            this.grbScorest.Name = "grbScorest";
            this.grbScorest.Size = new System.Drawing.Size(246, 51);
            this.grbScorest.TabIndex = 4;
            this.grbScorest.TabStop = false;
            this.grbScorest.Text = "成绩";
            // 
            // labScore
            // 
            this.labScore.AutoSize = true;
            this.labScore.Location = new System.Drawing.Point(104, 26);
            this.labScore.Name = "labScore";
            this.labScore.Size = new System.Drawing.Size(11, 12);
            this.labScore.TabIndex = 0;
            this.labScore.Text = "0";
            this.labScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SnakeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbScorest);
            this.Controls.Add(this.grbSet);
            this.Controls.Add(this.grbTheme);
            this.Controls.Add(this.grbDif);
            this.Controls.Add(this.groupBox1);
            this.Name = "SnakeControl";
            this.Size = new System.Drawing.Size(250, 549);
            this.groupBox1.ResumeLayout(false);
            this.grbDif.ResumeLayout(false);
            this.grbTheme.ResumeLayout(false);
            this.grbSet.ResumeLayout(false);
            this.grbSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCellWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudActivScopeCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudActivScopeRow)).EndInit();
            this.grbScorest.ResumeLayout(false);
            this.grbScorest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.HScrollBar hSbDifLevel;
        private System.Windows.Forms.GroupBox grbDif;
        private System.Windows.Forms.GroupBox grbTheme;
        private System.Windows.Forms.GroupBox grbSet;
        private System.Windows.Forms.Button btnSkinColor;
        private System.Windows.Forms.Button btnFruitColor;
        private System.Windows.Forms.GroupBox grbScorest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudActivScopeCol;
        private System.Windows.Forms.NumericUpDown nudActivScopeRow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudCellWidth;
        private System.Windows.Forms.Label labScore;
        private System.Windows.Forms.Button btnTheme;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button button1;
    }
}
