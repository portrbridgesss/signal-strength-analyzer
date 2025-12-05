namespace signalstrengthanalyzer
{
    public partial class mainMenu : Form
    {
        int clickCount = 0;


        public mainMenu()
        {
            InitializeComponent();
            LoadLocations();
        }
        private void LoadLocations()
        {
            // Clear any existing items first
            listBox_Locations.Items.Clear();

            // **Replace this with your actual data source (e.g., reading from a file or database)**
            List<string> locations = new List<string>
    {
        "A Building",
        "Jubilee Library",
        "Apo Pilo",
        "JVD Building",
        "Outdoor Patio",
        "Tonus Gym"
    };

            // Add each location string to the ListBox
            foreach (string location in locations)
            {
                listBox_Locations.Items.Add(location);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            diagnoseMenu f1 = new diagnoseMenu();
            f1.ShowDialog();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            settingsMenu f2 = new settingsMenu();
            f2.ShowDialog(); // Shows Form2 you can also use f2.Show() 
        }

        private void panelColor_MouseClick(object sender, MouseEventArgs e)
        {

            clickCount++;
            if (clickCount >= 5)
            {
                // Open the admin menu
                adminPanel secretForm = new adminPanel();
                secretForm.ShowDialog();

                // Reset the counter 
                clickCount = 0;
            }
        }

        private void mainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ExitMenu f3 = new ExitMenu();
                if (f3.ShowDialog() == DialogResult.Yes)
                {
                    //YES, walang gagawin
                }
                else
                {
                    //NO, mag exit sya
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

        private void panelColor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainMenu_Load(object sender, EventArgs e)
        {

        }

        private void groupBoxStatus_Enter(object sender, EventArgs e)
        {

        }

        private void labelOverallStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
