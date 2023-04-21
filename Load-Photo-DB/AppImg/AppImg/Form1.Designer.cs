namespace AppImg
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
            this.pictureSet = new System.Windows.Forms.PictureBox();
            this.pictureView = new System.Windows.Forms.PictureBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.Labelid = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureView)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureSet
            // 
            this.pictureSet.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureSet.Location = new System.Drawing.Point(66, 95);
            this.pictureSet.Name = "pictureSet";
            this.pictureSet.Size = new System.Drawing.Size(164, 172);
            this.pictureSet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureSet.TabIndex = 0;
            this.pictureSet.TabStop = false;
            // 
            // pictureView
            // 
            this.pictureView.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureView.Location = new System.Drawing.Point(335, 95);
            this.pictureView.Name = "pictureView";
            this.pictureView.Size = new System.Drawing.Size(164, 172);
            this.pictureView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureView.TabIndex = 1;
            this.pictureView.TabStop = false;
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSelect.Location = new System.Drawing.Point(82, 273);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(122, 33);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "SELECT";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnSet
            // 
            this.btnSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSet.Location = new System.Drawing.Point(66, 325);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(164, 42);
            this.btnSet.TabIndex = 3;
            this.btnSet.Text = "SET PHOTO";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnView.Location = new System.Drawing.Point(335, 325);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(164, 42);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "VIEW";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtID.Location = new System.Drawing.Point(367, 271);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(132, 26);
            this.txtID.TabIndex = 5;
            // 
            // Labelid
            // 
            this.Labelid.AutoSize = true;
            this.Labelid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Labelid.Location = new System.Drawing.Point(334, 273);
            this.Labelid.Name = "Labelid";
            this.Labelid.Size = new System.Drawing.Size(27, 20);
            this.Labelid.TabIndex = 6;
            this.Labelid.Text = "id:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 450);
            this.Controls.Add(this.Labelid);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.pictureView);
            this.Controls.Add(this.pictureSet);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureSet;
        private System.Windows.Forms.PictureBox pictureView;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label Labelid;
    }
}

