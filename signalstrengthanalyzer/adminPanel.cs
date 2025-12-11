using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SQLite;
using System.IO;

namespace signalstrengthanalyzer
{
    public partial class adminPanel : Form
    {
        private Random random = new Random();
        private List<SignalMeasurement> signalMeasurements = new List<SignalMeasurement>();
        private string currentView = "Dashboard";
        private string dbPath = Path.Combine(Application.StartupPath, "signals.db");

        public adminPanel()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadMeasurementsFromDB();
            ThemeManager.ApplyTheme(this);//dark mode
            this.Shown += AdminPanel_Shown;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;

        }

        private void AdminPanel_Shown(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        private void InitializeDatabase()
        {
            using (var conn = new SQLiteConnection(dbPath))
            {
                conn.CreateTable<SignalMeasurement>();
                conn.CreateTable<Location>();
            }
        }

        private void LoadMeasurementsFromDB()
        {
            using (var conn = new SQLiteConnection(dbPath))
            {
                signalMeasurements = conn.Table<SignalMeasurement>().ToList();
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // 1. Reset selection colors to look good in both modes
            dataGridView1.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            if (currentView == "Dashboard")
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string metric = row.Cells[0].Value?.ToString() ?? "";

                    // Force BLACK text on these light backgrounds
                    if (metric.Contains("Excellent"))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (metric.Contains("Fair"))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (metric.Contains("Poor"))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCyan;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
            else if (currentView == "Locations")
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Signal Strength"].Value == null) continue;
                    int strength = Convert.ToInt32(row.Cells["Signal Strength"].Value);

                    // Force BLACK text
                    if (strength > -50)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (strength > -70)
                    {
                        row.DefaultCellStyle.BackColor = Color.Orange;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
            else if (currentView == "Reports")
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string category = row.Cells[0].Value.ToString();

                    if (category == "Summary")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCyan;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        row.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                    }
                    else if (category == "Location")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (category == "Detail")
                    {
                        string details = row.Cells[2].Value.ToString();

                        if (details.Contains("Excellent"))
                        {
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                        }
                        else if (details.Contains("Fair"))
                        {
                            row.DefaultCellStyle.BackColor = Color.Orange;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                        }
                        else if (details.Contains("Poor"))
                        {
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                        }
                        else
                        {
                            // If no color is assigned, respect the Dark Mode theme
                            row.DefaultCellStyle.BackColor = ThemeManager.IsDarkMode ? Color.FromArgb(60, 60, 60) : Color.White;
                            row.DefaultCellStyle.ForeColor = ThemeManager.IsDarkMode ? Color.White : Color.Black;
                        }
                    }
                }
            }
        }

        private string GetStatus(int strength)
        {
            if (strength > -50) return "Excellent";
            if (strength > -70) return "Fair";
            return "Poor";
        }

        private void UpdateCurrentViewLabel()
        {
            if (label1 != null)
            {
                label1.Text = $"Current View: {currentView}";

                // Check if we are in Dark Mode
                bool isDark = ThemeManager.IsDarkMode;

                // Change text color based on view AND theme
                switch (currentView)
                {
                    case "Dashboard":
                        label1.ForeColor = isDark ? Color.Cyan : Color.Blue;
                        break;
                    case "Locations":
                        label1.ForeColor = isDark ? Color.Lime : Color.Green;
                        break;
                    case "Reports":
                        label1.ForeColor = isDark ? Color.Gold : Color.Orange;
                        break;
                    default:
                        label1.ForeColor = isDark ? Color.White : Color.Black;
                        break;
                }
            }
        }

        private bool IsColorDark(Color color)
        {
            // Standard formula for perceived brightness
            double brightness = (color.R * 0.299 + color.G * 0.587 + color.B * 0.114);
            return brightness < 128;
        }

        // -------------------- DASHBOARD --------------------
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        private void ShowDashboard()
        {
            LoadMeasurementsFromDB();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            currentView = "Dashboard";
            UpdateCurrentViewLabel();

            DataTable dt = new DataTable();
            dt.Columns.Add("Metric", typeof(string));
            dt.Columns.Add("Value", typeof(string));

            dt.Rows.Add("Total Devices", signalMeasurements.Count.ToString());
            dt.Rows.Add("Average Signal Strength", ((int)AverageSignal()).ToString() + " dBm");
            dt.Rows.Add("Excellent Signals", CountByStatus("Excellent").ToString());
            dt.Rows.Add("Fair Signals", CountByStatus("Fair").ToString());
            dt.Rows.Add("Poor Signals", CountByStatus("Poor").ToString());
            dt.Rows.Add("Top Location", TopLocation());
            dt.Rows.Add("Worst Location", WorstLocation());

            var top3 = Top3ReliableLocations();
            dt.Rows.Add("Top 3 Reliable Locations", string.Join(", ", top3));

            dataGridView1.DataSource = dt;
        }

        private double AverageSignal()
        {
            if (!signalMeasurements.Any()) return 0;
            return signalMeasurements.Average(s => s.SignalStrength);
        }

