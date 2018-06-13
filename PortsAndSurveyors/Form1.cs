using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using Newtonsoft.Json;

namespace PortsAndSurveyors {
    public partial class Form1 : Form {
        PortsAndASurveyorsData data;
        GMapOverlay markersOverlay;
        List<Port> filteredPorts;
        string searchText = "";
        List<Port> ShownPorts {
            get {
                if (searchText.Trim() == "" || filteredPorts == null) {
                    return data.Ports;
                }
                return filteredPorts;
            }
        }

        static readonly string DataURL = "https://pastebin.com/raw/UpafAyTR";
        static readonly string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ports and Surveyors");
        static readonly string FileName = "data.json";

        public Form1 () {
            InitializeComponent ();
        }

        private async void Form1_Load(object sender, EventArgs e) {
            gmap.MapProvider = BingMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gmap.MinZoom = 1;
            gmap.MaxZoom = 5;
            gmap.Position = new PointLatLng(0, 0);


            GMapOverlay markers = new GMapOverlay("markers");
            GMapMarker marker = new GMarkerGoogle(
                new PointLatLng(48.8617774, 2.349272),
                GMarkerGoogleType.red);
            markers.Markers.Add(marker);
            gmap.Overlays.Add(markers);
        }
    }
}
