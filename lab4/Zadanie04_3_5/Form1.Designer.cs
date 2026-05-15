namespace Zadanie04_3_5
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listViewContacts = new System.Windows.Forms.ListView();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.labelXmlPath = new System.Windows.Forms.Label();
            this.btnLoadXml = new System.Windows.Forms.Button();
            this.btnPrintAll = new System.Windows.Forms.Button();
            this.btnPrintSelected = new System.Windows.Forms.Button();
            this.btnPreviewAll = new System.Windows.Forms.Button();
            this.btnPreviewSelected = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 76;
            this.panelTop.Padding = new System.Windows.Forms.Padding(8, 6, 8, 0);
            this.panelTop.Controls.Add(this.labelSearch);
            this.panelTop.Controls.Add(this.textSearch);
            this.panelTop.Controls.Add(this.btnLoadXml);
            this.panelTop.Controls.Add(this.labelXmlPath);

            this.labelSearch.Text = "Szukaj:";
            this.labelSearch.Location = new System.Drawing.Point(8, 12);
            this.labelSearch.Size = new System.Drawing.Size(52, 22);
            this.labelSearch.Font = new System.Drawing.Font("Segoe UI", 9.5f);

            this.textSearch.Location = new System.Drawing.Point(64, 9);
            this.textSearch.Size = new System.Drawing.Size(280, 24);
            this.textSearch.Font = new System.Drawing.Font("Segoe UI", 9.5f);

            this.btnLoadXml.Text = "Wczytaj XML…";
            this.btnLoadXml.Location = new System.Drawing.Point(360, 7);
            this.btnLoadXml.Size = new System.Drawing.Size(120, 28);
            this.btnLoadXml.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.btnLoadXml.BackColor = System.Drawing.Color.DarkOrange;
            this.btnLoadXml.ForeColor = System.Drawing.Color.White;
            this.btnLoadXml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.labelXmlPath.Text = "Oczekiwanie na plik XML…";
            this.labelXmlPath.Location = new System.Drawing.Point(8, 44);
            this.labelXmlPath.Size = new System.Drawing.Size(900, 20);
            this.labelXmlPath.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Italic);
            this.labelXmlPath.ForeColor = System.Drawing.Color.Gray;

            this.listViewContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewContacts.Font = new System.Drawing.Font("Segoe UI", 9f);

            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height = 50;
            this.panelBottom.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.panelBottom.Controls.Add(this.btnPrintAll);
            this.panelBottom.Controls.Add(this.btnPrintSelected);
            this.panelBottom.Controls.Add(this.btnPreviewAll);
            this.panelBottom.Controls.Add(this.btnPreviewSelected);

            this.btnPrintAll.Text = "Drukuj wszystkie";
            this.btnPrintAll.Location = new System.Drawing.Point(8, 10);
            this.btnPrintAll.Size = new System.Drawing.Size(140, 30);
            this.btnPrintAll.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.btnPrintAll.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPrintAll.ForeColor = System.Drawing.Color.White;
            this.btnPrintAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.btnPrintSelected.Text = "Drukuj zaznaczone";
            this.btnPrintSelected.Location = new System.Drawing.Point(156, 10);
            this.btnPrintSelected.Size = new System.Drawing.Size(150, 30);
            this.btnPrintSelected.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.btnPrintSelected.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnPrintSelected.ForeColor = System.Drawing.Color.White;
            this.btnPrintSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.btnPreviewAll.Text = "Podgląd wszystkich";
            this.btnPreviewAll.Location = new System.Drawing.Point(314, 10);
            this.btnPreviewAll.Size = new System.Drawing.Size(158, 30);
            this.btnPreviewAll.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.btnPreviewAll.BackColor = System.Drawing.Color.SeaGreen;
            this.btnPreviewAll.ForeColor = System.Drawing.Color.White;
            this.btnPreviewAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.btnPreviewSelected.Text = "Podgląd zaznaczonych";
            this.btnPreviewSelected.Location = new System.Drawing.Point(480, 10);
            this.btnPreviewSelected.Size = new System.Drawing.Size(175, 30);
            this.btnPreviewSelected.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.btnPreviewSelected.BackColor = System.Drawing.Color.DarkGreen;
            this.btnPreviewSelected.ForeColor = System.Drawing.Color.White;
            this.btnPreviewSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.ClientSize = new System.Drawing.Size(900, 560);
            this.Controls.Add(this.listViewContacts);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Text = "Zadanie04_3_5 – Lista osób z XML";
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MinimumSize = new System.Drawing.Size(800, 480);

            this.panelTop.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListView listViewContacts;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.Label labelXmlPath;
        private System.Windows.Forms.Button btnLoadXml;
        private System.Windows.Forms.Button btnPrintAll;
        private System.Windows.Forms.Button btnPrintSelected;
        private System.Windows.Forms.Button btnPreviewAll;
        private System.Windows.Forms.Button btnPreviewSelected;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
    }
}