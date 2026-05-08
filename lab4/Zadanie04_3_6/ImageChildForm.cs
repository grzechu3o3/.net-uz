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
    public partial class ImageChildForm : Form
    {
        public ImageChildForm()
        {
            InitializeComponent();
        }

        public void DisplayImage(string path)
        {
            using (var tempImg = Image.FromFile(path))
            {
                pictureBox1.Image = new Bitmap(tempImg);
            }
        }
    }
}
