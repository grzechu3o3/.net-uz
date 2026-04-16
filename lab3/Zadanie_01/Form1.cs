using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie_01
{
    public partial class Form1 : Form
    {
        private DateTime date1;
        private DateTime date2;

        public Form1()
        {
            InitializeComponent();
        }

        private void compareBtn_Click(object sender, EventArgs e)
        {
            this.date1 = dateTimePicker1.Value;
            this.date2 = dateTimePicker2.Value;

            TimeSpan result = date1 - date2;
            double resultdays = Math.Round(Math.Abs(result.TotalDays),2);
            double resulthours = Math.Round(Math.Abs(result.TotalHours), 2);
            double resultsecs = Math.Round(Math.Abs(result.TotalSeconds), 2);

            days.Text = "Różnica w dniach: " + resultdays.ToString();
            hours.Text = "Różnica w godzinach: " + resulthours.ToString();
            secs.Text = "Różnica w sekundach: " + resultsecs.ToString();
        }
    }
}
