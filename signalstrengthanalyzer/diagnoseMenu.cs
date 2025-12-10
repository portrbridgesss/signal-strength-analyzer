using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace signalstrengthanalyzer
{
    public partial class diagnoseMenu : Form
    {
        public diagnoseMenu()
        {
            InitializeComponent();
        }
        Random random = new Random();


        private void diagnoseMenu_Load(object sender, EventArgs e)
        {

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
            int signalStrength = random.Next(-90, -30);

            lblSignalStrength.Text = $"Signal: {signalStrength} dBm";

            if (signalStrength > -50)
            {
                lblStatus.Text = "Excellent Connection";
                lblStatus.ForeColor = Color.Green;
            }
            else if (signalStrength > -70)
            {
                lblStatus.Text = "Fair Connection";
                lblStatus.ForeColor = Color.Orange;
            }
            else
            {
                lblStatus.Text = "Poor Connection";
                lblStatus.ForeColor = Color.Red;
            }


        }

        private void groupBoxDesignInfo_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
