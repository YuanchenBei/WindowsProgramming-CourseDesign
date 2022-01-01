using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace PIEIMS
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
        }

        //加载窗体时所要触发的事件
        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            //设置下拉栏默认选择index为0的项
            this.stat_comboBox.SelectedIndex = 0;
            //在选择年,月统计时才显示datatimepicker
            //并设置dateTimePicker的格式
            this.dateTimePicker1.Visible = false;
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            //查询后才显示统计表格
            this.chart1.Visible = false;
            this.chart2.Visible = false;
            this.chart3.Visible = false;
            this.chart_month.Visible = false;
            this.chart_year.Visible = false;
        }

        //点击"开始统计"按钮,分析并可视化统计结果
        private void start_button_Click(object sender, EventArgs e)
        {
            //选中"过去一周"
            //一个柱状图,两个饼状图
            //柱状图展示(日期,收入)和(日期,支出)两组数据
            //饼状图1展示(收入类型,各收入类型金额数和占比)
            //饼状图2展示(支出类型,各支出类型金额数和占比)
            if (this.stat_comboBox.SelectedIndex == 0)
            {
                //选择过去七天日期区间构造sql语句
                string now_dt = DateTime.Now.ToString("yyyy/MM/dd");
                string last_dt = DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd");
                string sqlStr_income = "SELECT IncomeNum, IncomeTime, IncomeType FROM Income WHERE IncomeTime>='" + last_dt + "' AND IncomeTime<='" + now_dt + "'";
                double tot_income = 0;
                double tot_expense = 0;

                //柱状图的x,y轴内容
                //x轴内容:七天的日期值
                string[] col_X = new string[7] { "", "", "", "", "", "", "" };
                for(int i = 7; i >= 1; i--)
                {
                    col_X[7 - i] = DateTime.Today.AddDays(-i).ToString("yyyy/MM/dd");
                }
                //分income和expense两组柱状图来展示数据
                double[] col_Y_income = new double[7] { 0, 0, 0, 0, 0, 0, 0 };
                double[] col_Y_expense = new double[7] { 0, 0, 0, 0, 0, 0, 0 };

                //饼状图1(收入)的x,y轴内容
                double[] pie_X_income = new double[4] { 0, 0, 0, 0 };
                string[] pie_Y_income = new string[4] { "工作收入", "奖金收入", "投资收入", "其他收入" };

                //饼状图2(支出)的x,y轴内容
                double[] pie_X_expense=new double[6] { 0, 0, 0, 0, 0, 0};
                string[] pie_Y_expense = new string[6] { "学习消费", "娱乐消费", "购物消费", "出行消费", "生活消费", "其他消费" };
                
                //先对Income数据进行数据库查询
                using(SqlConnection conn=new SqlConnection(utils.ConnectStr))
                {
                    SqlCommand cmd = new SqlCommand(sqlStr_income, conn);
                    try
                    {
                        conn.Open();
                        SqlDataReader r = cmd.ExecuteReader();
                        //对于读出的数据进行可视化图的统计
                        while (r.Read())
                        {
                            //添加相应天数对应的收入值
                            for(int i = 1; i <= 7; i++)
                            {
                                if ((DateTime)r[1] == DateTime.Today.AddDays(-i).Date)
                                {
                                    col_Y_income[7 - i] += (double)r[0];
                                    break;
                                }
                            }
                            //添加相应收入类型的值
                            for(int i = 0; i < 4; i++)
                            {
                                if ((string)r[2] == pie_Y_income[i])
                                {
                                    pie_X_income[i] += (double)r[0];
                                    tot_income += (double)r[0];
                                    break;
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        //数据库操作异常,弹出消息框提示用户
                        MessageBox.Show("抱歉, 统计信息失败: " + ex.Message, "好像出了点问题...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //进行支出记录的数据库查询
                string sqlStr_expense = "SELECT ExpenseNum, ExpenseTime, ExpenseType FROM Expense WHERE ExpenseTime>='" + last_dt + "' AND ExpenseTime<='" + now_dt + "'"; 
                using (SqlConnection conn = new SqlConnection(utils.ConnectStr))
                {
                    SqlCommand cmd = new SqlCommand(sqlStr_expense, conn);
                    try
                    {
                        conn.Open();
                        SqlDataReader r = cmd.ExecuteReader();
                        //对于读出的数据进行可视化图的统计
                        while (r.Read())
                        {
                            //添加相应天数对应的支出值
                            for (int i = 1; i <= 7; i++)
                            {
                                if ((DateTime)r[1] == DateTime.Today.AddDays(-i).Date)
                                {
                                    col_Y_expense[7 - i] += (double)r[0];
                                    break;
                                }
                            }
                            //添加相应支出类型的值
                            for (int i = 0; i < 6; i++)
                            {
                                if ((string)r[2] == pie_Y_expense[i])
                                {
                                    pie_X_expense[i] += (double)r[0];
                                    tot_expense += (double)r[0];
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //数据库操作异常,弹出消息框提示用户
                        MessageBox.Show("抱歉, 统计信息失败: " + ex.Message, "好像出了点问题...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                //柱状图数据展示
                //第一组数据:日期-收入
                this.chart1.Series[0].ChartType = SeriesChartType.Column;
                this.chart1.Series[0].Points.DataBindXY(col_X, col_Y_income);
                //第二组数据:日期-支出
                this.chart1.Series[1].ChartType = SeriesChartType.Column;
                this.chart1.Series[1].Points.DataBindXY(col_X, col_Y_expense);
                //x轴标签格式设置
                this.chart1.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;
                this.chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                this.chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("微软雅黑", 7f, FontStyle.Bold);
                this.chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("微软雅黑", 7f, FontStyle.Bold);
                this.chart1.Titles.Clear();//add之前先clear一下, 清空重复执行情况下的历史数据
                this.chart1.Titles.Add("过去一周收支信息统计柱状图");
                this.chart1.Titles[0].Font = new Font("微软雅黑", 9f, FontStyle.Bold);
                this.chart1.Titles[0].Alignment = ContentAlignment.TopCenter;
                this.chart1.Series[0].LegendText = "收入金额";
                this.chart1.Series[1].LegendText = "支出金额";
                this.chart1.Legends[0].Font = new Font("微软雅黑", 7f, FontStyle.Regular);
                this.chart1.ChartAreas[0].AxisX.Title = "日期";
                this.chart1.ChartAreas[0].AxisX.TitleFont = new Font("微软雅黑", 8f, FontStyle.Bold);
                this.chart1.ChartAreas[0].AxisY.Title = "金额 (元)";
                this.chart1.ChartAreas[0].AxisY.TitleFont = new Font("微软雅黑", 8f, FontStyle.Bold);
                //设置背景颜色为透明
                this.chart1.BackColor = Color.Transparent;
                this.chart1.ChartAreas[0].BackColor = Color.Transparent;
                this.chart1.ChartAreas[0].BorderColor = Color.Transparent;
                this.chart1.Titles[0].BackColor = Color.Transparent;
                this.chart1.Legends[0].BackColor = Color.Transparent;
                this.chart_month.Visible = false;
                this.chart_year.Visible = false;
                this.chart1.Visible = true;

                //饼状图(收入)的数据展示
                //设置饼状图的样式和展示属性
                this.chart2.Series[0].ChartType = SeriesChartType.Pie;
                this.chart2.Series[0]["PieLabelStyle"] = "Outside";
                this.chart2.Series[0]["PieLineColor"] = "Black";
                this.chart2.Series[0].Points.DataBindXY(pie_Y_income, pie_X_income);
                this.chart2.Series[0].LegendText = "#VALX: #VALY元";
                this.chart2.Series[0].Label = "#PERCENT";
                this.chart2.ChartAreas[0].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
                this.chart2.ChartAreas[0].Area3DStyle.Rotation = 15;//起始角度
                this.chart2.ChartAreas[0].Area3DStyle.Inclination = 45;//倾斜度(0～90)
                this.chart2.ChartAreas[0].Area3DStyle.LightStyle = LightStyle.Realistic;//表面光泽度
                this.chart2.Titles.Clear();//清空历史add数据
                this.chart2.Titles.Add("过去一周收入金额类型分布");
                this.chart2.Titles[0].Font = new Font("微软雅黑", 8f, FontStyle.Bold);
                this.chart2.Titles[0].Alignment = ContentAlignment.TopCenter;
                this.chart2.Titles.Add(string.Format("总收入: {0}元",tot_income));
                this.chart2.Titles[1].Font = new Font("微软雅黑", 7f, FontStyle.Regular);
                this.chart2.Titles[1].Alignment = ContentAlignment.TopCenter;
                this.chart2.Legends[0].Font = new Font("微软雅黑", 7f, FontStyle.Regular);
                //设置背景颜色为透明
                this.chart2.BackColor = Color.Transparent;
                this.chart2.ChartAreas[0].BackColor = Color.Transparent;
                this.chart2.ChartAreas[0].BorderColor = Color.Transparent;
                this.chart2.Titles[0].BackColor = Color.Transparent;
                this.chart2.Titles[1].BackColor = Color.Transparent;
                this.chart2.Legends[0].BackColor = Color.Transparent;
                this.chart2.Visible = true;

                //饼状图(支出)的数据展示
                //设置饼状图的样式和展示属性
                this.chart3.Series[0].ChartType = SeriesChartType.Pie;
                this.chart3.Series[0]["PieLabelStyle"] = "Outside";
                this.chart3.Series[0]["PieLineColor"] = "Black";
                this.chart3.Series[0].Points.DataBindXY(pie_Y_expense, pie_X_expense);
                this.chart3.Series[0].LegendText = "#VALX: #VALY元";
                this.chart3.Series[0].Label = "#PERCENT";
                this.chart3.ChartAreas[0].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
                this.chart3.ChartAreas[0].Area3DStyle.Rotation = 15;//起始角度
                this.chart3.ChartAreas[0].Area3DStyle.Inclination = 45;//倾斜度(0～90)
                this.chart3.ChartAreas[0].Area3DStyle.LightStyle = LightStyle.Realistic;//表面光泽度
                this.chart3.Titles.Clear();//清空历史add数据
                this.chart3.Titles.Add("过去一周支出金额类型分布");
                this.chart3.Titles[0].Font = new Font("微软雅黑", 8f, FontStyle.Bold);
                this.chart3.Titles[0].Alignment = ContentAlignment.TopCenter;
                this.chart3.Titles.Add(string.Format("总支出: {0}元", tot_expense));
                this.chart3.Titles[1].Font = new Font("微软雅黑", 7f, FontStyle.Regular);
                this.chart3.Titles[1].Alignment = ContentAlignment.TopCenter;
                this.chart3.Legends[0].Font = new Font("微软雅黑", 7f, FontStyle.Regular);
                //设置背景颜色为透明
                this.chart3.BackColor = Color.Transparent;
                this.chart3.ChartAreas[0].BackColor = Color.Transparent;
                this.chart3.ChartAreas[0].BorderColor = Color.Transparent;
                this.chart3.Titles[0].BackColor = Color.Transparent;
                this.chart3.Titles[1].BackColor = Color.Transparent;
                this.chart3.Legends[0].BackColor = Color.Transparent;
                this.chart3.Visible = true;
            }

            //选中"月收支统计"
            //柱状图展示(月收入,收入值),(月支出,支出值)
            //饼状图1展示(收入类型,各收入类型金额数和占比)
            //饼状图2展示(支出类型,各支出类型金额数和占比)
            if (this.stat_comboBox.SelectedIndex == 1)
            {
                //月起始时间
                DateTime month_start = Convert.ToDateTime(this.dateTimePicker1.Value.ToString("yyyy/MM")+"/01 00:00:00");
                //月终止时间
                DateTime month_end = month_start.AddMonths(1);
                string month_start_str = month_start.ToString("yyyy/MM/dd");
                string month_end_str = month_end.ToString("yyyy/MM/dd");
                //income查询的sql语句
                string sqlStr_income = "SELECT IncomeNum, IncomeTime, IncomeType FROM Income WHERE IncomeTime>='" + month_start_str + "' AND IncomeTime<='" + month_end_str + "'";
                double tot_income = 0;
                double tot_expense = 0;
                
                //月收入柱状图的x,y轴内容
                string[] col_X = new string[2] {"月收入","月支出"};
                double[] col_Y = new double[2] { 0, 0 };

                //饼状图1的x,y轴内容
                double[] pie_X_income = new double[4] { 0, 0, 0, 0 };
                string[] pie_Y_income = new string[4] { "工作收入", "奖金收入", "投资收入", "其他收入" };

                //饼状图2的x,y轴内容
                double[] pie_X_expense = new double[6] { 0, 0, 0, 0, 0, 0 };
                string[] pie_Y_expense = new string[6] { "学习消费", "娱乐消费", "购物消费", "出行消费", "生活消费", "其他消费" };

                //收入部分数据的统计
                using (SqlConnection conn = new SqlConnection(utils.ConnectStr))
                {
                    SqlCommand cmd = new SqlCommand(sqlStr_income, conn);
                    try
                    {
                        conn.Open();
                        SqlDataReader r = cmd.ExecuteReader();
                        while (r.Read())
                        {
                            //月收入值相应的增加
                            col_Y[0] += (double)r[0];
                            for (int i = 0; i < 4; i++)
                            {
                                //各收入类型值相应增加
                                if ((string)r[2] == pie_Y_income[i])
                                {
                                    pie_X_income[i] += (double)r[0];
                                    tot_income += (double)r[0];
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //数据库操作异常,弹出消息框提示用户
                        MessageBox.Show("抱歉, 统计信息失败: " + ex.Message, "好像出了点问题...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //支出记录选择的sql
                string sqlStr_expense = "SELECT ExpenseNum, ExpenseTime, ExpenseType FROM Expense WHERE ExpenseTime>='" + month_start_str + "' AND ExpenseTime<='" + month_end_str + "'";
                using (SqlConnection conn = new SqlConnection(utils.ConnectStr))
                {
                    SqlCommand cmd = new SqlCommand(sqlStr_expense, conn);
                    try
                    {
                        conn.Open();
                        SqlDataReader r = cmd.ExecuteReader();
                        while (r.Read())
                        {
                            //月支出值相应增加
                            col_Y[1] += (double)r[0];
                            for (int i = 0; i < 6; i++)
                            {
                                //各支出类型值相应增加
                                if ((string)r[2] == pie_Y_expense[i])
                                {
                                    pie_X_expense[i] += (double)r[0];
                                    tot_expense += (double)r[0];
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //数据库操作异常,弹出消息框提示用户
                        MessageBox.Show("抱歉, 统计信息失败: " + ex.Message, "好像出了点问题...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //柱状图展示
                    //设置柱状图的样式及格式属性
                    this.chart_month.Series[0].ChartType = SeriesChartType.Column;
                    this.chart_month.Series[0].Points.DataBindXY(col_X, col_Y);
                    this.chart_month.Legends.Clear();
                    this.chart_month.Titles.Clear();//add之前先clear一下, 清空重复执行情况下的历史数据
                    this.chart_month.Titles.Add(string.Format("{0}月收支信息统计柱状图",month_start.ToString("yyyy-MM")));
                    this.chart_month.Titles[0].Font = new Font("微软雅黑", 9f, FontStyle.Bold);
                    this.chart_month.Titles[0].Alignment = ContentAlignment.TopCenter;
                    this.chart_month.Series[0].Label = "#VAL";
                    this.chart_month.Series[0].Points[1].Color = Color.Green;
                    this.chart_month.ChartAreas[0].AxisX.LabelStyle.Font = new Font("微软雅黑", 8f, FontStyle.Bold);
                    this.chart_month.ChartAreas[0].AxisY.Title = "金额 (元)";
                    this.chart_month.ChartAreas[0].AxisY.TitleFont = new Font("微软雅黑", 8f, FontStyle.Bold);
                    this.chart_month.ChartAreas[0].AxisY.LabelStyle.Font = new Font("微软雅黑", 7f, FontStyle.Bold);
                    //设置背景颜色为透明
                    this.chart_month.BackColor = Color.Transparent;
                    this.chart_month.ChartAreas[0].BackColor = Color.Transparent;
                    this.chart_month.ChartAreas[0].BorderColor = Color.Transparent;
                    this.chart_month.Titles[0].BackColor = Color.Transparent;
                    this.chart1.Visible = false;
                    this.chart_year.Visible = false;
                    this.chart_month.Visible = true;

                    //饼状图展示(收入类型分布)
                    //设置饼状图展示样式
                    this.chart2.Series[0].ChartType = SeriesChartType.Pie;
                    this.chart2.Series[0]["PieLabelStyle"] = "Outside";
                    this.chart2.Series[0]["PieLineColor"] = "Black";
                    this.chart2.Series[0].Points.DataBindXY(pie_Y_income, pie_X_income);
                    this.chart2.Series[0].LegendText = "#VALX: #VALY元";
                    this.chart2.Series[0].Label = "#PERCENT";
                    this.chart2.ChartAreas[0].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
                    this.chart2.ChartAreas[0].Area3DStyle.Rotation = 15;//起始角度
                    this.chart2.ChartAreas[0].Area3DStyle.Inclination = 45;//倾斜度(0～90)
                    this.chart2.ChartAreas[0].Area3DStyle.LightStyle = LightStyle.Realistic;//表面光泽度
                    this.chart2.Titles.Clear();//清空历史add数据
                    this.chart2.Titles.Add(string.Format("{0}月收入金额类型分布",month_start.ToString("yyyy-MM")));
                    this.chart2.Titles[0].Font = new Font("微软雅黑", 8f, FontStyle.Bold);
                    this.chart2.Titles[0].Alignment = ContentAlignment.TopCenter;
                    this.chart2.Titles.Add(string.Format("总收入: {0}元", tot_income));
                    this.chart2.Titles[1].Font = new Font("微软雅黑", 7f, FontStyle.Regular);
                    this.chart2.Titles[1].Alignment = ContentAlignment.TopCenter;
                    this.chart2.Legends[0].Font = new Font("微软雅黑", 7f, FontStyle.Regular);
                    //设置背景颜色为透明
                    this.chart2.BackColor = Color.Transparent;
                    this.chart2.ChartAreas[0].BackColor = Color.Transparent;
                    this.chart2.ChartAreas[0].BorderColor = Color.Transparent;
                    this.chart2.Titles[0].BackColor = Color.Transparent;
                    this.chart2.Titles[1].BackColor = Color.Transparent;
                    this.chart2.Legends[0].BackColor = Color.Transparent;
                    this.chart2.Visible = true;

                    //饼状图展示(支出类型分布)
                    //设置饼状图的展示样式
                    this.chart3.Series[0].ChartType = SeriesChartType.Pie;
                    this.chart3.Series[0]["PieLabelStyle"] = "Outside";
                    this.chart3.Series[0]["PieLineColor"] = "Black";
                    this.chart3.Series[0].Points.DataBindXY(pie_Y_expense, pie_X_expense);
                    this.chart3.Series[0].LegendText = "#VALX: #VALY元";
                    this.chart3.Series[0].Label = "#PERCENT";
                    this.chart3.ChartAreas[0].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
                    this.chart3.ChartAreas[0].Area3DStyle.Rotation = 15;//起始角度
                    this.chart3.ChartAreas[0].Area3DStyle.Inclination = 45;//倾斜度(0～90)
                    this.chart3.ChartAreas[0].Area3DStyle.LightStyle = LightStyle.Realistic;//表面光泽度
                    this.chart3.Titles.Clear();//清空历史add数据
                    this.chart3.Titles.Add(string.Format("{0}月支出金额类型分布",month_start.ToString("yyyy-MM")));
                    this.chart3.Titles[0].Font = new Font("微软雅黑", 8f, FontStyle.Bold);
                    this.chart3.Titles[0].Alignment = ContentAlignment.TopCenter;
                    this.chart3.Titles.Add(string.Format("总支出: {0}元", tot_expense));
                    this.chart3.Titles[1].Font = new Font("微软雅黑", 7f, FontStyle.Regular);
                    this.chart3.Titles[1].Alignment = ContentAlignment.TopCenter;
                    this.chart3.Legends[0].Font = new Font("微软雅黑", 7f, FontStyle.Regular);
                    //设置背景颜色为透明
                    this.chart3.BackColor = Color.Transparent;
                    this.chart3.ChartAreas[0].BackColor = Color.Transparent;
                    this.chart3.ChartAreas[0].BorderColor = Color.Transparent;
                    this.chart3.Titles[0].BackColor = Color.Transparent;
                    this.chart3.Titles[1].BackColor = Color.Transparent;
                    this.chart3.Legends[0].BackColor = Color.Transparent;
                    this.chart3.Visible = true;
                }
            }

            //选中"年收支统计"
            //一个柱状图,两个饼状图
            //柱状图展示(年-月,收入)和(年-月,支出)两组数据
            //饼状图1展示(收入类型,各收入类型金额数和占比)
            //饼状图2展示(支出类型,各支出类型金额数和占比)
            if (this.stat_comboBox.SelectedIndex == 2)
            {
                //年起始和终止时间
                DateTime year_start = Convert.ToDateTime(this.dateTimePicker1.Value.ToString("yyyy") + "/01/01 00:00:00");
                DateTime year_end = year_start.AddYears(1);
                string year_start_str = year_start.ToString("yyyy/MM/dd");
                string year_end_str = year_end.ToString("yyyy/MM/dd");
                string sqlStr_income = "SELECT IncomeNum, IncomeTime, IncomeType FROM Income WHERE IncomeTime>='" + year_start_str + "' AND IncomeTime<='" + year_end_str + "'";
                double tot_income = 0;
                double tot_expense = 0;

                //年收入柱状图的x,y轴内容
                //x轴为年-月
                string[] col_X = new string[12] { "", "", "", "", "", "", "", "", "", "", "", "" };
                for(int i = 0; i < 12; i++)
                {
                    col_X[i] = year_start.AddMonths(i).ToString("yyyy/MM");
                }
                //y轴两组数据分别为收入值和支出值
                double[] col_Y_income = new double[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
                double[] col_Y_expense = new double[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                //饼状图1的x,y轴内容:收入类型和相应值
                double[] pie_X_income = new double[4] { 0, 0, 0, 0 };
                string[] pie_Y_income = new string[4] { "工作收入", "奖金收入", "投资收入", "其他收入" };

                //饼状图2的x,y轴内容:支出类型和相应值
                double[] pie_X_expense = new double[6] { 0, 0, 0, 0, 0, 0 };
                string[] pie_Y_expense = new string[6] { "学习消费", "娱乐消费", "购物消费", "出行消费", "生活消费", "其他消费" };

                //收入部分数据的统计
                using (SqlConnection conn = new SqlConnection(utils.ConnectStr))
                {
                    SqlCommand cmd = new SqlCommand(sqlStr_income, conn);
                    try
                    {
                        conn.Open();
                        SqlDataReader r = cmd.ExecuteReader();
                        while (r.Read())
                        {
                            for (int i = 0; i <= 11; i++)
                            {
                                DateTime vaild_date = Convert.ToDateTime(((DateTime)r[1]).ToString("yyyy/MM")+"/01 00:00:00");
                                //各月收入值进行累加
                                if (vaild_date == year_start.AddMonths(i))
                                {
                                    col_Y_income[i] += (double)r[0];
                                    break;
                                }
                            }
                            for (int i = 0; i < 4; i++)
                            {
                                //各收入类型进行累加
                                if ((string)r[2] == pie_Y_income[i])
                                {
                                    pie_X_income[i] += (double)r[0];
                                    tot_income += (double)r[0];
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //数据库操作异常,弹出消息框提示用户
                        MessageBox.Show("抱歉, 统计信息失败: " + ex.Message, "好像出了点问题...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //支出数据的sql查询
                string sqlStr_expense = "SELECT ExpenseNum, ExpenseTime, ExpenseType FROM Expense WHERE ExpenseTime>='" + year_start_str + "' AND ExpenseTime<='" + year_end_str + "'";
                using (SqlConnection conn = new SqlConnection(utils.ConnectStr))
                {
                    SqlCommand cmd = new SqlCommand(sqlStr_expense, conn);
                    try
                    {
                        conn.Open();
                        SqlDataReader r = cmd.ExecuteReader();
                        while (r.Read())
                        {
                            for (int i = 0; i <= 11; i++)
                            {
                                //各月支出值进行累加
                                DateTime vaild_date = Convert.ToDateTime(((DateTime)r[1]).ToString("yyyy/MM") + "/01 00:00:00");
                                if (vaild_date == year_start.AddMonths(i))
                                {
                                    col_Y_expense[i] += (double)r[0];
                                    break;
                                }
                            }
                            //各支出类型进行累加
                            for (int i = 0; i < 6; i++)
                            {
                                if ((string)r[2] == pie_Y_expense[i])
                                {
                                    pie_X_expense[i] += (double)r[0];
                                    tot_expense += (double)r[0];
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //数据库操作异常,弹出消息框提示用户
                        MessageBox.Show("抱歉, 统计信息失败: " + ex.Message, "好像出了点问题...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //柱状图展示
                    //设置柱状图的样式及格式属性
                    this.chart_year.Series[0].ChartType = SeriesChartType.Column;
                    this.chart_year.Series[0].Points.DataBindXY(col_X, col_Y_income);
                    this.chart_year.Series[1].ChartType = SeriesChartType.Column;
                    this.chart_year.Series[1].Points.DataBindXY(col_X, col_Y_expense);
                    this.chart_year.Legends[0].Font = new Font("微软雅黑", 7f, FontStyle.Bold);
                    this.chart_year.Legends[0].BackColor = Color.Transparent;
                    this.chart_year.Series[0].LegendText = "收入金额";
                    this.chart_year.Series[1].LegendText = "支出金额";
                    this.chart_year.ChartAreas[0].AxisX.Interval = 1;
                    this.chart_year.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;
                    this.chart_year.ChartAreas[0].AxisX.LabelStyle.Angle = -60;
                    this.chart_year.ChartAreas[0].AxisX.LabelStyle.Font = new Font("微软雅黑", 7f, FontStyle.Bold);
                    this.chart_year.ChartAreas[0].AxisY.LabelStyle.Font = new Font("微软雅黑", 7f, FontStyle.Bold);
                    this.chart_year.Titles.Clear();//add之前先clear一下, 清空重复执行情况下的历史数据
                    this.chart_year.Titles.Add(string.Format("{0}年收支信息统计柱状图", year_start.ToString("yyyy")));
                    this.chart_year.Titles[0].Font = new Font("微软雅黑", 9f, FontStyle.Bold);
                    this.chart_year.Titles[0].Alignment = ContentAlignment.TopCenter;
                    this.chart_year.ChartAreas[0].AxisX.Title = "月份";
                    this.chart_year.ChartAreas[0].AxisX.TitleFont = new Font("微软雅黑", 8f, FontStyle.Bold);
                    this.chart_year.ChartAreas[0].AxisY.Title = "金额 (元)";
                    this.chart_year.ChartAreas[0].AxisY.TitleFont = new Font("微软雅黑", 8f, FontStyle.Bold);
                    //设置背景颜色为透明
                    this.chart_year.BackColor = Color.Transparent;
                    this.chart_year.ChartAreas[0].BackColor = Color.Transparent;
                    this.chart_year.ChartAreas[0].BorderColor = Color.Transparent;
                    this.chart_year.Titles[0].BackColor = Color.Transparent;
                    this.chart1.Visible = false;
                    this.chart_month.Visible = false;
                    this.chart_year.Visible = true;

                    //饼状图展示(收入类型分布)
                    //设置饼状图展示样式
                    this.chart2.Series[0].ChartType = SeriesChartType.Pie;
                    this.chart2.Series[0]["PieLabelStyle"] = "Outside";
                    this.chart2.Series[0]["PieLineColor"] = "Black";
                    this.chart2.Series[0].Points.DataBindXY(pie_Y_income, pie_X_income);
                    this.chart2.Series[0].LegendText = "#VALX: #VALY元";
                    this.chart2.Series[0].Label = "#PERCENT";
                    this.chart2.ChartAreas[0].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
                    this.chart2.ChartAreas[0].Area3DStyle.Rotation = 15;//起始角度
                    this.chart2.ChartAreas[0].Area3DStyle.Inclination = 45;//倾斜度(0～90)
                    this.chart2.ChartAreas[0].Area3DStyle.LightStyle = LightStyle.Realistic;//表面光泽度
                    this.chart2.Titles.Clear();//清空历史add数据
                    this.chart2.Titles.Add(string.Format("{0}年收入金额类型分布", year_start.ToString("yyyy")));
                    this.chart2.Titles[0].Font = new Font("微软雅黑", 8f, FontStyle.Bold);
                    this.chart2.Titles[0].Alignment = ContentAlignment.TopCenter;
                    this.chart2.Titles.Add(string.Format("总收入: {0}元", tot_income));
                    this.chart2.Titles[1].Font = new Font("微软雅黑", 7f, FontStyle.Regular);
                    this.chart2.Titles[1].Alignment = ContentAlignment.TopCenter;
                    this.chart2.Legends[0].Font = new Font("微软雅黑", 7f, FontStyle.Regular);
                    //设置背景颜色为透明
                    this.chart2.BackColor = Color.Transparent;
                    this.chart2.ChartAreas[0].BackColor = Color.Transparent;
                    this.chart2.ChartAreas[0].BorderColor = Color.Transparent;
                    this.chart2.Titles[0].BackColor = Color.Transparent;
                    this.chart2.Titles[1].BackColor = Color.Transparent;
                    this.chart2.Legends[0].BackColor = Color.Transparent;
                    this.chart2.Visible = true;

                    //饼状图展示(支出类型分布)
                    //设置饼状图的展示样式
                    this.chart3.Series[0].ChartType = SeriesChartType.Pie;
                    this.chart3.Series[0]["PieLabelStyle"] = "Outside";
                    this.chart3.Series[0]["PieLineColor"] = "Black";
                    this.chart3.Series[0].Points.DataBindXY(pie_Y_expense, pie_X_expense);
                    this.chart3.Series[0].LegendText = "#VALX: #VALY元";
                    this.chart3.Series[0].Label = "#PERCENT";
                    this.chart3.ChartAreas[0].Area3DStyle.Enable3D = true;//开启三维模式;PointDepth:厚度BorderWidth:边框宽
                    this.chart3.ChartAreas[0].Area3DStyle.Rotation = 15;//起始角度
                    this.chart3.ChartAreas[0].Area3DStyle.Inclination = 45;//倾斜度(0～90)
                    this.chart3.ChartAreas[0].Area3DStyle.LightStyle = LightStyle.Realistic;//表面光泽度
                    this.chart3.Titles.Clear();//清空历史add数据
                    this.chart3.Titles.Add(string.Format("{0}年支出金额类型分布", year_start.ToString("yyyy")));
                    this.chart3.Titles[0].Font = new Font("微软雅黑", 8f, FontStyle.Bold);
                    this.chart3.Titles[0].Alignment = ContentAlignment.TopCenter;
                    this.chart3.Titles.Add(string.Format("总支出: {0}元", tot_expense));
                    this.chart3.Titles[1].Font = new Font("微软雅黑", 7f, FontStyle.Regular);
                    this.chart3.Titles[1].Alignment = ContentAlignment.TopCenter;
                    this.chart3.Legends[0].Font = new Font("微软雅黑", 7f, FontStyle.Regular);
                    //设置背景颜色为透明
                    this.chart3.BackColor = Color.Transparent;
                    this.chart3.ChartAreas[0].BackColor = Color.Transparent;
                    this.chart3.ChartAreas[0].BorderColor = Color.Transparent;
                    this.chart3.Titles[0].BackColor = Color.Transparent;
                    this.chart3.Titles[1].BackColor = Color.Transparent;
                    this.chart3.Legends[0].BackColor = Color.Transparent;
                    this.chart3.Visible = true;

                }
            }

        }

        //统计目标的选择框中的选择发生变化时的事件处理
        private void stat_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //选择"过去一周",无需用到dateTimePicker
            if (stat_comboBox.SelectedIndex == 0)
            {
                this.dateTimePicker1.Visible = false;
            }
            //选择"月统计",需要dateTimePicker并将格式设置为'年-月'
            if (stat_comboBox.SelectedIndex == 1)
            {
                this.dateTimePicker1.CustomFormat = "yyyy-MM";
                this.dateTimePicker1.Visible = true;
            }
            //选择"年统计",需要dateTimePicker并将格式设置为'年'
            if (stat_comboBox.SelectedIndex == 2)
            {
                this.dateTimePicker1.CustomFormat = "yyyy";
                this.dateTimePicker1.Visible = true;
            }
        }
    }
}
