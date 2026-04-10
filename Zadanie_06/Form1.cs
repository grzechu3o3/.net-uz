using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie_06
{
    public partial class Form1 : Form
    {
        private string sender_email;
        private string password;
        private string recipient_email;
        private string topic;
        private string content;
        //private file attachment;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.sender_email = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.password = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.recipient_email = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            this.topic = textBox4.Text;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            this.content = richTextBox2.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string uz_pattern = @"^\d+@stud\.uz\.zgora\.pl$";
            if (!Regex.IsMatch(textBox1.Text, uz_pattern))
            {
                MessageBox.Show("Niepoprawny adres e-mail. Aplikacja obsługuje maile studenckie, np: 111111@stud.uz.zgora.pl");
            } else
            {
                MailMessage message = new MailMessage(sender_email, recipient_email);
                message.Subject = topic;
                message.Body = content;

                SmtpClient client = new SmtpClient("poczta.stud.uz.zgora.pl");
                client.Port = 587; 
                client.EnableSsl = true; 
                client.Credentials = new NetworkCredential(sender_email, password);

                try
                {
                    client.Send(message);
                } catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
            }

        }
    }
}
