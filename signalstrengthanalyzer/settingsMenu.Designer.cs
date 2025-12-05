namespace signalstrengthanalyzer
{
    partial class settingsMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            checkBoxDarkMode = new CheckBox();
            labelSettings = new Label();
            SuspendLayout();
            // 
            // checkBoxDarkMode
            // 
            checkBoxDarkMode.AutoSize = true;
            checkBoxDarkMode.Location = new Point(121, 114);
            checkBoxDarkMode.Name = "checkBoxDarkMode";
            checkBoxDarkMode.Size = new Size(84, 19);
            checkBoxDarkMode.TabIndex = 0;
            checkBoxDarkMode.Text = "Dark Mode";
            checkBoxDarkMode.UseVisualStyleBackColor = true;
            // 
            // labelSettings
            // 
            labelSettings.AutoSize = true;
            labelSettings.Font = new Font("Jokerman", 27.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelSettings.Location = new Point(80, 25);
            labelSettings.Name = "labelSettings";
            labelSettings.Size = new Size(177, 55);
            labelSettings.TabIndex = 1;
            labelSettings.Text = "Settings";
            // 
            // settingsMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(326, 164);
            Controls.Add(labelSettings);
            Controls.Add(checkBoxDarkMode);
            Name = "settingsMenu";
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBoxDarkMode;
        private Label labelSettings;
    }
}