using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GPM
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=DESKTOP-8HIN9RF\\SQLEXPRESS; Database=gpmdb; Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
            LoadComboBoxValues(); // Load dropdown values on form load
        }

        private void LoadComboBoxValues()
        {
            // 🔹 Populate Designation ComboBox
            cmbDesignation.Items.AddRange(new string[] { "Driver", "Manager", "Supplier", "Worker" });

            // 🔹 Populate Category ComboBox
            cmbCategory.Items.AddRange(new string[] { "Permanent", "Trainee" });

            // 🔹 Populate Status ComboBox
            cmbStatus.Items.AddRange(new string[] { "Active", "Inactive" });

            // 🔹 Set default values (optional)
            cmbDesignation.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 🔹 Validate Required Fields
            if (string.IsNullOrWhiteSpace(txtName.Text.Trim()))
            {
                ShowValidationError("Name cannot be empty!", txtName);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNIC.Text.Trim()) || !Regex.IsMatch(txtNIC.Text.Trim(), @"^\d{9}[VvXx]|\d{12}$"))
            {
                ShowValidationError("Invalid NIC number! (Format: 9 digits + V/X or 12 digits)", txtNIC);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTel1.Text.Trim()) || !Regex.IsMatch(txtTel1.Text.Trim(), @"^0\d{9}$"))
            {
                ShowValidationError("Invalid Telephone Number! (Format: 0XXXXXXXXX)", txtTel1);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCommercialAddress.Text.Trim()))
            {
                ShowValidationError("Commercial Address cannot be empty!", txtCommercialAddress);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPermanentAddress.Text.Trim()))
            {
                ShowValidationError("Permanent Address cannot be empty!", txtPermanentAddress);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text.Trim()) || !Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ShowValidationError("Invalid Email Address!", txtEmail);
                return;
            }

            if (!int.TryParse(textBox9.Text.Trim(), out int duration))
            {
                ShowValidationError("Duration must be a valid number!", textBox9);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text.Trim()))
            {
                ShowValidationError("Description cannot be empty!", txtDescription);
                return;
            }

            // 🔹 EPF_ETFNo should be treated as a string in SQL Server
            string epfEtfNo = txtEPF_ETFNo.Text.Trim();
            if (string.IsNullOrWhiteSpace(epfEtfNo))
            {
                ShowValidationError("EPF/ETF No cannot be empty!", txtEPF_ETFNo);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO EmployeeDetails 
                        (NamewithInitials, BirthDate, NICNo, TelNo1, TelNo2, CommercialAddress, PermenentAddress, 
                        EMailAddress, Duration, Description, EPF_ETFNo, Designation, Category, AppointmentDate, Status) 
                        VALUES 
                        (@Name, @BirthDate, @NIC, @Tel1, @Tel2, @CommercialAddress, @PermenentAddress, 
                        @Email, @Duration, @Description, @EPF_ETFNo, @Designation, @Category, @AppointmentDate, @Status)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // 🔹 Assign values to parameters
                        cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@BirthDate", dtpBirthDate.Value);
                        cmd.Parameters.AddWithValue("@NIC", txtNIC.Text.Trim());
                        cmd.Parameters.AddWithValue("@Tel1", txtTel1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Tel2", txtTel2.Text.Trim());
                        cmd.Parameters.AddWithValue("@CommercialAddress", txtCommercialAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@PermenentAddress", txtPermanentAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Duration", duration);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@EPF_ETFNo", epfEtfNo);
                        cmd.Parameters.AddWithValue("@Designation", cmbDesignation.SelectedItem?.ToString() ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Category", cmbCategory.SelectedItem?.ToString() ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@AppointmentDate", dtpAppointmentDate.Value);
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem?.ToString() ?? (object)DBNull.Value);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Employee details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // 🔴 Delete Button Click - Delete Data from SQL Server
        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRecNo.Text.Trim()))
            {
                MessageBox.Show("Please enter a valid Record No (RecNo)!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    string query = "DELETE FROM EmployeeDetails WHERE RecNo = @RecNo";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RecNo", txtRecNo.Text.Trim());
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Employee record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No record found with the given RecNo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
