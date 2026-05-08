using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie04_3_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Obrazy (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp|Wszystkie pliki (*.*)|*.*";
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileName in ofd.FileNames)
                    {
                        CreateChildForm(fileName);
                    }
                }
            }
        }

        private void CreateChildForm(string filePath)
        {
            ImageChildForm child = new ImageChildForm();

            child.MdiParent = this;
            child.Text = System.IO.Path.GetFileName(filePath);

           
            child.DisplayImage(filePath);

            child.Show();
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
        }

        private void zamknijWszystkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }

        private void kaskadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void pionowoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void poziomoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void wyjdźToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
