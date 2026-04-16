using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie_6
{
    public partial class Form1 : Form
    {
        public class Contact
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public DateTime BirthDate { get; set; }
        }

        private List<Contact> allContacts;

        private int sortColumn = -1;

        public Form1()
        {
            InitializeComponent();
            SetupListView();
            LoadMockData();
            RefreshListView(allContacts);

            textSearch.TextChanged += TxtSearch_TextChanged;
            listViewContacts.ColumnClick += ListViewContacts_ColumnClick;
        }

        private void SetupListView()
        {
            listViewContacts.View = View.Details;
            listViewContacts.FullRowSelect = true;
            listViewContacts.GridLines = true;

            listViewContacts.Columns.Add("Imię", 100);
            listViewContacts.Columns.Add("Nazwisko", 120);
            listViewContacts.Columns.Add("Telefon", 100);
            listViewContacts.Columns.Add("Data urodzenia", 120);
        }

        private void LoadMockData()
        {
            allContacts = new List<Contact>
            {
                new Contact { FirstName = "Jan", LastName = "Kowalski", PhoneNumber = "500-100-001", BirthDate = new DateTime(1980, 1, 1) },
                new Contact { FirstName = "Anna", LastName = "Nowak", PhoneNumber = "500-100-002", BirthDate = new DateTime(1981, 2, 2) },
                new Contact { FirstName = "Piotr", LastName = "Wiśniewski", PhoneNumber = "500-100-003", BirthDate = new DateTime(1982, 3, 3) },
                new Contact { FirstName = "Katarzyna", LastName = "Wójcik", PhoneNumber = "500-100-004", BirthDate = new DateTime(1983, 4, 4) },
                new Contact { FirstName = "Tomasz", LastName = "Kowalczyk", PhoneNumber = "500-100-005", BirthDate = new DateTime(1984, 5, 5) },
                new Contact { FirstName = "Agnieszka", LastName = "Kamińska", PhoneNumber = "500-100-006", BirthDate = new DateTime(1985, 6, 6) },
                new Contact { FirstName = "Michał", LastName = "Lewandowski", PhoneNumber = "500-100-007", BirthDate = new DateTime(1986, 7, 7) },
                new Contact { FirstName = "Magdalena", LastName = "Zielińska", PhoneNumber = "500-100-008", BirthDate = new DateTime(1987, 8, 8) },
                new Contact { FirstName = "Paweł", LastName = "Szymański", PhoneNumber = "500-100-009", BirthDate = new DateTime(1988, 9, 9) },
                new Contact { FirstName = "Ewa", LastName = "Woźniak", PhoneNumber = "500-100-010", BirthDate = new DateTime(1989, 10, 10) },

                new Contact { FirstName = "Marcin", LastName = "Dąbrowski", PhoneNumber = "500-100-011", BirthDate = new DateTime(1990, 1, 11) },
                new Contact { FirstName = "Joanna", LastName = "Kozłowska", PhoneNumber = "500-100-012", BirthDate = new DateTime(1991, 2, 12) },
                new Contact { FirstName = "Krzysztof", LastName = "Jankowski", PhoneNumber = "500-100-013", BirthDate = new DateTime(1992, 3, 13) },
                new Contact { FirstName = "Monika", LastName = "Mazur", PhoneNumber = "500-100-014", BirthDate = new DateTime(1993, 4, 14) },
                new Contact { FirstName = "Łukasz", LastName = "Krawczyk", PhoneNumber = "500-100-015", BirthDate = new DateTime(1994, 5, 15) },
                new Contact { FirstName = "Natalia", LastName = "Piotrowska", PhoneNumber = "500-100-016", BirthDate = new DateTime(1995, 6, 16) },
                new Contact { FirstName = "Mateusz", LastName = "Grabowski", PhoneNumber = "500-100-017", BirthDate = new DateTime(1996, 7, 17) },
                new Contact { FirstName = "Karolina", LastName = "Zając", PhoneNumber = "500-100-018", BirthDate = new DateTime(1997, 8, 18) },
                new Contact { FirstName = "Sebastian", LastName = "Pawlak", PhoneNumber = "500-100-019", BirthDate = new DateTime(1998, 9, 19) },
                new Contact { FirstName = "Weronika", LastName = "Michalska", PhoneNumber = "500-100-020", BirthDate = new DateTime(1999, 10, 20) },

                new Contact { FirstName = "Damian", LastName = "Król", PhoneNumber = "500-100-021", BirthDate = new DateTime(1980, 11, 1) },
                new Contact { FirstName = "Paulina", LastName = "Wieczorek", PhoneNumber = "500-100-022", BirthDate = new DateTime(1981, 12, 2) },
                new Contact { FirstName = "Patryk", LastName = "Wróbel", PhoneNumber = "500-100-023", BirthDate = new DateTime(1982, 1, 3) },
                new Contact { FirstName = "Aleksandra", LastName = "Dudek", PhoneNumber = "500-100-024", BirthDate = new DateTime(1983, 2, 4) },
                new Contact { FirstName = "Rafał", LastName = "Adamczyk", PhoneNumber = "500-100-025", BirthDate = new DateTime(1984, 3, 5) },

                new Contact { FirstName = "Sylwia", LastName = "Walczak", PhoneNumber = "500-100-026", BirthDate = new DateTime(1985, 4, 6) },
                new Contact { FirstName = "Grzegorz", LastName = "Stępień", PhoneNumber = "500-100-027", BirthDate = new DateTime(1986, 5, 7) },
                new Contact { FirstName = "Izabela", LastName = "Górska", PhoneNumber = "500-100-028", BirthDate = new DateTime(1987, 6, 8) },
                new Contact { FirstName = "Dariusz", LastName = "Rutkowski", PhoneNumber = "500-100-029", BirthDate = new DateTime(1988, 7, 9) },
                new Contact { FirstName = "Beata", LastName = "Sikora", PhoneNumber = "500-100-030", BirthDate = new DateTime(1989, 8, 10) },

                new Contact { FirstName = "Filip", LastName = "Baran", PhoneNumber = "500-100-140", BirthDate = new DateTime(1990, 9, 20) },
                new Contact { FirstName = "Oliwia", LastName = "Lis", PhoneNumber = "500-100-141", BirthDate = new DateTime(1991, 10, 21) },
                new Contact { FirstName = "Igor", LastName = "Czarnecki", PhoneNumber = "500-100-142", BirthDate = new DateTime(1992, 11, 22) },
                new Contact { FirstName = "Julia", LastName = "Sawicka", PhoneNumber = "500-100-143", BirthDate = new DateTime(1993, 12, 23) },
                new Contact { FirstName = "Hubert", LastName = "Malinowski", PhoneNumber = "500-100-144", BirthDate = new DateTime(1994, 1, 24) },
                new Contact { FirstName = "Zuzanna", LastName = "Kołodziej", PhoneNumber = "500-100-145", BirthDate = new DateTime(1995, 2, 25) },
                new Contact { FirstName = "Norbert", LastName = "Wilk", PhoneNumber = "500-100-146", BirthDate = new DateTime(1996, 3, 26) },
                new Contact { FirstName = "Amelia", LastName = "Szewczyk", PhoneNumber = "500-100-147", BirthDate = new DateTime(1997, 4, 27) },
                new Contact { FirstName = "Bartosz", LastName = "Szczepański", PhoneNumber = "500-100-148", BirthDate = new DateTime(1998, 5, 28) },
                new Contact { FirstName = "Lena", LastName = "Kubiak", PhoneNumber = "500-100-149", BirthDate = new DateTime(1999, 6, 29) },
                new Contact { FirstName = "Antoni", LastName = "Bąk", PhoneNumber = "500-100-150", BirthDate = new DateTime(2000, 7, 30) }
            };
        }

        private void RefreshListView(List<Contact> contactsToShow)
        {
            listViewContacts.Items.Clear();

            foreach (var contact in contactsToShow)
            {
                var item = new ListViewItem(contact.FirstName);
                item.SubItems.Add(contact.LastName);
                item.SubItems.Add(contact.PhoneNumber);
                item.SubItems.Add(contact.BirthDate.ToShortDateString());

                listViewContacts.Items.Add(item);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = textSearch.Text.ToLower();
            var filteredContacts = allContacts.Where(c =>
                c.FirstName.ToLower().Contains(searchText) ||
                c.LastName.ToLower().Contains(searchText) ||
                c.PhoneNumber.Contains(searchText)
            ).ToList();

            RefreshListView(filteredContacts);
        }

        private void ListViewContacts_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == sortColumn)
            {
                if (listViewContacts.Sorting == SortOrder.Ascending)
                    listViewContacts.Sorting = SortOrder.Descending;
                else
                    listViewContacts.Sorting = SortOrder.Ascending;
            }
            else
            {
                listViewContacts.Sorting = SortOrder.Ascending;
            }

            sortColumn = e.Column;

            listViewContacts.ListViewItemSorter = new ListViewItemComparer(e.Column, listViewContacts.Sorting);
            listViewContacts.Sort();
        }
    }

    class ListViewItemComparer : IComparer
    {
        private int col;
        private SortOrder order;

        public ListViewItemComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }

        public int Compare(object x, object y)
        {
            int returnVal = -1;
            ListViewItem item1 = (ListViewItem)x;
            ListViewItem item2 = (ListViewItem)y;

            if (col == 3)
            {
                DateTime date1, date2;
                if (DateTime.TryParse(item1.SubItems[col].Text, out date1) &&
                    DateTime.TryParse(item2.SubItems[col].Text, out date2))
                {
                    returnVal = DateTime.Compare(date1, date2);
                }
            }
            else
            {
                returnVal = String.Compare(item1.SubItems[col].Text, item2.SubItems[col].Text);
            }

            if (order == SortOrder.Descending)
                returnVal *= -1;

            return returnVal;
        }
    }
}

