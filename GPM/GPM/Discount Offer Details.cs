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
using Org.BouncyCastle.Asn1.Cmp;
using System.Xml.Linq;

namespace GPM
{
    public partial class Discount_Offer_Details : Form
    {

        private string connectionString = "Server=DESKTOP-8HIN9RF\\SQLEXPRESS; Database=gpmdb; Integrated Security=True;";

        public Discount_Offer_Details()
        {
            InitializeComponent();
            LoadComboBoxes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 🔹 Validate Required Fields
            if (string.IsNullOrWhiteSpace(txtNo.Text) || string.IsNullOrWhiteSpace(txtValue.Text) ||
                cmbCategory.SelectedIndex == -1 || cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("All fields are required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtValue.Text, out decimal value) || value <= 0)
            {
                MessageBox.Show("Invalid Value! Enter a positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpStartDate.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("Start Date cannot be later than End Date!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Discount_Offer_Details (Name, Value, StartDate, EndDate, Category, Status) 
                                     VALUES (@Name, @Value, @StartDate, @EndDate, @Category, @Status)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@No", txtNo.Text.Trim());
                        cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Value", value);
                        cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value);
                        cmd.Parameters.AddWithValue("@EndDate", dateTimePicker2.Value);
                        cmd.Parameters.AddWithValue("@Category", cmbCategory.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrWhiteSpace(txtNo.Text) || !int.TryParse(txtNo.Text, out int no))
            {
                MessageBox.Show("Enter a valid No!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    string query = "DELETE FROM Discount_Offer_Details WHERE No = @No";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@No", no);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No record found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxes()
        {
            // Load Categories
            cmbCategory.Items.AddRange(new string[] { "Shirt", "Pants", "Jackets", "Dresses", "Accessories" });

            // Load Status
            cmbStatus.Items.AddRange(new string[] { "Pending", "In Progress", "Completed", "Cancelled" });
        }
    }
}
