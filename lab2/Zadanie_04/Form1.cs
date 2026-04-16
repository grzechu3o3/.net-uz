using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie_04
{
    public partial class Form1 : Form
    {
        private double num1 = 0;
        private double num2 = 0;
        private enum operations  {
            divide, multiply, substract, add, none
        };
        private operations operation = operations.none;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += 8;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void number7_Click(object sender, EventArgs e)
        {
            textBox1.Text += 7;
        }

        private void number9_Click(object sender, EventArgs e)
        {
            textBox1.Text += 9;
        }

        private void number4_Click(object sender, EventArgs e)
        {
            textBox1.Text += 4;
        }

        private void number5_Click(object sender, EventArgs e)
        {
            textBox1.Text += 5;
        }

        private void number6_Click(object sender, EventArgs e)
        {
            textBox1.Text += 6;
        }

        private void number1_Click(object sender, EventArgs e)
        {
            textBox1.Text += 1;
        }

        private void number2_Click(object sender, EventArgs e)
        {
            textBox1.Text += 2;
        }

        private void number3_Click(object sender, EventArgs e)
        {
            textBox1.Text += 3;
        }

        private void number0_Click(object sender, EventArgs e)
        {
            textBox1.Text += 0;
        }

        private void add_Click(object sender, EventArgs e)
        {
            this.operation = operations.add;
            this.num1 = convertToNum();
        }

        private void divide_Click(object sender, EventArgs e)
        {
            this.operation = operations.divide;
            this.num1 = convertToNum();
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            this.operation = operations.multiply;
            this.num1 = convertToNum();
        }

        private void subtract_Click(object sender, EventArgs e)
        {
            this.operation = operations.substract;
            this.num1 = convertToNum();
        }

        private void equals_Click(object sender, EventArgs e)
        {
            if (operation.Equals(operations.none)) MessageBox.Show("No operation selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.num2 = convertToNum();
                if(operation.Equals(operations.add))
                {
                    double result = num1 + num2;
                    textBox1.Text = result.ToString();
                } else if(operation.Equals(operations.substract))
                {
                    double result = num1 - num2;
                    textBox1.Text = result.ToString();
                } else if(operation.Equals(operations.multiply))
                {
                    double result = num1 * num2;
                    textBox1.Text = result.ToString();
                } else if(operation.Equals(operations.divide))
                {
                    if (num2 == 0) MessageBox.Show("Nie dziel przez zero!", "Błąd", MessageBoxButtons.OK);
                    else
                    {
                        double result = num1 / num2;
                        textBox1.Text = result.ToString();
                    }
                }
            }
            
        }

        private double convertToNum()
        {
            double.TryParse(textBox1.Text, out double result);
            textBox1.Clear();
            return result;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            this.num1 = 0;
            this.num2 = 0;
        }

        private void back_Click(object sender, EventArgs e)
        {
            string temp = textBox1.Text;
            string text = temp.Substring(0, temp.Length - 1);
            textBox1.Text = text;
        }
    }
}
