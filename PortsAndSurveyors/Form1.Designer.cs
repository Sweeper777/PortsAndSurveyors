﻿namespace PortsAndSurveyors {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && ( components != null )) {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.updateButton = new System.Windows.Forms.LinkLabel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.portsListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.surveyorsListBox = new System.Windows.Forms.ListBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.contactTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(12, 12);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 2;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(293, 480);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 2D;
            this.gmap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gmap_OnMarkerClick);
            // 
            // updateButton
            // 
            this.updateButton.AutoSize = true;
            this.updateButton.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.updateButton.Location = new System.Drawing.Point(694, 459);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(247, 15);
            this.updateButton.TabIndex = 1;
            this.updateButton.TabStop = true;
            this.updateButton.Text = "Update Ports and Suveyors Data";
            this.updateButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.updateButton_LinkClicked);
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusLabel.Location = new System.Drawing.Point(311, 478);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(630, 17);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "Loading ports and surveyors data...";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // portsListBox
            // 
            this.portsListBox.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.portsListBox.FormattingEnabled = true;
            this.portsListBox.ItemHeight = 15;
            this.portsListBox.Location = new System.Drawing.Point(6, 52);
            this.portsListBox.Name = "portsListBox";
            this.portsListBox.Size = new System.Drawing.Size(284, 274);
            this.portsListBox.TabIndex = 3;
            this.portsListBox.SelectedIndexChanged += new System.EventHandler(this.portsListBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.surveyorsListBox);
            this.groupBox1.Controls.Add(this.searchButton);
            this.groupBox1.Controls.Add(this.searchTextBox);
            this.groupBox1.Controls.Add(this.portsListBox);
            this.groupBox1.Location = new System.Drawing.Point(313, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 480);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Query";
            // 
            // surveyorsListBox
            // 
            this.surveyorsListBox.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.surveyorsListBox.FormattingEnabled = true;
            this.surveyorsListBox.ItemHeight = 15;
            this.surveyorsListBox.Location = new System.Drawing.Point(6, 332);
            this.surveyorsListBox.Name = "surveyorsListBox";
            this.surveyorsListBox.Size = new System.Drawing.Size(284, 139);
            this.surveyorsListBox.TabIndex = 6;
            this.surveyorsListBox.SelectedIndexChanged += new System.EventHandler(this.surveyorsListBox_SelectedIndexChanged);
            // 
            // searchButton
            // 
            this.searchButton.BackgroundImage = global::PortsAndSurveyors.Properties.Resources.search;
            this.searchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.searchButton.Location = new System.Drawing.Point(264, 20);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(26, 26);
            this.searchButton.TabIndex = 5;
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.searchTextBox.Location = new System.Drawing.Point(6, 20);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(252, 25);
            this.searchTextBox.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(617, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 444);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Surveyor Info";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.priceTextBox);
            this.groupBox4.Location = new System.Drawing.Point(13, 264);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(312, 180);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Price Details";
            // 
            // priceTextBox
            // 
            this.priceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.priceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.priceTextBox.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.priceTextBox.Location = new System.Drawing.Point(7, 21);
            this.priceTextBox.Multiline = true;
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.ReadOnly = true;
            this.priceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.priceTextBox.Size = new System.Drawing.Size(299, 153);
            this.priceTextBox.TabIndex = 0;
            this.priceTextBox.Text = "This is some text xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            this.priceTextBox.WordWrap = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.contactTextBox);
            this.groupBox3.Location = new System.Drawing.Point(6, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(312, 238);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Contact Details";
            // 
            // contactTextBox
            // 
            this.contactTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contactTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contactTextBox.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contactTextBox.Location = new System.Drawing.Point(7, 21);
            this.contactTextBox.Multiline = true;
            this.contactTextBox.Name = "contactTextBox";
            this.contactTextBox.ReadOnly = true;
            this.contactTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.contactTextBox.Size = new System.Drawing.Size(299, 211);
            this.contactTextBox.TabIndex = 0;
            this.contactTextBox.Text = "This is some text xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            this.contactTextBox.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(953, 504);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.gmap);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(969, 543);
            this.MinimumSize = new System.Drawing.Size(969, 543);
            this.Name = "Form1";
            this.Text = "Ports and Surveyors";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.LinkLabel updateButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ListBox portsListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ListBox surveyorsListBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox contactTextBox;
    }
}

