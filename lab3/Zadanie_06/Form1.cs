using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
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
        private List<string> attachmentPaths = new List<string>();

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

        private async void button4_Click(object sender, EventArgs e)
        {
            string uz_pattern = @"^\d+@stud\.uz\.zgora\.pl$";
            if (!Regex.IsMatch(textBox1.Text, uz_pattern))
            {
                MessageBox.Show("Niepoprawny adres e-mail. Aplikacja obsługuje maile studenckie, np: 111111@stud.uz.zgora.pl", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (string.IsNullOrEmpty(recipient_email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Nie podano hasła lub odbiorcy wiadomości", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else
            {
                MailMessage message = new MailMessage(sender_email, recipient_email);
                message.Subject = topic;
                message.Body = content;
                foreach (var path in attachmentPaths)
                {
                    message.Attachments.Add(new Attachment(path));
                }

                SmtpClient client = new SmtpClient("poczta.stud.uz.zgora.pl");
                client.Port = 587; 
                client.EnableSsl = true; 
                client.Credentials = new NetworkCredential(sender_email, password);

                try
                {
                    await client.SendMailAsync(message);
                    MessageBox.Show("Mail wysłany", "Sukces!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    MessageBox.Show(ex.ToString(), "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

                } finally
                {
                    client.Dispose();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Wybierz załącznik";

            if(fileDialog.ShowDialog() == DialogResult.OK)
            { 
                attachmentPaths.Add(fileDialog.FileName);
                attachment_list.Items.Add(Path.GetFileName(fileDialog.FileName));
            }
        }

        private void attachment_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void attachment_list_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = attachment_list.SelectedIndex;
            if (index >= 0)
            {
                attachmentPaths.RemoveAt(index);
                attachment_list.Items.RemoveAt(index);
            }
        }
    }
}
