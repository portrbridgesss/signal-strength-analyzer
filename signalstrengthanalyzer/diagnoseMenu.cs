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

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            //Simulate Signal Strength (-30 is perfect, -90 is bad)
            int signalStrength = random.Next(-90, -30);

            //Update the labels (Make sure you name your labels in the designer!)
            lblSignalStrength.Text = $"Signal: {signalStrength} dBm";

            // 4. Change color based on strength
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
    }
}
