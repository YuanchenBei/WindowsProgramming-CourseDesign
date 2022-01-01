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
    public partial class QueryIncomeForm : Form
    {
        public QueryIncomeForm()
        {
            InitializeComponent();
        }

        //窗体加载时要触发的事件
        private void QueryIncomeForm_Load(object sender, EventArgs e)
        {
            //点击查询按钮时才显示表格和总查询结果数
            this.query_dataGridView.Visible = false;
            this.query_num_txt.Visible = false;
        }

        //查询按钮点击事件
        private void query_button_Click(object sender, EventArgs e)
        {
            //合法性判断1.时间获取与检查是否合法
            DateTime dt1 = this.dateTimePicker1.Value;
            DateTime dt2 = this.dateTimePicker2.Value;
            if (DateTime.Compare(dt1, dt2) > 0)
            {
                MessageBox.Show("查询起始日期应该不晚于结束日期!","好像出了点问题...",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            //合法性判断2.type选择与检查是否合法
            if (!(checkBox1.Checked) && !(checkBox2.Checked) && !(checkBox3.Checked) && !(checkBox4.Checked))
            {
                MessageBox.Show("请选择您要查询的若干种收入类型","您好像忘记了一些事情...",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            //由于可以选择多种收入类型,构造sql查询语句的IncomeType字段相关内容
            string query_type_str = "";
            if (checkBox1.Checked)
            {
                query_type_str += "IncomeType=N'工作收入' OR ";
            }
            if (checkBox2.Checked)
            {
                query_type_str += "IncomeType=N'奖金收入' OR ";
            }
            if (checkBox3.Checked)
            {
                query_type_str += "IncomeType=N'投资收入' OR ";
            }
            if (checkBox4.Checked)
            {
                query_type_str += "IncomeType=N'其他收入' OR ";
            }
            //去掉最后一个位置的" OR "
            query_type_str = query_type_str.Remove(query_type_str.Length - 4, 4);

            //合法性判断3.金额范围选择与检查是否合法
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
                MessageBox.Show("金额范围格式不正确!", "好像出了点问题...",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            //不合法事件均已处理,接下来为合法事件的处理事件.
            ////将界面中选择的日期值转换为字符串格式
            string str_dt1 = dt1.ToString("yyyy/MM/dd");
            string str_dt2 = dt2.ToString("yyyy/MM/dd");
            //查询sql语句构造
            string base_sqlStr = "SELECT IncomeTime, IncomeType, IncomeNum, IncomeRemark FROM Income WHERE (" + query_type_str + ") AND IncomeTime>='" + str_dt1 + "' AND IncomeTime<='" + str_dt2 + "'";
            //对于4种不同的收入金额边界条件,分情况构造sql整体语句
            string[] sqlStr_list = new string[4] {
                base_sqlStr,
                base_sqlStr+string.Format(" AND IncomeNum<={0}",high_range),
                base_sqlStr+string.Format(" AND IncomeNum>={0}",low_range),
                base_sqlStr+string.Format(" AND IncomeNum>={0} AND IncomeNum<={1}",low_range,high_range)};
            string order_str = " ORDER BY IncomeTime asc, IncomeType asc"; //按时间顺序升序展示,在时间相同的情况下,按类型的字典序升序展示.
            //采用断开式的数据库连接方式执行查询操作
            using (SqlDataAdapter da = new SqlDataAdapter(sqlStr_list[range_case-1]+order_str, utils.ConnectStr))
            {
                //采用dataset来fill查询结果表
                DataSet ds = new DataSet();
                da.Fill(ds);
                //把查询结果表作为dataGridView的数据源
                this.query_dataGridView.DataSource = ds.Tables[0];
                //设置dataGridView的列名
                this.query_dataGridView.Columns[0].HeaderCell.Value = "日期";
                this.query_dataGridView.Columns[1].HeaderCell.Value = "收入类型";
                this.query_dataGridView.Columns[2].HeaderCell.Value = "收入金额";
                this.query_dataGridView.Columns[3].HeaderCell.Value = "备注";
                //设置日期的显示格式
                this.query_dataGridView.Columns[0].DefaultCellStyle.Format = "yyyy-MM-dd";
                //由于加载时隐藏掉了该控件,此时展示结果时将控件展示
                query_dataGridView.Visible = true;
                //显示查询记录总数
                string query_ans_str = string.Format("共有{0}条查询结果",ds.Tables[0].Rows.Count);
                query_num_txt.Text = query_ans_str;
                query_num_txt.Visible = true;
            }
        }

        //取消按钮点击事件,清空checkBox的点击和Text的文本内容
        private void cancel_button_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) checkBox1.Checked = false;
            if (checkBox2.Checked) checkBox2.Checked = false;
            if (checkBox3.Checked) checkBox3.Checked = false;
            if (checkBox4.Checked) checkBox4.Checked = false;
            money_range1.Text = "";
            money_range2.Text = "";
            return;
        }

    }
}
