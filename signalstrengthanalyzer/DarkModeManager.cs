using System.Drawing;
using System.Windows.Forms;

namespace signalstrengthanalyzer
{
    public static class ThemeManager
    {
        // Global variable to track mode
        public static bool IsDarkMode = false;

        // Colors for Dark Mode
        private static Color DarkBack = Color.FromArgb(45, 45, 48);
        private static Color DarkFore = Color.White;
        private static Color DarkControl = Color.FromArgb(60, 60, 60);

        // Colors for Light Mode
        private static Color LightBack = SystemColors.Control;
        private static Color LightFore = Color.Black;
        private static Color LightControl = Color.White;

        public static void ApplyTheme(Form form)
        {
            // Only change the form background if it's NOT the ExitMenu 
            // (ExitMenu might have specific styling, but usually it's fine to theme the background)
            form.BackColor = IsDarkMode ? DarkBack : LightBack;
            form.ForeColor = IsDarkMode ? DarkFore : LightFore;

            UpdateControls(form.Controls);

            form.Invalidate();
            form.Refresh();
        }

        private static void UpdateControls(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                // ---------------------------------------------------------
                // 1. EXCLUSION LIST
                // Skip specific controls that have custom colors
                // ---------------------------------------------------------
                if (c.Name == "panelColor" ||      // Main Menu Header (Blue)
                    c.Name == "button1" ||         // Exit Menu YES (Green)
                    c.Name == "button2" ||         // Exit Menu NO (Red)
                    c.Name == "labelHeaderName")   // Header Text (WhiteSmoke)
                {
                    // Even if we ignore the container, we still need to check inside it 
                    // (though in this case, panelColor children are also ignored)
                    if (c.HasChildren) UpdateControls(c.Controls);
                    continue;
                }

                // ---------------------------------------------------------
                // 2. THEME LOGIC
                // ---------------------------------------------------------
                if (c is Button btn)
                {
                    btn.BackColor = IsDarkMode ? DarkControl : SystemColors.ControlLight;
                    btn.ForeColor = IsDarkMode ? DarkFore : LightFore;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = IsDarkMode ? Color.Gray : Color.Black;
                }
                else if (c is TextBox || c is ListBox || c is ComboBox)
                {
                    c.BackColor = IsDarkMode ? DarkControl : Color.White;
                    c.ForeColor = IsDarkMode ? DarkFore : LightFore;
                }
                else if (c is Label)
                {
                    c.ForeColor = IsDarkMode ? DarkFore : LightFore;
                }
                else if (c is Panel || c is GroupBox)
                {
                    c.BackColor = IsDarkMode ? DarkBack : LightBack;
                    c.ForeColor = IsDarkMode ? DarkFore : LightFore;
                }
                else if (c is DataGridView dgv)
                {
                    dgv.BackgroundColor = IsDarkMode ? DarkControl : SystemColors.ButtonHighlight;
                    dgv.DefaultCellStyle.BackColor = IsDarkMode ? DarkControl : Color.White;
                    dgv.DefaultCellStyle.ForeColor = IsDarkMode ? DarkFore : Color.Black;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = IsDarkMode ? Color.Black : SystemColors.Control;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = IsDarkMode ? Color.White : Color.Black;
                    dgv.EnableHeadersVisualStyles = false;
                }

                // Recursive call for nested controls
                if (c.HasChildren)
                {
                    UpdateControls(c.Controls);
                }
            }
        }
    }
}