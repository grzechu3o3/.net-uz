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
        DateTime alarmTime;
        bool alarmSet = false;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "HH:mm:ss";
            timer2.Interval = 1000;
            timer2.Start();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void dateLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        { 
            dateLabel.Text = DateTime.Now.ToString("HH:mm:ss dd.MM.yyyy");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            if(alarmSet && now >= alarmTime)
            {
                alarmSet = false;
                label1.Text = "";
                MessageBox.Show("ALARM!", "Alarm");
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            alarmTime = dateTimePicker1.Value;
            alarmSet = true;
            label1.Text = "Alarm set to " + alarmTime.ToString("HH:mm:ss");

        }
    }
}
