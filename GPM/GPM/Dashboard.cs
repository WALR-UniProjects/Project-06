using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPM
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void OpenForm(Form form)
        {
            form.ShowDialog(); // Open the selected form
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenForm(new Advance_Payment_Details());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenForm(new Delivery_Cost_Details());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenForm(new Designation_Details());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenForm(new Discount_Offer_Details());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenForm(new Employee_Allocation());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenForm(new Form1());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenForm(new Item_Details());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenForm(new Product_Details());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenForm(new Product_Sale_Cost_Details());
        }
    }
}
