using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Org.BouncyCastle.Asn1.Cmp;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace GPM
{
    public partial class Advance_Payment_Details : Form
    {
        // ✅ MySQL Connection String
        private string connectionString = "Server=DESKTOP-8HIN9RF\\SQLEXPRESS; Database=gpmdb; Integrated Security=True;";

        public Advance_Payment_Details()
        {
            InitializeComponent();
            LoadComboBoxValues(); // Load dropdown values on form load
        }

        private void LoadComboBoxValues()
        {
            // 🔹 Populate Status ComboBox
            cmbStatus.Items.AddRange(new string[] { "Pending", "Approved", "Rejected", "Processing" });

            // 🔹 Set default value (optional)
            cmbStatus.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 🔹 Validate Required Fields
            if (string.IsNullOrWhiteSpace(txtCode.Text.Trim()))
            {
                ShowValidationError("Code cannot be empty!", txtCode);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPaymentNo.Text.Trim()))
            {
                ShowValidationError("Payment No cannot be empty!", txtPaymentNo);
                return;
            }

            if (!decimal.TryParse(txtValue.Text.Trim(), out decimal value))
            {
                ShowValidationError("Invalid Value!", txtValue);
                return;
            }

            if (!decimal.TryParse(txtValue.Text.Trim(), out decimal percentage))
            {
                ShowValidationError("Invalid Percentage!", txtValue);
                return;
            }

            string status = cmbStatus.SelectedItem?.ToString();
            string description = txtDescription.Text.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO Advance_Payment (code, payment_no, value, percentage, status, description) 
                                     VALUES (@Code, @PaymentNo, @Value, @Percentage, @Status, @Description)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // 🔹 Assign values to parameters
                        cmd.Parameters.AddWithValue("@Code", txtCode.Text.Trim());
                        cmd.Parameters.AddWithValue("@PaymentNo", txtPaymentNo.Text.Trim());
                        cmd.Parameters.AddWithValue("@Value", value);
                        cmd.Parameters.AddWithValue("@Percentage", percentage);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@Description", description);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Payment details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPaymentNo.Text.Trim()))
            {
                MessageBox.Show("Please enter a valid Payment No!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    string query = "DELETE FROM Advance_Payment WHERE payment_no = @PaymentNo";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PaymentNo", txtPaymentNo.Text.Trim());
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Payment record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No record found with the given Payment No!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
