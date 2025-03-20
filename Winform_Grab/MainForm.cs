﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_Grab
{
    public partial class MainForm: Form
    {
        private Customer currentCustomer;
        public MainForm(Customer customer)
        {
            InitializeComponent();
            currentCustomer = customer;
            txtHello.Text = "Hello, " + currentCustomer.Name + " Lên xe em đèo iu iu.";
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            Booking booking = new Booking(this);
            booking.Show();
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

        private void button2_Click(object sender, EventArgs e)
        {
            ShowInfor showInfo = new ShowInfor(this, currentCustomer);
            showInfo.Show();
            this.Hide();
        }
    }
}
