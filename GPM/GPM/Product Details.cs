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
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;

namespace GPM
{
    public partial class Product_Details : Form
    {

        private string connectionString = "Server=DESKTOP-8HIN9RF\\SQLEXPRESS; Database=gpmdb; Integrated Security=True;";

        public Product_Details()
        {
            InitializeComponent();
            LoadComboBoxValues();
        }

        private void LoadComboBoxValues()
        {
            // Add predefined values to combo boxes
            cmbSize.Items.AddRange(new string[] { "Small", "Medium", "Large", "Extra Large" });
            cmbColor.Items.AddRange(new string[] { "Red", "Blue", "Green", "Black", "White" });
            cmbMaterial.Items.AddRange(new string[] { "Cotton", "Polyester", "Silk", "Wool", "Leather" });
            cmbStatus.Items.AddRange(new string[] { "Active", "Inactive", "Discontinued" });
            cmbCategory.Items.AddRange(new string[] { "Clothing", "Footwear", "Accessories", "Bags", "Jewelry" }); // New Category ComboBox

            // Set default selections
            cmbSize.SelectedIndex = 0;
            cmbColor.SelectedIndex = 0;
            cmbMaterial.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0; // Set default category
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtNo.Text) ||
                string.IsNullOrWhiteSpace(txtCode.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("No, Code, and Name are required fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Product_Details 
                                    (No, Code, Name, Category, Size, Color, Materials, Status, Description) 
                                    VALUES (@No, @Code, @Name, @Category, @Size, @Color, @Materials, @Status, @Description)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@No", txtNo.Text.Trim());
                        cmd.Parameters.AddWithValue("@Code", txtCode.Text.Trim());
                        cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Category", cmbCategory.SelectedItem.ToString()); // ComboBox for Category
                        cmd.Parameters.AddWithValue("@Size", cmbSize.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Color", cmbColor.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Materials", cmbMaterial.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Description", string.IsNullOrWhiteSpace(txtDescription.Text) ? (object)DBNull.Value : txtDescription.Text.Trim());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Product details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
