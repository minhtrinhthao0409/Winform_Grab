namespace Winform_Grab
{
    partial class Booking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.PickUp = new System.Windows.Forms.TextBox();
            this.DropOff = new System.Windows.Forms.TextBox();
            this.vehicle = new System.Windows.Forms.ComboBox();
            this.bt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.distanceFare = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(13, 23);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(257, 297);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.Load += new System.EventHandler(this.gMapControl1_Load);
            // 
            // PickUp
            // 
            this.PickUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.PickUp.Location = new System.Drawing.Point(12, 337);
            this.PickUp.Multiline = true;
            this.PickUp.Name = "PickUp";
            this.PickUp.Size = new System.Drawing.Size(256, 27);
            this.PickUp.TabIndex = 2;
            this.PickUp.Text = "Pick-up Location";
            this.PickUp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PickUp_MouseClick);
            // 
            // DropOff
            // 
            this.DropOff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.DropOff.Location = new System.Drawing.Point(12, 380);
            this.DropOff.Multiline = true;
            this.DropOff.Name = "DropOff";
            this.DropOff.Size = new System.Drawing.Size(256, 27);
            this.DropOff.TabIndex = 3;
            this.DropOff.Text = "Drop-off Location";
            this.DropOff.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DropOff_MouseClick);
            // 
            // vehicle
            // 
            this.vehicle.FormattingEnabled = true;
            this.vehicle.Items.AddRange(new object[] {
            "Car",
            "Bike"});
            this.vehicle.Location = new System.Drawing.Point(13, 423);
            this.vehicle.Name = "vehicle";
            this.vehicle.Size = new System.Drawing.Size(120, 25);
            this.vehicle.TabIndex = 4;
            this.vehicle.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // bt
            // 
            this.bt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.bt.FlatAppearance.BorderSize = 0;
            this.bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt.ForeColor = System.Drawing.Color.White;
            this.bt.Location = new System.Drawing.Point(15, 471);
            this.bt.Name = "bt";
            this.bt.Size = new System.Drawing.Size(120, 29);
            this.bt.TabIndex = 5;
            this.bt.Text = "Confirm";
            this.bt.UseVisualStyleBackColor = false;
            this.bt.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.label1.Location = new System.Drawing.Point(204, 518);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "GO BACK";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // distanceFare
            // 
            this.distanceFare.AutoSize = true;
            this.distanceFare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.distanceFare.Location = new System.Drawing.Point(156, 424);
            this.distanceFare.Name = "distanceFare";
            this.distanceFare.Size = new System.Drawing.Size(0, 17);
            this.distanceFare.TabIndex = 8;
            // 
            // Booking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(285, 544);
            this.Controls.Add(this.distanceFare);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt);
            this.Controls.Add(this.vehicle);
            this.Controls.Add(this.DropOff);
            this.Controls.Add(this.PickUp);
            this.Controls.Add(this.gMapControl1);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Booking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Booking";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Booking_FormClosing);
            this.Load += new System.EventHandler(this.Booking_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.TextBox PickUp;
        private System.Windows.Forms.TextBox DropOff;
        private System.Windows.Forms.ComboBox vehicle;
        private System.Windows.Forms.Button bt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label distanceFare;
    }
}