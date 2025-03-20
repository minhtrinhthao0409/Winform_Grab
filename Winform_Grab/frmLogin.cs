using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Forms;
using System.IO;

namespace Winform_Grab
{
    public partial class frmLogin: Form
    {
        private string jsonFilePath = "customers.json";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtUsername.Text.Trim();
            string password = txtPassword.Text;

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
                    MessageBox.Show("Không tìm thấy dữ liệu người dùng!",
                                   "Đăng nhập thất bại",
                                   MessageBoxButtons.OK);
                    return;
                }

                // Kiểm tra thông tin đăng nhập
                // Kiểm tra thông tin đăng nhập
                Customer matchedCustomer = null;
                foreach (Customer c in customers)
                {
                    // Chuẩn hóa dữ liệu trước khi so sánh
                    string jsonPhone = c.PhoneNumber != null ? c.PhoneNumber.Trim() : "";
                    string jsonPass = c.Password != null ? c.Password.Trim() : "";

                    if (jsonPhone == phoneNumber && jsonPass == password)
                    {
                        matchedCustomer = c;
                        break;
                    }
                }
                // Đăng nhập thành công
                //MessageBox.Show("Đăng nhập thành công!",
                //               "Thành công",
                //               MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}",
                               "Lỗi hệ thống",
                               MessageBoxButtons.OK);
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
