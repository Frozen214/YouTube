using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;

namespace Design_1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        //для перетаскивания формы
        bool dragging = false;
        Point dragCursorPoint;
        Point dragFormPoint;
        // Глобальные цвета. Активная кнопка
        private Color activeBackgroundColor = Color.FromArgb(52, 52, 52);
        private Color activeForegroundColor = Color.FromArgb(47, 180, 90);

        //Глобальные цвета. Дефолтные цвета
        private Color defaultBackgroundColor = Color.FromArgb(46, 46, 50);
        private Color defaultForegroundColor = Color.FromArgb(200, 200, 200);

        private Form acriveForm = null;
        private void openForm(Form childForm)
        {
            if (acriveForm != null)
                acriveForm.Close();
            acriveForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel4.Controls.Add(childForm);
            panel4.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void SetButtonColors(IconButton button, Color backColor, Color foreColor)
        {
            // Устанавливаем цвета кнопки
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.IconColor = foreColor;
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            // Устанавливаем цвета активной кнопки
            IconButton activeButton = (IconButton)sender;
            SetButtonColors(activeButton, activeBackgroundColor, activeForegroundColor);

            //Включаем левую подсветку
            leftPanel1.Visible = true;

            // Сбрасываем цвета другой кнопки на дефолтные
            SetButtonColors(iconButton2, defaultBackgroundColor, defaultForegroundColor);
            SetButtonColors(iconButton3, defaultBackgroundColor, defaultForegroundColor);

            //сбрасываем левую подсветку у других кнопок
            leftPanel3.Visible = false;
            leftPanel2.Visible = false;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            // Устанавливаем цвета активной кнопки
            IconButton activeButton = (IconButton)sender;
            SetButtonColors(activeButton, activeBackgroundColor, activeForegroundColor);

            //Включаем левую подсветку
            leftPanel2.Visible = true;

            // Сбрасываем цвета другой кнопки на дефолтные
            SetButtonColors(iconButton1, defaultBackgroundColor, defaultForegroundColor);
            SetButtonColors(iconButton3, defaultBackgroundColor, defaultForegroundColor);

            //сбрасываем левую подсветку у других кнопок
            leftPanel3.Visible = false;
            leftPanel1.Visible = false;

            //Открытие формы
            openForm(new FormLK());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            // Устанавливаем цвета активной кнопки
            IconButton activeButton = (IconButton)sender;
            SetButtonColors(activeButton, activeBackgroundColor, activeForegroundColor);

            //Включаем левую подсветку
            leftPanel3.Visible = true;

            // Сбрасываем цвета другой кнопки на дефолтные
            SetButtonColors(iconButton1, defaultBackgroundColor, defaultForegroundColor);
            SetButtonColors(iconButton2, defaultBackgroundColor, defaultForegroundColor);

            //сбрасываем левую подсветку у других кнопок
            leftPanel2.Visible = false;
            leftPanel1.Visible = false;

            //Открытие формы
            openForm(new FormMusic());
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;

        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

