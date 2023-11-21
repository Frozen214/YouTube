using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             CreateChart2(grid, "Name My chart", "Name My series");
        }
        private void CreateChart2(DataGridView grid, string nameTitle,string seriesName)
        {
            try
            {
                chart.Series.Clear();
                chart.Series.Add(seriesName);

                for (int i = 0; i < grid.RowCount; i++)
                {
                    var name = grid.Rows[i].Cells[0].Value?.ToString() ?? "";
                    var value = grid.Rows[i].Cells[1].Value?.ToString() ?? "";
                    chart.Series[seriesName].Points.AddXY(name, value);
                }
                chart.Titles.Clear();
                chart.Titles.Add(nameTitle);

                chart.ChartAreas[0].AxisX.Title = grid.Columns[0].HeaderText;
                chart.ChartAreas[0].AxisY.Title = grid.Columns[1].HeaderText;

                MessageBox.Show("График сформирован", "Успех");
            }

            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Ошибка: Недостаточно столбцов в DataGridView", "Ошибка");
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка: недопустимые данные в DataGridView", "Ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.myTableTableAdapter.Fill(this.testDBDataSet.MyTable);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart.Series[0].ChartType = SeriesChartType.Column;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            chart.Series[0].ChartType = SeriesChartType.Pie;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            chart.Series[0].ChartType = SeriesChartType.Bar;
        }
    }
}