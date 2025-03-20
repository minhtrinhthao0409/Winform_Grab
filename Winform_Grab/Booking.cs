using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Windows.Forms;
using GMap.NET.WindowsForms.Markers;
using System.Drawing;
using System.Collections.Generic;

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

            // Initialize overlay for markers and routes
            markersOverlay = new GMapOverlay("markers");
            gMapControl1.Overlays.Add(markersOverlay);
        }
        private GMapOverlay markersOverlay;
        //private PointLatLng? pickupPoint = null;  // Store pickup location
        //private PointLatLng? dropoffPoint = null;
        //private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        // Convert click coordinates to latitude/longitude
        //        PointLatLng point = gMapControl1.FromLocalToLatLng(e.X, e.Y);

        //        if (pickupPoint == null) // Set pickup point
        //        {
        //            pickupPoint = point;
        //            AddMarker(point, GMarkerGoogleType.green_dot, "Pick-up");
        //            PickUp.Text = $"Pick-up: {point.Lat}, {point.Lng}";
        //        }
        //        else if (dropoffPoint == null) // Set dropoff point
        //        {
        //            dropoffPoint = point;
        //            AddMarker(point, GMarkerGoogleType.red_dot, "Drop-off");
        //            DropOff.Text = $"Drop-off: {point.Lat}, {point.Lng}";

        //            // Draw line between pickup and dropoff
        //            DrawRoute();
        //        }
        //    }
        //}
        //// Method to add a marker to the map
        //private void AddMarker(PointLatLng point, GMarkerGoogleType type, string tooltip)
        //{
        //    GMarkerGoogle marker = new GMarkerGoogle(point, type);
        //    marker.ToolTipText = tooltip;
        //    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
        //    markersOverlay.Markers.Add(marker);
        //    gMapControl1.Refresh();
        //}

        //// Method to draw a straight line between pickup and dropoff points
        //private void DrawRoute()
        //{
        //    if (pickupPoint != null && dropoffPoint != null)
        //    {
        //        // Clear previous routes
        //        markersOverlay.Routes.Clear();

        //        // Create a route with the two points
        //        var routePoints = new List<PointLatLng> { pickupPoint.Value, dropoffPoint.Value };
        //        GMapRoute route = new GMapRoute(routePoints, "PickupToDropoff");
        //        route.Stroke = new Pen(Color.Blue, 2); // Blue line with thickness 2

        //        // Add route to overlay
        //        markersOverlay.Routes.Add(route);
        //        gMapControl1.Refresh();
        //    }
        //}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = vehicle.SelectedItem.ToString().ToLower();
            bool type = true;
            double distance = 10;
            double fare;
            if (selectedOption == "car") type = false;
            fare = PriceCalculator.CalculatePrice(distance , type);
            distanceFare.Text = $"Distance: {distance} km\nFare: {fare:N0} VND";
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

        private void Booking_Load(object sender, EventArgs e)
        {

        }
    }
}
