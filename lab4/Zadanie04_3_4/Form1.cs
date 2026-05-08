using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Zadanie04_3_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                WczytajDaneDoDrzewa(openFileDialog1.FileName);
            }
        }

        private void WczytajDaneDoDrzewa(string sciezka)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Osoba>), new XmlRootAttribute("ArrayOfOsoba"));
                List<Osoba> lista;

                using (FileStream fs = new FileStream(sciezka, FileMode.Open))
                {
                    lista = (List<Osoba>)serializer.Deserialize(fs);
                }

                treeViewOsoby.Nodes.Clear(); 
                TreeNode rootNode = new TreeNode("Osoby z pliku XML");

                foreach (var osoba in lista)
                {
                    TreeNode osobaNode = new TreeNode($"{osoba.Imie} {osoba.Nazwisko}");

                    osobaNode.Nodes.Add($"Imię: {osoba.Imie}");
                    osobaNode.Nodes.Add($"Nazwisko: {osoba.Nazwisko}");
                    osobaNode.Nodes.Add($"Wiek: {osoba.Wiek}");

                    rootNode.Nodes.Add(osobaNode);
                }

                treeViewOsoby.Nodes.Add(rootNode);
                treeViewOsoby.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas wczytywania: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
