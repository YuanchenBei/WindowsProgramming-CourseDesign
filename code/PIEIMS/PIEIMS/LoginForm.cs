using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PIEIMS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        //登录按键事件
        private void login_button_Click(object sender, EventArgs e)
        {
            //获取用户在界面文本框中输入的用户名和密码
            string username = this.name_textBox.Text;
            string userpwd = this.pwd_textBox.Text;
            //合法性判断:用户名和密码不能为空
            if(username == "" && userpwd == "")
            {
                MessageBox.Show("用户名和密码不能为空!", "好像出了点问题...",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if(username == "")
            {
                MessageBox.Show("用户名不能为空!","好像出了点问题...",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if(userpwd == "")
            {
                MessageBox.Show("密码不能为空!","好像出了点问题...",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string connectStr = utils.ConnectStr;
            //对用户密码进行MD5加密
            string MD5pwd = utils.Get_MD5(userpwd);
            //用户验证的sql语句
            string sqlStr = "select * from Users where UserName='" + username + "' and UserPassword = '"+MD5pwd+"'";
            using(SqlConnection conn=new SqlConnection(connectStr))
            {
                try
                {
                    //数据库连接打开,数据库命令,数据库操作执行,数据库连接关闭
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlStr,conn);
                    SqlDataReader dr = cmd.ExecuteReader(); //数据库查询, 判断该用户是否存在
                    if (dr.Read())
                    {
                        //登录成功的事件处理,弹出提示成功的对话框并跳转到主界面
                        MessageBox.Show("登录成功!","欢迎回来!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.Hide();
                        MainForm mainForm = new MainForm();
                        mainForm.Show();
                    }
                    else
                    {
                        //登录失败的处理事件,弹出消息框提示用户
                        MessageBox.Show("登录失败，用户名或密码错误!","好像出了点问题...",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    dr.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("登录失败，"+ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        //重置按键事件
        private void cancel_button_Click(object sender, EventArgs e)
        {
            //清空两个文本框中的内容
            this.name_textBox.Text = "";
            this.pwd_textBox.Text = "";
        }
    }
}
