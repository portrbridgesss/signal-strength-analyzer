namespace signalstrengthanalyzer
{
    partial class mainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelSelectedStatus = new Label();
            listBox_Locations = new ListBox();
            buttonAnalyze = new Button();
            buttonSettings = new Button();
            panelColor = new Panel();
            labelHeaderName = new Label();
            label1 = new Label();
            groupBoxStatus = new GroupBox();
            labelOverallStatus = new Label();
            panelColor.SuspendLayout();
            groupBoxStatus.SuspendLayout();
            SuspendLayout();
            // 
            // labelSelectedStatus
            // 
            labelSelectedStatus.AutoSize = true;
            labelSelectedStatus.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSelectedStatus.Location = new Point(8, 23);
            labelSelectedStatus.Name = "labelSelectedStatus";
            labelSelectedStatus.Size = new Size(53, 21);
            labelSelectedStatus.TabIndex = 1;
            labelSelectedStatus.Text = "status";
            labelSelectedStatus.Click += label1_Click;
            // 
            // listBox_Locations
            // 
            listBox_Locations.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox_Locations.FormattingEnabled = true;
            listBox_Locations.ItemHeight = 25;
            listBox_Locations.Location = new Point(12, 100);
            listBox_Locations.Name = "listBox_Locations";
            listBox_Locations.Size = new Size(246, 279);
            listBox_Locations.TabIndex = 3;
            listBox_Locations.SelectedIndexChanged += listBox_Locations_SelectedIndexChanged;
            // 
            // buttonAnalyze
            // 
            buttonAnalyze.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonAnalyze.Location = new Point(264, 233);
            buttonAnalyze.Name = "buttonAnalyze";
            buttonAnalyze.Size = new Size(185, 94);
            buttonAnalyze.TabIndex = 4;
            buttonAnalyze.Text = "Analyze Current Connection";
            buttonAnalyze.UseVisualStyleBackColor = true;
            buttonAnalyze.Click += buttonAnalyze_Click;
            // 
            // buttonSettings
            // 
            buttonSettings.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSettings.Location = new Point(370, 348);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(79, 31);
            buttonSettings.TabIndex = 6;
            buttonSettings.Text = "Settings";
            buttonSettings.UseVisualStyleBackColor = true;
            buttonSettings.Click += buttonSettings_Click;
            // 
            // panelColor
            // 
            panelColor.BackColor = SystemColors.ActiveCaption;
            panelColor.Controls.Add(labelHeaderName);
            panelColor.Dock = DockStyle.Top;
            panelColor.Location = new Point(0, 0);
            panelColor.Name = "panelColor";
            panelColor.Size = new Size(461, 60);
            panelColor.TabIndex = 7;
            panelColor.Paint += panelColor_Paint;
            panelColor.MouseClick += panelColor_MouseClick;
            // 
            // labelHeaderName
            // 
            labelHeaderName.AutoSize = true;
            labelHeaderName.Font = new Font("Consolas", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelHeaderName.ForeColor = Color.WhiteSmoke;
            labelHeaderName.Location = new Point(3, 10);
            labelHeaderName.Name = "labelHeaderName";
            labelHeaderName.Size = new Size(449, 37);
            labelHeaderName.TabIndex = 10;
            labelHeaderName.Text = "Signal Strength Analyzer";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 76);
            label1.Name = "label1";
            label1.Size = new Size(156, 21);
            label1.TabIndex = 8;
            label1.Text = "Overall Area Status: ";
            // 
            // groupBoxStatus
            // 
            groupBoxStatus.Controls.Add(labelSelectedStatus);
            groupBoxStatus.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxStatus.Location = new Point(264, 100);
            groupBoxStatus.Name = "groupBoxStatus";
            groupBoxStatus.Size = new Size(185, 116);
            groupBoxStatus.TabIndex = 9;
            groupBoxStatus.TabStop = false;
            groupBoxStatus.Text = "Selected Area Status: ";
            groupBoxStatus.Enter += groupBoxStatus_Enter;
            // 
            // labelOverallStatus
            // 
            labelOverallStatus.AutoSize = true;
            labelOverallStatus.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelOverallStatus.Location = new Point(158, 76);
            labelOverallStatus.Name = "labelOverallStatus";
            labelOverallStatus.Size = new Size(53, 21);
            labelOverallStatus.TabIndex = 2;
            labelOverallStatus.Text = "status";
            labelOverallStatus.Click += labelOverallStatus_Click;
            // 
            // mainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(461, 394);
            Controls.Add(labelOverallStatus);
            Controls.Add(label1);
            Controls.Add(buttonSettings);
            Controls.Add(buttonAnalyze);
            Controls.Add(listBox_Locations);
            Controls.Add(panelColor);
            Controls.Add(groupBoxStatus);
            Name = "mainMenu";
            Text = "Form1";
            FormClosing += mainMenu_FormClosing;
            Load += mainMenu_Load;
            panelColor.ResumeLayout(false);
            panelColor.PerformLayout();
            groupBoxStatus.ResumeLayout(false);
            groupBoxStatus.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelSelectedStatus;
        private ListBox listBox_Locations;
        private Button buttonAnalyze;
        private Button buttonSettings;
        private Panel panelColor;
        private Label label1;
        private GroupBox groupBoxStatus;
        private Label labelOverallStatus;
        private Label labelHeaderName;
    }
}
