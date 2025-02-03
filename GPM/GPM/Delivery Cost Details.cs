using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPM
{
    public partial class Delivery_Cost_Details : Form
    {

        private string connectionString = "Server=DESKTOP-8HIN9RF\\SQLEXPRESS; Database=gpmdb; Integrated Security=True;";

        public Delivery_Cost_Details()
        {
            InitializeComponent();
            LoadComboBoxValues();
        }

        private void LoadComboBoxValues()
        {
            // Add predefined values to combo boxes
            cmbVehicleType.Items.AddRange(new string[] { "Bike", "Truck", "Van", "Car" });
            cmbStatus.Items.AddRange(new string[] { "Active", "Inactive" });

            // Set default selections
            cmbVehicleType.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtAmountPerKm.Text))
            {
                MessageBox.Show("Amount Per Km is a required field!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Delivery_Cost_Details 
                                    (VehicleType, AmountPerKm, Status) 
                                    VALUES (@VehicleType, @AmountPerKm, @Status)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@VehicleType", cmbVehicleType.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@AmountPerKm", decimal.Parse(txtAmountPerKm.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Delivery cost details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNo.Text))
            {
                MessageBox.Show("Please enter a valid No to update!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT VehicleType, AmountPerKm, Status FROM Delivery_Cost_Details WHERE No = @No";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@No", int.Parse(txtNo.Text.Trim()));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Auto-fill the form with previous data
                                cmbVehicleType.SelectedItem = reader["VehicleType"].ToString();
                                txtAmountPerKm.Text = reader["AmountPerKm"].ToString();
                                cmbStatus.SelectedItem = reader["Status"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No record found with the given No!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
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
                MessageBox.Show("Please enter a valid No to delete!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    string query = "DELETE FROM Delivery_Cost_Details WHERE No = @No";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@No", int.Parse(txtNo.Text.Trim()));
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button2_Click(object sender, EventArgs e)
        {
            // Navigate Back (you can implement navigation logic here)
            MessageBox.Show("Navigate Back", "Back", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    
}
