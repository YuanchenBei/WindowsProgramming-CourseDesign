
namespace PIEIMS
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.title_label = new System.Windows.Forms.Label();
            this.username_label = new System.Windows.Forms.Label();
            this.userpwd_label = new System.Windows.Forms.Label();
            this.name_textBox = new System.Windows.Forms.TextBox();
            this.pwd_textBox = new System.Windows.Forms.TextBox();
            this.login_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Bold);
            this.title_label.Location = new System.Drawing.Point(265, 55);
            this.title_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(317, 40);
            this.title_label.TabIndex = 0;
            this.title_label.Text = "个人收支信息管理系统";
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F);
            this.username_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.username_label.Location = new System.Drawing.Point(243, 165);
            this.username_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(75, 28);
            this.username_label.TabIndex = 1;
            this.username_label.Text = "用户名";
            // 
            // userpwd_label
            // 
            this.userpwd_label.AutoSize = true;
            this.userpwd_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F);
            this.userpwd_label.Location = new System.Drawing.Point(243, 229);
            this.userpwd_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.userpwd_label.Name = "userpwd_label";
            this.userpwd_label.Size = new System.Drawing.Size(72, 28);
            this.userpwd_label.TabIndex = 2;
            this.userpwd_label.Text = "密   码";
            // 
            // name_textBox
            // 
            this.name_textBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.name_textBox.Location = new System.Drawing.Point(326, 163);
            this.name_textBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.Size = new System.Drawing.Size(238, 30);
            this.name_textBox.TabIndex = 3;
            // 
            // pwd_textBox
            // 
            this.pwd_textBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pwd_textBox.Location = new System.Drawing.Point(326, 227);
            this.pwd_textBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pwd_textBox.Name = "pwd_textBox";
            this.pwd_textBox.Size = new System.Drawing.Size(238, 30);
            this.pwd_textBox.TabIndex = 4;
            this.pwd_textBox.UseSystemPasswordChar = true;
            // 
            // login_button
            // 
            this.login_button.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.login_button.Location = new System.Drawing.Point(326, 287);
            this.login_button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(79, 41);
            this.login_button.TabIndex = 5;
            this.login_button.Text = "登录";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancel_button.Location = new System.Drawing.Point(485, 287);
            this.cancel_button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(79, 41);
            this.cancel_button.TabIndex = 6;
            this.cancel_button.Text = "重置";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PIEIMS.Properties.Resources.username;
            this.pictureBox1.Location = new System.Drawing.Point(201, 160);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PIEIMS.Properties.Resources.password;
            this.pictureBox2.Location = new System.Drawing.Point(201, 223);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::PIEIMS.Properties.Resources.logo;
            this.pictureBox3.Location = new System.Drawing.Point(196, 42);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(65, 67);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 439);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.pwd_textBox);
            this.Controls.Add(this.name_textBox);
            this.Controls.Add(this.userpwd_label);
            this.Controls.Add(this.username_label);
            this.Controls.Add(this.title_label);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.Label userpwd_label;
        private System.Windows.Forms.TextBox name_textBox;
        private System.Windows.Forms.TextBox pwd_textBox;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}