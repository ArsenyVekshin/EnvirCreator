using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace WindowsFormsApp1
{

    //Config file struct:

    //cylinder r g b x0 y0 z0 R H
    //cone r g b x0 y0 z0 R H
    //sphere r g b x0 y0 z0 R

    //pyramid r g b x0 y0 z0 ... xn yn zn H
    //prism r g b x0 y0 z0 ... xn yn zn H


    public partial class Form1 : Form
    {
        const int picX = 800;
        const int picY = 600;
        
        int[,,] pic = new int[picY, picX, 3]; //2d pic
        int[,] zpic = new int[picY, picX]; //height pic


        public static string configname = "C:/EnvirCreator/config.txt";
        public static string picname = "C:/EnvirCreator/pic2d.jpg";



        public Form1()
        {
            InitializeComponent();
        }
        #region uselles:
            private void pictureBox1_Click(object sender, EventArgs e)
            {

            }
            private void label8_Click(object sender, EventArgs e)
            {

            }
            private void checkBox1_CheckedChanged(object sender, EventArgs e)
            {

            }
            private void textBox8_TextChanged(object sender, EventArgs e)
            {

            }

            private void textBox6_TextChanged(object sender, EventArgs e)
            {

            }

            private void textBox14_TextChanged(object sender, EventArgs e)
            {

            }

            private void textBox2_TextChanged(object sender, EventArgs e)
            {

            }
            private void textBox1_TextChanged(object sender, EventArgs e)
                {

                }

            private void label1_Click(object sender, EventArgs e)
            {

            }

            private void label2_Click(object sender, EventArgs e)
            {

            }

            private void label3_Click(object sender, EventArgs e)
            {

            }

            private void label5_Click(object sender, EventArgs e)
            {

            }

            private void label6_Click(object sender, EventArgs e)
            {

            }

            private void textBox7_TextChanged(object sender, EventArgs e)
            {

            }

            private void label7_Click(object sender, EventArgs e)
            {

            }

            private void label9_Click(object sender, EventArgs e)
            {

            }

            private void textBox9_TextChanged(object sender, EventArgs e)
            {

            }

            private void Form1_Load(object sender, EventArgs e)
            {

            }

            private void label2_Click_1(object sender, EventArgs e)
            {

            }
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        #endregion

        
        public void view2d()
        {
            image2d.Image = Image.FromFile(picname);
        }
        public void clear_board()
        {
            clr_r.Text = "";
            clr_g.Text = "";
            clr_b.Text = "";
            
            heightp1.Text = "";
            CylinderFlag.Checked = false;
            CCenter.Text = "";
            Radius.Text = "";

            heightp2.Text = "";
            point1.Text = "";
            point2.Text = "";
            point3.Text = "";
            point4.Text = "";
            point5.Text = "";
            point6.Text = "";
            point7.Text = "";
            point8.Text = "";
            PyramidFlag.Checked = false;


        }

        public void runPY()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("python");
            Process process = new Process();

            string directory = "C://EnvirCreator/";
            string script = "main.py";

            startInfo.WorkingDirectory = directory;
            startInfo.Arguments = script;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardOutput = true;

            process.StartInfo = startInfo;
            process.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter output = new StreamWriter(configname, false);

            if (clr_r.Text == "" || clr_g.Text == "" || clr_b.Text == "") return;        

           
            if (Radius.Text != "" && CCenter.Text != "") //конус + шар + цилиндр
            {
                //cone r g b x0 y0 z0 R H
                //cylinder r g b x0 y0 z0 R H
                //sphere r g b x0 y0 z0 R

                if (heightp1.Text != "" && !CylinderFlag.Checked) output.Write("cone ");
                else if (heightp1.Text != "" && CylinderFlag.Checked) output.Write("cylinder ");
                else output.Write("sphere ");

                output.Write(clr_r.Text + " " + clr_g.Text + " " + clr_b.Text + " ");
                output.Write(CCenter.Text.Replace(";", " ") + " ");
                output.Write(Radius.Text);
                if (heightp1.Text != "") output.Write(" " + heightp1.Text);
                output.WriteLine("");

                clear_board();
                Fin_Status.Text = "Status: OK";
                output.Close();
                runPY();
                return;
            }
            else if (heightp2.Text != "" && point1.Text != "" && point2.Text != "" && point3.Text != "")
            {
                //pyramid r g b x0 y0 z0 ... xn yn zn H
                //prism r g b x0 y0 z0 ... xn yn zn H
                if(PyramidFlag.Checked) output.Write("pyramid ");
                else output.Write("prism ");

                output.Write(clr_r.Text + " " + clr_g.Text + " " + clr_b.Text + " ");

                if (point1.Text != "") output.Write(point1.Text.Replace(";", " ") + " ");
                if (point2.Text != "") output.Write(point2.Text.Replace(";", " ") + " ");
                if (point3.Text != "") output.Write(point3.Text.Replace(";", " ") + " ");
                if (point4.Text != "") output.Write(point4.Text.Replace(";", " ") + " ");
                if (point5.Text != "") output.Write(point5.Text.Replace(";", " ") + " ");
                if (point6.Text != "") output.Write(point6.Text.Replace(";", " ") + " ");
                if (point7.Text != "") output.Write(point7.Text.Replace(";", " ") + " ");
                if (point8.Text != "") output.Write(point8.Text.Replace(";", " ") + " ");

                output.Write(heightp2.Text);
                output.WriteLine("");

                Fin_Status.Text = "Status: OK";
                clear_board();
                output.Close();
                runPY();
                return;
            }
            Fin_Status.Text = "Status: DATA ERROR";
            output.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter output = new StreamWriter(configname, false);
            output.WriteLine("2dpic");
            output.Close();
            runPY();
        }

        private void show3d_Click(object sender, EventArgs e)
        {
            StreamWriter output = new StreamWriter(configname, false);
            output.WriteLine("3dpic");
            output.Close();
            runPY();
        }
    }
}
