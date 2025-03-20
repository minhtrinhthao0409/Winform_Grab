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
    public partial class ShowInfor: Form
    {
        private MainForm parentForm;
        private Customer currentCustomer;
        
        public ShowInfor(MainForm p, Customer customer)
        {
            InitializeComponent();
            parentForm = p;
            currentCustomer = customer;
            txtfullName.Text = customer.Name;
            txtID.Text = customer.Id;
            txtPhoneNum.Text = customer.PhoneNumber;
        }
        
        private void label1_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Close();
        }

      

        private void ShowInfor_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        

        
    }
}
