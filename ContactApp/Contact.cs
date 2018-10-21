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
                // Clear fields
                Clear();
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

        // Click event for Close Button
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Method to clear fields
        public void Clear()
        {
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxContactNumber.Text = "";
            textBoxAddress.Text = "";
            cmbGender.Text = "";
        }

        // Click event for Update Button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get the data from textboxes
            c.ContactID = int.Parse(textBoxContactID.Text);
            c.FirstName = textBoxFirstName.Text;
            c.LastName = textBoxLastName.Text;
            c.ContactNo = textBoxContactNumber.Text;
            c.Address = textBoxAddress.Text;
            c.Gender = cmbGender.Text;

            // Update data into db
            bool success = c.Update(c);
            if (success == true)
            {
                // Updated successfully
                MessageBox.Show("Contact had been updated successfully");

                // Load data on Data GridView
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;

                // Clear fields
                Clear();
            }
            else
            {
                // Failed to update
                MessageBox.Show("Failed to update contact. Try again!");
            }
        }

        // Get data from Data Grid View and load it to the textboxes
        private void dgvContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            textBoxContactID.Text = dgvContactList.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxFirstName.Text = dgvContactList.Rows[rowIndex].Cells[1].Value.ToString();
            textBoxLastName.Text = dgvContactList.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxContactNumber.Text = dgvContactList.Rows[rowIndex].Cells[3].Value.ToString();
            textBoxAddress.Text = dgvContactList.Rows[rowIndex].Cells[4].Value.ToString();
            cmbGender.Text = dgvContactList.Rows[rowIndex].Cells[5].Value.ToString();
        }

        // Click event for Clear Button
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear fields
            Clear();
        }
    }
}
