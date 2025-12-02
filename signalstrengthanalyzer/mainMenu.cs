namespace signalstrengthanalyzer
{
    public partial class mainMenu : Form
    {
        int clickCount = 0;
        public mainMenu()
        {
            InitializeComponent();
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
            ExitMenu f3 = new ExitMenu();

            f3.ShowDialog(); // Shows Form2 you can also use f2.Show() 
        }
    }
}
