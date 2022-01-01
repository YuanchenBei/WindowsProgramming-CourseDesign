
namespace PIEIMS
{
    partial class StatisticsForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.stat_comboBox = new System.Windows.Forms.ComboBox();
            this.start_button = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_month = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_year = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_month)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_year)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(532, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "收支信息统计";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PIEIMS.Properties.Resources.statistics3;
            this.pictureBox1.Location = new System.Drawing.Point(467, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // stat_comboBox
            // 
            this.stat_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stat_comboBox.FormattingEnabled = true;
            this.stat_comboBox.Items.AddRange(new object[] {
            "过去一周",
            "月收支统计",
            "年收支统计"});
            this.stat_comboBox.Location = new System.Drawing.Point(474, 98);
            this.stat_comboBox.Name = "stat_comboBox";
            this.stat_comboBox.Size = new System.Drawing.Size(208, 32);
            this.stat_comboBox.TabIndex = 2;
            this.stat_comboBox.SelectedIndexChanged += new System.EventHandler(this.stat_comboBox_SelectedIndexChanged);
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(529, 136);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(98, 41);
            this.start_button.TabIndex = 4;
            this.start_button.Text = "开始统计";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(698, 98);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(177, 30);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(10, 183);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(617, 446);
            this.chart1.TabIndex = 6;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(627, 183);
            this.chart2.Name = "chart2";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart2.Series.Add(series3);
            this.chart2.Size = new System.Drawing.Size(511, 223);
            this.chart2.TabIndex = 7;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            chartArea3.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart3.Legends.Add(legend3);
            this.chart3.Location = new System.Drawing.Point(627, 406);
            this.chart3.Name = "chart3";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart3.Series.Add(series4);
            this.chart3.Size = new System.Drawing.Size(511, 223);
            this.chart3.TabIndex = 8;
            this.chart3.Text = "chart3";
            // 
            // chart_month
            // 
            chartArea4.Name = "ChartArea1";
            this.chart_month.ChartAreas.Add(chartArea4);
            this.chart_month.Location = new System.Drawing.Point(10, 183);
            this.chart_month.Name = "chart_month";
            series5.ChartArea = "ChartArea1";
            series5.Name = "Series1";
            this.chart_month.Series.Add(series5);
            this.chart_month.Size = new System.Drawing.Size(617, 446);
            this.chart_month.TabIndex = 10;
            this.chart_month.Text = "chart4";
            // 
            // chart_year
            // 
            chartArea5.Name = "ChartArea1";
            this.chart_year.ChartAreas.Add(chartArea5);
            legend4.Name = "Legend1";
            this.chart_year.Legends.Add(legend4);
            this.chart_year.Location = new System.Drawing.Point(10, 183);
            this.chart_year.Name = "chart_year";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series2";
            this.chart_year.Series.Add(series6);
            this.chart_year.Series.Add(series7);
            this.chart_year.Size = new System.Drawing.Size(617, 446);
            this.chart_year.TabIndex = 11;
            this.chart_year.Text = "chart_year";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 631);
            this.ControlBox = false;
            this.Controls.Add(this.chart_year);
            this.Controls.Add(this.chart_month);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.stat_comboBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "StatisticsForm";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_month)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_year)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox stat_comboBox;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_month;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_year;
    }
}