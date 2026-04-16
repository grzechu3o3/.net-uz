using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie_05
{
    public class MainForm : Form
    {
        private ListBox listBox;
        private TextBox txtInput;
        private Button btnDodaj;
        private Button btnUsun;
        private Label lblInfo;

        public MainForm()
        {
            this.Text = "ListBox";
            this.Size = new Size(340, 420);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10f);

            Label lblTytuł = new Label
            {
                Text = "Lista owoców:",
                Location = new Point(20, 15),
                AutoSize = true
            };

            listBox = new ListBox
            {
                Location = new Point(20, 40),
                Size = new Size(280, 200)
            };
            listBox.Items.AddRange(new[] { "Jabłko", "Banan", "Gruszka", "Śliwka", "Wiśnia" });
            listBox.SelectedIndexChanged += (s, e) =>
            {
                lblInfo.Text = listBox.SelectedItem != null
                    ? $"Wybrano: {listBox.SelectedItem}"
                    : "Nic nie wybrano";
            };

            txtInput = new TextBox
            {
                Location = new Point(20, 255),
                Width = 185,
            };

            btnDodaj = new Button
            {
                Text = "Dodaj",
                Location = new Point(215, 253),
                Width = 85
            };
            btnDodaj.Click += (s, e) =>
            {
                string tekst = txtInput.Text.Trim();
                if (tekst == "") return;
                listBox.Items.Add(tekst);
                txtInput.Clear();
                txtInput.Focus();
            };

            btnUsun = new Button
            {
                Text = "Usuń zaznaczony",
                Location = new Point(20, 295),
                Width = 280
            };
            btnUsun.Click += (s, e) =>
            {
                if (listBox.SelectedItem != null)
                    listBox.Items.Remove(listBox.SelectedItem);
            };

            lblInfo = new Label
            {
                Text = "Kliknij element na liście",
                Location = new Point(20, 345),
                AutoSize = true,
                ForeColor = Color.Gray
            };

            this.Controls.AddRange(new Control[]
            {
                lblTytuł, listBox, txtInput, btnDodaj, btnUsun, lblInfo
            });
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
