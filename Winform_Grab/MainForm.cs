using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using Svg; // Add this for SVG.NET

namespace Winform_Grab
{
    public partial class MainForm: Form
    {
        private Customer currentCustomer;
        public MainForm(Customer customer)
        {
            InitializeComponent();

            currentCustomer = customer;
            txtHello.Text = "Hello, " + customer.Name + " Lên xe em đèo nè iu iu.";
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            new Booking().Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }
    }
}
