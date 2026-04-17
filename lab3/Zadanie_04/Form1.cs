using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie_04
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Person> _database = new Dictionary<string, Person>();
        private int _lastId = 0;
        private BindingSource _bs = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            RefreshList();
            lstPeople.DataSource = _bs;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            _lastId++;
            int currentId = _lastId;

            var person = new Person
            {
                Id = currentId.ToString(),
                FirstName = txtName.Text,
                LastName = txtSurname.Text,
                PhoneNumber = txtPhone.Text,
                Address = txtAddress.Text
            };

            _database[currentId.ToString()] = person;

            RefreshList();
            ClearInputs();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstPeople.SelectedItem is Person selected)
            {
                _database.Remove(selected.Id);
                RefreshList();
                ClearInputs();
            }
        }

        private void RefreshList()
        {
            _bs.DataSource = _database.Values.ToList();
            _bs.ResetBindings(false);
        }

        private void ClearInputs()
        {
            foreach (var ctrl in this.Controls.OfType<TextBox>())
                ctrl.Clear();
        }

        private void lstPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPeople.SelectedItem is Person selected)
            {
                txtName.Text = selected.FirstName;
                txtSurname.Text = selected.LastName;
                txtPhone.Text = selected.PhoneNumber;
                txtAddress.Text = selected.Address;
            }
        }
    }
}