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
    public partial class AddExpenseForm : Form
    {
        public AddExpenseForm()
        {
            InitializeComponent();
        }

        //按下窗体中"确定"按钮时,准备开始新增支出记录
        private void ok_button_Click(object sender, EventArgs e)
        {
            //合法性判断:支出类型为必选项
            if (!(radioButton1.Checked) && !(radioButton2.Checked) && !(radioButton3.Checked) && !(radioButton4.Checked) && !(radioButton5.Checked) && !(radioButton6.Checked))
            {
                MessageBox.Show("支出类型为必选项!", "好像出了点问题...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //合法性判断:支出金额为必选项
            string money_text = this.money_textBox.Text;
            if (string.IsNullOrEmpty(money_text))
            {
                MessageBox.Show("支出金额为必填项!", "好像出了点问题...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //合法性判断:支出金额的用户输入格式是否为正确的浮点数格式
            float expense_nomey;
            bool is_collect = float.TryParse(money_text, out expense_nomey);
            //如果以上合法性判断均正确,开始准备新增支出记录的数据库操作
            if (is_collect)
            {
                //获取字符串格式的日期值
                string expense_time = this.dateTimePicker.Value.ToString("yyyy/MM/dd");
                string type_str = "";
                //获取支出类型的字符串
                if (radioButton1.Checked) type_str = radioButton1.Text;
                else if (radioButton2.Checked) type_str = radioButton2.Text;
                else if (radioButton3.Checked) type_str = radioButton3.Text;
                else if (radioButton4.Checked) type_str = radioButton4.Text;
                else if (radioButton5.Checked) type_str = radioButton5.Text;
                else type_str = radioButton6.Text;
                //新增支出记录的sql操作
                string sqlStr = string.Format("insert into Expense (ExpenseType,ExpenseTime,ExpenseNum,ExpenseRemark) values (N'{0}',N'{1}',{2},N'{3}')", type_str, expense_time, expense_nomey, remark_TextBox.Text);
                using (SqlConnection conn = new SqlConnection(utils.ConnectStr))
                {
                    SqlCommand cmd = new SqlCommand(sqlStr, conn);
                    try
                    {
                        //数据库连接打开,数据库命令,数据库操作执行,数据库连接关闭
                        conn.Open();
                        int number = cmd.ExecuteNonQuery();
                        //如果插入记录数大于0,插入记录成功,弹出消息框提示用户
                        if (number > 0)
                        {
                            MessageBox.Show(string.Format("成功增加{0}条支出记录，控制消费呀!", number), "新增成功!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            //插入失败,弹出消息框提示用户
                            MessageBox.Show("支出记录新增失败!", "好像出了点问题...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        //数据库抛出异常,弹出消息框提示用户新增失败
                        MessageBox.Show("支出记录新增失败!" + ex.Message, "好像出了点问题...", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (radioButton5.Checked) radioButton5.Checked = false;
            if (radioButton6.Checked) radioButton6.Checked = false;
            this.money_textBox.Text = "";
            this.remark_TextBox.Text = "";
            return;
        }

    }
}
