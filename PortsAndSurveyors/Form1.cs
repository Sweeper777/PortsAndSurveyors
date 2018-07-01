using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using Newtonsoft.Json;

namespace PortsAndSurveyors {
    public partial class Form1 : Form {
        PortsAndASurveyorsData data;
        GMapOverlay markersOverlay;
        GMapMarker searchMarker;
        List<Port> filteredPorts;
        string searchText = "";
        PortSearcher portSearcher;
        List<Port> ShownPorts {
            get {
                if (searchText.Trim() == "" || filteredPorts == null) {
                    return data.Ports.OrderBy(x => x.Name).ToList();
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
            gmap.MapProvider = GoogleMapProvider.Instance;
            gmap.DisableFocusOnMouseEnter = true;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gmap.MinZoom = 1;
            gmap.MaxZoom = 7;
            gmap.Position = new PointLatLng(0, 0);
            

            await InitalizeData();

            ReloadEverything();
        }

        private void ReloadEverything() {
            if (data != null) {
                portSearcher = new PortSearcher(data.Ports);
                portSearcher.CoordinateFound += OnCoordinatesFound;
                LoadMarkers();
                portsListBox.Items.Clear();
                portsListBox.Items.AddRange(ShownPorts.OrderBy(x => x.Name).ToArray());
                //Console.WriteLine(data.Surveyors);
                surveyorsListBox.Items.Clear();
            } else {
                MessageBox.Show("Invalid Data Detected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                Controls.Cast<Control>().ForEach(x => x.Enabled = false);
                return;
            }
            if (!VerifyData(data)) {
                data = null;
                statusLabel.Text = "Invalid Data Detected";
                Controls.Cast<Control>().ForEach(x => x.Enabled = false);
                return;
            }
            statusLabel.Text = "Successfully loaded ports and surveyors data.";
        }

        private void searchButton_Click(object sender, EventArgs e) {
            PerformSearch();

        }

        private void PerformSearch() {
            searchText = searchTextBox.Text;
            if (searchMarker != null) {
                markersOverlay.Markers.Remove(searchMarker);
            }
            if (searchText.Trim() == "") {
                filteredPorts = null;
                searchResultsTypeLabel.Text = "All known ports:";
            } else {
                // must first set text
                searchResultsTypeLabel.Text = "Search Results:";
                filteredPorts = portSearcher.Search(searchText);
            }

            portsListBox.Items.Clear();
            portsListBox.Items.AddRange(ShownPorts.ToArray());
            markersOverlay.Markers.ForEach(x => x.IsVisible = true);
        }

        private void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e) {
            gmap.Position = item.Position;
        }

        private async void updateButton_Clicked(object sender, EventArgs e) {
            await UpdatePortsAndSurveyorsData();
            ReloadEverything();
        }

        private void LoadMarkers() {
            if (markersOverlay == null) {
                markersOverlay = new GMapOverlay("markers");
                gmap.Overlays.Add(markersOverlay);
            } else {
                markersOverlay.Markers.Clear();
            }

            for (int i = 0 ; i < data.Ports.Count ; i++) {
                var port = data.Ports[i];
                var marker = new GMarkerGoogle(port.Location, GMarkerGoogleType.red);
                marker.Tag = port;
                marker.ToolTipText = port.Name;
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                markersOverlay.Markers.Add(marker);
            }

        }

        private void portsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            var selectedIndex = portsListBox.SelectedIndex;
            
            if (selectedIndex != -1) {
                surveyorsListBox.Items.Clear();
                surveyorsListBox.Items.AddRange((portsListBox.SelectedItem as Port).Surveyors.Select(x => data.Surveyors[x]).ToArray());
                var marker = markersOverlay.Markers.First(x => x.Tag == portsListBox.SelectedItem);
                gmap.Position = marker.Position;

                markersOverlay.Markers.ForEach(x => x.IsVisible = false);
                marker.IsVisible = true;
            } else {
                surveyorsListBox.Items.Clear();
                markersOverlay.Markers.ForEach(x => x.IsVisible = true);
            }
            UpdateSurveyorInfoTextBoxes();
        }

        private void UpdateSurveyorInfoTextBoxes() {
            if (portsListBox.SelectedIndex == -1 || surveyorsListBox.SelectedIndex == -1) {
                contactTextBox.Text = "";
                priceTextBox.Text = "";
            } else {
                contactTextBox.Text = (surveyorsListBox.SelectedItem as Surveyor).Contacts;
                priceTextBox.Text = (surveyorsListBox.SelectedItem as Surveyor).Prices;
            }
        }

        private void surveyorsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateSurveyorInfoTextBoxes();
        }

        private void OnCoordinatesFound(PortSearcher searcher, PointLatLng coordinate) {
            searchMarker = new GMarkerGoogle(coordinate, GMarkerGoogleType.green);
            markersOverlay.Markers.Add(searchMarker);
            gmap.Position = coordinate;
            searchResultsTypeLabel.Text = "Nearest Ports:";
        }

        private void emailLabel_Click(object sender, EventArgs e) {
            Process.Start("mailto:sumulang.apps@gmail.com?subject=Ports And Surveyors Support");
        }

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                PerformSearch();
                e.Handled = true;
            }
        }
    }

    static class EnumerableExtensions {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action) {
            foreach (T val in enumerable) {
                action(val);
            }
        }
    }
}
