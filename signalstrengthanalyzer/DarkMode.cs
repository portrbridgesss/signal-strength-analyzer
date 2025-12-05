using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using signalstrengthanalyzer;

namespace signalstrengthanalyzer
{
    public static class DarkMode
    {
        public static class DarkThemeColors
        {
            public static readonly Color DarkBackground = Color.FromArgb(45, 45, 48);
            public static readonly Color DarkPanel = Color.FromArgb(50, 50, 50);
            public static readonly Color DarkForeground = Color.White;

            // Light Theme Colors (use standard system colors for a light theme)
            public static readonly Color LightBackground = SystemColors.Control;
            public static readonly Color LightForeground = SystemColors.ControlText;
        }
        public static class ThemeManager
        {
            // STATIC PROPERTY: Tracks the current state of the theme
            public static bool IsDarkModeEnabled { get; private set; } = false;

            // METHOD: Public method to toggle the theme and apply it globally
            public static void ToggleTheme(bool enableDark)
            {
                IsDarkModeEnabled = enableDark;

                // Loop through all currently open forms and apply the theme
                foreach (Form form in Application.OpenForms)
                {
                    ApplyTheme(form);
                }
            }

            // CORE METHOD: Applies the current theme based on the IsDarkModeEnabled state
            public static void ApplyTheme(Control container)
            {
                if (IsDarkModeEnabled)
                {
                    ApplyDarkTheme(container);
                }
                else
                {
                    ApplyLightTheme(container);
                }
            }

            // ... (Place the detailed ApplyDarkTheme and ApplyLightTheme methods here) ...

            private static void ApplyDarkTheme(Control container)
            {
                container.BackColor = DarkThemeColors.DarkBackground;
                // ... (rest of the dark theme logic as provided previously)
                foreach (Control control in container.Controls)
                {
                    if (control is Panel || control is GroupBox) control.BackColor = DarkThemeColors.DarkPanel;
                    if (control is Label) control.ForeColor = DarkThemeColors.DarkForeground;
                    // Add more control types here...
                    if (control.HasChildren) ApplyDarkTheme(control);
                }
            }

            private static void ApplyLightTheme(Control container)
            {
                container.BackColor = DarkThemeColors.LightBackground;
                // ... (logic to reset colors to LightThemeColors, e.g., SystemColors.Control)
                foreach (Control control in container.Controls)
                {
                    if (control is Panel || control is GroupBox) control.BackColor = DarkThemeColors.LightBackground;
                    if (control is Label) control.ForeColor = DarkThemeColors.LightForeground;
                    // Add more control types here...
                    if (control.HasChildren) ApplyLightTheme(control);
                }
            }
        }
    }
}
