using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GPM
{
    public partial class Form1 : Form
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        private string connectionString = "Server=localhost;Port=3307;Database=gpmdb;Uid=root;Pwd=78563;";
=======
        private string connectionString = "Server=DESKTOP-8HIN9RF\\SQLEXPRESS; Database=gpmdb; Integrated Security=True;";
>>>>>>> Stashed changes
=======
        private string connectionString = "Server=DESKTOP-8HIN9RF\\SQLEXPRESS; Database=gpmdb; Integrated Security=True;";
>>>>>>> Stashed changes

        public Form1()
        {
            InitializeComponent();
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

            if (string.IsNullOrWhiteSpace(txtTel2.Text.Trim()) || !Regex.IsMatch(txtTel2.Text.Trim(), @"^0\d{9}$"))
            {
                ShowValidationError("Invalid Telephone Number! (Format: 0XXXXXXXXX)", txtTel2);
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

            if (!int.TryParse(txtEPF_ETFNo.Text.Trim(), out int epfEtfNo))
            {
                ShowValidationError("EPF/ETF No must be a valid number!", txtEPF_ETFNo);
                return;
            }

            //if (cmbDesignation.SelectedIndex == -1)
            //{
            //    ShowValidationError("Please select a designation!", cmbDesignation);
            //    return;
            //}

            //if (cmbCategory.SelectedIndex == -1)
            //{
            //    ShowValidationError("Please select a category!", cmbCategory);
            //    return;
            //}

            //if (cmbStatus.SelectedIndex == -1)
            //{
            //    ShowValidationError("Please select a status!", cmbStatus);
            //    return;
            //}

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO EmployeeDetails 
                        (NamewithInitials, BirthDate, NICNo, TelNo1, TelNo2, CommercialAddress, PermenentAddress, 
                        EMailAddress, Duration, Description, EPF_ETFNo, Designation, Category, AppointmentDate, Status) 
                        VALUES 
                        (@Name, @BirthDate, @NIC, @Tel1, @Tel2, @CommercialAddress, @PermenentAddress, 
                        @Email, @Duration, @Description, @EPF_ETFNo, @Designation, @Category, @AppointmentDate, @Status)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
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
                        cmd.Parameters.AddWithValue("@Duration", textBox9.Text.Trim());
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@EPF_ETFNo", epfEtfNo);
                        //cmd.Parameters.AddWithValue("@Designation", cmbDesignation.SelectedItem.ToString());
                        //cmd.Parameters.AddWithValue("@Category", cmbCategory.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@AppointmentDate", dtpAppointmentDate.Value);
                        //cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());

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

        // 🔴 Delete Button Click - Delete Data from MySQL
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
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "DELETE FROM EmployeeDetails WHERE RecNo = @RecNo";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
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
