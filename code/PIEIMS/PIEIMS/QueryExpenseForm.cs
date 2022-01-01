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
    public partial class QueryExpenseForm : Form
    {
        public QueryExpenseForm()
        {
            InitializeComponent();
        }

        //窗体加载时要触发的事件
        private void QueryExpenseForm_Load(object sender, EventArgs e)
        {
            //将查询结果相关展示控件先隐藏,待选择查询条件并成功查询后再显示
            this.query_dataGridView.Visible = false;
            this.query_num_txt.Visible = false;
        }

        //按下"查询"按钮时所要触发的事件
        private void query_button_Click(object sender, EventArgs e)
        {
            //合法性检查1.时间获取与检查是否合法
            DateTime dt1 = this.dateTimePicker1.Value;
            DateTime dt2 = this.dateTimePicker2.Value;
            if (DateTime.Compare(dt1, dt2) > 0)
            {
                MessageBox.Show("查询起始日期应该不晚于结束日期!", "好像出了点问题...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //合法性检查2.type选择与检查是否合法
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
            if (checkBox6.Checked)
            {
                query_type_str += "ExpenseType=N'其他消费' OR ";
            }
            //把最后一个位置的" OR "去掉
            query_type_str = query_type_str.Remove(query_type_str.Length - 4, 4);

            //合法性检查3.金额范围选择与检查是否合法
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

            //不合法事件均已处理,接下来为合法事件的处理事件.
            //将界面中选择的日期值转换为字符串格式
            string str_dt1 = dt1.ToString("yyyy/MM/dd");
            string str_dt2 = dt2.ToString("yyyy/MM/dd");
            //查询sql语句构造
            string base_sqlStr = "SELECT ExpenseTime, ExpenseType, ExpenseNum, ExpenseRemark FROM Expense WHERE (" + query_type_str + ") AND ExpenseTime>='" + str_dt1 + "' AND ExpenseTime<='" + str_dt2 + "'";
            //对于4种不同的金额范围分情况构造相应的sql整体语句
            string[] sqlStr_list = new string[4] {
                base_sqlStr,
                base_sqlStr+string.Format(" AND ExpenseNum<={0}",high_range),
                base_sqlStr+string.Format(" AND ExpenseNum>={0}",low_range),
                base_sqlStr+string.Format(" AND ExpenseNum>={0} AND ExpenseNum<={1}",low_range,high_range)};
            string order_str = " ORDER BY ExpenseTime asc, ExpenseType asc"; //按时间顺序升序展示,在时间相同的情况下,按类型的字典序升序展示.
            //采用断开式数据库连接方式
            using (SqlDataAdapter da = new SqlDataAdapter(sqlStr_list[range_case - 1] + order_str, utils.ConnectStr))
            {
                DataSet ds = new DataSet();
                da.Fill(ds);
                //查询结果展示在dataGridView中
                this.query_dataGridView.DataSource = ds.Tables[0];
                //设置dataGridView的列名
                this.query_dataGridView.Columns[0].HeaderCell.Value = "日期";
                this.query_dataGridView.Columns[1].HeaderCell.Value = "支出类型";
                this.query_dataGridView.Columns[2].HeaderCell.Value = "支出金额";
                this.query_dataGridView.Columns[3].HeaderCell.Value = "备注";
                //设置日期的显示格式
                this.query_dataGridView.Columns[0].DefaultCellStyle.Format = "yyyy-MM-dd";
                query_dataGridView.Visible = true; //由于加载时隐藏掉了该控件,此时展示结果时将控件展示
                //显示查询记录数
                string query_ans_str = string.Format("共有{0}条查询结果", ds.Tables[0].Rows.Count); 
                query_num_txt.Text = query_ans_str;
                query_num_txt.Visible = true;
            }
        }

        //按下"取消"按钮时,清空checkBox的点击和Text的文本内容
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

    }
}
