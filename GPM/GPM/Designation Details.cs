using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GPM
{
    public partial class Designation_Details : Form
    {
        private string connectionString = "Server=DESKTOP-8HIN9RF\\SQLEXPRESS; Database=gpmdb; Integrated Security=True;";

        public Designation_Details()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 🔹 Validate Required Fields
            if (string.IsNullOrWhiteSpace(txtNo.Text))
            {
                ShowValidationError("No cannot be empty!", txtNo);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                ShowValidationError("Name cannot be empty!", txtName);
                return;
            }        

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                ShowValidationError("Description cannot be empty!", txtDescription);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO Designation_Details (Name, Description) 
                                     VALUES (@Name, @Description)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // 🔹 Assign values to parameters
                        cmd.Parameters.AddWithValue("@No", txtNo.Text.Trim());
                        cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Designation details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNo.Text))
            {
                MessageBox.Show("Please enter a valid No!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.No)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "DELETE FROM Designation_Details WHERE No = @No";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@No", txtNo.Text.Trim());
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Designation record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No record found with the given No!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Helper method to show validation message and focus on the field
        private void ShowValidationError(string message, Control control)
        {
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }
    }
    
}
