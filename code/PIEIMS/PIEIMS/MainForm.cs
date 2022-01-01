using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIEIMS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //为了美观，将背景色设置为透明
            this.welcome_label1.BackColor = Color.Transparent;
            this.welcome_label2.BackColor = Color.Transparent;
            this.welcome_label3.BackColor = Color.Transparent;
            this.welcome_label4.BackColor = Color.Transparent;
            this.logo_pictureBox.BackColor = Color.Transparent;
            this.main_pictureBox.BackColor = Color.Transparent;
            //为按下"新增收入记录"按钮时增加处理事件
            this.add_income.Click += new System.EventHandler(this.add_income_clicked);
            //为按下"新增支出记录"按钮时增加处理事件
            this.add_expense.Click += new System.EventHandler(this.add_expense_clicked);
            //为按下"查询收入记录"按钮时增加处理事件
            this.query_income.Click += new System.EventHandler(this.query_income_clicked);
            //为按下"查询支出记录"按钮时增加处理事件
            this.query_expense.Click += new System.EventHandler(this.query_expense_clicked);
            //为按下"修改/删除 收入记录"按钮时增加处理事件
            this.ud_income.Click += new System.EventHandler(this.ud_income_clicked);
            //为按下"修改/删除 支出记录"按钮时增加处理事件
            this.ud_expense.Click += new System.EventHandler(this.ud_expense_clicked);
            //为按下"收支信息统计"按钮时增加处理事件
            this.stat_button.Click += new System.EventHandler(this.stat_button_clicked);
        }

        //关闭主窗体时关闭应用程序
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //按下"新增收入记录"按钮时所要触发的事件,将AddIncomeForm窗口嵌入主界面的main_panel中并显示
        private void add_income_clicked(object sender,EventArgs e)
        {
            AddIncomeForm addIncomeForm = new AddIncomeForm();
            addIncomeForm.MdiParent = this;
            addIncomeForm.Parent = this.main_panel;
            addIncomeForm.WindowState = FormWindowState.Maximized;
            welcome_word_visible(false);
            addIncomeForm.Show();
        }

        //按下"新增支出记录"按钮时所要触发的事件,将AddExpenseForm窗口嵌入主界面的main_panel中并显示
        private void add_expense_clicked(object sender,EventArgs e)
        {
            AddExpenseForm addExpenseForm = new AddExpenseForm();
            addExpenseForm.MdiParent = this;
            addExpenseForm.Parent = this.main_panel;
            addExpenseForm.WindowState = FormWindowState.Maximized;
            welcome_word_visible(false);
            addExpenseForm.Show();
        }

        //按下"查询收入记录"按钮时所要触发的事件,将QueryIncomeForm窗口嵌入主界面的main_panel中并显示
        private void query_income_clicked(object sender, EventArgs e)
        {
            QueryIncomeForm queryIncomeForm = new QueryIncomeForm();
            queryIncomeForm.MdiParent = this;
            queryIncomeForm.Parent = this.main_panel;
            queryIncomeForm.WindowState = FormWindowState.Maximized;
            welcome_word_visible(false);
            queryIncomeForm.Show();
        }

        //按下"查询支出记录"按钮时所要触发的事件,将QueryExpenseForm窗口嵌入主界面的main_panel中并显示
        private void query_expense_clicked(object sender, EventArgs e)
        {
            QueryExpenseForm queryExpenseForm = new QueryExpenseForm();
            queryExpenseForm.MdiParent = this;
            queryExpenseForm.Parent = this.main_panel;
            queryExpenseForm.WindowState = FormWindowState.Maximized;
            welcome_word_visible(false);
            queryExpenseForm.Show();
        }

        //按下"修改/删除 收入记录"按钮时所要触发的事件,将UDIncomeForm窗口嵌入主界面的main_panel中并显示
        private void ud_income_clicked(object sender, EventArgs e)
        {
            UDIncomeForm udIncomeForm = new UDIncomeForm();
            udIncomeForm.MdiParent = this;
            udIncomeForm.Parent = this.main_panel;
            udIncomeForm.WindowState = FormWindowState.Maximized;
            welcome_word_visible(false);
            udIncomeForm.Show();
        }

        //按下"修改/删除 支出记录"按钮时所要触发的事件,将UDExpenseForm窗口嵌入主界面的main_panel中并显示
        private void ud_expense_clicked(object sender, EventArgs e)
        {
            UDExpenseForm udExpenseForm = new UDExpenseForm();
            udExpenseForm.MdiParent = this;
            udExpenseForm.Parent = this.main_panel;
            udExpenseForm.WindowState = FormWindowState.Maximized;
            welcome_word_visible(false);
            udExpenseForm.Show();
        }

        //按下菜单栏统计按钮时所要触发的事件,将StatisticsForm窗口嵌入主界面的main_panel中并显示
        private void stat_button_clicked(object sender, EventArgs e)
        {
            StatisticsForm statisticsForm = new StatisticsForm();
            statisticsForm.MdiParent = this;
            statisticsForm.Parent = this.main_panel;
            statisticsForm.WindowState = FormWindowState.Maximized;
            welcome_word_visible(false);
            statisticsForm.Show();
        }

        //控制主界面中的欢迎语是否可视化
        private void welcome_word_visible(bool is_vis)
        {
            this.welcome_label1.Visible = is_vis;
            this.welcome_label2.Visible = is_vis;
            this.welcome_label3.Visible = is_vis;
            this.welcome_label4.Visible = is_vis;
            this.logo_pictureBox.Visible = is_vis;
            this.main_pictureBox.Visible = is_vis;
        }
    }
}
