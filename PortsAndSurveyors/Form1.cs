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
        private async Task InitalizeData() {
            if (File.Exists(Path.Combine(FilePath, FileName))) {
                await LoadExistingPortsAndSurveyorsData();
            } else {
                if (!Directory.Exists(FilePath)) {
                    Directory.CreateDirectory(FilePath);
                }
                await UpdatePortsAndSurveyorsData();
            }
        }

        private async Task LoadExistingPortsAndSurveyorsData() {
            statusLabel.Text = "Loading ports and surveyors data...";
            using (var reader = File.OpenText(Path.Combine(FilePath, FileName))) {
                var json = await reader.ReadToEndAsync();
                LoadPortsAndSurveyorsData(json);
            }
        }

        private async Task UpdatePortsAndSurveyorsData() {
            statusLabel.Text = "Loading ports and surveyors data...";
            var json = await DownloadPortsAndSurveyorsData();
            LoadPortsAndSurveyorsData(json);

            if (data != null) {
                using (var writer = File.CreateText(Path.Combine(FilePath, FileName))) {
                    await writer.WriteAsync(json);
                } 
            }
        }

        async Task<string> DownloadPortsAndSurveyorsData() {
            var client = new WebClient();
            var json = await client.DownloadStringTaskAsync(new Uri(DataURL));
            return json;
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
        
        void LoadPortsAndSurveyorsData(string json) {
            try {
                data = PortsAndASurveyorsData.FromJson(json);
            } catch (JsonSerializationException) {
                data = null;
                statusLabel.Text = "Invalid Data Detected";
                return;
            }
            if (!VerifyData(data)) {
                data = null;
                statusLabel.Text = "Invalid Data Detected";
                return;
            }
            statusLabel.Text = "Successfully loaded ports and surveyors data.";
        }
    }
}
