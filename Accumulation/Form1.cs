using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Diagnostics;

namespace Accumulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ifEmpty()) {
                label5.Text = loop();
            }
        }

        private String loop() {
            double originalDeposit = Double.Parse(textBox1.Text.Replace('.', ','));
            double percentage = 1 + (Double.Parse(textBox2.Text.Replace('.', ',')) / 100);
            double depositEach = Double.Parse(textBox3.Text.Replace('.', ','));
            int numberOf = Int32.Parse(textBox4.Text.Replace('.', ','));

            double am = originalDeposit;

            for (int i = 0; i < numberOf; i++) {
                if (percentageCheckBox.Checked)
                {
                    am = am * percentage + depositEach;
                }
                else {
                    am = (am + depositEach) * percentage;
                }
            }

            return "Amount: " + split(am);
        }

        private bool ifEmpty() {
            bool empty = true;

            if (string.IsNullOrEmpty(textBox1.Text)) {
                empty = false;
            }else if (string.IsNullOrEmpty(textBox2.Text))
            {
                empty = false;
            }else if (string.IsNullOrEmpty(textBox3.Text))
            {
                empty = false;
            }else if (string.IsNullOrEmpty(textBox4.Text))
            {
                empty = false;
            }

            return empty;
        }

        private String split(double am) {
            var f = new NumberFormatInfo { NumberGroupSeparator = " " };

            var s = am.ToString("n", f); // 2 000 000.00

            return s;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            label5.Text = "Amount";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ifEmptyRoot())
            {
                textBox7.Text = root();
            }
        }

        private String root()
        {
            double percentage = 1 + (Double.Parse(textBox5.Text.Replace('.', ',')) / 100);
            double root = Double.Parse(textBox6.Text.Replace('.', ','));

            double result = Math.Pow(percentage, (1.0 / root));
            result = (result - 1) * 100;


            return result.ToString();
        }

        private bool ifEmptyRoot()
        {
            bool empty = true;

            if (string.IsNullOrEmpty(textBox5.Text))
            {
                empty = false;
            }
            else if (string.IsNullOrEmpty(textBox6.Text))
            {
                empty = false;
            }

            return empty;
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }
    }
}
