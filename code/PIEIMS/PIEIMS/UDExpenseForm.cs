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
    public partial class UDExpenseForm : Form
    {
        public UDExpenseForm()
        {
            InitializeComponent();
        }

        SqlDataAdapter da;
        DataTable dataTable;
        int counter = 0; //记录ok按钮的点击次数,防止每次修改/删除时重复在dataGridView中添加修改/删除Button; 
        
        //加载窗体的事件
        private void UDExpenseForm_Load(object sender, EventArgs e)
        {
            //初始时不显示DataGridView, 在按下"确定"按钮后再显示
            this.dataGridView.Visible = false;
            this.query_num_txt.Text = "";
        }

        //按下确定按钮时的触发事件处理
        private void ok_button_Click(object sender, EventArgs e)
        {
            //1.检查合法性: 更新按钮和删除按钮必须点击一个
            if (!update_Button.Checked && !delete_Button.Checked)
            {
                MessageBox.Show("请选择您要进行更新操作还是删除操作!", "您好像忘了点什么...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //2.检查合法性: 要选择若干收入类型
            if (!(checkBox1.Checked) && !(checkBox2.Checked) && !(checkBox3.Checked) && !(checkBox4.Checked) && !(checkBox5.Checked) && !(checkBox6.Checked))
            {
                MessageBox.Show("请选择您要查询的若干种收入类型", "您好像忘记了一些事情...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //由于可以选择多种支出类型,构造sql查询语句的ExpenseType字段相关内容
            string query_type_str = "";
            if (checkBox1.Checked)
            {
                query_type_str += "ExpenseType=N'学习消费' OR ";
            }
            if (checkBox2.Checked)
            {
                query_type_str += "ExpenseType=N'娱乐消费' OR ";
            }
            if (checkBox3.Checked)
            {
                query_type_str += "ExpenseType=N'购物消费' OR ";
            }
            if (checkBox4.Checked)
            {
                query_type_str += "ExpenseType=N'出行消费' OR ";
            }
            if (checkBox5.Checked)
            {
                query_type_str += "ExpenseType=N'生活消费' OR ";
            }
            if(checkBox6.Checked)
            {
                query_type_str += "ExpenseType=N'其他消费' OR ";
            }
            //去掉最后一个" OR "
            query_type_str = query_type_str.Remove(query_type_str.Length - 4, 4);

            //3.金额范围选择与检查是否合法
            int range_case = 0;
            float low_range, high_range;
            bool is_collect_low = float.TryParse(money_range1.Text, out low_range);
            bool is_collect_high = float.TryParse(money_range2.Text, out high_range);
            //可能出现的情况:
            //(1)下边界为空,上边界为空,查询所有金额
            if (money_range1.Text == "" && money_range2.Text == "") range_case = 1;
            //(2)下边界为空,上边界非空,查询<=上边界的金额
            else if (money_range1.Text == "" && is_collect_high) range_case = 2;
            //(3)下边界非空,上边界为空,查询>=下边界的金额
            else if (is_collect_low && money_range2.Text == "") range_case = 3;
            //(4)上下边界均非空且合法
            else if (is_collect_low && is_collect_high && low_range <= high_range) range_case = 4;
            //(5)上下边界中存在不合法
            else
            {
                MessageBox.Show("金额范围格式不正确!", "好像出了点问题...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            counter++;
            //之前已经点过该按钮,remove掉之前添加的操作button,防止重复添加
            if (counter > 1)
            {
                dataGridView.Columns.Remove(dataGridView.Columns[dataGridView.Columns.Count - 1]);
            }
            //不合法事件均已处理,接下来为合法事件的处理事件.
            //将界面选择的日期值转化为字符串
            string str_dt1 = this.dateTimePicker1.Value.ToString("yyyy/MM/dd");
            string str_dt2 = this.dateTimePicker2.Value.ToString("yyyy/MM/dd");
            //查询sql语句构造
            string base_sqlStr = "SELECT * FROM Expense WHERE (" + query_type_str + ") AND ExpenseTime>='" + str_dt1 + "' AND ExpenseTime<='" + str_dt2 + "'";
            //对于4种不同的收入金额边界条件,分情况构造sql整体语句
            string[] sqlStr_list = new string[4] {
                base_sqlStr,
                base_sqlStr+string.Format(" AND ExpenseNum<={0}",high_range),
                base_sqlStr+string.Format(" AND ExpenseNum>={0}",low_range),
                base_sqlStr+string.Format(" AND ExpenseNum>={0} AND ExpenseNum<={1}",low_range,high_range)};
            string order_str = " ORDER BY ExpenseTime asc, ExpenseType asc";

            //断开式数据库连接方式,先查出所要修改/删除的数据
            da = new SqlDataAdapter(sqlStr_list[range_case - 1] + order_str, utils.ConnectStr);

            //生成增删改数据库操作命令
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.InsertCommand = builder.GetInsertCommand();
            da.UpdateCommand = builder.GetUpdateCommand();
            da.DeleteCommand = builder.GetDeleteCommand();
            //采用dataTable来fill查询结果表
            dataTable = new DataTable();
            da.Fill(dataTable);

            //把查询结果表作为dataGridView的数据源
            this.dataGridView.DataSource = dataTable;
            //设置dataGridView的列名
            this.dataGridView.Columns[0].HeaderCell.Value = "id";
            this.dataGridView.Columns[1].HeaderCell.Value = "支出类型";
            this.dataGridView.Columns[2].HeaderCell.Value = "日期";
            this.dataGridView.Columns[3].HeaderCell.Value = "支出金额";
            this.dataGridView.Columns[4].HeaderCell.Value = "备注";
            this.dataGridView.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd";
            //为了美观,将对于当前操作无用的属性列隐藏,并调整列的显示位置
            this.dataGridView.Columns[0].Visible = false;
            this.dataGridView.Columns[2].DisplayIndex = 0;

            //如果选择的是修改操作,在dataGridView中增加"修改"操作按钮
            if (update_Button.Checked)
            {
                DataGridViewButtonColumn modify_btn = new DataGridViewButtonColumn();
                modify_btn.Name = "modify_btn";
                modify_btn.HeaderText = "";
                modify_btn.DefaultCellStyle.NullValue = "修改";
                dataGridView.Columns.Add(modify_btn);
            }
            else if (delete_Button.Checked)
            {
                //如果选择的是删除操作,在dataGridView中增加"删除"操作按钮
                DataGridViewButtonColumn delete_btn = new DataGridViewButtonColumn();
                delete_btn.Name = "delete_btn";
                delete_btn.HeaderText = "";
                delete_btn.DefaultCellStyle.NullValue = "删除";
                dataGridView.Columns.Add(delete_btn);
            }

            //显示查询结果及查询记录总数
            dataGridView.Visible = true;
            string query_ans_str = string.Format("共有{0}条查询结果", dataTable.Rows.Count);
            query_num_txt.Text = query_ans_str;
            query_num_txt.Visible = true;

            return;
        }

        //按下取消按钮时的触发事件处理,清空checkBox的check事件和Text内容
        private void cancel_button_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) checkBox1.Checked = false;
            if (checkBox2.Checked) checkBox2.Checked = false;
            if (checkBox3.Checked) checkBox3.Checked = false;
            if (checkBox4.Checked) checkBox4.Checked = false;
            if (checkBox5.Checked) checkBox5.Checked = false;
            if (checkBox6.Checked) checkBox6.Checked = false;

            this.money_range1.Text = "";
            this.money_range2.Text = "";

            return;
        }

        //检测dataGridView的点击
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //点击datagridview修改按钮事件
            if (dataGridView.Columns[e.ColumnIndex].Name == "modify_btn" && e.RowIndex >= 0)
            {
                //说明点击的列是DataGridViewButtonColumn列
                try
                {
                    //将修改更新到数据库
                    da.Update(dataTable);
                    MessageBox.Show("数据修改成功啦!", "修改成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    //数据库操作出现异常,弹出消息框提示用户
                    MessageBox.Show("数据修改失败, " + ex.Message, "好像出了点问题...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //点击datagridview删除按钮事件
            if (dataGridView.Columns[e.ColumnIndex].Name == "delete_btn" && e.RowIndex >= 0)
            {
                //说明点击的列是DataGridViewButtonColumn列
                try
                {
                    //删除记录影响较大,提示用户再次确认
                    DialogResult dialogResult = MessageBox.Show("您确认要删除该数据吗?", "请再确认一下", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //若用户确认,对数据库进行删除操作
                    if(dialogResult==DialogResult.Yes)
                    {
                        dataGridView.Rows.Remove(dataGridView.Rows[e.RowIndex]);
                        da.Update(dataTable);
                        MessageBox.Show("数据删除成功啦!", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                 }
                catch (SqlException ex)
                {
                    //数据库操作出现异常,弹出消息框提示用户
                    MessageBox.Show("数据删除失败, " + ex.Message, "好像出了点问题...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
