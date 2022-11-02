
namespace WindowsFormsApp1
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
            this.image2d = new System.Windows.Forms.PictureBox();
            this.clr_r = new System.Windows.Forms.TextBox();
            this.clr_g = new System.Windows.Forms.TextBox();
            this.clr_b = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.heightp1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Radius = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CCenter = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.heightp2 = new System.Windows.Forms.TextBox();
            this.point1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.point2 = new System.Windows.Forms.TextBox();
            this.point3 = new System.Windows.Forms.TextBox();
            this.point4 = new System.Windows.Forms.TextBox();
            this.point5 = new System.Windows.Forms.TextBox();
            this.point6 = new System.Windows.Forms.TextBox();
            this.point7 = new System.Windows.Forms.TextBox();
            this.point8 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Fin_Status = new System.Windows.Forms.Label();
            this.CylinderFlag = new System.Windows.Forms.CheckBox();
            this.PyramidFlag = new System.Windows.Forms.CheckBox();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.show2d = new System.Windows.Forms.Button();
            this.show3d = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.image2d)).BeginInit();
            this.SuspendLayout();
            // 
            // image2d
            // 
            this.image2d.Location = new System.Drawing.Point(12, 12);
            this.image2d.Name = "image2d";
            this.image2d.Size = new System.Drawing.Size(411, 318);
            this.image2d.TabIndex = 0;
            this.image2d.TabStop = false;
            this.image2d.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // clr_r
            // 
            this.clr_r.Location = new System.Drawing.Point(506, 32);
            this.clr_r.Name = "clr_r";
            this.clr_r.Size = new System.Drawing.Size(44, 20);
            this.clr_r.TabIndex = 1;
            this.clr_r.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // clr_g
            // 
            this.clr_g.Location = new System.Drawing.Point(556, 32);
            this.clr_g.Name = "clr_g";
            this.clr_g.Size = new System.Drawing.Size(44, 20);
            this.clr_g.TabIndex = 2;
            this.clr_g.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // clr_b
            // 
            this.clr_b.Location = new System.Drawing.Point(606, 32);
            this.clr_b.Name = "clr_b";
            this.clr_b.Size = new System.Drawing.Size(44, 20);
            this.clr_b.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Location = new System.Drawing.Point(438, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Цвет (r,g,b)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // heightp1
            // 
            this.heightp1.Location = new System.Drawing.Point(446, 105);
            this.heightp1.Name = "heightp1";
            this.heightp1.Size = new System.Drawing.Size(44, 20);
            this.heightp1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(503, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "высота";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(503, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "радиус";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Radius
            // 
            this.Radius.Location = new System.Drawing.Point(446, 131);
            this.Radius.Name = "Radius";
            this.Radius.Size = new System.Drawing.Size(44, 20);
            this.Radius.TabIndex = 10;
            this.Radius.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(649, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "центр окружн.";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // CCenter
            // 
            this.CCenter.Location = new System.Drawing.Point(568, 131);
            this.CCenter.Name = "CCenter";
            this.CCenter.Size = new System.Drawing.Size(67, 20);
            this.CCenter.TabIndex = 12;
            this.CCenter.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(438, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Конус/шар:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(438, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Призма/пирамида:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(503, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "высота";
            // 
            // heightp2
            // 
            this.heightp2.Location = new System.Drawing.Point(446, 194);
            this.heightp2.Name = "heightp2";
            this.heightp2.Size = new System.Drawing.Size(44, 20);
            this.heightp2.TabIndex = 16;
            this.heightp2.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // point1
            // 
            this.point1.Location = new System.Drawing.Point(446, 243);
            this.point1.Name = "point1";
            this.point1.Size = new System.Drawing.Size(67, 20);
            this.point1.TabIndex = 18;
            this.point1.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(438, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Основание (x; y; z)";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // point2
            // 
            this.point2.Location = new System.Drawing.Point(519, 243);
            this.point2.Name = "point2";
            this.point2.Size = new System.Drawing.Size(67, 20);
            this.point2.TabIndex = 20;
            // 
            // point3
            // 
            this.point3.Location = new System.Drawing.Point(592, 243);
            this.point3.Name = "point3";
            this.point3.Size = new System.Drawing.Size(67, 20);
            this.point3.TabIndex = 21;
            // 
            // point4
            // 
            this.point4.Location = new System.Drawing.Point(665, 243);
            this.point4.Name = "point4";
            this.point4.Size = new System.Drawing.Size(67, 20);
            this.point4.TabIndex = 22;
            // 
            // point5
            // 
            this.point5.Location = new System.Drawing.Point(446, 269);
            this.point5.Name = "point5";
            this.point5.Size = new System.Drawing.Size(67, 20);
            this.point5.TabIndex = 23;
            // 
            // point6
            // 
            this.point6.Location = new System.Drawing.Point(519, 269);
            this.point6.Name = "point6";
            this.point6.Size = new System.Drawing.Size(67, 20);
            this.point6.TabIndex = 24;
            this.point6.TextChanged += new System.EventHandler(this.textBox14_TextChanged);
            // 
            // point7
            // 
            this.point7.Location = new System.Drawing.Point(592, 269);
            this.point7.Name = "point7";
            this.point7.Size = new System.Drawing.Size(67, 20);
            this.point7.TabIndex = 25;
            // 
            // point8
            // 
            this.point8.Location = new System.Drawing.Point(665, 269);
            this.point8.Name = "point8";
            this.point8.Size = new System.Drawing.Size(67, 20);
            this.point8.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(592, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 26);
            this.button1.TabIndex = 27;
            this.button1.Text = "Добавить объект";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Fin_Status
            // 
            this.Fin_Status.AutoSize = true;
            this.Fin_Status.Location = new System.Drawing.Point(473, 318);
            this.Fin_Status.Name = "Fin_Status";
            this.Fin_Status.Size = new System.Drawing.Size(40, 13);
            this.Fin_Status.TabIndex = 28;
            this.Fin_Status.Text = "Status:";
            this.Fin_Status.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // CylinderFlag
            // 
            this.CylinderFlag.AutoSize = true;
            this.CylinderFlag.Location = new System.Drawing.Point(568, 108);
            this.CylinderFlag.Name = "CylinderFlag";
            this.CylinderFlag.Size = new System.Drawing.Size(70, 17);
            this.CylinderFlag.TabIndex = 29;
            this.CylinderFlag.Text = "Цилиндр";
            this.CylinderFlag.UseVisualStyleBackColor = true;
            this.CylinderFlag.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // PyramidFlag
            // 
            this.PyramidFlag.AutoSize = true;
            this.PyramidFlag.Location = new System.Drawing.Point(565, 196);
            this.PyramidFlag.Name = "PyramidFlag";
            this.PyramidFlag.Size = new System.Drawing.Size(78, 17);
            this.PyramidFlag.TabIndex = 30;
            this.PyramidFlag.Text = "Пирамида";
            this.PyramidFlag.UseVisualStyleBackColor = true;
            this.PyramidFlag.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // show2d
            // 
            this.show2d.Location = new System.Drawing.Point(592, 343);
            this.show2d.Name = "show2d";
            this.show2d.Size = new System.Drawing.Size(135, 26);
            this.show2d.TabIndex = 31;
            this.show2d.Text = "Показать 2д";
            this.show2d.UseVisualStyleBackColor = true;
            this.show2d.Click += new System.EventHandler(this.button2_Click);
            // 
            // show3d
            // 
            this.show3d.Location = new System.Drawing.Point(592, 375);
            this.show3d.Name = "show3d";
            this.show3d.Size = new System.Drawing.Size(135, 26);
            this.show3d.TabIndex = 32;
            this.show3d.Text = "Показать 3д";
            this.show3d.UseVisualStyleBackColor = true;
            this.show3d.Click += new System.EventHandler(this.show3d_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 450);
            this.Controls.Add(this.show3d);
            this.Controls.Add(this.show2d);
            this.Controls.Add(this.PyramidFlag);
            this.Controls.Add(this.CylinderFlag);
            this.Controls.Add(this.Fin_Status);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.point8);
            this.Controls.Add(this.point7);
            this.Controls.Add(this.point6);
            this.Controls.Add(this.point5);
            this.Controls.Add(this.point4);
            this.Controls.Add(this.point3);
            this.Controls.Add(this.point2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.point1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.heightp2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CCenter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Radius);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.heightp1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clr_b);
            this.Controls.Add(this.clr_g);
            this.Controls.Add(this.clr_r);
            this.Controls.Add(this.image2d);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.image2d)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox image2d;
        private System.Windows.Forms.TextBox clr_r;
        private System.Windows.Forms.TextBox clr_g;
        private System.Windows.Forms.TextBox clr_b;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox heightp1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Radius;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CCenter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox heightp2;
        private System.Windows.Forms.TextBox point1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox point2;
        private System.Windows.Forms.TextBox point3;
        private System.Windows.Forms.TextBox point4;
        private System.Windows.Forms.TextBox point5;
        private System.Windows.Forms.TextBox point6;
        private System.Windows.Forms.TextBox point7;
        private System.Windows.Forms.TextBox point8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Fin_Status;
        private System.Windows.Forms.CheckBox CylinderFlag;
        private System.Windows.Forms.CheckBox PyramidFlag;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.Button show2d;
        private System.Windows.Forms.Button show3d;
    }
}

