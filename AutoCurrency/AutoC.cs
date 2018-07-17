using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoCurrency
{
    public partial class AutoC : Form
    {

        public double currency;
        public string cur;
        public AutoC()
        {
            InitializeComponent();
            label11.Text = Convert.ToString(Properties.Settings.Default.USDb);
            label12.Text = Convert.ToString(Properties.Settings.Default.EURb);
            label13.Text = Convert.ToString(Properties.Settings.Default.RUBb);
            label14.Text = Convert.ToString(Properties.Settings.Default.USDs);
            label15.Text = Convert.ToString(Properties.Settings.Default.EURs);
            label16.Text = Convert.ToString(Properties.Settings.Default.RUBs);
            label17.Text = Convert.ToString(Properties.Settings.Default.USDv);
            label18.Text = Convert.ToString(Properties.Settings.Default.EURv);
            label19.Text = Convert.ToString(Properties.Settings.Default.RUBv);
            label22.Text = Convert.ToString(Properties.Settings.Default.BYNv);
        }

        private void AutoC_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedEmployee = (string)comboBox.SelectedItem;
            if (selectedEmployee.Equals("USD"))
            {
                currency = Properties.Settings.Default.USDb ;
                cur = "USD";
            }
            if (selectedEmployee.Equals("EUR"))
            {
                currency = Properties.Settings.Default.EURb;
                cur = "EUR";
            }
            if (selectedEmployee.Equals("RUB"))
            {
                currency = Properties.Settings.Default.RUBb;
                cur = "RUB";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("dd.MM.yyyy");//yyyy.MM.dd_HH-mm-ss
            string time1 = DateTime.Now.ToString("HH.mm.ss");
            TextWriter tw = new StreamWriter("Квитанции/"+time+"_"+time1+".txt");

            // написать строку текста в файл
            tw.WriteLine("----------\n"+"Квитанция о валютно-обменной операции\nПокупка валюты\nПолучено:\n"+textBox1.Text+"    \n"
                +"Сумма для обмена:"+textBox2.Text+"\n"+"Валюта:"+cur+"  "+currency+ "\n----------\n");


            // закрыть поток
            tw.Close();

            double poluchsum = Convert.ToDouble(textBox1.Text);
            double obmensum = Convert.ToDouble(textBox2.Text);
            double sum;//итого выдано
            double sdacha;//сдача
            label29.Text = cur;
            try
            {

                sum = obmensum * currency;
                if (Properties.Settings.Default.BYNv - sum < 0)
                {
                    throw new Exception();
                }
                else
                {
                    Properties.Settings.Default.BYNv = Properties.Settings.Default.BYNv - sum;
            switch (cur)
            {
                case "USD":
                    Properties.Settings.Default.USDv += obmensum;
                    break;
                case "EUR":
                    Properties.Settings.Default.EURv += obmensum;
                    break;
                case "RUB":
                    Properties.Settings.Default.RUBv += obmensum;
                    break;
            }
                    sdacha = poluchsum - obmensum;
                    textBox3.Text = Convert.ToString(sum);
                    textBox4.Text = Convert.ToString(sdacha);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не хватает денежных средств для обмена.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            update();


            //  String path = @"Квитанции\" + time + "_" + time1;
            //   bool exists1 = System.IO.Directory.Exists(path);
            // if (!exists1)
            //     System.IO.Directory.CreateDirectory(path);
            //path += "\\Квитанция." + System.IO.Path.GetFileName(infilename);
            //File.Copy(infilename, path, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double poluchsum = Convert.ToDouble(textBox1.Text);
            double obmensum = Convert.ToDouble(textBox2.Text);
            double sum;//итого выдано
            double sdacha;//сдача
            label29.Text = cur;
            try
            {
                
                sum = obmensum * currency;
                if (Properties.Settings.Default.BYNv - sum < 0)
                {
                    throw new Exception();
                }
                else
                {
                    sdacha = poluchsum - obmensum;
                    textBox3.Text = Convert.ToString(sum);
                    textBox4.Text = Convert.ToString(sdacha);

                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Не хватает денежных средств для обмена.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void update()
        {
            label11.Text = Convert.ToString(Properties.Settings.Default.USDb);
            label12.Text = Convert.ToString(Properties.Settings.Default.EURb);
            label13.Text = Convert.ToString(Properties.Settings.Default.RUBb);
            label14.Text = Convert.ToString(Properties.Settings.Default.USDs);
            label15.Text = Convert.ToString(Properties.Settings.Default.EURs);
            label16.Text = Convert.ToString(Properties.Settings.Default.RUBs);
            label17.Text = Convert.ToString(Properties.Settings.Default.USDv);
            label18.Text = Convert.ToString(Properties.Settings.Default.EURv);
            label19.Text = Convert.ToString(Properties.Settings.Default.RUBv);
            label22.Text = Convert.ToString(Properties.Settings.Default.BYNv);
        }

        private void button3_Click(object sender, EventArgs e)//продажа валюты-подсчет
        {
            double poluchsum = Convert.ToDouble(textBox8.Text);//белрубли
            double obmensum = Convert.ToDouble(textBox7.Text);//для обмена
            double sum;//итого выдано
            double sdacha;//сдача
            label32.Text = cur;
            try
            {

                sum = obmensum / currency;
                sdacha = obmensum % currency;

                switch (cur)
                {
                    case "USD":
                        if (Properties.Settings.Default.USDv - sum < 0)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            //Properties.Settings.Default.USDv += obmensum;
                            //sdacha += poluchsum - obmensum;
                            textBox6.Text = Convert.ToString(sum);
                            textBox5.Text = Convert.ToString(sdacha);
                        }
                            break;
                    case "EUR":
                        if (Properties.Settings.Default.EURv - sum < 0)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            //Properties.Settings.Default.EURv += obmensum;
                            //sdacha += poluchsum - obmensum;
                            textBox6.Text = Convert.ToString(sum);
                            textBox5.Text = Convert.ToString(sdacha);
                        }
                        break;
                    case "RUB":
                        if (Properties.Settings.Default.RUBv - sum < 0)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            //Properties.Settings.Default.RUBv += obmensum;
                           // sdacha += poluchsum - obmensum;
                            textBox6.Text = Convert.ToString(sum);
                            textBox5.Text = Convert.ToString(sdacha);
                        }
                        break;
                }

                update();
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не хватает денежных средств для обмена.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedEmployee = (string)comboBox.SelectedItem;
            if (selectedEmployee.Equals("USD"))
            {
                currency = Properties.Settings.Default.USDs;
                cur = "USD";
            }
            if (selectedEmployee.Equals("EUR"))
            {
                currency = Properties.Settings.Default.EURs;
                cur = "EUR";
            }
            if (selectedEmployee.Equals("RUB"))
            {
                currency = Properties.Settings.Default.RUBs;
                cur = "RUB";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("dd.MM.yyyy");//yyyy.MM.dd_HH-mm-ss
            string time1 = DateTime.Now.ToString("HH.mm.ss");
            TextWriter tw = new StreamWriter("Квитанции/" + time + "_" + time1 + ".txt");

            // написать строку текста в файл
            tw.WriteLine("----------\n" + "Квитанция о валютно-обменной операции\nПокупка валюты\nПолучено:\n" + textBox1.Text + "    \n"
                + "Сумма для обмена:" + textBox2.Text + "\n" + "Валюта:" + cur + "  " + currency + "\n----------\n");


            // закрыть поток
            tw.Close();

            double poluchsum = Convert.ToDouble(textBox8.Text);//белрубли
            double obmensum = Convert.ToDouble(textBox7.Text);//для обмена
            double sum;//итого выдано
            double sdacha;//сдача
            label32.Text = cur;
            try
            {

                sum = obmensum / currency;
                sdacha = obmensum % currency;

                switch (cur)
                {
                    case "USD":
                        if (Properties.Settings.Default.USDv - sum < 0)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            Properties.Settings.Default.USDv -= sum;
                            Properties.Settings.Default.BYNv += obmensum;

                        }
                        break;
                    case "EUR":
                        if (Properties.Settings.Default.EURv - sum < 0)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            Properties.Settings.Default.EURv -= sum;
                            Properties.Settings.Default.BYNv += obmensum;

                        }
                        break;
                    case "RUB":
                        if (Properties.Settings.Default.RUBv - sum < 0)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            Properties.Settings.Default.RUBv -= sum;
                            Properties.Settings.Default.BYNv += obmensum;

                        }
                        break;
                }


                update();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не хватает денежных средств для обмена.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
