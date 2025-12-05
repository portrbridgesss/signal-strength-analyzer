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
    public partial class settingsMenu : Form
    {
        public settingsMenu()
        {
            InitializeComponent();


        }

        private void labelSettings_Click(object sender, EventArgs e)
        {

        }


        private void checkBoxDarkMode_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBoxDarkMode.Checked)
            {
                // Dark Mode
                this.BackColor = Color.FromArgb(30, 30, 30); // Dark Gray
                this.ForeColor = Color.White;

                // You would need to do this for the Main Menu too
            }
            else
            {
                // Light Mode
                this.BackColor = SystemColors.Control;
                this.ForeColor = Color.Black;
            }
        }
    }
}
