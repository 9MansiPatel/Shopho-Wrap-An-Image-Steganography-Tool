using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMG_STEGO
{
    public partial class Form1 : Form
    {
        public static string method;
        long size;
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files( *.bmp)|; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(open.FileName);
                string imagename = open.SafeFileName;
                textBox1.Text = open.FileName.ToString();
                pictureBox1.ImageLocation = textBox1.Text;



                string path = textBox1.Text;
                pictureBox1.ImageLocation = path;

                open.RestoreDirectory = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();

            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "Text Files|*.doc;*.docx;*.txt;*.text";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = fdlg.FileName;
                size = new FileInfo(fdlg.FileName).Length;
                //      Console.Write("size of file" + size);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            encrypt obj = new encrypt();
            obj.LSBchange(textBox1.Text, textBox2.Text,size);           
                       
        }

       


        private void button2_Click(object sender, EventArgs e)
        {


            decrypt obj = new decrypt();
            obj.LSBDec(textBox3.Text, textBox4.Text);

           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            encrypt obj = new encrypt();
            obj.changeB(textBox1.Text,textBox2.Text,size);
                       
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel5.Visible = true;
                
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            decrypt obj = new decrypt();
            obj.changBDecr(textBox3.Text, textBox4.Text);

          
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files( *.bmp)|; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(open.FileName);
                string imagename = open.SafeFileName;
                textBox3.Text = open.FileName.ToString();
                pictureBox1.ImageLocation = textBox3.Text;



                string path = textBox3.Text;
                pictureBox1.ImageLocation = path;

                open.RestoreDirectory = true;
            }
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
            
             
        }

        private void button8_Click(object sender, EventArgs e)
        {
           /* OpenFileDialog fdlg = new OpenFileDialog();

            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "Text Files|*.doc;*.docx;*.txt;*.text";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {

                textBox4.Text = fdlg.FileName;
              
                if (!File.Exists(textBox4.Text))
                {
                    StreamWriter file = new StreamWriter(textBox4.Text);
                    file.Close();
                    file = new StreamWriter(textBox4.Text);
                    //   file.WriteLine(sb.ToString());
                    file.Close();

                }
                else if (File.Exists(textBox4.Text))
                {
                    TextWriter tw = new StreamWriter(textBox4.Text);
                    //   tw.Write(sb.ToString());
                    tw.Close();
                }

                //      Console.Write("size of file" + size);
            }
            * */

            SaveFileDialog savefile = new SaveFileDialog();
          //  savefile.Filter = "Image Files(*.bmp)| ; *.bmp";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = savefile.FileName.ToString()+".txt";
              //  pictureBox1.ImageLocation = textBox4.Text;
              //  File.Create(textBox4.Text);
                StreamWriter file = new StreamWriter(textBox4.Text);
                file.Close();
                
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            panel1.Visible = false;
            panel2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            pictureBox1.ImageLocation = null;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                label7.Text = "seleted method:  LSB method";
            else
                label7.Text ="selected method:  change B pixel";
            panel5.Visible = false;
            panel4.Visible = true;
            label7.Visible = true;
            if (comboBox1.SelectedIndex==-1)
                MessageBox.Show("PLEASE..SELET ANY METHOD...");
        }

        

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
                MessageBox.Show("PLEASE..SELET ANY MODE...");
            label7.Visible = false;
            panel4.Visible = false;
            
            if (comboBox2.SelectedIndex == 0 && comboBox1.SelectedIndex == 0)
            {
                panel1.Visible = true;
                button1.Visible = true;
                label8.Text = "seleted method:  LSB method" + "\nseleted mode: Encrypt  ";
                

            }
            else if (comboBox2.SelectedIndex == 0 && comboBox1.SelectedIndex == 1)
            {
                panel1.Visible = true;
                button6.Visible = true;
                label8.Text = "seleted method: change B pixel" + "\nseleted mode: Encrypt  ";
            }
            if (comboBox2.SelectedIndex == 1 && comboBox1.SelectedIndex == 0)
            {
                panel2.Visible = true;
                button2.Visible = true;
                label9.Text = "seleted method:  LSB method" + "\nseleted mode:Decrypt";
            }
            else if (comboBox2.SelectedIndex == 1 && comboBox1.SelectedIndex == 1)
            {
                panel2.Visible = true;
                button5.Visible = true;
                label9.Text = "seleted method: change B pixel" + "\nseleted mode: Decrypt ";
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel5.Visible = true;
            panel4.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel5.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            pictureBox1.ImageLocation = null;
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel5_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel4.Visible = true;
            panel5.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            panel4.Visible = true;
            panel5.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;

        }

    }

}    
