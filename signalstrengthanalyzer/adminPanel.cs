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
            this.Shown += AdminPanel_Shown;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
        }

        private void AdminPanel_Shown(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        private void InitializeDatabase()
        {
            // SQLite-net will create the file automatically
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
            if (currentView == "Dashboard")
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string metric = row.Cells[0].Value?.ToString() ?? "";

                    if (metric.Contains("Excellent")) row.DefaultCellStyle.BackColor = Color.LightGreen;
                    else if (metric.Contains("Fair")) row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                    else if (metric.Contains("Poor")) row.DefaultCellStyle.BackColor = Color.LightCoral;
                    else row.DefaultCellStyle.BackColor = Color.LightCyan;
                }
            }
            else if (currentView == "Locations")
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Signal Strength"].Value == null) continue;

                    int strength = Convert.ToInt32(row.Cells["Signal Strength"].Value);
                    if (strength > -50) row.DefaultCellStyle.BackColor = Color.LightGreen;
                    else if (strength > -70) row.DefaultCellStyle.BackColor = Color.Orange;
                    else row.DefaultCellStyle.BackColor = Color.LightCoral;
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
                        row.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                    }
                    else if (category == "Location")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                    }
                    else if (category == "Detail")
                    {
                        string details = row.Cells[2].Value.ToString();
                        if (details.Contains("Excellent")) row.DefaultCellStyle.BackColor = Color.LightGreen;
                        else if (details.Contains("Fair")) row.DefaultCellStyle.BackColor = Color.Orange;
                        else if (details.Contains("Poor")) row.DefaultCellStyle.BackColor = Color.LightCoral;
                        else row.DefaultCellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
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
            double sum = 0;
            foreach (var s in signalMeasurements) sum += s.SignalStrength;
            return sum / signalMeasurements.Count;
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
            int minStrength = signalMeasurements.Min(s => s.SignalStrength);
            int maxStrength = signalMeasurements.Max(s => s.SignalStrength);

            var locationReliability = signalMeasurements
                .GroupBy(s => s.Location)
                .Select(g =>
                {
                    double avgNormalized = g.Average(s => ((double)(s.SignalStrength - minStrength) / (maxStrength - minStrength)) * 100);
                    return new { Location = g.Key, Reliability = avgNormalized };
                })
                .OrderByDescending(l => l.Reliability)
                .Take(3)
                .Select(l => l.Location)
                .ToList();

            return locationReliability;
        }

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

        // ------------------- Location Management -------------------

        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            string newLoc = Microsoft.VisualBasic.Interaction.InputBox("Enter new location:");
            if (string.IsNullOrWhiteSpace(newLoc)) return;

            using (var conn = new SQLiteConnection(dbPath))
            {
                conn.CreateTable<Location>();
                if (conn.Table<Location>().Any(l => l.LocationName == newLoc)) return;
                conn.Insert(new Location { LocationName = newLoc });
            }

            LoadLocationsGrid();
        }

        private void btnRenameLocation_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            string oldName = dataGridView1.SelectedRows[0].Cells["Location"].Value.ToString();
            string newName = Microsoft.VisualBasic.Interaction.InputBox("Rename location:", oldName);
            if (string.IsNullOrWhiteSpace(newName)) return;

            using (var conn = new SQLiteConnection(dbPath))
            {
                conn.CreateTable<Location>();
                var loc = conn.Table<Location>().FirstOrDefault(l => l.LocationName == oldName);
                if (loc != null)
                {
                    loc.LocationName = newName;
                    conn.Update(loc);
                }

                var signals = conn.Table<SignalMeasurement>().Where(s => s.Location == oldName).ToList();
                foreach (var s in signals)
                {
                    s.Location = newName;
                    conn.Update(s);
                }
            }

            LoadLocationsGrid();
        }

        private void btnDeleteLocation_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            string name = dataGridView1.SelectedRows[0].Cells["Location"].Value.ToString();

            using (var conn = new SQLiteConnection(dbPath))
            {
                conn.CreateTable<Location>();
                var loc = conn.Table<Location>().FirstOrDefault(l => l.LocationName == name);
                if (loc != null) conn.Delete(loc);

                var signals = conn.Table<SignalMeasurement>().Where(s => s.Location == name).ToList();
                foreach (var s in signals) conn.Delete(s);
            }

            LoadLocationsGrid();
        }

        // ------------------- Data Classes -------------------
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

        private void btnReports_Click(object sender, EventArgs e)
        {
            currentView = "Reports";

            LoadMeasurementsFromDB();
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            DataTable reportTable = new DataTable();
            reportTable.Columns.Add("Category", typeof(string));
            reportTable.Columns.Add("Item", typeof(string));
            reportTable.Columns.Add("Value / Details", typeof(string));

            // ---------------- Signal Summary ----------------
            reportTable.Rows.Add("Summary", "Total Devices", signalMeasurements.Count.ToString());
            reportTable.Rows.Add("Summary", "Excellent Signals", CountByStatus("Excellent").ToString());
            reportTable.Rows.Add("Summary", "Fair Signals", CountByStatus("Fair").ToString());
            reportTable.Rows.Add("Summary", "Poor Signals", CountByStatus("Poor").ToString());
            reportTable.Rows.Add("Summary", "Average Signal Strength", ((int)AverageSignal()).ToString() + " dBm");
            reportTable.Rows.Add("Summary", "Top Location", TopLocation());
            reportTable.Rows.Add("Summary", "Worst Location", WorstLocation());

            // ---------------- Location Analysis ----------------
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

            // ---------------- Device Details ----------------
            foreach (var s in signalMeasurements)
            {
                string details = $"Location: {s.Location}, Strength: {s.SignalStrength} dBm, Status: {s.Status}, Date: {s.MeasurementDate}";
                reportTable.Rows.Add("Detail", s.DeviceName, details);
            }

            dataGridView1.DataSource = reportTable;
        }


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
                    btnReports_Click(sender, e); // reuse the reports loader
                    break;
            }
        }
    }
}
