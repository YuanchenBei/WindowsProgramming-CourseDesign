
namespace PIEIMS
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.add_income = new System.Windows.Forms.ToolStripMenuItem();
            this.add_expense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.query_income = new System.Windows.Forms.ToolStripMenuItem();
            this.query_expense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.ud_income = new System.Windows.Forms.ToolStripMenuItem();
            this.ud_expense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.stat_button = new System.Windows.Forms.ToolStripButton();
            this.welcome_label1 = new System.Windows.Forms.Label();
            this.welcome_label2 = new System.Windows.Forms.Label();
            this.welcome_label3 = new System.Windows.Forms.Label();
            this.welcome_label4 = new System.Windows.Forms.Label();
            this.logo_pictureBox = new System.Windows.Forms.PictureBox();
            this.main_pictureBox = new System.Windows.Forms.PictureBox();
            this.main_panel = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.main_pictureBox)).BeginInit();
            this.main_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.toolStripDropDownButton4,
            this.toolStripSeparator2,
            this.toolStripDropDownButton2,
            this.toolStripSeparator3,
            this.stat_button});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1178, 33);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.add_income,
            this.add_expense});
            this.toolStripDropDownButton1.Image = global::PIEIMS.Properties.Resources.add;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(160, 28);
            this.toolStripDropDownButton1.Text = "新增收支记录";
            // 
            // add_income
            // 
            this.add_income.Name = "add_income";
            this.add_income.Size = new System.Drawing.Size(270, 34);
            this.add_income.Text = "新增收入记录";
            // 
            // add_expense
            // 
            this.add_expense.Name = "add_expense";
            this.add_expense.Size = new System.Drawing.Size(270, 34);
            this.add_expense.Text = "新增支出记录";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripDropDownButton4
            // 
            this.toolStripDropDownButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.query_income,
            this.query_expense});
            this.toolStripDropDownButton4.Image = global::PIEIMS.Properties.Resources.query;
            this.toolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
            this.toolStripDropDownButton4.Size = new System.Drawing.Size(160, 28);
            this.toolStripDropDownButton4.Text = "查询收支记录";
            // 
            // query_income
            // 
            this.query_income.Name = "query_income";
            this.query_income.Size = new System.Drawing.Size(270, 34);
            this.query_income.Text = "查询收入记录";
            // 
            // query_expense
            // 
            this.query_expense.Name = "query_expense";
            this.query_expense.Size = new System.Drawing.Size(270, 34);
            this.query_expense.Text = "查询支出记录";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ud_income,
            this.ud_expense});
            this.toolStripDropDownButton2.Image = global::PIEIMS.Properties.Resources.update;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(209, 28);
            this.toolStripDropDownButton2.Text = "修改/删除 收支记录";
            // 
            // ud_income
            // 
            this.ud_income.Name = "ud_income";
            this.ud_income.Size = new System.Drawing.Size(270, 34);
            this.ud_income.Text = "修改/删除 收入记录";
            // 
            // ud_expense
            // 
            this.ud_expense.Name = "ud_expense";
            this.ud_expense.Size = new System.Drawing.Size(270, 34);
            this.ud_expense.Text = "修改/删除 支出记录";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 33);
            // 
            // stat_button
            // 
            this.stat_button.Image = global::PIEIMS.Properties.Resources.statistics;
            this.stat_button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stat_button.Name = "stat_button";
            this.stat_button.Size = new System.Drawing.Size(146, 28);
            this.stat_button.Text = "收支信息统计";
            // 
            // welcome_label1
            // 
            this.welcome_label1.AutoSize = true;
            this.welcome_label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Bold);
            this.welcome_label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.welcome_label1.Location = new System.Drawing.Point(516, 194);
            this.welcome_label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.welcome_label1.Name = "welcome_label1";
            this.welcome_label1.Size = new System.Drawing.Size(146, 42);
            this.welcome_label1.TabIndex = 3;
            this.welcome_label1.Text = "欢迎使用";
            // 
            // welcome_label2
            // 
            this.welcome_label2.AutoSize = true;
            this.welcome_label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold);
            this.welcome_label2.Location = new System.Drawing.Point(399, 258);
            this.welcome_label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.welcome_label2.Name = "welcome_label2";
            this.welcome_label2.Size = new System.Drawing.Size(380, 47);
            this.welcome_label2.TabIndex = 4;
            this.welcome_label2.Text = "个人收支信息管理系统";
            // 
            // welcome_label3
            // 
            this.welcome_label3.AutoSize = true;
            this.welcome_label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.welcome_label3.Location = new System.Drawing.Point(311, 305);
            this.welcome_label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.welcome_label3.Name = "welcome_label3";
            this.welcome_label3.Size = new System.Drawing.Size(557, 28);
            this.welcome_label3.TabIndex = 5;
            this.welcome_label3.Text = "Personal Income and Expense Management System";
            // 
            // welcome_label4
            // 
            this.welcome_label4.AutoSize = true;
            this.welcome_label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.welcome_label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.welcome_label4.Location = new System.Drawing.Point(468, 382);
            this.welcome_label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.welcome_label4.Name = "welcome_label4";
            this.welcome_label4.Size = new System.Drawing.Size(243, 28);
            this.welcome_label4.TabIndex = 7;
            this.welcome_label4.Text = "请选择上方菜单开始操作";
            // 
            // logo_pictureBox
            // 
            this.logo_pictureBox.Image = global::PIEIMS.Properties.Resources.logo;
            this.logo_pictureBox.Location = new System.Drawing.Point(517, 51);
            this.logo_pictureBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.logo_pictureBox.Name = "logo_pictureBox";
            this.logo_pictureBox.Size = new System.Drawing.Size(145, 128);
            this.logo_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo_pictureBox.TabIndex = 9;
            this.logo_pictureBox.TabStop = false;
            // 
            // main_pictureBox
            // 
            this.main_pictureBox.Image = global::PIEIMS.Properties.Resources.main_picture;
            this.main_pictureBox.Location = new System.Drawing.Point(513, 426);
            this.main_pictureBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.main_pictureBox.Name = "main_pictureBox";
            this.main_pictureBox.Size = new System.Drawing.Size(152, 152);
            this.main_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.main_pictureBox.TabIndex = 11;
            this.main_pictureBox.TabStop = false;
            // 
            // main_panel
            // 
            this.main_panel.Controls.Add(this.logo_pictureBox);
            this.main_panel.Controls.Add(this.main_pictureBox);
            this.main_panel.Controls.Add(this.welcome_label2);
            this.main_panel.Controls.Add(this.welcome_label1);
            this.main_panel.Controls.Add(this.welcome_label4);
            this.main_panel.Controls.Add(this.welcome_label3);
            this.main_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_panel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.main_panel.Location = new System.Drawing.Point(0, 33);
            this.main_panel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(1178, 653);
            this.main_panel.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1178, 686);
            this.Controls.Add(this.main_panel);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "个人收支信息管理系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.main_pictureBox)).EndInit();
            this.main_panel.ResumeLayout(false);
            this.main_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem add_income;
        private System.Windows.Forms.ToolStripMenuItem add_expense;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton4;
        private System.Windows.Forms.ToolStripMenuItem query_income;
        private System.Windows.Forms.ToolStripMenuItem check_expense;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem ud_income;
        private System.Windows.Forms.ToolStripMenuItem ud_expense;
        private System.Windows.Forms.ToolStripButton stat_button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label welcome_label1;
        private System.Windows.Forms.Label welcome_label2;
        private System.Windows.Forms.Label welcome_label3;
        private System.Windows.Forms.Label welcome_label4;
        private System.Windows.Forms.PictureBox logo_pictureBox;
        private System.Windows.Forms.PictureBox main_pictureBox;
        private System.Windows.Forms.Panel main_panel;
        private System.Windows.Forms.ToolStripMenuItem query_expense;
    }
}

