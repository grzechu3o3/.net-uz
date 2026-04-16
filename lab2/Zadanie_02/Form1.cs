using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void count_Click(object sender, EventArgs e)
        {
            decimal number1 = num1.Value;
            decimal number2 = num2.Value;
            string sign = operation.Text;

            if(sign == "+")
            {
                decimal value = number1 + number2;
                MessageBox.Show(value.ToString(), "+");
            } 
            else if (sign == "-")
            {
                decimal value = number1 - number2;
                MessageBox.Show(value.ToString(), "+");
            }
            else if (sign == "*")
            {
                decimal value = number1 * number2;
                MessageBox.Show(value.ToString(), "+");
            }
            else if (sign == "/")
            {
                if(number2 == 0)
                {
                    MessageBox.Show("Division by zero!", "Error");

                } else
                {
                    decimal value = number1 / number2;
                    MessageBox.Show(value.ToString(), "/");
                }
            }
        }
    }
}
