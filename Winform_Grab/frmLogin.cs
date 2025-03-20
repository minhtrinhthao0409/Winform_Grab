using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Forms;
using System.IO;

namespace Winform_Grab
{
    public partial class frmLogin: Form
    {
        private string jsonFilePath = "customer.json";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            

            // Kiểm tra đầu vào
            if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ số điện thoại và mật khẩu!", "Đăng nhập thất bại", MessageBoxButtons.OK);
                return;
            }
            try
            {
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
                    if (customer.PhoneNumber != phoneNumber)
                    {
                        MessageBox.Show("Số điện thoại này chưa được đăng ký!", "Đăng nhập thất bại", MessageBoxButtons.OK);
                        return;
                    }
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();

        }

        private void checkboxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxShowPas.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else txtPassword.UseSystemPasswordChar = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtUsername.Clear();
            checkboxShowPas.Checked = false;
        }
    }
}
