using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using signalstrengthanalyzer;

namespace signalstrengthanalyzer
{
    public partial class adminPanel : Form
    {
        // Random generator
        private Random random = new Random();
        private List<SignalMeasurement> signalMeasurements = new List<SignalMeasurement>();
        private string currentView = "Dashboard";
        public adminPanel()
        {
            InitializeComponent();
            LoadSampleMeasurements();
            this.Shown += AdminPanel_Shown;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
        }
        private void AdminPanel_Shown(object sender, EventArgs e)
        {
            ShowDashboard();   // Force redraw AFTER form loads
        }
        private void LoadSampleMeasurements()
        {
            signalMeasurements.Clear();

            string[] locations = new string[]
            {
                "A Building",
                "Jubilee Library",
                "Apo Pilo",
                "JVD Building",
                "Outdoor Patio",
                "Tonus Gym"
            };

            for (int i = 0; i < locations.Length; i++)
            {
                int strength = random.Next(-90, -30);
                signalMeasurements.Add(new SignalMeasurement
                {
                    SignalID = i + 1,
                    DeviceName = $"Device {i + 1}",
                    Location = locations[i],
                    SignalStrength = strength,
                    Status = GetStatus(strength),
                    MeasurementDate = DateTime.Now
                });
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (currentView == "Dashboard")
            {
                // Dashboard coloring
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
                // Locations coloring
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
                // Reports coloring
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

            // Add actual metrics only (no Dashboard header)
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

            // Formatting: color metrics by status
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string metric = row.Cells[0].Value?.ToString() ?? "";

                if (metric.Contains("Excellent")) row.DefaultCellStyle.BackColor = Color.LightGreen;
                else if (metric.Contains("Fair")) row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                else if (metric.Contains("Poor")) row.DefaultCellStyle.BackColor = Color.LightCoral;
                else row.DefaultCellStyle.BackColor = Color.LightCyan;
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

            var min = signalMeasurements.Min(s => s.SignalStrength);
            var max = signalMeasurements.Max(s => s.SignalStrength);

            foreach (var s in signalMeasurements)
            {
                double reliability = ((double)(s.SignalStrength - min) / (max - min)) * 100;
                dt.Rows.Add(s.DeviceName, s.Location, s.SignalStrength, s.Status, Math.Round(reliability));
            }

            dataGridView1.DataSource = dt;

            // Formatting
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Signal Strength"].Value == null) continue;

                int strength = Convert.ToInt32(row.Cells["Signal Strength"].Value);
                if (strength > -50) row.DefaultCellStyle.BackColor = Color.LightGreen;
                else if (strength > -70) row.DefaultCellStyle.BackColor = Color.Orange;
                else row.DefaultCellStyle.BackColor = Color.LightCoral;
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }



        private void btnReports_Click(object sender, EventArgs e)
        {
            ShowReports();
        }

        private void ShowReports()
        {
            currentView = "Reports";

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
            int minStrength = signalMeasurements.Min(s => s.SignalStrength);
            int maxStrength = signalMeasurements.Max(s => s.SignalStrength);

            var locations = signalMeasurements.GroupBy(s => s.Location);
            foreach (var loc in locations)
            {
                int total = loc.Count();
                double sumNormalized = 0;

                foreach (var s in loc)
                {
                    double normalized = ((double)(s.SignalStrength - minStrength) / (maxStrength - minStrength)) * 100;
                    sumNormalized += normalized;
                }

                double reliability = sumNormalized / total;
                double avgSignal = loc.Average(s => s.SignalStrength);
                string details = $"Avg Signal: {avgSignal:F1} dBm, Reliability: {reliability:F1}% ({total} measurements)";
                reportTable.Rows.Add("Location", loc.Key, details);
            }

            // ---------------- Device Details ----------------
            foreach (var s in signalMeasurements)
            {
                string details = $"Location: {s.Location}, Strength: {s.SignalStrength} dBm, Status: {s.Status}, Date: {s.MeasurementDate}";
                reportTable.Rows.Add("Detail", s.DeviceName, details);
            }

            dataGridView1.DataSource = reportTable;

            // ---------------- Formatting ----------------
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ViewButton" && e.RowIndex >= 0)
            {
                var selectedReport = ((List<ReportInfo>)dataGridView1.DataSource)[e.RowIndex];
                if (selectedReport.ReportName == "Signal Summary Report")
                {
                    
                }
                else if (selectedReport.ReportName == "Device Detail Report")
                {
                
                }
            }
        }

        private double AverageSignal()
        {
            double sum = 0;
            foreach (var s in signalMeasurements)
                sum += s.SignalStrength;
            return sum / signalMeasurements.Count;
        }

        private int CountByStatus(string status)
        {
            int count = 0;
            foreach (var s in signalMeasurements)
                if (s.Status == status) count++;
            return count;
        }

        // ------------------- Data Classes -------------------
        public class SignalMeasurement
        {
            public int SignalID { get; set; }
            public string DeviceName { get; set; }
            public string Location { get; set; }
            public int SignalStrength { get; set; }
            public string Status { get; set; }
            public DateTime MeasurementDate { get; set; }
        }

        public class DashboardInfo
        {
            public string Metric { get; set; }
            public string Value { get; set; }
        }

        public class ReportInfo
        {
            public string ReportName { get; set; }
            public string Description { get; set; }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Update signal strengths
            foreach (var s in signalMeasurements)
            {
                int newStrength = random.Next(-90, -30);
                s.SignalStrength = newStrength;
                s.Status = GetStatus(newStrength);
            }

            // Reload the currently active view
            switch (currentView)
            {
                case "Dashboard":
                    ShowDashboard();
                    break;
                case "Locations":
                    LoadLocationsGrid();
                    break;
                case "Reports":
                    ShowReports();
                    break;
            }
        }

        private void btnExitadminPanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
