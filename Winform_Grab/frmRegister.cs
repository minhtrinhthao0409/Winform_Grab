﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Forms;
using System.IO;

namespace Winform_Grab
{
    
    public partial class frmRegister: Form
    {
        private string jsonFilePath = "customers.json";
        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtUsername.Clear();
            txtComPassword.Clear();
            checkboxShowPas.Checked = false;
        }

        private void checkboxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxShowPas.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtComPassword.UseSystemPasswordChar = false;

            }
            else 
            { 
                txtPassword.UseSystemPasswordChar = true;
                txtComPassword.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string name = txtName.Text.Trim();  

            // Kiểm tra đầu vào
            if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(txtComPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ số điện thoại và mật khẩu!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            
            List<Customer> customers;

            // Đọc danh sách khách hàng hiện có từ file JSON
            if (File.Exists(jsonFilePath))
            {
                string jsonContent = File.ReadAllText(jsonFilePath);
                customers = JsonSerializer.Deserialize<List<Customer>>(jsonContent);
            }
            else
            {
                customers = new List<Customer>(); // Nếu file chưa tồn tại, tạo danh sách mới
            }

            // Kiểm tra xem số điện thoại đã tồn tại chưa
            foreach (Customer customer in customers)
            {
                if (customer.PhoneNumber == phoneNumber)
                {
                    MessageBox.Show("Số điện thoại này đã được đăng ký!");
                    return;
                }
            }

            // Tạo khách hàng mới
            Customer newCustomer = new Customer
            {
                PhoneNumber = phoneNumber,
                Password = password,
                Name = name,
            };

            // Thêm vào danh sách
            customers.Add(newCustomer);

            // Ghi lại vào file JSON (serialize)
            string updatedJson = JsonSerializer.Serialize(customers, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonFilePath, updatedJson);

            MessageBox.Show("Đăng ký thành công!");
                
            // Quay lại trang đăng nhập
            new frmLogin().Show();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
