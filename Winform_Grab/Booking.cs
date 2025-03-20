using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Windows.Forms;

namespace Winform_Grab
{
    public partial class Booking: Form
    {
        private MainForm parentForm;
        //private GMapControl gMapControl1;
        public Booking(MainForm p)
        {
            InitializeComponent();
            SetupMap();
            parentForm = p;
        }
        private void SetupMap()
        {
            // Cấu hình nhà cung cấp bản đồ (Google Maps)
            gMapControl1.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerAndCache; // Dùng server và cache

            // Đặt vị trí ban đầu (ví dụ: trung tâm TP.HCM, Việt Nam)
            gMapControl1.Position = new PointLatLng(10.7769, 106.7009);

            // Thiết lập mức zoom
            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 20;
            gMapControl1.Zoom = 12;

            // Cho phép kéo bản đồ bằng chuột trái
            gMapControl1.DragButton = MouseButtons.Left;

            // Ẩn dấu "+" ở giữa bản đồ
            gMapControl1.ShowCenter = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        private void label1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận",
                       MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                click_pick = 0;
                click_drop = 0;
                parentForm.Show();
                this.Close();
            }
            else
            {
                new Booking(parentForm).Show();
            }

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        int click_pick = 0;
        int click_drop = 0;
        private void PickUp_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (click_pick == 0)
            
            {
                PickUp.Text = "";
                click_pick++;
            }
        }
        private void DropOff_MouseClick(object sender, MouseEventArgs e)
        {
            if (click_drop == 0)

            {
                DropOff.Text = "";
                click_drop++;
            }
        }

        private void Booking_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
