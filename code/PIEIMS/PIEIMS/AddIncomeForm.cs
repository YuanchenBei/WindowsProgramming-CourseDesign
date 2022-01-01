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
    public partial class AddIncomeForm : Form
    {
        public AddIncomeForm()
        {
            InitializeComponent();
            //this.SizeChanged += new Resize(this).Form_Resize;
        }

        //按下窗体中"确定"按钮时,准备开始新增收入记录
        private void ok_button_Click(object sender, EventArgs e)
        {
            //合法性检查:收入类型为必选项
            if (!(radioButton1.Checked)&&!(radioButton2.Checked)&&!(radioButton3.Checked)&&!(radioButton4.Checked))
            {
                MessageBox.Show("收入类型为必选项!", "好像出了点问题...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //合法性检查:收入金额为必选项
            string money_text = this.money_textBox.Text;
            if(string.IsNullOrEmpty(money_text))
            {
                MessageBox.Show("收入金额为必填项!", "好像出了点问题...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //合法性检查:收入金额的用户输入格式是否为正确的浮点数格式
            float income_nomey;
            bool is_collect = float.TryParse(money_text, out income_nomey);
            if (is_collect)
            {
                //dateTimePicker的日期值的字符串形式
                string income_time = this.dateTimePicker.Value.ToString("yyyy/MM/dd");
                string type_str = "";
                //收入类型的字符串文本
                if (radioButton1.Checked) type_str = radioButton1.Text;
                else if (radioButton2.Checked) type_str = radioButton2.Text;
                else if (radioButton3.Checked) type_str = radioButton3.Text;
                else type_str = radioButton4.Text;
                //新增收入记录的sql操作
                string sqlStr = string.Format("insert into Income (IncomeType,IncomeTime,IncomeNum,IncomeRemark) values (N'{0}',N'{1}',{2},N'{3}')",type_str,income_time,income_nomey,remark_TextBox.Text);
                using (SqlConnection conn = new SqlConnection(utils.ConnectStr))
                {
                    //数据库连接打开,数据库命令,数据库操作执行,数据库连接关闭
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    try
                    {
                        conn.Open();
                        int number = cmd.ExecuteNonQuery();
                        //插入记录数大于0,插入记录成功,弹出消息框提示用户
                        if (number > 0)
                        {
                            MessageBox.Show(string.Format("成功增加{0}条收入记录，越来越富有了!",number),"新增成功!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        else
                        {
                            //插入失败,弹出消息框提示用户
                            MessageBox.Show("收入记录新增失败!", "好像出了点问题...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch(Exception ex)
                    {
                        //数据库抛出异常,弹出消息框提示用户新增失败
                        MessageBox.Show("收入记录新增失败!"+ex.Message,"好像出了点问题...",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                //金额格式不正确的浮点数格式
                MessageBox.Show("金额格式不正确,请按正确的浮点数格式进行输入!", "好像出了点问题...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        //"取消"按钮的点击处理事件,清空radioButton的点击和文本内容
        private void cancel_button_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) radioButton1.Checked = false;
            if (radioButton2.Checked) radioButton2.Checked = false;
            if (radioButton3.Checked) radioButton3.Checked = false;
            if (radioButton4.Checked) radioButton4.Checked = false;
            money_textBox.Text = "";
            remark_TextBox.Text = "";
            return;
        }
    }
}
