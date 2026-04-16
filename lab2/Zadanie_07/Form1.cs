using System;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Zadanie_07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadCodecs();
        }

        private void LoadCodecs()
        {
            this.Text = "Kodeki obrazów 2D";

            var lista = new ListBox { Dock = DockStyle.Left, Width = 200 };

            var info = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new System.Drawing.Font("Courier New", 10)
            };

            this.Controls.Add(info);
            this.Controls.Add(lista);

            var kodeki = ImageCodecInfo.GetImageEncoders();
            foreach (var k in kodeki)
                lista.Items.Add(k.FormatDescription);

            lista.SelectedIndexChanged += (s, e) =>
            {
                var k = kodeki[lista.SelectedIndex];
                info.Text =
                    $"Nazwa:        {k.CodecName}\r\n" +
                    $"Format:       {k.FormatDescription}\r\n" +
                    $"Rozszerzenia: {k.FilenameExtension}\r\n" +
                    $"MIME:         {k.MimeType}\r\n" +
                    $"GUID:         {k.FormatID}\r\n" +
                    $"Flagi:        {k.Flags}\r\n" +
                    $"Wersja:       {k.Version}";
            };
        }
    }
}