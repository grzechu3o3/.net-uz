using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Prosty komunikat");
            MessageBox.Show("Komunikat z tytulem", "Tytul");
            MessageBox.Show("test", "Komunikat z przyciskami", MessageBoxButtons.YesNoCancel);
            MessageBox.Show("testowy", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show("testowa", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
