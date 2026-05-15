using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Zadanie04_3_5
{
    public partial class Form1 : Form
    {
        public class Osoba
        {
            public int Id { get; set; }
            public string Imie { get; set; }
            public string Nazwisko { get; set; }
            public int Wiek { get; set; }
        }

        private List<Osoba> allOsoby;
        private int sortColumn = -1;

        private List<string[]> rowsToPrint;
        private int printPageIndex = 0;
        private const int RowsPerPage = 30;

        private readonly int[] colWidths = { 60, 130, 150, 70 };
        private readonly string[] colHeaders = { "Id", "Imię", "Nazwisko", "Wiek" };

        private string xmlPath;

        public Form1()
        {
            InitializeComponent();
            SetupListView();
            LoadFromXml();
            RefreshListView(allOsoby);

            textSearch.TextChanged += TxtSearch_TextChanged;
            listViewContacts.ColumnClick += ListViewContacts_ColumnClick;
            btnPrintAll.Click += BtnPrintAll_Click;
            btnPrintSelected.Click += BtnPrintSelected_Click;
            btnPreviewAll.Click += BtnPreviewAll_Click;
            btnPreviewSelected.Click += BtnPreviewSelected_Click;
            btnLoadXml.Click += BtnLoadXml_Click;
        }

        private void SetupListView()
        {
            listViewContacts.View = View.Details;
            listViewContacts.FullRowSelect = true;
            listViewContacts.GridLines = true;
            listViewContacts.MultiSelect = true;

            listViewContacts.Columns.Add("Id", 60);
            listViewContacts.Columns.Add("Imię", 130);
            listViewContacts.Columns.Add("Nazwisko", 150);
            listViewContacts.Columns.Add("Wiek", 70);
        }

      
        private void LoadFromXml()
        {
            string[] candidates =
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.xml"),
                Path.Combine(Directory.GetCurrentDirectory(), "database.xml"),
            };
            xmlPath = candidates.FirstOrDefault(File.Exists);

            if (xmlPath == null)
            {
                allOsoby = new List<Osoba>();
                labelXmlPath.Text = "Brak pliku database.xml – użyj przycisku „Wczytaj XML…";
                labelXmlPath.ForeColor = Color.Red;
                return;
            }

            ParseXml(xmlPath);
        }

        private void ParseXml(string path)
        {
            try
            {
                XDocument doc = XDocument.Load(path);
                allOsoby = doc.Root
                    .Elements("Osoba")
                    .Select(e => new Osoba
                    {
                        Id = int.TryParse(e.Element("Id")?.Value, out int id) ? id : 0,
                        Imie = e.Element("Imie")?.Value ?? "",
                        Nazwisko = e.Element("Nazwisko")?.Value ?? "",
                        Wiek = int.TryParse(e.Element("Wiek")?.Value, out int w) ? w : 0
                    })
                    .ToList();

                labelXmlPath.Text = $"Wczytano {allOsoby.Count} rekordów  ←  {Path.GetFileName(path)}";
                labelXmlPath.ForeColor = Color.DarkGreen;
            }
            catch (Exception ex)
            {
                allOsoby = new List<Osoba>();
                labelXmlPath.Text = $"Błąd XML: {ex.Message}";
                labelXmlPath.ForeColor = Color.Red;
            }
        }
        private void BtnLoadXml_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Wybierz plik XML z bazą danych";
                ofd.Filter = "Pliki XML (*.xml)|*.xml|Wszystkie pliki (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    xmlPath = ofd.FileName;
                    ParseXml(xmlPath);
                    textSearch.Clear();
                    RefreshListView(allOsoby);
                }
            }
        }

      
        private void RefreshListView(List<Osoba> list)
        {
            listViewContacts.Items.Clear();
            foreach (var o in list)
            {
                var item = new ListViewItem(o.Id.ToString());
                item.SubItems.Add(o.Imie);
                item.SubItems.Add(o.Nazwisko);
                item.SubItems.Add(o.Wiek.ToString());
                listViewContacts.Items.Add(item);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string q = textSearch.Text.ToLower();
            var filtered = allOsoby.Where(o =>
                o.Imie.ToLower().Contains(q) ||
                o.Nazwisko.ToLower().Contains(q) ||
                o.Id.ToString().Contains(q) ||
                o.Wiek.ToString().Contains(q)).ToList();
            RefreshListView(filtered);
        }

       
        private void ListViewContacts_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == sortColumn)
                listViewContacts.Sorting = listViewContacts.Sorting == SortOrder.Ascending
                    ? SortOrder.Descending : SortOrder.Ascending;
            else
                listViewContacts.Sorting = SortOrder.Ascending;

            sortColumn = e.Column;
            bool numeric = (e.Column == 0 || e.Column == 3); 
            listViewContacts.ListViewItemSorter =
                new ListViewItemComparer(e.Column, listViewContacts.Sorting, numeric);
            listViewContacts.Sort();
        }

        
        private List<string[]> GetAllRows()
        {
            var rows = new List<string[]>();
            foreach (ListViewItem item in listViewContacts.Items)
                rows.Add(Cells(item));
            return rows;
        }

        private List<string[]> GetSelectedRows()
        {
            var rows = new List<string[]>();
            foreach (ListViewItem item in listViewContacts.SelectedItems)
                rows.Add(Cells(item));
            return rows;
        }

        private string[] Cells(ListViewItem i) =>
            new[] { i.SubItems[0].Text, i.SubItems[1].Text,
                    i.SubItems[2].Text, i.SubItems[3].Text };

       
        private void BtnPrintAll_Click(object sender, EventArgs e) =>
            StartPrint(GetAllRows(), preview: false);

        private void BtnPrintSelected_Click(object sender, EventArgs e)
        {
            var r = GetSelectedRows();
            if (r.Count == 0) { MessageBox.Show("Nie zaznaczono żadnych wierszy.", "Informacja"); return; }
            StartPrint(r, preview: false);
        }

        private void BtnPreviewAll_Click(object sender, EventArgs e) =>
            StartPrint(GetAllRows(), preview: true);

        private void BtnPreviewSelected_Click(object sender, EventArgs e)
        {
            var r = GetSelectedRows();
            if (r.Count == 0) { MessageBox.Show("Nie zaznaczono żadnych wierszy.", "Informacja"); return; }
            StartPrint(r, preview: true);
        }

     
        private void StartPrint(List<string[]> rows, bool preview)
        {
            rowsToPrint = rows;
            printPageIndex = 0;

            var pd = new PrintDocument { DocumentName = "Lista osób" };
            pd.PrintPage += PrintDocument_PrintPage;

            if (preview)
            {
                using (var ppd = new PrintPreviewDialog { Document = pd, Width = 950, Height = 720 })
                    ppd.ShowDialog();
            }
            else
            {
                using (var dlg = new PrintDialog { Document = pd })
                    if (dlg.ShowDialog() == DialogResult.OK)
                        pd.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            float pageWidth = e.MarginBounds.Width;

            float total = colWidths.Sum();
            float[] sw = colWidths.Select(w => w / total * pageWidth).ToArray();

            Font fontTitle = new Font("Arial", 14, FontStyle.Bold);
            Font fontHeader = new Font("Arial", 10, FontStyle.Bold);
            Font fontData = new Font("Arial", 9, FontStyle.Regular);
            float rowH = fontData.GetHeight(g) + 6;

            g.DrawString("Lista osób", fontTitle, Brushes.Black, x, y);
            y += fontTitle.GetHeight(g) + 10;

            DrawRow(g, colHeaders, x, y, sw, fontHeader, Brushes.Black, Color.LightSteelBlue, rowH);
            y += rowH;

            int start = printPageIndex * RowsPerPage;
            int end = Math.Min(start + RowsPerPage, rowsToPrint.Count);
            for (int i = start; i < end; i++)
            {
                Color bg = i % 2 == 0 ? Color.White : Color.AliceBlue;
                DrawRow(g, rowsToPrint[i], x, y, sw, fontData, Brushes.Black, bg, rowH);
                y += rowH;
            }

            int totalPages = (int)Math.Ceiling(rowsToPrint.Count / (double)RowsPerPage);
            string footer = $"Strona {printPageIndex + 1} z {totalPages}   |   Łącznie: {rowsToPrint.Count} rekordów";
            g.DrawString(footer, fontData, Brushes.Gray, x, e.MarginBounds.Bottom - rowH);

            printPageIndex++;
            e.HasMorePages = printPageIndex * RowsPerPage < rowsToPrint.Count;

            fontTitle.Dispose();
            fontHeader.Dispose();
            fontData.Dispose();
        }

        private void DrawRow(Graphics g, string[] cells, float x, float y,
                             float[] widths, Font font, Brush textBrush, Color bgColor, float rowH)
        {
            float cx = x;
            for (int i = 0; i < cells.Length; i++)
            {
                var cellRect = new RectangleF(cx, y, widths[i], rowH);
                using (var bg = new SolidBrush(bgColor))
                    g.FillRectangle(bg, cellRect);
                g.DrawRectangle(Pens.Gray, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                g.DrawString(cells[i], font, textBrush,
                    new RectangleF(cx + 3, y + 2, widths[i] - 6, rowH - 4),
                    new StringFormat { Trimming = StringTrimming.EllipsisCharacter });
                cx += widths[i];
            }
        }
    }

    class ListViewItemComparer : IComparer
    {
        private readonly int col;
        private readonly SortOrder order;
        private readonly bool numeric;

        public ListViewItemComparer(int column, SortOrder order, bool numeric = false)
        {
            col = column;
            this.order = order;
            this.numeric = numeric;
        }

        public int Compare(object x, object y)
        {
            string a = ((ListViewItem)x).SubItems[col].Text;
            string b = ((ListViewItem)y).SubItems[col].Text;

            int result;
            if (numeric && int.TryParse(a, out int na) && int.TryParse(b, out int nb))
                result = na.CompareTo(nb);
            else
                result = string.Compare(a, b, StringComparison.CurrentCulture);

            return order == SortOrder.Descending ? -result : result;
        }
    }
}