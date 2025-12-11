using System;
using System.Windows.Forms;

namespace signalstrengthanalyzer
{
    public partial class settingsMenu : Form
    {
        public settingsMenu()
        {
            InitializeComponent();
        }

        private void settingsMenu_Load(object sender, EventArgs e)
        {
            // 1. Set the checkbox to match the current global state
            checkBoxDarkMode.Checked = ThemeManager.IsDarkMode;

            // 2. Apply the theme to this form immediately
            ThemeManager.ApplyTheme(this);
        }

        private void checkBoxDarkMode_CheckedChanged_1(object sender, EventArgs e)
        {
            // 1. Update the global variable
            ThemeManager.IsDarkMode = checkBoxDarkMode.Checked;

            // 2. Apply changes to THIS form immediately so you can see it
            ThemeManager.ApplyTheme(this);
        }
    }
}