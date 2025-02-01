using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GPM
{
    public partial class Employee_Allocation : Form
    {
        private readonly string connectionString = "Server=DESKTOP-8HIN9RF\\SQLEXPRESS; Database=gpmdb; Integrated Security=True;";

        public Employee_Allocation()
        {
            InitializeComponent();
            LoadStatusOptions();
        }

        private void LoadStatusOptions()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("Inactive");
            cmbStatus.SelectedIndex = 0; // Default selection
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtManager.Text) ||
                string.IsNullOrWhiteSpace(txtSupplier1.Text) ||
                string.IsNullOrWhiteSpace(txtWorker1.Text) ||
                cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("All required fields must be filled!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Validate Employee IDs
                //if (!IsValidEmployeeID(txtManager.Text.Trim()) ||
                //    !IsValidEmployeeID(txtSupplier1.Text.Trim()) ||
                //    !IsValidEmployeeID(txtWorker1.Text.Trim()) ||
                //    (!string.IsNullOrWhiteSpace(txtSupplier2.Text) && !IsValidEmployeeID(txtSupplier2.Text.Trim())) ||
                //    (!string.IsNullOrWhiteSpace(txtWorker2.Text) && !IsValidEmployeeID(txtWorker2.Text.Trim())) ||
                //    (!string.IsNullOrWhiteSpace(txtWorker3.Text) && !IsValidEmployeeID(txtWorker3.Text.Trim())) ||
                //    (!string.IsNullOrWhiteSpace(txtWorker4.Text) && !IsValidEmployeeID(txtWorker4.Text.Trim())))
                //{
                //    MessageBox.Show("One or more Employee IDs are invalid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Employee_Allocation 
                            (ManagerEMPNo, SupplierEMPNo1, SupplierEMPNo2, WorkerEMPNo1, WorkerEMPNo2, WorkerEMPNo3, WorkerEMPNo4, Status) 
                            VALUES (@ManagerEMPNo, @SupplierEMPNo1, @SupplierEMPNo2, @WorkerEMPNo1, @WorkerEMPNo2, @WorkerEMPNo3, @WorkerEMPNo4, @Status)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ManagerEMPNo", int.Parse(txtManager.Text.Trim()));
                        cmd.Parameters.AddWithValue("@SupplierEMPNo1", int.Parse(txtSupplier1.Text.Trim()));
                        cmd.Parameters.AddWithValue("@SupplierEMPNo2", string.IsNullOrWhiteSpace(txtSupplier2.Text) ? (object)DBNull.Value : int.Parse(txtSupplier2.Text.Trim()));
                        cmd.Parameters.AddWithValue("@WorkerEMPNo1", int.Parse(txtWorker1.Text.Trim()));
                        cmd.Parameters.AddWithValue("@WorkerEMPNo2", string.IsNullOrWhiteSpace(txtWorker2.Text) ? (object)DBNull.Value : int.Parse(txtWorker2.Text.Trim()));
                        cmd.Parameters.AddWithValue("@WorkerEMPNo3", string.IsNullOrWhiteSpace(txtWorker3.Text) ? (object)DBNull.Value : int.Parse(txtWorker3.Text.Trim()));
                        cmd.Parameters.AddWithValue("@WorkerEMPNo4", string.IsNullOrWhiteSpace(txtWorker4.Text) ? (object)DBNull.Value : int.Parse(txtWorker4.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for Employee IDs.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidEmployeeID(string employeeID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Employees WHERE EmployeeID = @EmployeeID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", int.Parse(employeeID));
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; // Returns true if the EmployeeID exists
                    }
                }
            }
            catch
            {
                return false; // If any error occurs, assume the ID is invalid
            }
        }
    }
}