        private int CountByStatus(string status)
        {
            return signalMeasurements.Count(s => s.Status == status);
        }

        private string TopLocation()
        {
            if (!signalMeasurements.Any()) return "";
            return signalMeasurements.GroupBy(s => s.Location)
                                     .OrderByDescending(g => g.Average(s => s.SignalStrength))
                                     .First().Key;
        }

        private string WorstLocation()
        {
            if (!signalMeasurements.Any()) return "";
            return signalMeasurements.GroupBy(s => s.Location)
                                     .OrderBy(g => g.Average(s => s.SignalStrength))
                                     .First().Key;
        }

        private List<string> Top3ReliableLocations()
        {
            if (!signalMeasurements.Any()) return new List<string>();
            int min = signalMeasurements.Min(s => s.SignalStrength);
            int max = signalMeasurements.Max(s => s.SignalStrength);

            var locationReliability = signalMeasurements
                .GroupBy(s => s.Location)
                .Select(g =>
                {
                    double avgNormalized = g.Average(s => ((double)(s.SignalStrength - min) / (max - min)) * 100);
                    return new { Location = g.Key, Reliability = avgNormalized };
                })
                .OrderByDescending(l => l.Reliability)
                .Take(3)
                .Select(l => l.Location)
                .ToList();

            return locationReliability;
        }

        // -------------------- LOCATIONS --------------------
        private void btnLocations_Click(object sender, EventArgs e)
        {
            LoadLocationsGrid();
        }

        private void LoadLocationsGrid()
        {
            LoadMeasurementsFromDB();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            currentView = "Locations";
            UpdateCurrentViewLabel();

            DataTable dt = new DataTable();
            dt.Columns.Add("Device", typeof(string));
            dt.Columns.Add("Location", typeof(string));
            dt.Columns.Add("Signal Strength", typeof(int));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("Reliability (%)", typeof(double));

            if (!signalMeasurements.Any())
            {
                dataGridView1.DataSource = dt;
                return;
            }

            int min = signalMeasurements.Min(s => s.SignalStrength);
            int max = signalMeasurements.Max(s => s.SignalStrength);

            foreach (var s in signalMeasurements)
            {
                double reliability = ((double)(s.SignalStrength - min) / (max - min)) * 100;
                dt.Rows.Add(s.DeviceName, s.Location, s.SignalStrength, s.Status, Math.Round(reliability));
            }

            dataGridView1.DataSource = dt;
        }

        // -------------------- REPORTS --------------------
        private void btnReports_Click(object sender, EventArgs e)
        {
            LoadMeasurementsFromDB();
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            DataTable reportTable = new DataTable();
            reportTable.Columns.Add("Category", typeof(string));
            reportTable.Columns.Add("Item", typeof(string));
            reportTable.Columns.Add("Value / Details", typeof(string));

            currentView = "Reports";
            UpdateCurrentViewLabel();

            // Summary
            reportTable.Rows.Add("Summary", "Total Devices", signalMeasurements.Count.ToString());
            reportTable.Rows.Add("Summary", "Excellent Signals", CountByStatus("Excellent").ToString());
            reportTable.Rows.Add("Summary", "Fair Signals", CountByStatus("Fair").ToString());
            reportTable.Rows.Add("Summary", "Poor Signals", CountByStatus("Poor").ToString());
            reportTable.Rows.Add("Summary", "Average Signal Strength", ((int)AverageSignal()).ToString() + " dBm");
            reportTable.Rows.Add("Summary", "Top Location", TopLocation());
            reportTable.Rows.Add("Summary", "Worst Location", WorstLocation());

            // Location Analysis
            if (signalMeasurements.Any())
            {
                int minStrength = signalMeasurements.Min(s => s.SignalStrength);
                int maxStrength = signalMeasurements.Max(s => s.SignalStrength);

                var locations = signalMeasurements.GroupBy(s => s.Location);
                foreach (var loc in locations)
                {
                    int total = loc.Count();
                    double sumNormalized = loc.Average(s => ((double)(s.SignalStrength - minStrength) / (maxStrength - minStrength)) * 100);
                    double avgSignal = loc.Average(s => s.SignalStrength);
                    string details = $"Avg Signal: {avgSignal:F1} dBm, Reliability: {sumNormalized:F1}% ({total} measurements)";
                    reportTable.Rows.Add("Location", loc.Key, details);
                }
            }

            // Device Details
            foreach (var s in signalMeasurements)
            {
                string details = $"Location: {s.Location}, Strength: {s.SignalStrength} dBm, Status: {s.Status}, Date: {s.MeasurementDate}";
                reportTable.Rows.Add("Detail", s.DeviceName, details);
            }

            dataGridView1.DataSource = reportTable;
        }

