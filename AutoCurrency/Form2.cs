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
    public partial class Form2 : Form
    {

        public string Login;
        public string Password1;
        public string Password2;

        public Form2()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Login = this.textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Password1 = this.textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Password2 = this.textBox5.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Password1 == Password2)
            {
                Properties.Settings.Default.password = this.textBox4.Text;
                Properties.Settings.Default.login = this.textBox3.Text;

                Properties.Settings.Default.Save();
                Form1 newForm = new Form1();
                newForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Какой-то текст", "Заголовок", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Hide();
        }
    }
}
