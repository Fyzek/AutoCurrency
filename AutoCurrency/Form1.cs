using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoCurrency
{
    public partial class Form1 : Form
    {
        public string textLogin=" ";
        public string textPassword=" ";
        

        public Form1()
        {

            InitializeComponent();
            label3.ForeColor = Color.DimGray;
            string subPath1 = "Квитанции";
            bool exists1 = System.IO.Directory.Exists(subPath1);
            if (!exists1)
                System.IO.Directory.CreateDirectory(subPath1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
            textLogin = this.textBox1.Text;
           // Properties.Settings.Default.login = this.textBox1.Text;
           // Properties.Settings.Default.Save();
           // Console.WriteLine(Properties.Settings.Default.login);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
            textPassword = this.textBox2.Text;
            //Properties.Settings.Default.password = this.textBox2.Text;
            //Properties.Settings.Default.Save();
            //Console.WriteLine(Properties.Settings.Default.password);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(Properties.Settings.Default.login + " " + Properties.Settings.Default.password);
            if (textLogin == Properties.Settings.Default.login && textPassword == Properties.Settings.Default.password)
            {
                //Console.WriteLine(textLogin + " " + textPassword);
                //MessageBox.Show("Какой-то текст", "Статус", MessageBoxButtons.OK);
                Currency newform = new Currency();
                newform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.DimGray;
        }
    }
}
