using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SQLite;

namespace signalstrengthanalyzer
{
    public partial class diagnoseMenu : Form
    {
        private Random random = new Random();
        private string dbPath = System.IO.Path.Combine(Application.StartupPath, "signals.db");

        public diagnoseMenu()
        {
            InitializeComponent();
        }

        public void LoadLocationsFromMain(ListBox.ObjectCollection locations)
        {
            comboBox1.Items.Clear();
            foreach (var item in locations)
            {
                comboBox1.Items.Add(item);
            }
        }

        private void buttonAnalyze_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;

            int signalStrength = random.Next(-90, -30);
            string status = GetStatus(signalStrength);

            lblSignalStrength.Text = $"Signal: {signalStrength} dBm";
            lblStatus.Text = status.Contains("Excellent") ? "Excellent Connection" :
                             status.Contains("Fair") ? "Fair Connection" : "Poor Connection";
            lblStatus.ForeColor = status == "Excellent" ? Color.Green :
                                  status == "Fair" ? Color.Orange : Color.Red;

            // Save to DB
            using (var conn = new SQLiteConnection(dbPath))
            {
                conn.CreateTable<adminPanel.SignalMeasurement>();
                conn.Insert(new adminPanel.SignalMeasurement
                {
                    DeviceName = $"Device {DateTime.Now.Ticks % 1000}", // simple device id
                    Location = comboBox1.SelectedItem.ToString(),
                    SignalStrength = signalStrength,
                    Status = status,
                    MeasurementDate = DateTime.Now
                });
            }
        }

        private string GetStatus(int strength)
        {
            if (strength > -50) return "Excellent";
            if (strength > -70) return "Fair";
            return "Poor";
        }

        private void lblSignalStrength_Click(object sender, EventArgs e)
        {

        }
    }
}
