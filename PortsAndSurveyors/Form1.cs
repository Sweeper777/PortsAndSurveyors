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
            

            await InitalizeData();

            ReloadEverything();
        }
        private bool VerifyData(PortsAndASurveyorsData data) {
            if (data.Ports == null || data.Surveyors == null) {
                return false;
            }
            if (data.Ports.SelectMany(x => x.Surveyors).Any(x => !data.Surveyors.ContainsKey(x))) {
                return false;
            }
            if (data.Ports.Any(x => x.Surveyors.Count == 0)) {
                return false;
            }
            return true;
        }
    }
}
