using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SQLite;
using System.IO;

namespace signalstrengthanalyzer
{
    public partial class mainMenu : Form
    {
        private int clickCount = 0;
        private string dbPath = Path.Combine(Application.StartupPath, "signals.db");

        public mainMenu()
        {
            InitializeComponent();
            LoadLocations();
            UpdateOverallStatus(); // Calculate overall status on startup
            UpdateRecentActivity();
            ThemeManager.ApplyTheme(this); //dark mode!!
        }

        private void LoadLocations()
        {
            string currentSelection = listBox_Locations.SelectedItem?.ToString();

            listBox_Locations.Items.Clear();
            using (var conn = new SQLiteConnection(dbPath))
            {
                conn.CreateTable<adminPanel.Location>();
                conn.CreateTable<adminPanel.SignalMeasurement>();
                var locations = conn.Table<adminPanel.Location>().ToList();
                if (!locations.Any())
                {
                    string[] defaultLocs = { "A Building", "Jubilee Library", "Apo Pilo", "JVD Building", "Outdoor Patio", "Tonus Gym" };
                    foreach (var loc in defaultLocs)
                    {
                        conn.Insert(new adminPanel.Location { LocationName = loc });
                        listBox_Locations.Items.Add(loc);
                    }
                }
                else
                {
                    foreach (var loc in locations) listBox_Locations.Items.Add(loc.LocationName);
                }
            }

            // Restore selection if it still exists
            if (currentSelection != null && listBox_Locations.Items.Contains(currentSelection))
            {
                listBox_Locations.SelectedItem = currentSelection;
            }
        }
        private void GetStatusInfo(double strength, out string text, out Color color)
        {
            if (strength > -50)
            {
                text = "Excellent";
                color = Color.Green;
            }
            else if (strength > -70)
            {
                text = "Fair";
                color = Color.Orange;
            }
            else
            {
                text = "Poor";
                color = Color.Red;
            }
        }
        private void UpdateLocationStatus(string locationName)
        {
            using (var conn = new SQLiteConnection(dbPath))
            {
                var measurements = conn.Table<adminPanel.SignalMeasurement>()
                                       .Where(s => s.Location == locationName)
                                       .ToList();

                if (measurements.Any())
                {
                    double avg = measurements.Average(s => s.SignalStrength);
                    GetStatusInfo(avg, out string statusText, out Color statusColor);

                    labelSelectedStatus.Text = statusText;
                    labelSelectedStatus.ForeColor = statusColor;
                }
                else
                {
                    labelSelectedStatus.Text = "No Data";
                    labelSelectedStatus.ForeColor = Color.Gray;
                }
            }
        }
        private void UpdateOverallStatus()
        {
            using (var conn = new SQLiteConnection(dbPath))
            {
                var allMeasurements = conn.Table<adminPanel.SignalMeasurement>().ToList();

                if (allMeasurements.Any())
                {
                    double avg = allMeasurements.Average(s => s.SignalStrength);
                    GetStatusInfo(avg, out string statusText, out Color statusColor);

                    labelOverallStatus.Text = statusText;
                    labelOverallStatus.ForeColor = statusColor;
                }
                else
                {
                    labelOverallStatus.Text = "No Data";
                    labelOverallStatus.ForeColor = Color.Gray;
                }
            }
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            if (listBox_Locations.SelectedItem == null)
            {
                MessageBox.Show("Please select a location first.");
                return;
            }

            diagnoseMenu f1 = new diagnoseMenu();
            f1.LoadLocationsFromMain(listBox_Locations.Items);
            f1.ShowDialog();
            LoadLocations();
            UpdateOverallStatus();
            if (listBox_Locations.SelectedItem != null)
            {
                string selectedLoc = listBox_Locations.SelectedItem.ToString();
                UpdateLocationStatus(selectedLoc);
                UpdateRecentActivity(selectedLoc);
            }
        }

        private void listBox_Locations_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox_Locations.SelectedItem != null)
            {
                string selectedLoc = listBox_Locations.SelectedItem.ToString();
                UpdateLocationStatus(selectedLoc);

                UpdateRecentActivity(selectedLoc);
            }
        }

        private void panelColor_MouseClick(object sender, MouseEventArgs e)
        {
            clickCount++;
            if (clickCount >= 5)
            {
                using (adminPanel secretForm = new adminPanel())
                {
                    secretForm.ShowDialog();
                }

                // Refresh everything
                LoadLocations();
                UpdateOverallStatus();

                if (listBox_Locations.SelectedItem != null)
                {
                    string selectedLoc = listBox_Locations.SelectedItem.ToString();
                    UpdateLocationStatus(selectedLoc);
                    UpdateRecentActivity(selectedLoc);
                }

                clickCount = 0;
            }
        }

        private void mainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ExitMenu f3 = new ExitMenu();
                if (f3.ShowDialog() != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            settingsMenu f2 = new settingsMenu();
            f2.ShowDialog();
            ThemeManager.ApplyTheme(this);
        }

        private void mainMenu_Load(object sender, EventArgs e)
        {

        }
        private void UpdateRecentActivity(string locationName = null)
        {
            lblRecent1.Text = "";
            lblRecent2.Text = "";
            if (string.IsNullOrEmpty(locationName)) return;
            using (var conn = new SQLiteConnection(dbPath))
            {
                var recentItems = conn.Table<adminPanel.SignalMeasurement>()
                                      .Where(s => s.Location == locationName)
                                      .OrderByDescending(s => s.MeasurementDate)
                                      .Take(2)
                                      .ToList();

                if (recentItems.Count > 0)
                {
                    var item = recentItems[0];
                    lblRecent1.Text = $"{item.SignalStrength} dBm ({item.Status})";
                    lblRecent1.ForeColor = item.SignalStrength > -50 ? Color.Green :
                                           item.SignalStrength > -70 ? Color.Orange : Color.Red;
                }

                if (recentItems.Count > 1)
                {
                    var item = recentItems[1];
                    lblRecent2.Text = $"{item.SignalStrength} dBm ({item.Status})";
                    lblRecent2.ForeColor = item.SignalStrength > -50 ? Color.Green :
                                           item.SignalStrength > -70 ? Color.Orange : Color.Red;
                }
            }
        }

        private void labelSubscript_Click(object sender, EventArgs e)
        {

        }
    }
}
