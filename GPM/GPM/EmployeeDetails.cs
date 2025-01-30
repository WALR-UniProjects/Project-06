using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GPM
{
    public partial class Form1 : Form
    {

        // MySQL Connection String
        private string connectionString = "Server=127.0.0.1;Database=gpmdb;Uid=root;Pwd=78563;";

        public Form1()
        {
            InitializeComponent();
        }

        // 🔴 OK Button Click - Insert Data into MySQL
        private void button1_Click(object sender, EventArgs e)
        {
            // Validate Inputs
            //if (string.IsNullOrWhiteSpace(txtName.Text) ||
            //    dtpBirthDate.Value == null ||
            //    string.IsNullOrWhiteSpace(txtNIC.Text) ||
            //    !System.Text.RegularExpressions.Regex.IsMatch(txtNIC.Text, @"^\d{9}[VvXx]|\d{12}$") || // Validate NIC (Old & New)
            //    string.IsNullOrWhiteSpace(txtTel1.Text) ||
            //    !System.Text.RegularExpressions.Regex.IsMatch(txtTel1.Text, @"^0\d{9}$") || // Validate Phone Number Format
            //    string.IsNullOrWhiteSpace(txtTel2.Text) ||
            //    !System.Text.RegularExpressions.Regex.IsMatch(txtTel2.Text, @"^0\d{9}$") ||
            //    string.IsNullOrWhiteSpace(txtCommercialAddress.Text) ||
            //    string.IsNullOrWhiteSpace(txtPermanentAddress.Text) ||
            //    string.IsNullOrWhiteSpace(txtEmail.Text) ||
            //    !System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") || // Email Validation
            //    string.IsNullOrWhiteSpace(textBox9.Text) ||
            //    !int.TryParse(textBox9.Text, out _) || // Ensure duration is a number
            //    string.IsNullOrWhiteSpace(txtDescription.Text) ||
            //    string.IsNullOrWhiteSpace(txtEPF_ETFNo.Text) ||
            //    !int.TryParse(txtEPF_ETFNo.Text, out _) || // Ensure EPF/ETF No is a number
            //    cmbDesignation.SelectedIndex == -1 ||
            //    cmbCategory.SelectedIndex == -1 ||
            //    cmbStatus.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Please fill in all required fields correctly!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}


            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO EmployeeDetails 
                        (NamewithInitials, BirthDate, Age, NICNo, TelNo1, TelNo2, CommercialAddress, PermenentAddress, 
                        EMailAddress, Duration, Description, EPF_ETFNo, Designation, Category, AppointmentDate, Status) 
                        VALUES 
                        (@Name, @BirthDate, @Age, @NIC, @Tel1, @Tel2, @CommercialAddress, @PermenentAddress, 
                        @Email, @Duration, @Description, @EPF_ETFNo, @Designation, @Category, @AppointmentDate, @Status)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Assigning values to parameters
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@BirthDate", dtpBirthDate.Value);
                        cmd.Parameters.AddWithValue("@NIC", txtNIC.Text);
                        cmd.Parameters.AddWithValue("@Tel1", txtTel1.Text);
                        cmd.Parameters.AddWithValue("@Tel2", txtTel2.Text);
                        cmd.Parameters.AddWithValue("@CommercialAddress", txtCommercialAddress.Text);
                        cmd.Parameters.AddWithValue("@PermenentAddress", txtPermanentAddress.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Duration", textBox9.Text);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@EPF_ETFNo", txtEPF_ETFNo.Text);
                        cmd.Parameters.AddWithValue("@Designation", cmbDesignation.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Category", cmbCategory.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@AppointmentDate", dtpAppointmentDate.Value);
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());

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
    }   
}
