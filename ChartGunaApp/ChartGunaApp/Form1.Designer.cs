namespace ChartGunaApp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.Charts.WinForms.ChartFont chartFont57 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont58 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont59 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.ChartFont chartFont60 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid22 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick22 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont61 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid23 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.Tick tick23 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont62 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Grid grid24 = new Guna.Charts.WinForms.Grid();
            Guna.Charts.WinForms.PointLabel pointLabel8 = new Guna.Charts.WinForms.PointLabel();
            Guna.Charts.WinForms.ChartFont chartFont63 = new Guna.Charts.WinForms.ChartFont();
            Guna.Charts.WinForms.Tick tick24 = new Guna.Charts.WinForms.Tick();
            Guna.Charts.WinForms.ChartFont chartFont64 = new Guna.Charts.WinForms.ChartFont();
            this.button1 = new System.Windows.Forms.Button();
            this.gunaChart1 = new Guna.Charts.WinForms.GunaChart();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button1.Location = new System.Drawing.Point(141, 458);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Chart Pie";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gunaChart1
            // 
            this.gunaChart1.BackColor = System.Drawing.Color.White;
            chartFont57.FontName = "Arial";
            this.gunaChart1.Legend.LabelFont = chartFont57;
            this.gunaChart1.Location = new System.Drawing.Point(70, 67);
            this.gunaChart1.Name = "gunaChart1";
            this.gunaChart1.Size = new System.Drawing.Size(681, 372);
            this.gunaChart1.TabIndex = 1;
            chartFont58.FontName = "Arial";
            chartFont58.Size = 12;
            chartFont58.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            this.gunaChart1.Title.Font = chartFont58;
            chartFont59.FontName = "Arial";
            this.gunaChart1.Tooltips.BodyFont = chartFont59;
            chartFont60.FontName = "Arial";
            chartFont60.Size = 9;
            chartFont60.Style = Guna.Charts.WinForms.ChartFontStyle.Bold;
            this.gunaChart1.Tooltips.TitleFont = chartFont60;
            this.gunaChart1.XAxes.GridLines = grid22;
            chartFont61.FontName = "Arial";
            tick22.Font = chartFont61;
            this.gunaChart1.XAxes.Ticks = tick22;
            this.gunaChart1.YAxes.GridLines = grid23;
            chartFont62.FontName = "Arial";
            tick23.Font = chartFont62;
            this.gunaChart1.YAxes.Ticks = tick23;
            this.gunaChart1.ZAxes.GridLines = grid24;
            chartFont63.FontName = "Arial";
            pointLabel8.Font = chartFont63;
            this.gunaChart1.ZAxes.PointLabels = pointLabel8;
            chartFont64.FontName = "Arial";
            tick24.Font = chartFont64;
            this.gunaChart1.ZAxes.Ticks = tick24;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button2.Location = new System.Drawing.Point(268, 458);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "Chart Polar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button3.Location = new System.Drawing.Point(395, 458);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 35);
            this.button3.TabIndex = 3;
            this.button3.Text = "Chart Bar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button4.Location = new System.Drawing.Point(522, 458);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(121, 35);
            this.button4.TabIndex = 4;
            this.button4.Text = "Chart BarHoriz";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 558);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.gunaChart1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Guna.Charts.WinForms.GunaChart gunaChart1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

