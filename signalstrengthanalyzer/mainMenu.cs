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
        "Office Entrance",
        "Conference Room (North)",
        "Server Closet",
        "Break Room",
        "Outdoor Patio"
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
                // Open the new form (e.g., Admin Panel or Secret Menu)
                adminPanel secretForm = new adminPanel();
                secretForm.ShowDialog();

                // 4. Reset the counter so you can do it again later
                clickCount = 0;
            }
        }

        private void mainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ExitMenu f3 = new ExitMenu();

                // Check what the user clicked in the ExitMenu
                if (f3.ShowDialog() == DialogResult.Yes)
                {
                    // User said YES
                }
                else
                {
                    // User said NO 
                    e.Cancel = true;
                }
            }
        }

        private void listBox_Locations_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panelColor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