        // -------------------- EXIT / REFRESH --------------------
        private void btnExitadminPanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            switch (currentView)
            {
                case "Dashboard":
                    ShowDashboard();
                    break;
                case "Locations":
                    LoadLocationsGrid();
                    break;
                case "Reports":
                    btnReports_Click(sender, e);
                    break;
            }
        }

        // -------------------- DATA CLASSES --------------------
        public class SignalMeasurement
        {
            [PrimaryKey, AutoIncrement]
            public int SignalID { get; set; }
            public string DeviceName { get; set; }
            public string Location { get; set; }
            public int SignalStrength { get; set; }
            public string Status { get; set; }
            public DateTime MeasurementDate { get; set; }
        }

        public class Location
        {
            [PrimaryKey, AutoIncrement]
            public int LocationID { get; set; }
            public string LocationName { get; set; }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (var conn = new SQLiteConnection(dbPath))
            {
                conn.CreateTable<Location>();
                var locations = conn.Table<Location>().OrderBy(l => l.LocationName).ToList();

                Form editForm = new Form()
                {
                    Width = 400,
                    Height = 250,
                    Text = "Manage Locations",
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    StartPosition = FormStartPosition.CenterParent,
                    MinimizeBox = false,
                    MaximizeBox = false
                };

                Label lbl = new Label() { Left = 20, Top = 20, Text = "Select Location:" };
                ComboBox combo = new ComboBox() { Left = 20, Top = 50, Width = 340 };
                combo.Items.AddRange(locations.Select(l => l.LocationName).ToArray());
                if (combo.Items.Count > 0) combo.SelectedIndex = 0;

                TextBox txtName = new TextBox() { Left = 20, Top = 90, Width = 340 };
                txtName.PlaceholderText = "New Location Name";

                Button btnAdd = new Button() { Text = "Add", Left = 20, Width = 100, Top = 140 };
                Button btnRename = new Button() { Text = "Rename", Left = 140, Width = 100, Top = 140 };
                Button btnDelete = new Button() { Text = "Delete", Left = 260, Width = 100, Top = 140 };

                editForm.Controls.Add(lbl);
                editForm.Controls.Add(combo);
                editForm.Controls.Add(txtName);
                editForm.Controls.Add(btnAdd);
                editForm.Controls.Add(btnRename);
                editForm.Controls.Add(btnDelete);

                // Add event handlers
                btnAdd.Click += (btnSender, btnE) =>
                {
                    string newName = txtName.Text.Trim();
                    if (string.IsNullOrWhiteSpace(newName))
                    {
                        MessageBox.Show("Enter a valid name.");
                        return;
                    }
                    if (conn.Table<Location>().Any(loc => loc.LocationName == newName))
                    {
                        MessageBox.Show("Location already exists!");
                        return;
                    }

                    conn.Insert(new Location { LocationName = newName });
                    MessageBox.Show($"Location '{newName}' added.");
                    editForm.Close();
                };

                btnRename.Click += (btnSender, btnE) =>
                {
                    if (combo.SelectedItem == null)
                    {
                        MessageBox.Show("Select a location to rename.");
                        return;
                    }

                    string oldName = combo.SelectedItem.ToString();
                    string newName = txtName.Text.Trim();
                    if (string.IsNullOrWhiteSpace(newName) || newName == oldName)
                    {
                        MessageBox.Show("Enter a valid new name.");
                        return;
                    }
                    if (conn.Table<Location>().Any(loc => loc.LocationName == newName))
                    {
                        MessageBox.Show("Location already exists!");
                        return;
                    }

                    var locToRename = conn.Table<Location>().FirstOrDefault(loc => loc.LocationName == oldName);
                    if (locToRename != null)
                    {
                        locToRename.LocationName = newName;
                        conn.Update(locToRename);
                    }

                    // Update signal measurements
                    var signalsToUpdate = conn.Table<SignalMeasurement>().Where(sig => sig.Location == oldName).ToList();
                    foreach (var sig in signalsToUpdate)
                    {
                        sig.Location = newName;
                        conn.Update(sig);
                    }

                    MessageBox.Show($"Location '{oldName}' renamed to '{newName}'.");
                    editForm.Close();
                };

                btnDelete.Click += (btnSender, btnE) =>
                {
                    if (combo.SelectedItem == null)
                    {
                        MessageBox.Show("Select a location to delete.");
                        return;
                    }

                    string delName = combo.SelectedItem.ToString();
                    if (MessageBox.Show($"Are you sure you want to delete '{delName}' and all related signals?",
                                        "Confirm Delete", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;

                    var locToDelete = conn.Table<Location>().FirstOrDefault(loc => loc.LocationName == delName);
                    if (locToDelete != null) conn.Delete(locToDelete);

                    var signalsToDelete = conn.Table<SignalMeasurement>().Where(sig => sig.Location == delName).ToList();
                    foreach (var sig in signalsToDelete) conn.Delete(sig);

                    MessageBox.Show($"Location '{delName}' deleted.");
                    editForm.Close();
                };

                editForm.ShowDialog();
            }

            // Refresh the grid regardless of current view
            if (currentView == "Locations")
                LoadLocationsGrid();
        }
    }
}
