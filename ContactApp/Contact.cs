using ContactApp.ContactClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactApp
{
    public partial class Contact : Form
    {
        public Contact()
        {
            InitializeComponent();
        }

        // Create ContactClass object (c)
        ContactClass c = new ContactClass();

        private void IblContactID_Click(object sender, EventArgs e)
        {

        }

        // Button click event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Get value from input field
            c.FirstName = textBoxFirstName.Text;
            c.LastName = textBoxLastName.Text;
            c.ContactNo = textBoxContactNumber.Text;
            c.Address = textBoxAddress.Text;
            c.Gender = cmbGender.Text;

            // Insert data into db
            bool success = c.Insert(c);
            if (success == true)
            {
                // Successfully Inserted!
                MessageBox.Show("New Contact Successfully Inserted!");
            }
            else
            {
                // Failed to add
                MessageBox.Show("Failed to add new contact. Try again!");
            }

            // Load data on Data GridView
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }

        // Pageload event
        private void Contact_Load(object sender, EventArgs e)
        {
            // Load data on Data GridView
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }
    }
}
