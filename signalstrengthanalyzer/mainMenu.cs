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
        }

        private void LoadLocations()
        {
            listBox_Locations.Items.Clear();
            using (var conn = new SQLiteConnection(dbPath))
            {
                conn.CreateTable<adminPanel.Location>();
                var locations = conn.Table<adminPanel.Location>().ToList();

                // Add default locations if DB is empty
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
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            if (listBox_Locations.SelectedItem == null) return;

            diagnoseMenu f1 = new diagnoseMenu();
            f1.LoadLocationsFromMain(listBox_Locations.Items);
            f1.ShowDialog();

            // Optional: update mainMenu display or status after analyze
            labelSelectedStatus.Text = "Analyzed";
            labelSelectedStatus.ForeColor = Color.Blue;
            labelOverallStatus.Text = "Updated";
            labelOverallStatus.ForeColor = Color.Blue;
        }

        private void panelColor_MouseClick(object sender, MouseEventArgs e)
        {
            clickCount++;
            if (clickCount >= 5)
            {
                adminPanel secretForm = new adminPanel();
                secretForm.ShowDialog();
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

        private void listBox_Locations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Locations.SelectedItem != null)
            {
                labelSelectedStatus.Text = "Normal";
                labelSelectedStatus.ForeColor = Color.Green;
                labelOverallStatus.Text = "Normal";
                labelOverallStatus.ForeColor = Color.Green;
            }
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            settingsMenu f2 = new settingsMenu();
            f2.ShowDialog();
        }
    }
}
