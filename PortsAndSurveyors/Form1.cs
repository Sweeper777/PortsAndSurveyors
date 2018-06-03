using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;

namespace PortsAndSurveyors {
    public partial class Form1 : Form {
        public Form1 () {
            InitializeComponent ();
        }

        private void Form1_Load(object sender, EventArgs e) {
            gmap.Zoom = 10;
            gmap.MinZoom = 2;
            gmap.MaxZoom = 14;
            gmap.Position = new PointLatLng(0, 0);
            gmap.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;

            gmap.ShowCenter = false;

            GMapOverlay markers = new GMapOverlay("markers");
            GMapMarker marker = new GMarkerGoogle(
                new PointLatLng(48.8617774, 2.349272),
                GMarkerGoogleType.red);
            markers.Markers.Add(marker);
            gmap.Overlays.Add(markers);
        }
    }
}
