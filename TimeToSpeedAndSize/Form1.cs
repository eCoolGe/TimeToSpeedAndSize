using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeToSpeedAndSize
{
    public partial class Form1 : Form
    {
        double speed;
        double weight;



        public Form1()
        {
            InitializeComponent();
            //linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;

            KeyPreview = true;
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Enter) button1_Click(button1, null); };        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == 0) // kb/s > mb/s
                {
                    speed = Convert.ToDouble(textBox1.Text) / 1024;
                }
                else if (comboBox1.SelectedIndex == 1) // mbit/s > mb/s
                {
                    speed = Convert.ToDouble(textBox1.Text) / 8;
                }
                else if (comboBox1.SelectedIndex == 2) // mb/s > mb/s
                {
                    speed = Convert.ToDouble(textBox1.Text);
                }
                else if (comboBox1.SelectedIndex == 3) // gbit/s > mb/s
                {
                    speed = Convert.ToDouble(textBox1.Text) * 128;
                }

                if (comboBox2.SelectedIndex == 0) // tb > mb
                {
                    weight = Convert.ToDouble(textBox2.Text) * 1048576;
                }
                else if (comboBox2.SelectedIndex == 1) // gb > mb
                {
                    weight = Convert.ToDouble(textBox2.Text) * 1024;
                }
                else if (comboBox2.SelectedIndex == 2) // mb > mb
                {
                    weight = Convert.ToDouble(textBox2.Text);
                }
                else if (comboBox2.SelectedIndex == 3) // kb > mb
                {
                    weight = Convert.ToDouble(textBox2.Text) / 1024;
                }

                //weight = Convert.ToDouble(textBox2.Text) * 8192;

                var ts = TimeSpan.FromSeconds(weight / speed);
                textBox3.Text = ts.Days.ToString() + "дн. " + ts.Hours.ToString() + "ч. " + ts.Minutes.ToString() + "м. " + ts.Seconds.ToString() + "с.";
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Попробуйте внести данные и убрать всё, кроме цифр.", "Обнаружена ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/thenickgame");
        }
    }
}
